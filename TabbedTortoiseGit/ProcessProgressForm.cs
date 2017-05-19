using log4net;
using System;
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

namespace TabbedTortoiseGit
{
    public partial class ProcessProgressForm : Form
    {
        private static readonly ILog LOG = LogManager.GetLogger( typeof( ProcessProgressForm ) );

        private static readonly Regex NEWLINE_REGEX = new Regex( "[\r\n]+" );

        private readonly List<Process> _processes = new List<Process>();

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

            _canExit = false;

            this.Shown += ( sender, e ) => Worker.RunWorkerAsync();
            this.FormClosing += ProcessProgressForm_FormClosing;

            Worker.DoWork += Worker_DoWork;
            Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        private void AddProcess( Process p )
        {
            LOG.DebugFormat( "AddProcess - Filename: {0} - Arguments: {1} - Working Directory: {2}", p.StartInfo.FileName, p.StartInfo.Arguments, p.StartInfo.WorkingDirectory );
            _processes.Add( p );

            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.EnableRaisingEvents = true;
            p.OutputDataReceived += Process_OutputDataReceived;
            p.ErrorDataReceived += Process_ErrorDataReceived;
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
            LogOutput( this.CompletedText, Color.Blue );
            _canExit = true;
        }

        private void RunProcesses()
        {
            LOG.DebugFormat( "RunProcesses - Process Count: {0}", _processes.Count );

            foreach( Process p in _processes )
            {
                LOG.DebugFormat( "RunProcesses - Filename: {0} - Arguments: {1} - Working Directory: {2}", p.StartInfo.FileName, p.StartInfo.Arguments, p.StartInfo.WorkingDirectory );
                Output.Invoke( (Action<String>)LogOutput, "{0} {1}".XFormat( p.StartInfo.FileName, p.StartInfo.Arguments ) );
                p.Start();
                p.BeginOutputReadLine();
                p.BeginErrorReadLine();
            }

            LOG.Debug( "RunProcesses - Start Wait for All HasExited" );
            while( !_processes.All( p => p.HasExited ) )
            {
                Thread.Sleep( 10 );
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
    }
}
