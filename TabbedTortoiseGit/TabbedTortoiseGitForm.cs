﻿using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TabbedTortoiseGit.Properties;
using System.Configuration;
using Microsoft.WindowsAPICodePack.Dialogs;
using LibGit2Sharp;
using Newtonsoft.Json;
using log4net;
using log4net.Config;
using Tabs;
using System.IO;

namespace TabbedTortoiseGit
{
    public partial class TabbedTortoiseGitForm : Form
    {
        private static readonly ILog LOG = LogManager.GetLogger( typeof( TabbedTortoiseGitForm ) );

        private readonly CommonOpenFileDialog _folderDialog;
        private readonly List<Process> _processes = new List<Process>();
        private readonly Dictionary<int, Tab> _tabs = new Dictionary<int, Tab>();
        private readonly Semaphore _checkForModifiedTabsSemaphore = new Semaphore( 1, 1 );
        private readonly bool _showStartUpRepos;
        private readonly Stack<String> _closedRepos = new Stack<String>();

        private readonly HotKey _newTabHotKey;
        private readonly HotKey _nextTabHotKey;
        private readonly HotKey _previousTabHotKey;
        private readonly HotKey _closeTabHotKey;
        private readonly HotKey _reopenClosedTabHotKey;

        private TreeNode<FavoriteRepo> _favoriteRepos;

        private bool _favoriteContextMenuOpen;

        private IEnumerable<HotKey> HotKeys
        {
            get
            {
                yield return _newTabHotKey;
                yield return _nextTabHotKey;
                yield return _previousTabHotKey;
                yield return _closeTabHotKey;
                yield return _reopenClosedTabHotKey;
            }
        }

        class TabTag
        {
            public Process Process { get; private set; }
            public String Repo { get; private set; }
            public bool Modified { get; set; }

            public TabTag( Process process, String repo )
            {
                Process = process;
                Repo = repo;
                Modified = false;
            }
        }

        public TabbedTortoiseGitForm( bool showStartUpRepos )
        {
            LOG.DebugFormat( "Constructor - Show Start-up Repos: {0}", showStartUpRepos );

            InitializeComponent();
            InitializeEventHandlers();

            _showStartUpRepos = showStartUpRepos;

            _folderDialog = new CommonOpenFileDialog();
            _folderDialog.IsFolderPicker = true;

            _newTabHotKey = new HotKey( this.Handle );
            _newTabHotKey.AddHandle( this.Handle );
            _newTabHotKey.HotKeyPressed += NewTabHotKey_HotKeyPressed;

            _nextTabHotKey = new HotKey( this.Handle );
            _nextTabHotKey.AddHandle( this.Handle );
            _nextTabHotKey.HotKeyPressed += NextTabHotKey_HotKeyPressed;

            _previousTabHotKey = new HotKey( this.Handle );
            _previousTabHotKey.AddHandle( this.Handle );
            _previousTabHotKey.HotKeyPressed += PreviousTabHotKey_HotKeyPressed;

            _closeTabHotKey = new HotKey( this.Handle );
            _closeTabHotKey.AddHandle( this.Handle );
            _closeTabHotKey.HotKeyPressed += CloseTabHotKey_HotKeyPressed;

            _reopenClosedTabHotKey = new HotKey( this.Handle );
            _reopenClosedTabHotKey.AddHandle( this.Handle );
            _reopenClosedTabHotKey.HotKeyPressed += ReopenClosedTabHotKey_HotKeyPressed;

            this.Icon = Resources.TortoiseIcon;

            UpdateFromSettings( true );
        }

        private void UpdateFromSettings( bool updateWindowState )
        {
            if( updateWindowState )
            {
                if( !Settings.Default.Size.IsEmpty )
                {
                    this.Size = Settings.Default.Size;
                    this.CenterToScreen();
                }

                if( Settings.Default.Maximized )
                {
                    this.WindowState = FormWindowState.Maximized;
                }
            }

            if( Settings.Default.DeveloperSettingsEnabled )
            {
                LogTabs.ShowHitTest = Settings.Default.ShowHitTest;
            }
            else
            {
                LogTabs.ShowHitTest = false;
            }

            CheckForModifiedTabsTimer.Enabled = Settings.Default.IndicateModifiedTabs;
            CheckForModifiedTabsTimer.Interval = Settings.Default.CheckForModifiedTabsInterval;

            lock( _processes )
            {
                foreach( Tab t in LogTabs.Tabs )
                {
                    UpdateTabDisplay( t );
                }
            }

            UpdateShortcutsFromSettings();
            UpdateRecentReposFromSettings();
            UpdateRepoContextMenusFromSettings();
            UpdateFavoriteReposFromSettings();
        }

        private void UpdateShortcutsFromSettings()
        {
            _newTabHotKey.SetShortcut( Settings.Default.NewTabShortcut );
            _nextTabHotKey.SetShortcut( Settings.Default.NextTabShortcut );
            _previousTabHotKey.SetShortcut( Settings.Default.PreviousTabShortcut );
            _closeTabHotKey.SetShortcut( Settings.Default.CloseTabShortcut );
            _reopenClosedTabHotKey.SetShortcut( Settings.Default.ReopenClosedTabShortcut );
        }

        private void UpdateRecentReposFromSettings()
        {
            NewTabContextMenu.SuspendLayout();

            RecentReposMenu.DropDownItems.Clear();
            NewTabContextMenu.Items.Clear();

            foreach( String repo in Settings.Default.RecentRepos )
            {
                RecentReposMenu.DropDownItems.Add( repo ).Click += RecentRepoMenuItem_Click;
                NewTabContextMenu.Items.Add( repo ).Click += RecentRepoMenuItem_Click;
            }

            RecentReposMenu.Enabled = RecentReposMenu.HasDropDownItems;
            NewTabContextMenu.Enabled = NewTabContextMenu.Items.Count != 0;

            NewTabContextMenu.ResumeLayout();
        }

        private void UpdateRepoContextMenusFromSettings()
        {
            TabContextMenu.SuspendLayout();
            FavoriteRepoContextMenu.SuspendLayout();

            TabContextMenu.Items.Clear();
            TabContextMenu.Items.Add( OpenRepoLocationTabMenuItem );
            TabContextMenu.Items.Add( AddToFavoritesRepoTabMenuItem );

            FavoriteRepoContextMenu.Items.Clear();
            FavoriteRepoContextMenu.Items.Add( OpenFavoriteRepoLocationContextMenuItem );

            List<TortoiseGitCommand> actions = Settings.Default.TabContextMenuGitActions
                                                    .Where( action => TortoiseGit.ACTIONS.ContainsKey( action ) )
                                                    .Select( action => TortoiseGit.ACTIONS[ action ] ).ToList();
            if( actions.Count > 0 )
            {
                TabContextMenu.Items.Add( "-" );

                FavoriteRepoContextMenu.Items.Add( "-" );

                foreach( TortoiseGitCommand action in actions )
                {
                    ToolStripItem tabMenuItem = TabContextMenu.Items.Add( action.Name, action.Icon );
                    tabMenuItem.Click += GitCommandTabMenuItem_Click;
                    tabMenuItem.Tag = action.Func;

                    ToolStripItem favoriteMenuItem = FavoriteRepoContextMenu.Items.Add( action.Name, action.Icon );
                    favoriteMenuItem.Click += GitCommandFavoriteContextMenuItem_Click;
                    favoriteMenuItem.Tag = action.Func;
                }
            }

            TabContextMenu.Items.Add( "-" );
            TabContextMenu.Items.Add( CloseRepoTabMenuItem );

            FavoriteRepoContextMenu.Items.Add( "-" );
            FavoriteRepoContextMenu.Items.Add( RemoveFavoriteContextMenuItem );

            TabContextMenu.ResumeLayout();
            FavoriteRepoContextMenu.ResumeLayout();
        }

        private void UpdateFavoriteReposFromSettings()
        {
            FavoritesMenuStrip.SuspendLayout();

            FavoritesMenuStrip.Items.Clear();

            _favoriteRepos = Settings.Default.FavoriteRepos;

            CreateFavoritesMenu( _favoriteRepos, FavoritesMenuStrip.Items );

            FavoritesMenuStrip.ResumeLayout();
        }

        private void CreateFavoritesMenu( TreeNode<FavoriteRepo> favorites, ToolStripItemCollection menuItems )
        {
            foreach( TreeNode<FavoriteRepo> favorite in favorites.Children )
            {
                ToolStripMenuItem item = new ToolStripMenuItem( favorite.Value.Name );
                item.ToolTipText = favorite.Value.Repo;
                if( favorite.Value.IsFavoriteFolder )
                {
                    item.Image = Resources.FolderFolder;
                }
                else if( favorite.Value.IsDirectory )
                {
                    item.Image = Resources.Folder;
                    item.Click += FavoritedRepoMenuItem_Click;
                }
                else
                {
                    item.Image = Resources.File;
                    item.Click += FavoritedRepoMenuItem_Click;
                }
                item.Tag = favorite;
                item.MouseUp += FavoriteMenuItem_MouseUp;
                item.DropDown.Closing += FavoriteMenuItemDropDown_Closing;

                menuItems.Add( item );

                CreateFavoritesMenu( favorite, item.DropDownItems );
            }
        }

        private void AddToRecentRepos( String path )
        {
            String repo = Git.GetBaseRepoDirectory( path );
            if( repo == null )
            {
                LOG.ErrorFormat( "Failed to add recent repo - Path: {0}", path );
                return;
            }

            if( Settings.Default.RecentRepos.Contains( repo ) )
            {
                Settings.Default.RecentRepos.Remove( repo );
            }
            Settings.Default.RecentRepos.Insert( 0, repo );

            int maxRecentRepos = Settings.Default.MaxRecentRepos;
            if( Settings.Default.RecentRepos.Count > maxRecentRepos )
            {
                Settings.Default.RecentRepos.RemoveRange( maxRecentRepos, Settings.Default.RecentRepos.Count - maxRecentRepos );
            }

            Settings.Default.Save();
            UpdateRecentReposFromSettings();
        }

        private void AddFavoriteRepo( String name, String path )
        {
            String repo = Git.GetBaseRepoDirectory( path );
            if( repo == null )
            {
                LOG.ErrorFormat( "Failed to add favorite repo: {0}", path );
            }

            bool isDirectroy = Directory.Exists( repo );
            _favoriteRepos.Add( new FavoriteRepo( name, path, isDirectroy, false ) );

            Settings.Default.FavoriteRepos = _favoriteRepos;
            Settings.Default.Save();

            UpdateFavoriteReposFromSettings();
        }

        private void RemoveFavorite( TreeNode<FavoriteRepo> favorite )
        {
            favorite.Parent.Remove( favorite );
            Settings.Default.FavoriteRepos = _favoriteRepos;
            Settings.Default.Save();

            UpdateFavoriteReposFromSettings();
        }

        private async Task OpenLog( String path )
        {
            AddToRecentRepos( path );

            Process p = TortoiseGit.Log( path );
            await AddNewLog( p, path );
        }

        internal async Task AddNewLog( Process p, String path )
        {
            LOG.DebugFormat( "AddNewLog - Path: {0} - PID: {1}", path, p.Id );
            lock( _processes )
            {
                if( _processes.Any( ( pf ) => pf.Id == p.Id ) )
                {
                    LOG.DebugFormat( "AddNewLog - Process already under control - Path: {0} - PID: {1}", path, p.Id );
                    return;
                }
                _processes.Add( p );
            }

            LOG.DebugFormat( "AddNewLog - Start Wait for MainWindowHandle - Path: {0} - PID: {1}", path, p.Id );
            while( !p.HasExited && p.MainWindowHandle == IntPtr.Zero )
            {
                await Task.Delay( 10 );
            }
            LOG.DebugFormat( "AddNewLog - End Wait for MainWindowHandle - Path: {0} - PID: {1}", path, p.Id );

            Tab t = new Tab( path );
            LogTabs.Tabs.Add( t );
            LogTabs.SelectedTab = t;
            t.Tag = new TabTag( p, path );
            _tabs.Add( p.Id, t );

            UpdateTabDisplay( t );

            Native.RemoveBorder( p.MainWindowHandle );
            Native.SetWindowParent( p.MainWindowHandle, t );
            ResizeTab( p, t );

            foreach( HotKey hotKey in HotKeys )
            {
                hotKey.AddHandle( p.MainWindowHandle );
            }

            t.Resize += Tab_Resize;
            p.EnableRaisingEvents = true;
            p.Exited += Process_Exited;

            ShowMe();
        }

        private void ResizeTab( Process p, Tab t )
        {
            Size sizeDiff = Native.ResizeToParent( p.MainWindowHandle, t );

            if( sizeDiff.Width > 0 )
            {
                this.Width += sizeDiff.Width;
                this.MinimumSize = new Size( this.Width, this.MinimumSize.Height );
            }

            if( sizeDiff.Height > 0 )
            {
                this.Height += sizeDiff.Height;
                this.MinimumSize = new Size( this.MinimumSize.Width, this.Height );
            }
        }

        private void RemoveLog( Process p )
        {
            LOG.DebugFormat( "RemoveLog - {0}", p.Id );

            lock( _processes )
            {
                if( !_processes.Contains( p ) )
                {
                    LOG.ErrorFormat( "Attempting to remove log not under control - Process ID: {0}", p.Id );
                    return;
                }

                p.EnableRaisingEvents = false;
                p.Exited -= Process_Exited;

                foreach( HotKey hotKey in HotKeys )
                {
                    hotKey.RemoveHandle( p.MainWindowHandle );
                    hotKey.RemoveHandle( p.MainWindowHandle );
                }

                _processes.Remove( p );

                Tab t = _tabs.Pluck( p.Id );

                TabTag tag = (TabTag)t.Tag;
                _closedRepos.Push( tag.Repo );

                if( t.Parent != null )
                {
                    t.Parent.Controls.Remove( t );
                }
                else
                {
                    LOG.DebugFormat( "RemoveLog - Tab has already been removed: {0}", t.Text );
                }

                if( !p.HasExited )
                {
                    p.Kill();
                }
                else
                {
                    LOG.DebugFormat( "RemoveLog - Process has already exited: {0}", p.Id );
                }
            }
        }

        private void RemoveAllLogs()
        {
            lock( _processes )
            {
                LOG.DebugFormat( "RemoveAllLogs - Count: {0}", _processes.Count );

                while( _processes.Count > 0 )
                {
                    RemoveLog( _processes.First() );
                }
            }
        }

        private void CloseTab( Tab tab )
        {
            TabTag t = (TabTag)tab.Tag;

            LOG.DebugFormat( "Close Tab - Repo: {0} - ID: {1}", t.Repo, t.Process.Id );

            RemoveLog( t.Process );

            if( LogTabs.TabCount == 0
             && Settings.Default.CloseWindowOnLastTabClosed )
            {
                LOG.Debug( "Close Tab - Closing window after last tab closed" );
                this.Close();
            }
        }

        internal bool OwnsLog( Process logProcess )
        {
            lock( _processes )
            {
                return _processes.Any( p => p.Id == logProcess.Id );
            }
        }

        private async Task FindRepo()
        {
            LOG.Debug( "FindRepo" );

            if( _folderDialog.ShowDialog() == CommonFileDialogResult.Ok )
            {
                String path = _folderDialog.FileName;
                if( !Git.IsRepo( path ) )
                {
                    LOG.DebugFormat( "FindRepo - Invalid repo: {0}", path );
                    MessageBox.Show( "Directory is not a git repo!", "Invalid Directory", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
                else
                {
                    LOG.DebugFormat( "FindRepo - Opening repo: {0}", path );
                    await OpenLog( path );
                }
            }
        }

        private void ShowMe()
        {
            this.Show();
            if( this.WindowState == FormWindowState.Minimized )
            {
                this.WindowState = FormWindowState.Normal;
            }
            this.BringToFront();
        }

        private async Task OpenStartupRepos()
        {
            LOG.Debug( nameof( OpenStartupRepos ) );

            foreach( String repo in Settings.Default.StartupRepos )
            {
                if( Git.IsRepo( repo ) )
                {
                    await OpenLog( repo );
                }
            }
        }

        private async Task OpenFavoriteRepos( TreeNode<FavoriteRepo> favorite )
        {
            foreach( TreeNode<FavoriteRepo> child in favorite.Children )
            {
                if( !child.Value.IsFavoriteFolder )
                {
                    await OpenLog( child.Value.Repo );
                }
                else
                {
                    await OpenFavoriteRepos( child );
                }
            }
        }

        private void SaveWindowState()
        {
            if( this.WindowState == FormWindowState.Maximized )
            {
                Settings.Default.Maximized = true;
                Settings.Default.Size = this.RestoreBounds.Size;
            }
            else if( this.WindowState == FormWindowState.Minimized )
            {
                Settings.Default.Maximized = false;
                Settings.Default.Size = this.RestoreBounds.Size;
            }
            else
            {
                Settings.Default.Maximized = false;
                Settings.Default.Size = this.Size;
            }

            Settings.Default.Save();
        }

        private bool ConfirmClose()
        {
            if( !this.Visible )
            {
                return true;
            }
            else if( _processes.Count == 0 )
            {
                return true;
            }
            else if( Settings.Default.ConfirmOnClose )
            {
                CloseConfirmationDialog d = new CloseConfirmationDialog( this.Visible );
                DialogResult result = d.ShowDialog();
                if( result == DialogResult.Yes
                 || result == DialogResult.No )
                {
                    Settings.Default.ConfirmOnClose = !d.DontAskAgain;
                    Settings.Default.Save();

                    if( result == DialogResult.Yes )
                    {
                        return true;
                    }
                }

                return false;
            }
            else
            {
                return true;
            }
        }

        private void UpdateTabDisplay( Tab tab )
        {
            TabTag tag = (TabTag)tab.Tag;
            if( Settings.Default.IndicateModifiedTabs && tag.Modified )
            {
                tab.Font = Settings.Default.ModifiedTabFont;
                tab.ForeColor = Settings.Default.ModifiedTabFontColor;
            }
            else
            {
                tab.Font = Settings.Default.NormalTabFont;
                tab.ForeColor = Settings.Default.NormalTabFontColor;
            }
        }

        private void CloseDropDowns( ToolStripItemCollection menuItems )
        {
            foreach( ToolStripDropDownItem dropDownItem in menuItems.OfType<ToolStripDropDownItem>() )
            {
                dropDownItem.HideDropDown();
                CloseDropDowns( dropDownItem.DropDownItems );
            }

        }
    }
}
