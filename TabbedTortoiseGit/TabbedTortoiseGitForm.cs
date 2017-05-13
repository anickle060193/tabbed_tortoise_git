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

namespace TabbedTortoiseGit
{
    public partial class TabbedTortoiseGitForm : Form
    {
        public static readonly String TORTOISE_GIT_EXE = "TortoiseGitProc.exe";
        public static readonly String SHOW_LOG_COMMAND = "/command:log /path \"{0}\"";

        private readonly CommonOpenFileDialog _folderDialog;
        private readonly ManagementEventWatcher _watcher;
        private readonly List<Process> _processes = new List<Process>();
        private readonly Dictionary<int, TabPage> _tabs = new Dictionary<int, TabPage>();

        public TabbedTortoiseGitForm()
        {
            InitializeComponent();
            InitializeEventHandlers();

            _folderDialog = new CommonOpenFileDialog();
            _folderDialog.IsFolderPicker = true;

            String condition = "TargetInstance ISA 'Win32_Process'" +
                           "AND TargetInstance.Name = 'TortoiseGitProc.exe'" +
                           "AND TargetInstance.CommandLine LIKE '%/command:log%'";
            _watcher = new ManagementEventWatcher( new WqlEventQuery( "__InstanceCreationEvent", new TimeSpan( 10 ), condition ) );
            _watcher.Options.Timeout = new TimeSpan( 0, 1, 0 );
            _watcher.EventArrived += Watcher_EventArrived;
            _watcher.Start();

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

        private void AddToRecentRepos( String path )
        {
            List<String> recentRepos = Settings.Default.RecentRepos != null ? Settings.Default.RecentRepos : new List<String>();
            if( recentRepos.Contains( path ) )
            {
                recentRepos.Remove( path );
            }
            recentRepos.Insert( 0, path );

            int maxRecentRepos = Settings.Default.MaxRecentRepos;
            if( recentRepos.Count > maxRecentRepos )
            {
                recentRepos.RemoveRange( maxRecentRepos, recentRepos.Count - maxRecentRepos );
            }

            Settings.Default.RecentRepos = recentRepos;
            Settings.Default.Save();
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

            ShowMe();
        }

        private void EndProcess( Process p )
        {
            p.EnableRaisingEvents = false;
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

        private void RemoveAllProcesses()
        {
            lock( _processes )
            {
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
            if( _folderDialog.ShowDialog() == CommonFileDialogResult.Ok )
            {
                String path = _folderDialog.FileName;
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
    }
}
