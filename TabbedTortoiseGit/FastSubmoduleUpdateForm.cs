using LibGit2Sharp;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TabbedTortoiseGit.Properties;

namespace TabbedTortoiseGit
{
    public partial class FastSubmoduleUpdateForm : Form
    {
        private static readonly ILog LOG = LogManager.GetLogger( typeof( FastSubmoduleUpdateForm ) );

        public String Repo { get; private set; }

        private readonly Repository _repo;

        public static void UpdateSubmodules( String repo )
        {
            FastSubmoduleUpdateForm f = new FastSubmoduleUpdateForm( repo );
            f.ShowDialog();
        }

        private FastSubmoduleUpdateForm( String repo )
        {
            InitializeComponent();
            UpdateFromSettings();

            this.Icon = Resources.TortoiseIcon;

            Repo = repo;
            _repo = new Repository( repo );

            foreach( Submodule s in _repo.Submodules )
            {
                LOG.DebugFormat( "Submodule - {0}", s.Path );
                SubmoduleCheckList.Items.Add( s.Path );
            }

            SetChecked( true );

            Cancel.Click += ( sender, e ) => this.Close();
            UpdateSubmodulesButton.Click += UpdateSubmodulesButton_Click;
            SelectModifiedSubmodules.Click += SelectModifiedSubmodules_Click;
            SelectAllSubmodules.Click += ( sender, e ) => SetChecked( true );
            SelectNoneSubmodules.Click += ( sender, e ) => SetChecked( false );

            this.Disposed += ( sender, e ) => _repo.Dispose();
        }

        private async void SelectModifiedSubmodules_Click( object sender, EventArgs e )
        {
            LOG.DebugFormat( "Select Modified Submodules - Repo: {0}", Repo );
            String previousText = SelectModifiedSubmodules.Text;
            SelectModifiedSubmodules.Enabled = false;
            SelectModifiedSubmodules.Text = "Getting submodule status...";

            UpdateSubmodulesButton.Enabled = false;
            SelectAllSubmodules.Enabled = false;
            SelectNoneSubmodules.Enabled = false;

            try
            {
                LOG.Debug( "Select Modified Submodules - Get Modified Submodules - Start" );
                List<String> modifiedSubmodules = await Git.GetModifiedSubmodules( Repo );
                LOG.Debug( "Select Modified Submodules - Get Modified Submodules - End" );

                SetChecked( false );

                foreach( String submodule in modifiedSubmodules )
                {
                    int index = SubmoduleCheckList.Items.IndexOf( submodule );
                    if( index != ListBox.NoMatches )
                    {
                        LOG.DebugFormat( "Select Modified Submodules - Modified Submodule: {0}", submodule );
                        SubmoduleCheckList.SetItemChecked( index, true );
                    }
                    else
                    {
                        LOG.ErrorFormat( "Select Modified Submodules - Modified Submodule: {0} - Could not find", submodule );
                    }
                }
            }
            catch( Exception ex )
            {
                LOG.Error( "An error occured while selecting modified submodules", ex );
            }

            UpdateSubmodulesButton.Enabled = true;
            SelectAllSubmodules.Enabled = true;
            SelectNoneSubmodules.Enabled = true;

            SelectModifiedSubmodules.Enabled = true;
            SelectModifiedSubmodules.Text = previousText;
        }

        private void UpdateSubmodulesButton_Click( object sender, EventArgs e )
        {
            UpdateSubmodulesButton.Enabled = false;
            UpdateSubmodules();
        }

        private void UpdateFromSettings()
        {
            InitCheck.Checked = Settings.Default.FastSubmoduleUpdateInitChecked;
            RecursiveCheck.Checked = Settings.Default.FastSubmoduleUpdateRecursiveChecked;
            ForceCheck.Checked = Settings.Default.FastSubmoduleUpdateForceChecked;
            MaxProcessCountNumeric.Value = Settings.Default.FastSubmoduleUpdateMaxProcesses;
        }

        private void SetChecked( bool value )
        {
            for( int i = 0; i < SubmoduleCheckList.Items.Count; i++ )
            {
                SubmoduleCheckList.SetItemChecked( i, value );
            }
        }

        private void UpdateSubmodules()
        {
            if( SubmoduleCheckList.CheckedItems.Count > 0 )
            {
                LOG.DebugFormat( "UpdateSubmodules" );

                bool init = InitCheck.Checked;
                bool recursive = RecursiveCheck.Checked;
                bool force = ForceCheck.Checked;
                int maxProcesses = (int)MaxProcessCountNumeric.Value;

                Settings.Default.FastSubmoduleUpdateInitChecked = init;
                Settings.Default.FastSubmoduleUpdateRecursiveChecked = recursive;
                Settings.Default.FastSubmoduleUpdateForceChecked = force;
                Settings.Default.FastSubmoduleUpdateMaxProcesses = maxProcesses;
                Settings.Default.Save();

                this.Close();
                var processes = SubmoduleCheckList.CheckedItems.Cast<String>().Select( submodule => UpdateSubmodule( Repo, submodule, init, recursive, force ) );
                ProcessProgressForm.ShowProgress( Repo + " - Fast Submodule Update", "Submodule Update Completed", processes, maxProcesses );
            }
            else
            {
                LOG.DebugFormat( "UpdateSubmodules - No Submodules Selected" );
                MessageBox.Show( "No submodules selected" );
            }
        }

        public Process UpdateSubmodule( String repoPath, String submodulePath, bool init, bool recursive, bool force )
        {
            StringBuilder args = new StringBuilder( "submodule update " );
            if( init )
            {
                args.Append( "--init " );
            }
            if( recursive )
            {
                args.Append( "--recursive " );
            }
            if( force )
            {
                args.Append( "--force " );
            }
            args.AppendFormat( "-- \"{0}\"", submodulePath );

            Process p = new Process();
            p.StartInfo.FileName = "git.exe";
            p.StartInfo.Arguments = args.ToString();
            p.StartInfo.WorkingDirectory = repoPath;

            LOG.DebugFormat( "UpdateSubmodule - Filename: {0} - Arguments: {1} - Working Directory: {2}", p.StartInfo.FileName, p.StartInfo.Arguments, p.StartInfo.WorkingDirectory );

            return p;
        }
    }
}
