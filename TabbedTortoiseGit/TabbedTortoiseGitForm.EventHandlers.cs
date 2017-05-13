using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TabbedTortoiseGit.Properties;

namespace TabbedTortoiseGit
{
    partial class TabbedTortoiseGitForm
    {
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
            ExitMenuItem.Click += ExitMenuItem_Click;

            NotifyIcon.DoubleClick += NotifyIcon_DoubleClick;
            OpenNotifyIconMenuItem.Click += OpenNotifyIconMenuItem_Click;
            ExitNotifyIconMenuItem.Click += ExitMenuItem_Click;
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
            Process p = (Process)e.Tab.Tag;

            EndProcess( p );
            _processes.Remove( p );
            _tabs.Remove( p.Id );
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
            Process p = (Process)t.Tag;

            Native.ResizeToParent( p.MainWindowHandle, t );
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
            Process p = Process.GetProcessById( (int)(UInt32)o[ "ProcessId" ] );
            LogTabs.Invoke( (Func<Process, Task>)AddNewProcess, p );
        }

        private void NotifyIcon_DoubleClick( object sender, EventArgs e )
        {
            this.ShowMe();
        }

        private void OpenNotifyIconMenuItem_Click( object sender, EventArgs e )
        {
            this.ShowMe();
        }
    }
}
