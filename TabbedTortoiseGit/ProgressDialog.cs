using Common;
using log4net;
using System;
using System.Collections.Concurrent;
using System.Collections.Immutable;
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
    public partial class ProgressDialog : Form
    {
        private static readonly ILog LOG = LogManager.GetLogger( typeof( ProgressDialog ) );

        private static readonly Regex NEWLINE_REGEX = new Regex( "[\r\n]+" );

        private readonly ConcurrentQueue<ProgressTask> _tasks = new ConcurrentQueue<ProgressTask>();
        private readonly ConcurrentDictionary<ProgressTask, byte> _runningTasks = new ConcurrentDictionary<ProgressTask, byte>();

        private bool _started;
        private DateTime _start;
        private bool _cancel;
        private bool _completed;

        public String Title
        {
            set
            {
                this.Text = value;
            }

            get
            {
                return this.Text;
            }
        }

        public String CompletedText { get; set; }
        public int MaxTasks { get; set; }
        public Color CommandTextColor { get; set; }
        public Color ErrorTextColor { get; set; }
        public Color CompletedTextColor { get; set; }
        public Color CancelledTextColor { get; set; }

        public ProgressDialog()
        {
            InitializeComponent();
            this.Icon = Resources.TortoiseIcon;

            MaxTasks = 6;

            CommandTextColor = Color.Green;
            ErrorTextColor = Color.DarkRed;
            CompletedTextColor = Color.Blue;
            CancelledTextColor = Color.DarkBlue;

            _started = false;
            _cancel = false;

            this.FormClosing += ProgressDialog_FormClosing;

            Cancel.Click += Cancel_Click;

            ElapsedUpdateTimer.Tick += ElapsedUpdateTimer_Tick;

            Worker.DoWork += Worker_DoWork;
            Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        public void AddTasks( IEnumerable<ProgressTask> tasks )
        {
            foreach( ProgressTask t in tasks )
            {
                AddTask( t );
            }
        }

        public void AddTask( ProgressTask task )
        {
            LOG.DebugFormat( "AddTask - {0}", task.Description );
            _tasks.Enqueue( task );

            task.OutputReceived += Task_OutputReceived;
            task.ErrorOutputReceived += Task_ErrorOutputReceived;
            task.ProgressCompleted += Task_ProgressCompleted;

            ProgressBar.UiBeginInvoke( (Action)( () => ProgressBar.Maximum++ ) );
        }

        public void DoProgress()
        {
            if( _started )
            {
                throw new InvalidOperationException( "Progress has already been started" );
            }

            if( !_cancel )
            {
                this.Show();
                _started = true;
                _start = DateTime.Now;
                ElapsedUpdateTimer.Start();
                Worker.RunWorkerAsync();
            }
        }

        private void Cancel_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        private void ProgressDialog_FormClosing( object sender, FormClosingEventArgs e )
        {
            LOG.Debug( "Form Closing" );

            if( _started
             && !_completed )
            {
                LOG.Debug( "Form Closing - Not Completed, Cancelling Tasks" );
                this.CancelTasks();
                e.Cancel = true;
            }
            else
            {
                _cancel = true;
            }
        }

        private void ElapsedUpdateTimer_Tick( object sender, EventArgs e )
        {
            ElapsedTime.Text = ( DateTime.Now - _start ).TotalSeconds.ToString( "0.00 seconds" );
        }

        private void Worker_DoWork( object sender, DoWorkEventArgs e )
        {
            LOG.Debug( "Worker - Do Work" );
            RunTasks();
        }

        private void Worker_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
        {
            LOG.DebugFormat( "Worker - Work Completed - Elapsed Time: {0}", DateTime.Now - _start );

            _completed = true;

            ElapsedUpdateTimer.Stop();

            if( !_cancel )
            {
                LogOutput( Environment.NewLine + this.CompletedText, CompletedTextColor );
            }
            else
            {
                LogOutput( Environment.NewLine + "Cancelled", CancelledTextColor );
            }
            Cancel.Text = "Close";
            Cancel.Enabled = true;
        }

        private void CancelTasks()
        {
            if( !_cancel )
            {
                _cancel = true;
                Cancel.Enabled = false;
                Cancel.Text = "Cancelling...";
                LogOutput( "Cancelling! Waiting on remaining tasks to finish...", CancelledTextColor );

                foreach( ProgressTask task in _runningTasks.Keys )
                {
                    task.Cancel();
                }
            }
        }

        private void RunTasks()
        {
            LOG.DebugFormat( "RunTasks - Task Count: {0}", _tasks.Count );

            while( !_cancel && ( !_tasks.IsEmpty || !_runningTasks.IsEmpty ) )
            {
                if( _runningTasks.Count < this.MaxTasks && !_tasks.IsEmpty )
                {
                    ProgressTask t;
                    if( _tasks.TryDequeue( out t ) )
                    {
                        LOG.DebugFormat( "RunTasks - {0}", t.Description );
                        String initialOutput = t.InitialOutput;
                        if( !String.IsNullOrWhiteSpace( initialOutput ) )
                        {
                            Output.UiBeginInvoke( (Action<String, Color>)LogOutput, initialOutput, CommandTextColor );
                        }
                        _runningTasks[ t ] = 0;
                        t.StartProgress();
                    }
                    else
                    {
                        LOG.ErrorFormat( "RunTasks - Failed to dequeue task - Count: {0}", _tasks.Count );
                    }
                }
                else
                {
                    Thread.Sleep( 20 );
                }
            }

            if( _cancel )
            {
                LOG.Debug( "RunTasks - Waiting for cancelled tasks to complete" );
                while( !_runningTasks.IsEmpty )
                {
                    Thread.Sleep( 20 );
                }
                LOG.Debug( "RunTasks - Cancelled tasks completed" );
            }

            LOG.Debug( "RunTasks - Completed" );
        }

        private void LogOutput( String output, Color color )
        {
            if( output != null )
            {
                String o = NEWLINE_REGEX.Replace( output, Environment.NewLine ).TrimEnd( '\r', '\n' ) + Environment.NewLine;
                Output.AppendText( o, color );
                Output.SelectionStart = Output.Text.Length;
                Output.ScrollToCaret();
            }
        }

        private void LogOutput( String output )
        {
            LogOutput( output, Output.ForeColor );
        }

        private void Task_OutputReceived( object sender, OutputEventArgs e )
        {
            Output.UiBeginInvoke( (Action<String>)LogOutput, e.Output );
        }

        private void Task_ErrorOutputReceived( object sender, OutputEventArgs e )
        {
            Output.UiBeginInvoke( (Action<String, Color>)LogOutput, e.Output, ErrorTextColor );
        }

        private void Task_ProgressCompleted( object sender, ProgressCompletedEventArgs e )
        {
            ProgressTask t = (ProgressTask)sender;

            this.AddTasks( e.AdditionalTasks );

            byte removed;
            if( !_runningTasks.TryRemove( t, out removed ) )
            {
                LOG.ErrorFormat( "Task_ProgressCompleted - Failed to remove running task - {0}", t.Description );
            }
            ProgressBar.UiBeginInvoke( (Action)ProgressBar.PerformStep );
        }
    }

    public class OutputEventArgs : EventArgs
    {
        public String Output { get; private set; }

        public OutputEventArgs( String output )
        {
            Output = output;
        }
    }

    public class ProgressCompletedEventArgs : EventArgs
    {
        private static readonly ProgressCompletedEventArgs _empty = new ProgressCompletedEventArgs( Enumerable.Empty<ProgressTask>() );
        public static new ProgressCompletedEventArgs Empty
        {
            get
            {
                return _empty;
            }
        }

        public ImmutableList<ProgressTask> AdditionalTasks { get; private set; }

        public ProgressCompletedEventArgs( IEnumerable<ProgressTask> additionalTasks )
        {
            AdditionalTasks = ImmutableList.CreateRange( additionalTasks );
        }
    }

    public abstract class ProgressTask
    {
        public event EventHandler<OutputEventArgs> OutputReceived;
        public event EventHandler<OutputEventArgs> ErrorOutputReceived;
        public event EventHandler<ProgressCompletedEventArgs> ProgressCompleted;

        public abstract String InitialOutput { get; }
        public abstract String Description { get; }

        protected void OnOutputReceived( OutputEventArgs e )
        {
            OutputReceived?.Invoke( this, e );
        }

        protected void Output( String output )
        {
            OnOutputReceived( new OutputEventArgs( output ) );
        }

        protected void OnErrorReceived( OutputEventArgs e )
        {
            ErrorOutputReceived?.Invoke( this, e );
        }

        protected void Error( String output )
        {
            OnErrorReceived( new OutputEventArgs( output ) );
        }

        protected void OnProgressCompleted( ProgressCompletedEventArgs e )
        {
            ProgressCompleted?.Invoke( this, e );
        }

        public abstract void StartProgress();
        public abstract void Cancel();
    }

    public class ProcessProgressTask : ProgressTask
    {
        public Process Process { get; private set; }

        public override string InitialOutput
        {
            get
            {
                return "{0} {1}".XFormat( this.Process.StartInfo.FileName, this.Process.StartInfo.Arguments );
            }
        }

        public override string Description
        {
            get
            {
                String fileName = this.Process.StartInfo.FileName;
                String arguments = this.Process.StartInfo.Arguments;
                String workingDirectory = this.Process.StartInfo.WorkingDirectory;
                return "Filename: {0} - Arguments: {1} - Working Directory: {2}".XFormat( fileName, arguments, workingDirectory );
            }
        }

        public ProcessProgressTask( Process p )
        {
            Process = p;
        }

        private void Process_OutputDataReceived( object sender, DataReceivedEventArgs e )
        {
            Output( e.Data );
        }

        private void Process_ErrorDataReceived( object sender, DataReceivedEventArgs e )
        {
            Error( e.Data );
        }

        private void Process_Exited( object sender, EventArgs e )
        {
            OnProgressCompleted( ProgressCompletedEventArgs.Empty );
        }

        public override void StartProgress()
        {
            this.Process.StartInfo.RedirectStandardOutput = true;
            this.Process.StartInfo.RedirectStandardError = true;
            this.Process.StartInfo.CreateNoWindow = true;
            this.Process.StartInfo.UseShellExecute = false;
            this.Process.EnableRaisingEvents = true;
            this.Process.OutputDataReceived += Process_OutputDataReceived;
            this.Process.ErrorDataReceived += Process_ErrorDataReceived;
            this.Process.Exited += Process_Exited;

            this.Process.Start();

            this.Process.BeginOutputReadLine();
            this.Process.BeginErrorReadLine();
        }

        public override void Cancel()
        {
        }
    }
}
