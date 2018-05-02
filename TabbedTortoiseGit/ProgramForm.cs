using Common;
using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
    class ProgramForm : Form
    {
        public static readonly int WM_SHOWME = Native.RegisterWindowMessage( "{86ebc75b-fc1b-4370-86bb-2a5daaa51e78}" );

        private static readonly ILog LOG = LogManager.GetLogger( typeof( ProgramForm ) );

        private static readonly String TORTOISE_GIT_EVENT_QUERY = @"TargetInstance ISA 'Win32_Process' 
                                                                AND TargetInstance.Name = 'TortoiseGitProc.exe'
                                                                AND ( TargetInstance.CommandLine LIKE '%/command:log%'
                                                                   OR TargetInstance.CommandLine LIKE '%/command log%'
                                                                   OR TargetInstance.CommandLine LIKE '%-command:log%'
                                                                   OR TargetInstance.CommandLine LIKE '%-command log%' )";
        private static readonly String TORTOISE_GIT_QUERY = @"SELECT *
                                                              FROM Win32_Process
                                                              WHERE Name = 'TortoiseGitProc.exe'
                                                                AND ( CommandLine LIKE '%/command:log%'
                                                                   OR CommandLine LIKE '%/command log%'
                                                                   OR CommandLine LIKE '%-command:log%'
                                                                   OR CommandLine LIKE '%-command log%' )";
        private static readonly Regex TORTOISE_GIT_COMMAND_LINE_REGEX = new Regex( @"(/|-)path:?\s*""?(?<path>.+?)""? *( /|$)", RegexOptions.IgnoreCase );

        private readonly List<TabbedTortoiseGitForm> _forms = new List<TabbedTortoiseGitForm>();
        private readonly HashSet<int> _capturedLogs = new HashSet<int>();
        private readonly ManagementEventWatcher _watcher;
        private readonly NotifyIcon _notifyIcon;
        private readonly Timer _watcherTimer;
        private readonly bool _startup;

        private TabbedTortoiseGitForm _activeForm;

        public static ProgramForm Instance { get; private set; }

        public static ProgramForm Create( bool startup )
        {
            if( Instance == null )
            {
                Instance = new ProgramForm( startup );
            }
            return Instance;
        }

        private ProgramForm( bool startup )
        {
            _startup = startup;

            _watcher = new ManagementEventWatcher( new WqlEventQuery( "__InstanceCreationEvent", new TimeSpan( 10 ), TORTOISE_GIT_EVENT_QUERY ) );
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

            _watcherTimer = new Timer();
            _watcherTimer.Interval = 1000;
            _watcherTimer.Tick += WatcherTimer_Tick;
            _watcherTimer.Start();

            this.FormClosing += ProgramForm_FormClosing;

            this.CreateHandle();
        }

        public void CreateNewFromTab( Tab tab, Point location )
        {
            TabbedTortoiseGitForm form = CreateNewTabbedTortoiseGit( false, location );
            form.AddExistingTab( tab );
        }

        protected override void WndProc( ref Message m )
        {
            if( m.Msg == WM_SHOWME )
            {
                CreateNewTabbedTortoiseGit( true, Point.Empty );
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
            KeyboardShortcutsManager.Create( this.Handle );
            KeyboardShortcutsManager.Instance.KeyboardShortcutPressed += KeyboardShortcutsManager_KeyboardShortcutPressed;

            if( !_startup )
            {
                CreateNewTabbedTortoiseGit( Settings.Default.OpenStartupReposOnReOpen, Point.Empty );
            }
        }

        protected override void Dispose( bool disposing )
        {
            base.Dispose( disposing );

            if( disposing )
            {
                _notifyIcon.Icon = null;
                _notifyIcon.Visible = false;
                _notifyIcon.Dispose();

                _watcher.Dispose();

                _watcherTimer.Stop();
                _watcherTimer.Dispose();
            }
        }

        private TabbedTortoiseGitForm CreateNewTabbedTortoiseGit( bool showStartUpRepos, Point createdAtPoint )
        {
            TabbedTortoiseGitForm form = new TabbedTortoiseGitForm( showStartUpRepos, createdAtPoint );
            form.FormClosed += TabbedTortoiseGitForm_FormClosed;
            form.Activated += TabbedTortoiseGitForm_Activated;

            _forms.Add( form );
            _activeForm = form;
            form.Show();

            return form;
        }

        private void ShowLastTabbedTortoiseGit()
        {
            if( _activeForm == null )
            {
                CreateNewTabbedTortoiseGit( Settings.Default.OpenStartupReposOnReOpen, Point.Empty );
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
                CreateNewTabbedTortoiseGit( false, Point.Empty );
            }
            await _activeForm.AddNewLogProcess( p, repo );
        }

        private bool CheckTortoiseGitProcessObject( ManagementBaseObject o )
        {
            String commandLine = (String)o[ "CommandLine" ];
            Match m = TORTOISE_GIT_COMMAND_LINE_REGEX.Match( commandLine );
            String path = m.Groups[ "path" ].Value;
            int pid = (int)(UInt32)o[ "ProcessId" ];
            Process p = Process.GetProcessById( pid );

            lock( _capturedLogs )
            {
                if( _capturedLogs.Contains( pid ) )
                {
                    return false;
                }

                _capturedLogs.Add( pid );

                p.Exited += LogProcess_Exited;
            }

            if( _forms.Any( form => form.OwnsLogProcess( p ) ) )
            {
                return false;
            }

            LOG.DebugFormat( "CheckObject - New Process found - PID: {0}", p.Id );

            this.UiBeginInvoke( (Func<Process, String, Task>)CaptureNewLog, p, path );

            return true;
        }

        private void LogProcess_Exited( object sender, EventArgs e )
        {
            lock( _capturedLogs )
            {
                Process p = sender as Process;
                _capturedLogs.Remove( p.Id );
            }
        }

        private void KeyboardShortcutsManager_KeyboardShortcutPressed( object sender, KeyboardShortcutPressedEventArgs e )
        {
            LOG.DebugFormat( "KeyboardShortcutPressed - KeyboardShortcut: {0}", e.KeyboardShortcut );
            
            if( _activeForm == null )
            {
                LOG.Error( "KeyboardShortcut received but there is no active form" );
                return;
            }

            _activeForm.HandleKeyboardShortcut( e.KeyboardShortcut );
        }

        private void ProgramForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            LOG.DebugFormat( "ProgramForm_FormClosing - Close Reason: {0}", e.CloseReason );

            _watcher.Stop();
            _watcherTimer.Stop();

            KeyboardShortcutsManager.Instance.Dispose();
        }

        private void Watcher_EventArrived( object sender, EventArrivedEventArgs e )
        {
            ManagementBaseObject o = (ManagementBaseObject)e.NewEvent[ "TargetInstance" ];
            LOG.DebugFormat( "Watcher_EventArrived - Object: {0}", o.GetText( TextFormat.Mof ) );

            CheckTortoiseGitProcessObject( o );
        }

        private void WatcherTimer_Tick( object sender, EventArgs e )
        {
            var searcher = new ManagementObjectSearcher( TORTOISE_GIT_QUERY );
            foreach( ManagementBaseObject o in searcher.Get() )
            {
                if( CheckTortoiseGitProcessObject( o ) )
                {
                    LOG.DebugFormat( "WatcherTimer_Tick - Process found by WatcherTimer - PID: {0}", o[ "ProcessId" ] );

                    _watcher.Stop();
                    _watcher.Start();
                }
            }
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
