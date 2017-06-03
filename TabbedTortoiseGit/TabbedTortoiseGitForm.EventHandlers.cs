using Common;
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
using Tabs;

namespace TabbedTortoiseGit
{
    partial class TabbedTortoiseGitForm
    {
        private static readonly Regex TORTOISE_GIT_COMMAND_LINE_REGEX = new Regex( "/path:\"?(?<repo>.*?)\"? *( /|$)", RegexOptions.IgnoreCase );

        private void InitializeEventHandlers()
        {
            this.Load += TabbedTortoiseGitForm_Load;
            this.ResizeEnd += TabbedTortoiseGitForm_ResizeEnd;
            this.FormClosing += TabbedTortoiseGitForm_FormClosing;
            this.FormClosed += TabbedTortoiseGitForm_FormClosed;

            LogTabs.NewTabClick += LogTabs_NewTabClick;
            LogTabs.TabClosed += LogTabs_TabClosed;
            LogTabs.SelectedIndexChanged += LogTabs_SelectedIndexChanged;

            OpenRepoMenuItem.Click += OpenRepoMenuItem_Click;
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

        private async void TabbedTortoiseGitForm_Load( object sender, EventArgs e )
        {
            UpdateFromSettings( true );

            if( !_startup )
            {
                await OpenStartupRepos();
            }
        }

        private void TabbedTortoiseGitForm_ResizeEnd( object sender, EventArgs e )
        {
            SaveWindowState();
        }

        private void TabbedTortoiseGitForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            LOG.DebugFormat( "FormClosing - Reason: {0}", e.CloseReason );

            if( e.CloseReason == CloseReason.UserClosing )
            {
                if( !this.ConfirmClose() )
                {
                    LOG.Debug( "FormClosing - Cancelled on confirm close" );
                    e.Cancel = true;
                    return;
                }

                if( !Settings.Default.CloseToSystemTray )
                {
                    LOG.Debug( "FormClosing - Exiting application" );
                    Application.Exit();
                }
                else
                {
                    LOG.Debug( "FormClosing - Closing to system tray" );

                    if( !Settings.Default.RetainLogsOnClose )
                    {
                        this.RemoveAllLogs();
                    }
                    
                    e.Cancel = true;
                    this.Hide();
                }
            }

            SaveWindowState();
        }

        private void TabbedTortoiseGitForm_FormClosed( object sender, FormClosedEventArgs e )
        {
            LOG.Debug( "Form Closed" );

            _watcher.Stop();

            RemoveAllLogs();
        }

        private void Process_Exited( object sender, EventArgs e )
        {
            Process p = (Process)sender;

            LOG.DebugFormat( "Process Exited - ID: {0}", p.Id );

            this.BeginInvoke( (Action<Process>)RemoveLog, p );
        }

        private async void LogTabs_NewTabClick( object sender, EventArgs e )
        {
            await FindRepo();
        }

        private void LogTabs_TabClosed( object sender, TabClosedEventArgs e )
        {
            TabTag t = (TabTag)e.Tab.Tag;

            LOG.DebugFormat( "Tab Closed - Repo: {0} - ID: {1}", t.Repo, t.Process.Id );

            RemoveLog( t.Process );
        }

        private void LogTabs_SelectedIndexChanged( object sender, EventArgs e )
        {
            if( LogTabs.SelectedTab != null )
            {
                this.Text = LogTabs.SelectedTab.Text + " - Tabbed TortoiseGit";
            }
            else
            {
                this.Text = "Tabbed TortoiseGit";
            }
        }

        private void Tab_Resize( object sender, EventArgs e )
        {
            if( this.WindowState != FormWindowState.Minimized )
            {
                Tab t = (Tab)sender;
                TabTag tag = (TabTag)t.Tag;
                ResizeTab( tag.Process, t );
            }
        }

        private async void FavoritedRepoMenuItem_Click( object sender, EventArgs e )
        {
            ToolStripItem item = (ToolStripItem)sender;
            String repo = (String)item.Tag;
            await OpenLog( repo );
        }

        private async void OpenRepoMenuItem_Click( object sender, EventArgs e )
        {
            await FindRepo();
        }

        private void SettingsMenuItem_Click( object sender, EventArgs e )
        {
            if( SettingsForm.ShowSettingsDialog() )
            {
                UpdateFromSettings( false );
            }
        }

        private void AboutMenuItem_Click( object sender, EventArgs e )
        {
            AboutBox.ShowAbout();
        }

        private async void RecentRepoMenuItem_Click( object sender, EventArgs e )
        {
            ToolStripItem item = (ToolStripItem)sender;
            await OpenLog( item.Text );
        }

        private void ExitMenuItem_Click( object sender, EventArgs e )
        {
            if( this.ConfirmClose() )
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
            this.BeginInvoke( (Func<Process, String, Task>)AddNewLog, p, repo );
        }

        private async void NotifyIcon_DoubleClick( object sender, EventArgs e )
        {
            this.ShowMe();

            if( Settings.Default.OpenStartupReposOnReOpen
             && !Settings.Default.RetainLogsOnClose )
            {
                await OpenStartupRepos();
            }
        }

        private async void OpenNotifyIconMenuItem_Click( object sender, EventArgs e )
        {
            this.ShowMe();

            if( Settings.Default.OpenStartupReposOnReOpen
             && !Settings.Default.RetainLogsOnClose )
            {
                await OpenStartupRepos();
            }
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
