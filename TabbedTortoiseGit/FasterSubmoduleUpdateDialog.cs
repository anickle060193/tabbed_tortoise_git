#nullable enable

using Common;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TabbedTortoiseGit.Properties;

namespace TabbedTortoiseGit
{
    public partial class FasterSubmoduleUpdateDialog : Form
    {
        private static readonly ILog LOG = LogManager.GetLogger( typeof( FasterSubmoduleUpdateDialog ) );

        public String Repo { get; private set; }

        public FasterSubmoduleUpdateDialog( String repo )
        {
            InitializeComponent();
            InitializeFromSettings();

            this.Icon = Resources.TortoiseIcon;

            this.Repo = repo;

            this.Text = $"{Repo} - {this.Text}";

            SubmodulesAll.CheckedChanged += FasterSubmoduleUpdateDialog_SettingChanged;
            InitCheck.CheckedChanged += FasterSubmoduleUpdateDialog_SettingChanged;
            RecursiveCheck.CheckedChanged += FasterSubmoduleUpdateDialog_SettingChanged;
            ForceCheck.CheckedChanged += FasterSubmoduleUpdateDialog_SettingChanged;
            MaxProcessCountNumeric.ValueChanged += FasterSubmoduleUpdateDialog_SettingChanged;

            Cancel.Click += Cancel_Click;
            UpdateSubmodulesButton.Click += UpdateSubmodulesButton_Click;
        }

        private void FasterSubmoduleUpdateDialog_SettingChanged( object sender, EventArgs e )
        {
            Settings.Default.FasterSubmoduleUpdateAllSubmodules = SubmodulesAll.Checked;
            Settings.Default.FasterSubmoduleUpdateInitChecked = InitCheck.Checked;
            Settings.Default.FasterSubmoduleUpdateRecursiveChecked = RecursiveCheck.Checked;
            Settings.Default.FasterSubmoduleUpdateForceChecked = ForceCheck.Checked;
            Settings.Default.FasterSubmoduleUpdateMaxProcesses = (int)MaxProcessCountNumeric.Value;
            Settings.Default.Save();
        }

        private void InitializeFromSettings()
        {
            if( Settings.Default.FasterSubmoduleUpdateAllSubmodules )
            {
                SubmodulesAll.Checked = true;
            }
            else
            {
                SubmodulesModifiedOnly.Checked = true;
            }
            InitCheck.Checked = Settings.Default.FasterSubmoduleUpdateInitChecked;
            RecursiveCheck.Checked = Settings.Default.FasterSubmoduleUpdateRecursiveChecked;
            ForceCheck.Checked = Settings.Default.FasterSubmoduleUpdateForceChecked;
            MaxProcessCountNumeric.Value = Settings.Default.FasterSubmoduleUpdateMaxProcesses;
        }

        private void Cancel_Click( object sender, EventArgs e )
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void UpdateSubmodulesButton_Click( object sender, EventArgs e )
        {
            UpdateSubmodulesButton.Enabled = false;
            await UpdateSubmodules();
        }

        private async Task UpdateSubmodules()
        {
            LOG.Debug( nameof( UpdateSubmodules ) );

            this.Hide();

            bool allSubmodules = SubmodulesAll.Checked;
            bool init = InitCheck.Checked;
            bool recursive = RecursiveCheck.Checked;
            bool force = ForceCheck.Checked;
            int maxProcesses = (int)MaxProcessCountNumeric.Value;

            RetrieveSubmodulesProgressTask task = new UpdateSubmodulesProgressTask( this.Repo, !allSubmodules, init, recursive, force );

            ProgressDialog dialog = new ProgressDialog()
            {
                Title = this.Text,
                CompletedText = "Faster Submodule Update Completed",
                MaxTasks = maxProcesses
            };
            dialog.AddTask( task );
            dialog.Show();
            dialog.DoProgress();

            await dialog.WaitForClose();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }

    class UpdateSubmodulesProgressTask : RetrieveSubmodulesProgressTask
    {
        public bool Init { get; private set; }
        public bool Recursive { get; private set; }
        public bool Force { get; private set; }

        public UpdateSubmodulesProgressTask( String repo, bool modifiedOnly, bool init, bool recursive, bool force ) : base( repo, modifiedOnly )
        {
            this.Init = init;
            this.Recursive = recursive;
            this.Force = force;
        }

        protected override ProcessProgressTask GetTaskForSubmodule( string submodule )
        {
            return Git.CreateSubmoduleUpdateTask( this.Repo, submodule, this.Init, this.Recursive, this.Force );
        }
    }
}
