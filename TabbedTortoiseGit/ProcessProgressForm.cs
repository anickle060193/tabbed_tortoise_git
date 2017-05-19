using log4net;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TabbedTortoiseGit.Properties;

namespace TabbedTortoiseGit
{
    public partial class ProcessProgressForm : Form
    {
        private static readonly ILog LOG = LogManager.GetLogger( typeof( ProcessProgressForm ) );

        private static readonly Regex NEWLINE_REGEX = new Regex( "[\r\n]+" );

        private readonly ConcurrentQueue<Process> _processes = new ConcurrentQueue<Process>();
        private readonly ConcurrentDictionary<int, Process> _runningProcesses = new ConcurrentDictionary<int, Process>();

        private bool _canExit;

        public String Title
        {
            set
            {
                this.Text = value;
            }
        }

        public String CompletedText { get; set; }

        public static void ShowProgress( String title, String completedText, IEnumerable<Process> processes )
        {
            LOG.DebugFormat( "ShowProgress - Title: {0} - Completed Text: {1}", title, completedText );
            ProcessProgressForm f = new ProcessProgressForm();
            f.Title = title;
            f.CompletedText = completedText;
            foreach( Process p in processes )
            {
                f.AddProcess( p );
            }
            f.ShowDialog();
        }

        private ProcessProgressForm()
        {
            InitializeComponent();
            this.Icon = Resources.TortoiseIcon;

            _canExit = false;

            this.Shown += ( sender, e ) => Worker.RunWorkerAsync();
            this.FormClosing += ProcessProgressForm_FormClosing;

            Worker.DoWork += Worker_DoWork;
            Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        private void AddProcess( Process p )
        {
            LOG.DebugFormat( "AddProcess - Filename: {0} - Arguments: {1} - Working Directory: {2}", p.StartInfo.FileName, p.StartInfo.Arguments, p.StartInfo.WorkingDirectory );
            _processes.Enqueue( p );

            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.EnableRaisingEvents = true;
            p.OutputDataReceived += Process_OutputDataReceived;
            p.ErrorDataReceived += Process_ErrorDataReceived;
            p.Exited += Process_Exited;
        }

        private void ProcessProgressForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            LOG.Debug( "Form Closing" );
            if( !_canExit )
            {
                LOG.Debug( "Form Closing - Cancelled" );
                e.Cancel = true;
            }
        }

        private void Worker_DoWork( object sender, DoWorkEventArgs e )
        {
            LOG.Debug( "Worker - Do Work" );
            RunProcesses();
        }

        private void Worker_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
        {
            LOG.Debug( "Worker - Work Completed" );
            CloseButton.Enabled = true;
            LogOutput( Environment.NewLine + this.CompletedText, Color.Blue );
            _canExit = true;
        }

        private void RunProcesses()
        {
            LOG.DebugFormat( "RunProcesses - Process Count: {0}", _processes.Count );

            while( !_processes.IsEmpty )
            {
                while( _runningProcesses.Count >= 6 )
                {
                    Thread.Sleep( 50 );
                }
                Process p;
                if( _processes.TryDequeue( out p ) )
                {
                    LOG.DebugFormat( "RunProcesses - Filename: {0} - Arguments: {1} - Working Directory: {2}", p.StartInfo.FileName, p.StartInfo.Arguments, p.StartInfo.WorkingDirectory );
                    Output.Invoke( (Action<String, Color>)LogOutput, "{0} {1}".XFormat( p.StartInfo.FileName, p.StartInfo.Arguments ), Color.Green );
                    p.Start();
                    _runningProcesses[ p.Id ] = p;
                    p.BeginOutputReadLine();
                    p.BeginErrorReadLine();
                }
                else
                {
                    LOG.ErrorFormat( "RunProcesses - Failed to dequeue process - Count: {0}", _processes.Count );
                }
            }

            LOG.Debug( "RunProcesses - Start Wait for All HasExited" );
            while( !_runningProcesses.IsEmpty )
            {
                Thread.Sleep( 50 );
            }
            LOG.Debug( "RunProcesses - End Wait for All HasExited" );
        }

        private void LogOutput( String output, Color color )
        {
            if( output != null )
            {
                String o = NEWLINE_REGEX.Replace( output, Environment.NewLine ).TrimEnd( '\r', '\n' ) + Environment.NewLine;
                Output.AppendText( o, color );
                Output.SelectionStart = Output.TextLength;
                Output.SelectionLength = 0;
            }
        }

        private void LogOutput( String output )
        {
            LogOutput( output, Output.ForeColor );
        }

        private void Process_OutputDataReceived( object sender, DataReceivedEventArgs e )
        {
            Output.Invoke( (Action<String>)LogOutput, e.Data );
        }

        private void Process_ErrorDataReceived( object sender, DataReceivedEventArgs e )
        {
            Output.Invoke( (Action<String, Color>)LogOutput, e.Data, Color.Red );
        }

        private void Process_Exited( object sender, EventArgs e )
        {
            Process p = (Process)sender;
            Process removed;
            if( !_runningProcesses.TryRemove( p.Id, out removed ) )
            {
                LOG.ErrorFormat( "Process_Exited - Failed to remove running process - Process ID: {0}", p.Id );
            }
        }
    }
}
