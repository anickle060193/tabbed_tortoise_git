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

namespace TabbedTortoiseGit
{
    public partial class TabbedTortoiseGitForm : Form
    {
        private static readonly ILog LOG = LogManager.GetLogger( typeof( TabbedTortoiseGitForm ) );

        private readonly CommonOpenFileDialog _folderDialog;
        private readonly ManagementEventWatcher _watcher;
        private readonly List<Process> _processes = new List<Process>();
        private readonly Dictionary<int, Tab> _tabs = new Dictionary<int, Tab>();
        private readonly bool _startup;

        class TabTag
        {
            public Process Process { get; private set; }
            public String Repo { get; private set; }

            public TabTag( Process process, String repo )
            {
                Process = process;
                Repo = repo;
            }
        }

        public TabbedTortoiseGitForm() : this( false )
        {
        }

        public TabbedTortoiseGitForm( bool startup )
        {
            LOG.DebugFormat( "Control Constructor - Startup: {0}", startup );

            InitializeComponent();
            InitializeEventHandlers();

            _startup = startup;

            _folderDialog = new CommonOpenFileDialog();
            _folderDialog.IsFolderPicker = true;

            String condition = "TargetInstance ISA 'Win32_Process'" +
                           "AND TargetInstance.Name = 'TortoiseGitProc.exe'" +
                           "AND TargetInstance.CommandLine LIKE '%/command:log%'";
            _watcher = new ManagementEventWatcher( new WqlEventQuery( "__InstanceCreationEvent", new TimeSpan( 10 ), condition ) );
            _watcher.Options.Timeout = new TimeSpan( 0, 1, 0 );
            _watcher.EventArrived += Watcher_EventArrived;
            _watcher.Start();

            this.Icon = Resources.TortoiseIcon;
            NotifyIcon.Icon = this.Icon;
        }

        protected override void WndProc( ref Message m )
        {
            if( m.Msg == Native.WM_SHOWME )
            {
                ShowMe();
            }
            else
            {
                base.WndProc( ref m );
            }
        }

        private void UpdateFromSettings( bool updateWindowState )
        {
            if( updateWindowState )
            {
                if( !Settings.Default.Size.IsEmpty )
                {
                    this.Size = Settings.Default.Size;
                }

                if( !Settings.Default.Location.IsEmpty )
                {
                    this.Location = Settings.Default.Location;
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

            UpdateRecentReposFromSettings();
            UpdateTabMenuFromSettings();
            UpdateFavoriteReposFromSettings();
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

        private void UpdateTabMenuFromSettings()
        {
            TabContextMenu.SuspendLayout();

            TabContextMenu.Items.Clear();
            TabContextMenu.Items.Add( OpenRepoLocationTabMenuItem );
            TabContextMenu.Items.Add( FavoriteRepoTabMenuItem );

            List<TortoiseGitCommand> actions = Settings.Default.TabContextMenuGitActions
                                                    .Where( action => TortoiseGit.ACTIONS.ContainsKey( action ) )
                                                    .Select( action => TortoiseGit.ACTIONS[ action ] ).ToList();
            if( actions.Count > 0 )
            {
                TabContextMenu.Items.Add( "-" );

                foreach( TortoiseGitCommand action in actions )
                {
                    var menuItem = TabContextMenu.Items.Add( action.Name, action.Icon, GitCommandMenuItem_Click );
                    menuItem.Tag = action.Func;
                }
            }

            TabContextMenu.Items.Add( "-" );
            TabContextMenu.Items.Add( CloseRepoTabMenuItem );

            TabContextMenu.ResumeLayout();
        }

        private void UpdateFavoriteReposFromSettings()
        {
            MenuStrip.SuspendLayout();

            MenuStrip.Items.Clear();
            MenuStrip.Items.Add( OptionsMenu );

            foreach( KeyValuePair<String, String> kv in Settings.Default.FavoriteRepos )
            {
                if( Git.IsRepo( kv.Value ) )
                {
                    ToolStripItem item = MenuStrip.Items.Add( kv.Key );
                    item.ToolTipText = kv.Value;
                    item.Tag = kv.Value;
                    item.Click += FavoritedRepoMenuItem_Click;
                }
            }

            MenuStrip.ResumeLayout();
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

        private bool AddFavoriteRepo( String name, String path )
        {
            String repo = Git.GetBaseRepoDirectory( path );
            if( repo == null )
            {
                LOG.ErrorFormat( "Failed to add favorite repo: {0}", path );
                return false;
            }

            Dictionary<String, String> favoriteRepos = Settings.Default.FavoriteRepos;

            if( favoriteRepos.ContainsKey( name ) )
            {
                MessageBox.Show( "A favorited repo already exists with name: \"{0}\".".XFormat( name ) );
                return false;
            }

            if( favoriteRepos.ContainsValue( repo ) )
            {
                MessageBox.Show( "A favorited repo already exists for that repo." );
                return false;
            }

            favoriteRepos[ name ] = repo;
            Settings.Default.FavoriteRepos = favoriteRepos;
            Settings.Default.Save();

            UpdateFavoriteReposFromSettings();
            return true;
        }

        private void RemoveFavoriteRepo( String path )
        {
            String repo = Git.GetBaseRepoDirectory( path );
            if( repo == null )
            {
                LOG.ErrorFormat( "Failed to remove favorite repo - Path: {0}", path );
                return;
            }

            Dictionary<String, String> favoriteRepos = Settings.Default.FavoriteRepos;

            foreach( String key in favoriteRepos.Where( kv => kv.Value == repo ).Select( kv => kv.Key ).ToList() )
            {
                favoriteRepos.Remove( key );
            }
            Settings.Default.FavoriteRepos = favoriteRepos;
            Settings.Default.Save();

            UpdateFavoriteReposFromSettings();
        }

        private bool IsFavoriteRepo( String path )
        {
            String repo = Git.GetBaseRepoDirectory( path );
            if( repo == null )
            {
                return false;
            }

            return Settings.Default.FavoriteRepos.ContainsValue( repo );
        }

        private async Task OpenLog( String path )
        {
            AddToRecentRepos( path );

            Process p = TortoiseGit.Log( path );
            await AddNewLog( p, path );
        }

        private async Task AddNewLog( Process p, String path )
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
            t.Tag = new TabTag( p, path );
            _tabs.Add( p.Id, t );

            Native.RemoveBorder( p.MainWindowHandle );
            Native.SetWindowParent( p.MainWindowHandle, t );
            ResizeTab( p, t );

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
                if( !_tabs.ContainsKey( p.Id ) )
                {
                    return;
                }

                p.EnableRaisingEvents = false;
                p.Exited -= Process_Exited;

                _processes.Remove( p );

                Tab t = _tabs.Pluck( p.Id );
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

        private void SaveWindowState()
        {
            if( this.WindowState == FormWindowState.Maximized )
            {
                Settings.Default.Maximized = true;
                Settings.Default.Size = this.RestoreBounds.Size;
                Settings.Default.Location = this.RestoreBounds.Location;
            }
            else if( this.WindowState == FormWindowState.Minimized )
            {
                Settings.Default.Maximized = false;
                Settings.Default.Size = this.RestoreBounds.Size;
                Settings.Default.Location = this.RestoreBounds.Location;
            }
            else
            {
                Settings.Default.Maximized = false;
                Settings.Default.Size = this.Size;
                Settings.Default.Location = this.Location;
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
    }
}
