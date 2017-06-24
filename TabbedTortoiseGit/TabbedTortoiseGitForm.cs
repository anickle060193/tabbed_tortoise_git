using Common;
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

        private readonly Dictionary<int, TabControllerTag> _tags = new Dictionary<int, TabControllerTag>();
        private readonly CommonOpenFileDialog _folderDialog;
        private readonly Semaphore _checkForModifiedTabsSemaphore = new Semaphore( 1, 1 );
        private readonly bool _showStartUpRepos;
        private readonly Point _createdAtPoint;
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

        public TabbedTortoiseGitForm( bool showStartUpRepos, Point createdAtPoint )
        {
            LOG.DebugFormat( "Constructor - Show Start-up Repos: {0}", showStartUpRepos );

            InitializeComponent();
            InitializeEventHandlers();

            _showStartUpRepos = showStartUpRepos;
            _createdAtPoint = createdAtPoint;

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

                if( !_createdAtPoint.IsEmpty )
                {
                    this.StartPosition = FormStartPosition.Manual;

                    Rectangle formBounds = this.Bounds;
                    Rectangle tabBounds = LogTabs.RectangleToScreen( LogTabs.GetTabRect( 0 ) );
                    int tabX = tabBounds.Left - formBounds.Left;
                    int tabY = tabBounds.Top - formBounds.Top;

                    int x = _createdAtPoint.X - tabX - tabBounds.Width / 2;
                    int y = _createdAtPoint.Y - tabY - tabBounds.Height / 2;
                    this.Location = new Point( x, y );
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

            lock( _tags )
            {
                foreach( TabControllerTag tag in _tags.Values )
                {
                    tag.UpdateTabDisplay();
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
            await AddNewLogProcess( p, path );
        }

        internal void AddExistingTab( Tab tab )
        {
            LOG.DebugFormat( "AddExistingTab - Tab: {0}", tab );

            TabControllerTag tag = tab.Controller();

            if( this.OwnsLogProcess( tag.Process ) )
            {
                LOG.ErrorFormat( "AddExistingTab - Already own process - PID: {0}", tag.Process.Id );
                return;
            }

            LogTabs.Tabs.Add( tab );
            LogTabs.SelectedTab = tab;
        }

        internal async Task AddNewLogProcess( Process p, String path )
        {
            TabControllerTag tag;
            lock( _tags )
            {
                LOG.DebugFormat( "AddNewLogProcess - Path: {0} - PID: {1}", path, p.Id );
                if( this.OwnsLogProcess( p ) )
                {
                    LOG.DebugFormat( "AddNewLogProcess - Process already under control - Path: {0} - PID: {1}", path, p.Id );
                    return;
                }

                tag = TabControllerTag.CreateController( p, path );
                _tags.Add( tag.Process.Id, tag );
            }

            await tag.WaitForStartup();

            foreach( HotKey hotKey in HotKeys )
            {
                hotKey.AddHandle( tag.Process.MainWindowHandle );
            }

            LogTabs.Tabs.Add( tag.Tab );
            LogTabs.SelectedTab = tag.Tab;
        }

        private void RegisterExistingTab( Tab tab )
        {
            LOG.DebugFormat( "RegisterExistingTab - Tab: {0}", tab );

            TabControllerTag tag = tab.Controller();

            if( this.OwnsLogProcess( tag.Process ) )
            {
                LOG.ErrorFormat( "RegisterExistingTab - Already own process - PID: {0}", tag.Process.Id );
                return;
            }

            lock( _tags )
            {
                _tags.Add( tag.Process.Id, tag );
            }

            foreach( HotKey hotKey in HotKeys )
            {
                hotKey.AddHandle( tag.Process.MainWindowHandle );
            }

            ShowMe();
        }

        private void RemoveLogProcess( Process p, bool killProcess )
        {
            LOG.DebugFormat( "RemoveLogProcess - PID: {0} - Kill Process: {1}", p.Id, killProcess );

            lock( _tags )
            {
                if( !this.OwnsLogProcess( p ) )
                {
                    LOG.ErrorFormat( "Attempting to remove log not under control - Process ID: {0}", p.Id );
                    return;
                }

                foreach( HotKey hotKey in HotKeys )
                {
                    hotKey.RemoveHandle( p.MainWindowHandle );
                    hotKey.RemoveHandle( p.MainWindowHandle );
                }

                TabControllerTag tag = _tags[ p.Id ];

                _tags.Remove( p.Id );

                tag.Tab.Parent = null;

                if( killProcess )
                {
                    _closedRepos.Push( tag.Repo );

                    tag.Close();
                }
            }
        }

        private void RemoveAllLogs()
        {
            lock( _tags )
            {
                LOG.DebugFormat( "RemoveAllLogs - Count: {0}", _tags.Count );

                while( _tags.Count > 0 )
                {
                    RemoveLogProcess( _tags.Values.First().Process, true );
                }
            }
        }

        private void CloseTab( Tab tab )
        {
            TabControllerTag t = tab.Controller();

            LOG.DebugFormat( "Close Tab - Repo: {0} - ID: {1}", t.Repo, t.Process.Id );

            RemoveLogProcess( t.Process, true );

            if( LogTabs.TabCount == 0
             && Settings.Default.CloseWindowOnLastTabClosed )
            {
                LOG.Debug( "Close Tab - Closing window after last tab closed" );
                this.Close();
            }
        }

        internal bool OwnsLogProcess( Process logProcess )
        {
            lock( _tags )
            {
                return _tags.ContainsKey( logProcess.Id );
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
            else if( _tags.Count == 0 )
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
