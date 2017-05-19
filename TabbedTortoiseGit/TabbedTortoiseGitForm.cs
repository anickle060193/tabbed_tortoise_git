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

namespace TabbedTortoiseGit
{
    public partial class TabbedTortoiseGitForm : Form
    {
        private static readonly ILog LOG = LogManager.GetLogger( typeof( TabbedTortoiseGitForm ) );

        private readonly CommonOpenFileDialog _folderDialog;
        private readonly ManagementEventWatcher _watcher;
        private readonly List<Process> _processes = new List<Process>();
        private readonly Dictionary<int, TabPage> _tabs = new Dictionary<int, TabPage>();
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

                if( _processes.Count == 0 )
                {
                    OpenDefaultRepos();
                }
            }
            base.WndProc( ref m );
        }

        private void UpdateFromSettings()
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

            UpdateRecentReposFromSettings();
            UpdateTabMenuFromSettings();
            UpdateFavoriteReposFromSettings();
        }

        private void UpdateRecentReposFromSettings()
        {
            NewTabContextMenu.SuspendLayout();

            RecentReposMenu.DropDownItems.Clear();
            NewTabContextMenu.Items.Clear();
            if( Settings.Default.RecentRepos != null )
            {
                foreach( String repo in Settings.Default.RecentRepos )
                {
                    RecentReposMenu.DropDownItems.Add( repo ).Click += RecentRepoMenuItem_Click;
                    NewTabContextMenu.Items.Add( repo ).Click += RecentRepoMenuItem_Click;
                }
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

            if( Settings.Default.TabContextMenuGitActions != null )
            {
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

            foreach( KeyValuePair<String, String> kv in GetFavoritedRepos() )
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

            List<String> recentRepos = Settings.Default.RecentRepos != null ? Settings.Default.RecentRepos : new List<String>();
            if( recentRepos.Contains( repo ) )
            {
                recentRepos.Remove( repo );
            }
            recentRepos.Insert( 0, repo );

            int maxRecentRepos = Settings.Default.MaxRecentRepos;
            if( recentRepos.Count > maxRecentRepos )
            {
                recentRepos.RemoveRange( maxRecentRepos, recentRepos.Count - maxRecentRepos );
            }

            Settings.Default.RecentRepos = recentRepos;
            Settings.Default.Save();
            UpdateRecentReposFromSettings();
        }

        private Dictionary<String, String> GetFavoritedRepos()
        {
            String favoritedReposString = Settings.Default.FavoritedRepos;
            Dictionary<String, String> favoriteRepos = null;
            try
            {
                favoriteRepos = JsonConvert.DeserializeObject<Dictionary<String, String>>( favoritedReposString );
            }
            catch( JsonReaderException e )
            {
                LOG.ErrorFormat( "Failed to parse Favorite Repos setting - Favorited Repos: {0}", favoritedReposString );
                LOG.Error( e );
            }

            if( favoriteRepos == null )
            {
                return new Dictionary<String, String>();
            }
            else
            {
                return favoriteRepos;
            }
        }

        private void SaveFavoritedRepos( Dictionary<String, String> favoritedRepos )
        {
            String favoritedReposString = JsonConvert.SerializeObject( favoritedRepos );
            Settings.Default.FavoritedRepos = favoritedReposString;
            Settings.Default.Save();
        }

        private bool AddFavoriteRepo( String name, String path )
        {
            String repo = Git.GetBaseRepoDirectory( path );
            if( repo == null )
            {
                LOG.ErrorFormat( "Failed to add favorite repo: {0}", path );
                return false;
            }

            Dictionary<String, String> f = GetFavoritedRepos();

            if( f.ContainsKey( name ) )
            {
                MessageBox.Show( "A favorited repo already exists with name: \"{0}\".".XFormat( name ) );
                return false;
            }

            if( f.ContainsValue( repo ) )
            {
                MessageBox.Show( "A favorited repo already exists for that repo." );
                return false;
            }

            f[ name ] = repo;
            SaveFavoritedRepos( f );

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

            Dictionary<String, String> f = GetFavoritedRepos();

            foreach( String key in f.Where( kv => kv.Value == repo ).Select( kv => kv.Key ).ToList() )
            {
                f.Remove( key );
            }
            SaveFavoritedRepos( f );

            UpdateFavoriteReposFromSettings();
        }

        private bool IsFavoriteRepo( String path )
        {
            String repo = Git.GetBaseRepoDirectory( path );
            if( repo == null )
            {
                return false;
            }

            Dictionary<String, String> f = GetFavoritedRepos();
            return f.ContainsValue( repo );
        }

        private async void OpenLog( String path )
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

            TabPage t = new TabPage( path );
            LogTabs.TabPages.Add( t );
            LogTabs.SelectedTab = t;
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

        private void ResizeTab( Process p, TabPage t )
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

        private void EndProcess( Process p )
        {
            LOG.DebugFormat( "EndProcess - {0}", p.Id );

            p.EnableRaisingEvents = false;
            p.Exited -= Process_Exited;
            if( !p.HasExited )
            {
                p.Kill();
            }
            else
            {
                LOG.DebugFormat( "EndProcess - Process has already exited: {0}", p.Id );
            }
        }

        private void RemoveLog( Process p )
        {
            LOG.DebugFormat( "RemoveLog - {0}", p.Id );

            _processes.Remove( p );

            TabPage t = _tabs.Pluck( p.Id );
            t.Invoke( (Action<TabPage>)( ( tab ) => tab.Parent.Controls.Remove( tab ) ), t );
        }

        private void RemoveAllProcesses()
        {
            lock( _processes )
            {
                LOG.DebugFormat( "RemoveAllProcesses - Count: {0}", _processes.Count );

                foreach( Process p in _processes )
                {
                    EndProcess( p );
                }
                _processes.Clear();

                foreach( TabPage t in _tabs.Values )
                {
                    LogTabs.TabPages.Remove( t );
                }
                _tabs.Clear();
            }
        }

        private void FindRepo()
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
                    OpenLog( path );
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

        private void OpenDefaultRepos()
        {
            LOG.Debug( "OpenDefaultRepos" );

            if( Settings.Default.DefaultRepos != null )
            {
                foreach( String repo in Settings.Default.DefaultRepos )
                {
                    if( Git.IsRepo( repo ) )
                    {
                        OpenLog( repo );
                    }
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
    }
}
