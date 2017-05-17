using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;
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
            this.ResizeEnd += TabbedTortoiseGitForm_ResizeEnd;
            this.FormClosing += TabbedTortoiseGitForm_FormClosing;
            this.FormClosed += TabbedTortoiseGitForm_FormClosed;
            this.Disposed += TabbedTortoiseGitForm_Disposed;

            LogTabs.NewTabClicked += LogTabs_NewTabClicked;
            LogTabs.TabClosed += LogTabs_TabClosed;
            LogTabs.Selected += LogTabs_Selected;

            OpenRepoMenuItem.Click += OpenRepoMenuItem_Click;
            OpenLogFileLocationMenuItem.Click += OpenLogFileLocationMenuItem_Click;
            SettingsMenuItem.Click += SettingsMenuItem_Click;
            AboutMenuItem.Click += AboutMenuItem_Click;
            ExitMenuItem.Click += ExitMenuItem_Click;

            TabContextMenu.Opening += TabContextMenu_Opening;

            OpenRepoLocationTabMenuItem.Click += OpenRepoLocationTabMenuItem_Click;
            FavoriteRepoTabMenuItem.Click += FavoriteRepoTabMenuItem_Click;
            CloseRepoTabMenuItem.Click += CloseRepoTabMenuItem_Click;

            NotifyIcon.DoubleClick += NotifyIcon_DoubleClick;
            OpenNotifyIconMenuItem.Click += OpenNotifyIconMenuItem_Click;
            ExitNotifyIconMenuItem.Click += ExitMenuItem_Click;
        }

        private void TabbedTortoiseGitForm_Load( object sender, EventArgs e )
        {
            if( Settings.Default.UpgradeRequired )
            {
                Settings.Default.Upgrade();
                Settings.Default.UpgradeRequired = false;
                Settings.Default.Save();
            }

            UpdateFromSettings();

            OpenDefaultRepos();
        }

        private void TabbedTortoiseGitForm_ResizeEnd( object sender, EventArgs e )
        {
            SaveWindowState();
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

            SaveWindowState();
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
            RemoveLog( (Process)sender );
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
            ResizeTab( tag.Process, t );
        }

        private void FavoritedRepoMenuItem_Click( object sender, EventArgs e )
        {
            ToolStripItem item = (ToolStripItem)sender;
            String repo = (String)item.Tag;
            OpenLog( repo );
        }

        private void OpenRepoMenuItem_Click( object sender, EventArgs e )
        {
            FindRepo();
        }

        private void OpenLogFileLocationMenuItem_Click( object sender, EventArgs e )
        {
            FileAppender rootAppender = ( (Hierarchy)LogManager.GetRepository() )
                                         .Root.Appenders.OfType<FileAppender>()
                                         .FirstOrDefault();
            if( rootAppender != null )
            {
                Util.OpenInExplorer( rootAppender.File );
            }
        }

        private void SettingsMenuItem_Click( object sender, EventArgs e )
        {
            if( SettingsForm.ShowSettingsDialog() )
            {
                UpdateRecentReposFromSettings();
                UpdateTabMenuFromSettings();
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
            if( Settings.Default.ConfirmOnClose )
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
                        Application.Exit();
                    }
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void Watcher_EventArrived( object sender, EventArrivedEventArgs e )
        {
            ManagementBaseObject o = (ManagementBaseObject)e.NewEvent[ "TargetInstance" ];
            String commandLine = (String)o[ "CommandLine" ];
            Match m = TORTOISE_GIT_COMMAND_LINE_REGEX.Match( commandLine );
            String repo = m.Groups[ "repo" ].Value;
            int pid = (int)(UInt32)o[ "ProcessId" ];
            LOG.DebugFormat( "Watcher_EventArrived - CommandLine: {0} - Repo: {1} - PID: {2}", commandLine, repo, pid );
            Process p = Process.GetProcessById( pid );
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

        private void TabContextMenu_Opening( object sender, System.ComponentModel.CancelEventArgs e )
        {
            TabTag t = (TabTag)LogTabs.SelectedTab.Tag;
            FavoriteRepoTabMenuItem.Checked = IsFavoriteRepo( t.Repo );
        }

        private void OpenRepoLocationTabMenuItem_Click( object sender, EventArgs e )
        {
            TabTag t = (TabTag)LogTabs.SelectedTab.Tag;
            Util.OpenInExplorer( t.Repo );
        }

        private void FavoriteRepoTabMenuItem_Click( object sender, EventArgs e )
        {
            TabTag t = (TabTag)LogTabs.SelectedTab.Tag;

            if( FavoriteRepoTabMenuItem.Checked )
            {
                RemoveFavoriteRepo( t.Repo );
            }
            else
            {
                bool added = false;
                String name = null;
                while( !added )
                {
                    name = InputDialog.ShowInput( "Favorite Repo Name", "Name for \"{0}\"".XFormat( t.Repo ), name );
                    if( name == null )
                    {
                        break;
                    }
                    else if( !String.IsNullOrWhiteSpace( name ) )
                    {
                        if( AddFavoriteRepo( name, t.Repo ) )
                        {
                            FavoriteRepoTabMenuItem.Checked = true;
                            added = true;
                        }
                    }
                }
            }
        }

        private void CloseRepoTabMenuItem_Click( object sender, EventArgs e )
        {
            TabTag t = (TabTag)LogTabs.SelectedTab.Tag;
            this.RemoveLog( t.Process );
            this.EndProcess( t.Process );
        }

        private void GitCommandMenuItem_Click( object sender, EventArgs e )
        {
            ToolStripItem c = (ToolStripItem)sender;
            TortoiseGitCommandFunc func = (TortoiseGitCommandFunc)c.Tag;

            TabTag tag = (TabTag)LogTabs.SelectedTab.Tag;
            func.Invoke( tag.Repo );
        }
    }
}
