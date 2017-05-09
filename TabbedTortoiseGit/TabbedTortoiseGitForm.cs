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

namespace TabbedTortoiseGit
{
    public partial class TabbedTortoiseGitForm : Form
    {
        public static readonly String TORTOISE_GIT_EXE = "TortoiseGitProc.exe";
        public static readonly String SHOW_LOG_COMMAND = "/command:log /path \"{0}\"";

        private readonly List<Process> _processes = new List<Process>();
        private readonly Dictionary<int, TabPage> _tabs = new Dictionary<int, TabPage>();

        private ManagementEventWatcher _watcher;

        public TabbedTortoiseGitForm()
        {
            InitializeComponent();

            LogTabs.NewTabContextMenu = NewTabContextMenu;

            StartProcessQuery();

            this.Disposed += TabbedTortoiseGitForm_Disposed;
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
        }

        private void UpdateRecentReposFromSettings()
        {
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
        }

        private void StartProcessQuery()
        {
            String condition = "TargetInstance ISA 'Win32_Process'" +
                           "AND TargetInstance.Name = 'TortoiseGitProc.exe'" +
                           "AND TargetInstance.CommandLine LIKE '%/command:log%'";
            _watcher = new ManagementEventWatcher( new WqlEventQuery( "__InstanceCreationEvent", new TimeSpan( 10 ), condition ) );
            _watcher.Options.Timeout = new TimeSpan( 0, 1, 0 );
            _watcher.EventArrived += Watcher_EventArrived;
            _watcher.Start();
        }

        private void TabbedTortoiseGitForm_Disposed( object sender, EventArgs e )
        {
            _watcher.Dispose();
        }

        private void RecentRepoMenuItem_Click( object sender, EventArgs e )
        {
            ToolStripItem item = (ToolStripItem)sender;
            OpenLog( item.Text );
        }

        private void AddToRecentRepos( String path )
        {
            List<String> recentRepos = Settings.Default.RecentRepos != null ? Settings.Default.RecentRepos : new List<String>();
            if( recentRepos.Contains( path ) )
            {
                recentRepos.Remove( path );
            }
            recentRepos.Insert( 0, path );
            Settings.Default.RecentRepos = recentRepos;
            UpdateRecentReposFromSettings();
        }

        private async void OpenLog( String path )
        {
            AddToRecentRepos( path );

            ProcessStartInfo info = new ProcessStartInfo()
            {
                FileName = TORTOISE_GIT_EXE,
                Arguments = String.Format( SHOW_LOG_COMMAND, path ),
                WorkingDirectory = path
            };
            Process p = Process.Start( info );
            await AddNewProcess( p );
        }

        private async Task AddNewProcess( Process p )
        {
            lock( _processes )
            {
                if( _processes.Any( ( pf ) => pf.Id == p.Id ) )
                {
                    return;
                }
                _processes.Add( p );
            }

            p.WaitForInputIdle();
            while( !p.HasExited && p.MainWindowHandle == IntPtr.Zero )
            {
                await Task.Delay( 10 );
            }

            TabPage t = new TabPage( p.MainWindowTitle.Replace( " - Log Messages - TortoiseGit", "" ) );
            LogTabs.TabPages.Add( t );
            LogTabs.SelectedTab = t;
            t.Tag = p;
            _tabs.Add( p.Id, t );

            Native.RemoveBorder( p.MainWindowHandle );
            Native.SetWindowParent( p.MainWindowHandle, t );

            t.Resize += Tab_Resize;
            p.EnableRaisingEvents = true;
            p.Exited += Process_Exited;

            this.BringToFront();
        }

        private void EndProcess( Process p )
        {
            p.Exited -= Process_Exited;
            if( !p.HasExited )
            {
                p.Kill();
            }
        }

        private void RemoveProcess( Process p )
        {
            _processes.Remove( p );

            TabPage t = _tabs.Pluck( p.Id );
            t.Invoke( (Action<TabPage>)( ( tab ) => tab.Parent.Controls.Remove( tab ) ), t );
        }

        private void FindRepo()
        {
            if( FindRepoDialog.ShowDialog() == DialogResult.OK )
            {
                String path = FindRepoDialog.SelectedPath;
                if( !Git.IsRepo( path ) )
                {
                    MessageBox.Show( "Directory is not a git repo!", "Invalid Directory", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
                else
                {
                    OpenLog( path );
                }
            }
        }

        private void Tab_Resize( object sender, EventArgs e )
        {
            TabPage t = (TabPage)sender;
            Process p = (Process)t.Tag;

            Native.ResizeToParent( p.MainWindowHandle, t );
        }

        private void Process_Exited( object sender, EventArgs e )
        {
            RemoveProcess( (Process)sender );
        }

        private void TabbedTortoiseGitForm_Load( object sender, EventArgs e )
        {
            UpdateFromSettings();
        }

        private void TabbedTortoiseGitForm_FormClosing( object sender, FormClosingEventArgs e )
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

        private void TabbedTortoiseGitForm_FormClosed( object sender, FormClosedEventArgs e )
        {
            lock( _processes )
            {
                foreach( Process p in _processes )
                {
                    EndProcess( p );
                }
            }
        }

        private void LogTabs_NewTabClicked( object sender, EventArgs e )
        {
            FindRepo();
        }

        private void LogTabs_TabClosed( object sender, TabClosedEventArgs e )
        {
            Process p = (Process)e.Tab.Tag;

            EndProcess( p );
            _processes.Remove( p );
            _tabs.Remove( p.Id );
        }

        private void LogTabs_Selected( object sender, TabControlEventArgs e )
        {
            this.Text = e.TabPage.Text + " - Tabbed TortoiseGit";
        }

        private void OpenRepoMenuItem_Click( object sender, EventArgs e )
        {
            FindRepo();
        }

        private void Watcher_EventArrived( object sender, EventArrivedEventArgs e )
        {
            ManagementBaseObject o = (ManagementBaseObject)e.NewEvent[ "TargetInstance" ];
            Process p = Process.GetProcessById( (int)(UInt32)o[ "ProcessId" ] );
            LogTabs.Invoke( (Func<Process, Task>)AddNewProcess, p );
        }
    }
}
