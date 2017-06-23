using Common;
using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TabbedTortoiseGit.Properties;

namespace TabbedTortoiseGit
{
    class ProgramForm : Form
    {
        public static readonly int WM_SHOWME = Native.RegisterWindowMessage( "{86ebc75b-fc1b-4370-86bb-2a5daaa51e78}" );

        private static readonly ILog LOG = LogManager.GetLogger( typeof( ProgramForm ) );

        private static readonly Regex TORTOISE_GIT_COMMAND_LINE_REGEX = new Regex( "/path:\"?(?<repo>.*?)\"? *( /|$)", RegexOptions.IgnoreCase );

        private readonly List<TabbedTortoiseGitForm> _forms = new List<TabbedTortoiseGitForm>();
        private readonly ManagementEventWatcher _watcher;
        private readonly NotifyIcon _notifyIcon;

        private TabbedTortoiseGitForm _activeForm;

        public ProgramForm( bool startup )
        {
            String condition = "TargetInstance ISA 'Win32_Process'" +
                           "AND TargetInstance.Name = 'TortoiseGitProc.exe'" +
                           "AND TargetInstance.CommandLine LIKE '%/command:log%'";
            _watcher = new ManagementEventWatcher( new WqlEventQuery( "__InstanceCreationEvent", new TimeSpan( 10 ), condition ) );
            _watcher.Options.Timeout = new TimeSpan( 0, 1, 0 );
            _watcher.EventArrived += Watcher_EventArrived;
            _watcher.Start();

            _notifyIcon = new NotifyIcon();
            _notifyIcon.Text = "Tabbed TortoiseGit";
            _notifyIcon.Icon = Resources.TortoiseIcon;
            _notifyIcon.Visible = true;
            _notifyIcon.DoubleClick += NotifyIcon_DoubleClick;
            _notifyIcon.ContextMenuStrip = new ContextMenuStrip();

            ToolStripItem openItem = _notifyIcon.ContextMenuStrip.Items.Add( "Open" );
            openItem.Click += OpenNotifyIconMenuItem_Click;
            ToolStripItem exitItem = _notifyIcon.ContextMenuStrip.Items.Add( "Exit" );
            exitItem.Click += ExitNotifyIconMenuItem_Click;

            this.FormClosing += ProgramForm_FormClosing;

            this.CreateHandle();

            CreateNewTabbedTortoiseGit( !startup );
        }

        protected override void WndProc( ref Message m )
        {
            if( m.Msg == WM_SHOWME )
            {
                CreateNewTabbedTortoiseGit( true );
            }
            else
            {
                base.WndProc( ref m );
            }
        }

        protected override void SetVisibleCore( bool value )
        {
            base.SetVisibleCore( false );
        }

        protected override void OnHandleCreated( EventArgs e )
        {
            base.OnHandleCreated( e );

            Native.SetParent( this.Handle, Native.HWND_MESSAGE );
        }

        private void CreateNewTabbedTortoiseGit( bool showStartUpRepos )
        {
            TabbedTortoiseGitForm form = new TabbedTortoiseGitForm( showStartUpRepos );
            form.FormClosed += TabbedTortoiseGitForm_FormClosed;
            form.Activated += TabbedTortoiseGitForm_Activated;

            _forms.Add( form );
            _activeForm = form;
            form.Show();
        }

        private void ShowLastTabbedTortoiseGit()
        {
            if( _activeForm == null )
            {
                CreateNewTabbedTortoiseGit( Settings.Default.OpenStartupReposOnReOpen );
            }

            if( _activeForm.WindowState == FormWindowState.Minimized )
            {
                _activeForm.WindowState = FormWindowState.Normal;
            }

            _activeForm.Show();
        }

        private async Task CaptureNewLog( Process p, String repo )
        {
            if( _activeForm == null )
            {
                LOG.Debug( "CaptureNewLog - No active form" );
                CreateNewTabbedTortoiseGit( false );
            }
            await _activeForm.AddNewLog( p, repo );
        }

        private void ProgramForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            LOG.DebugFormat( "ProgramForm_FormClosing - Close Reason: {0}", e.CloseReason );

            _watcher.Stop();
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

            if( _forms.Any( form => form.OwnsLog( p ) ) )
            {
                LOG.DebugFormat( "Watcher_EventArrived - Log opened by child - PID: {0}", p.Id );
                return;
            }

            this.UiBeginInvoke( (Func<Process, String, Task>)CaptureNewLog, p, repo );
        }

        private void NotifyIcon_DoubleClick( object sender, EventArgs e )
        {
            ShowLastTabbedTortoiseGit();
        }

        private void OpenNotifyIconMenuItem_Click( object sender, EventArgs e )
        {
            ShowLastTabbedTortoiseGit();
        }

        private void ExitNotifyIconMenuItem_Click( object sender, EventArgs e )
        {
            Application.Exit();
        }

        private void TabbedTortoiseGitForm_FormClosed( object sender, FormClosedEventArgs e )
        {
            TabbedTortoiseGitForm form = (TabbedTortoiseGitForm)sender;
            _forms.Remove( form );
            if( form == _activeForm )
            {
                _activeForm = _forms.LastOrDefault();
            }

            if( _forms.Count == 0 )
            {
                if( !Settings.Default.CloseToSystemTray )
                {
                    Application.Exit();
                }
            }
        }

        private void TabbedTortoiseGitForm_Activated( object sender, EventArgs e )
        {
            TabbedTortoiseGitForm form = (TabbedTortoiseGitForm)sender;
            _forms.Remove( form );
            _forms.Add( form );
            _activeForm = form;
        }
    }
}
