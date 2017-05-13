using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TabbedTortoiseGit.Properties;

namespace TabbedTortoiseGit
{
    partial class TabbedTortoiseGitForm
    {
        private static readonly Regex TORTOISE_GIT_COMMAND_LINE_REGEX = new Regex( "/path:\"(?<repo>.*?)\" (/|$)", RegexOptions.IgnoreCase );

        private void InitializeEventHandlers()
        {
            this.Load += TabbedTortoiseGitForm_Load;
            this.FormClosing += TabbedTortoiseGitForm_FormClosing;
            this.FormClosed += TabbedTortoiseGitForm_FormClosed;
            this.Disposed += TabbedTortoiseGitForm_Disposed;

            LogTabs.NewTabClicked += LogTabs_NewTabClicked;
            LogTabs.TabClosed += LogTabs_TabClosed;
            LogTabs.Selected += LogTabs_Selected;

            OpenRepoMenuItem.Click += OpenRepoMenuItem_Click;
            SettingsMenuItem.Click += SettingsMenuItem_Click;
            AboutMenuItem.Click += AboutMenuItem_Click;
            ExitMenuItem.Click += ExitMenuItem_Click;

            NotifyIcon.DoubleClick += NotifyIcon_DoubleClick;
            OpenNotifyIconMenuItem.Click += OpenNotifyIconMenuItem_Click;
            ExitNotifyIconMenuItem.Click += ExitMenuItem_Click;

            OpenRepoLocationMenuItem.Click += OpenRepoLocationMenuItem_Click;
        }

        private void TabbedTortoiseGitForm_Load( object sender, EventArgs e )
        {
            UpdateFromSettings();

            OpenDefaultRepos();
        }

        private void TabbedTortoiseGitForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            if( !Settings.Default.RetainLogsOnClose )
            {
                this.RemoveAllProcesses();
            }

            if( e.CloseReason == CloseReason.UserClosing )
            {
                e.Cancel = true;
                this.Hide();
            }

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

        private void TabbedTortoiseGitForm_Disposed( object sender, EventArgs e )
        {
            _watcher.Dispose();
        }

        private void Process_Exited( object sender, EventArgs e )
        {
            RemoveProcess( (Process)sender );
        }

        private void LogTabs_NewTabClicked( object sender, EventArgs e )
        {
            FindRepo();
        }

        private void LogTabs_TabClosed( object sender, TabClosedEventArgs e )
        {
            TabTag t = (TabTag)e.Tab.Tag;

            EndProcess( t.Process );
            _processes.Remove( t.Process );
            _tabs.Remove( t.Process.Id );
        }

        private void LogTabs_Selected( object sender, TabControlEventArgs e )
        {
            if( e.TabPage != null )
            {
                this.Text = e.TabPage.Text + " - Tabbed TortoiseGit";
            }
            else
            {
                this.Text = "Tabbed TortoiseGit";
            }
        }

        private void Tab_Resize( object sender, EventArgs e )
        {
            TabPage t = (TabPage)sender;
            TabTag tag = (TabTag)t.Tag;

            Native.ResizeToParent( tag.Process.MainWindowHandle, t );
        }

        private void OpenRepoMenuItem_Click( object sender, EventArgs e )
        {
            FindRepo();
        }

        private void SettingsMenuItem_Click( object sender, EventArgs e )
        {
            if( SettingsForm.ShowSettingsDialog() )
            {
                UpdateRecentReposFromSettings();
            }
        }

        private void AboutMenuItem_Click( object sender, EventArgs e )
        {
            AboutBox.ShowAbout();
        }

        private void RecentRepoMenuItem_Click( object sender, EventArgs e )
        {
            ToolStripItem item = (ToolStripItem)sender;
            OpenLog( item.Text );
        }

        private void ExitMenuItem_Click( object sender, EventArgs e )
        {
            Application.Exit();
        }

        private void Watcher_EventArrived( object sender, EventArrivedEventArgs e )
        {
            ManagementBaseObject o = (ManagementBaseObject)e.NewEvent[ "TargetInstance" ];
            String commandLine = (String)o[ "CommandLine" ];
            Match m = TORTOISE_GIT_COMMAND_LINE_REGEX.Match( commandLine );
            String repo = m.Groups[ "repo" ].Value;
            Process p = Process.GetProcessById( (int)(UInt32)o[ "ProcessId" ] );
            LogTabs.Invoke( (Func<Process, String, Task>)AddNewLog, p, repo );
        }

        private void NotifyIcon_DoubleClick( object sender, EventArgs e )
        {
            this.ShowMe();
        }

        private void OpenNotifyIconMenuItem_Click( object sender, EventArgs e )
        {
            this.ShowMe();
        }

        private void OpenRepoLocationMenuItem_Click( object sender, EventArgs e )
        {
            TabTag t = (TabTag)LogTabs.SelectedTab.Tag;
            if( Directory.Exists( t.Repo ) )
            {
                Process.Start( t.Repo );
            }
            else if( File.Exists( t.Repo ) )
            {
                Process.Start( "explorer.exe", String.Format( "/select, \"{0}\"", t.Repo ) );
            }
            else
            {
                MessageBox.Show( String.Format( "Could not find repo location: \"{0}\"", t.Repo ) );
            }
        }
    }
}
