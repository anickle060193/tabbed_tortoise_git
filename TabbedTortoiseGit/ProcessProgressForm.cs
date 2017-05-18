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
            if( !_canExit )
            {
                e.Cancel = true;
            }
        }

        private void Worker_DoWork( object sender, DoWorkEventArgs e )
        {
            RunProcesses();
        }

        private void Worker_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
        {
            Close.Enabled = true;
            LogOutput( this.CompletedText, Color.Blue );
            _canExit = true;
        }

        private void RunProcesses()
        {
            foreach( Process p in _processes )
            {
                Output.Invoke( (Action<String>)LogOutput, "{0} {1}".XFormat( p.StartInfo.FileName, p.StartInfo.Arguments ) );
                p.Start();
                p.BeginOutputReadLine();
                p.BeginErrorReadLine();
            }

            while( !_processes.All( p => p.HasExited ) )
            {
                Thread.Sleep( 10 );
            }
        }

        private void LogOutput( String output, Color color )
        {
            if( output != null )
            {
                String o = NEWLINE_REGEX.Replace( output, Environment.NewLine ).TrimEnd( '\r', '\n' ) + Environment.NewLine;
                Output.AppendText( o, color );
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
