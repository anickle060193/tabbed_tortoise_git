using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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
        public static readonly String TORTOISE_GIT_EXE = @"C:\Program Files\TortoiseGit\bin\TortoiseGitProc.exe";
        public static readonly String SHOW_LOG_COMMAND = "/command:log /path \"{0}\"";

        private readonly List<Process> _processes = new List<Process>();
        private readonly Dictionary<int, TabPage> _tabs = new Dictionary<int, TabPage>();

        public TabbedTortoiseGitForm()
        {
            InitializeComponent();

            UpdateFromSettings();

            OpenLog( @"D:\Users\Adam\Desktop\anickle060193.github.io" );
        }

        private void UpdateFromSettings()
        {
            RecentReposMenu.DropDownItems.Clear();
            if( Settings.Default.RecentRepos != null )
            {
                foreach( String repo in Settings.Default.RecentRepos )
                {
                    RecentReposMenu.DropDownItems.Add( repo ).Click += RecentRepoMenuItem_Click;
                }
            }
            RecentReposMenu.Enabled = RecentReposMenu.HasDropDownItems;
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
            Settings.Default.Save();
            UpdateFromSettings();
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
            _processes.Add( p );

            Native.SetWindowParent( p.MainWindowHandle, t );
            Native.RemoveBorder( p.MainWindowHandle );

            t.Resize += Tab_Resize;
            p.EnableRaisingEvents = true;
            p.Exited += Process_Exited;
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

        private void TabbedTortoiseGitForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            foreach( Process p in _processes )
            {
                EndProcess( p );
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
    }
}
