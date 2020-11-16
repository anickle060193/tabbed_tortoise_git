using Common;
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
    public partial class FastSubmoduleUpdateDialog : Form
    {
        private static readonly ILog LOG = LogManager.GetLogger( typeof( FastSubmoduleUpdateDialog ) );

        private readonly List<String> _submodules = new List<String>();
        private readonly Dictionary<String, bool> _checkedSubmodules = new Dictionary<String, bool>();

        private List<String>? _modifiedSubmodules;
        private bool _userModified;

        public String Repo { get; private set; }

        public FastSubmoduleUpdateDialog( String repo )
        {
            InitializeComponent();
            UpdateFromSettings();

            this.Icon = Resources.TortoiseIcon;

            Repo = repo;

            this.Text = $"{Repo} - {this.Text}";

            this.Shown += FastSubmoduleUpdateForm_Shown;

            Cancel.Click += Cancel_Click;
            UpdateSubmodulesButton.Click += UpdateSubmodulesButton_Click;

            SubmoduleCheckList.Click += SubmoduleCheckList_Click;
            SubmoduleCheckList.ItemCheck += SubmoduleCheckList_ItemCheck;

            SelectModifiedSubmodules.Click += SelectModifiedSubmodules_Click;
            SelectAllSubmodules.Click += SelectAllSubmodules_Click;
            SelectNoneSubmodules.Click += SelectNoneSubmodules_Click;

            ShowModifiedSubmodulesOnlyCheck.CheckedChanged += ShowModifiedSubmodulesOnlyCheck_CheckedChanged;
            CheckModifiedSubmodulesByDefaultCheck.CheckedChanged += CheckModifiedSubmodulesByDefaultCheck_CheckedChanged;

            InitCheck.CheckedChanged += InitCheck_CheckedChanged;
            RecursiveCheck.CheckedChanged += RecursiveCheck_CheckedChanged;
            ForceCheck.CheckedChanged += ForceCheck_CheckedChanged;
            MaxProcessCountNumeric.ValueChanged += MaxProcessCountNumeric_ValueChanged;
        }

        protected override void WndProc( ref Message m )
        {
            base.WndProc( ref m );

            if( m.Msg == Native.WindowMessage.NCHITTEST )
            {
                switch( m.Result.ToInt32() )
                {
                    case Native.HitTestValues.LEFT:
                    case Native.HitTestValues.RIGHT:
                        m.Result = new IntPtr( Native.HitTestValues.CAPTION );
                        break;

                    case Native.HitTestValues.TOPLEFT:
                    case Native.HitTestValues.TOPRIGHT:
                        m.Result = new IntPtr( Native.HitTestValues.TOP );
                        break;

                    case Native.HitTestValues.BOTTOMLEFT:
                    case Native.HitTestValues.BOTTOMRIGHT:
                        m.Result = new IntPtr( Native.HitTestValues.BOTTOM );
                        break;
                }
            }
        }

        private async void FastSubmoduleUpdateForm_Shown( object? sender, EventArgs e )
        {
            LOG.Debug( nameof( FastSubmoduleUpdateForm_Shown ) );

            LOG.Debug( $"{nameof( FastSubmoduleUpdateForm_Shown )} - Get Submodules - Start" );
            foreach( String submodule in await Task.Run( () => Git.GetSubmodules( Repo ) ) )
            {
                LOG.Debug( $"Submodule - {submodule}" );
                _submodules.Add( submodule );
                _checkedSubmodules[ submodule ] = true;
                SubmoduleCheckList.Items.Add( submodule );
            }
            LOG.Debug( $"{nameof( FastSubmoduleUpdateForm_Shown )} - Get Submodules - End" );

            UpdateChecked();

            LOG.Debug( $"{nameof( FastSubmoduleUpdateForm_Shown )} - Get Modified Submodules - Start" );
            try
            {
                _modifiedSubmodules = await Task.Run( () => Git.GetModifiedSubmodules( Repo, _submodules, Settings.Default.TreatUninitializedSubmodulesAsModified ) );
            }
            catch( Exception ex )
            {
                LOG.Error( "An error occured while retrieving modified submodules.", ex );
            }
            LOG.Debug( $"{nameof( FastSubmoduleUpdateForm_Shown )} - Get Modified Submodules - End" );

            SelectModifiedSubmodules.Text = "Select Modified Submodules";
            SelectModifiedSubmodules.Enabled = true;
            ShowModifiedSubmodulesOnlyCheck.Enabled = true;

            UpdateSubmoduleList();

            if( !_userModified )
            {
                if( Settings.Default.FastSubmoduleUpdateCheckModifiedSubmodulesByDefault )
                {
                    SetModifiedSubmodulesChecked();
                }
            }
        }

        private void Cancel_Click( object? sender, EventArgs e )
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SubmoduleCheckList_Click( object? sender, EventArgs e )
        {
            _userModified = true;
        }

        private void SubmoduleCheckList_ItemCheck( object? sender, ItemCheckEventArgs e )
        {
            String submodule = (String)SubmoduleCheckList.Items[ e.Index ];
            _checkedSubmodules[ submodule ] = e.NewValue == CheckState.Checked;

            UpdateSubmoduleUpdateButton();
        }

        private void SelectNoneSubmodules_Click( object? sender, EventArgs e )
        {
            _userModified = true;

            SetChecked( false );
        }

        private void SelectAllSubmodules_Click( object? sender, EventArgs e )
        {
            _userModified = true;

            SetChecked( true );
        }

        private void ShowModifiedSubmodulesOnlyCheck_CheckedChanged( object? sender, EventArgs e )
        {
            Settings.Default.FastSubmoduleUpdateShowOnlyModifiedSubmodulesChecked = ShowModifiedSubmodulesOnlyCheck.Checked;
            Settings.Default.Save();

            UpdateSubmoduleList();
        }

        private void CheckModifiedSubmodulesByDefaultCheck_CheckedChanged( object? sender, EventArgs e )
        {
            Settings.Default.FastSubmoduleUpdateCheckModifiedSubmodulesByDefault = CheckModifiedSubmodulesByDefaultCheck.Checked;
            Settings.Default.Save();
        }

        private void InitCheck_CheckedChanged( object? sender, EventArgs e )
        {
            Settings.Default.FastSubmoduleUpdateInitChecked = InitCheck.Checked;
            Settings.Default.Save();
        }

        private void RecursiveCheck_CheckedChanged( object? sender, EventArgs e )
        {
            Settings.Default.FastSubmoduleUpdateRecursiveChecked = RecursiveCheck.Checked;
            Settings.Default.Save();
        }

        private void ForceCheck_CheckedChanged( object? sender, EventArgs e )
        {
            Settings.Default.FastSubmoduleUpdateForceChecked = ForceCheck.Checked;
            Settings.Default.Save();
        }

        private void MaxProcessCountNumeric_ValueChanged( object? sender, EventArgs e )
        {
            Settings.Default.FastSubmoduleUpdateMaxProcesses = (int)MaxProcessCountNumeric.Value;
            Settings.Default.Save();
        }

        private void SelectModifiedSubmodules_Click( object? sender, EventArgs e )
        {
            SetModifiedSubmodulesChecked();
        }

        private async void UpdateSubmodulesButton_Click( object? sender, EventArgs e )
        {
            UpdateSubmodulesButton.Enabled = false;
            await UpdateSubmodules();
        }

        private void UpdateFromSettings()
        {
            InitCheck.Checked = Settings.Default.FastSubmoduleUpdateInitChecked;
            RecursiveCheck.Checked = Settings.Default.FastSubmoduleUpdateRecursiveChecked;
            ForceCheck.Checked = Settings.Default.FastSubmoduleUpdateForceChecked;

            MaxProcessCountNumeric.Value = Settings.Default.FastSubmoduleUpdateMaxProcesses;

            ShowModifiedSubmodulesOnlyCheck.Checked = Settings.Default.FastSubmoduleUpdateShowOnlyModifiedSubmodulesChecked;
            CheckModifiedSubmodulesByDefaultCheck.Checked = Settings.Default.FastSubmoduleUpdateCheckModifiedSubmodulesByDefault;
        }

        private void SetChecked( bool value )
        {
            foreach( String key in _checkedSubmodules.Keys.ToList() )
            {
                _checkedSubmodules[ key ] = value;
            }
            UpdateChecked();
        }

        private void SetModifiedSubmodulesChecked()
        {
            if( _modifiedSubmodules != null )
            {
                SetChecked( false );

                foreach( String submodule in _modifiedSubmodules )
                {
                    int index = SubmoduleCheckList.Items.IndexOf( submodule );
                    if( index != ListBox.NoMatches )
                    {
                        LOG.Debug( $"{nameof( SetModifiedSubmodulesChecked )} - Modified Submodule: {submodule}" );
                        SubmoduleCheckList.SetItemChecked( index, true );
                    }
                    else
                    {
                        LOG.Error( $"{nameof( SetModifiedSubmodulesChecked )} - Modified Submodule: {submodule} - Could not find" );
                    }
                }
            }
            else
            {
                LOG.Error( $"{nameof( SetModifiedSubmodulesChecked )} - Modified Submodules == null" );
            }
        }

        private void UpdateChecked()
        {
            List<String> submodules = SubmoduleCheckList.Items.Cast<String>().ToList();
            foreach( var s in submodules.Select( ( submodule, i ) => new { Submodule = submodule, Index = i } ) )
            {
                SubmoduleCheckList.SetItemChecked( s.Index, _checkedSubmodules[ s.Submodule ] );
            }
            UpdateSubmoduleUpdateButton();
        }

        private void UpdateSubmoduleUpdateButton()
        {
            if( _checkedSubmodules.Values.Any( c => c ) )
            {
                UpdateSubmodulesButton.Enabled = true;
            }
            else
            {
                UpdateSubmodulesButton.Enabled = false;
            }
        }

        private void UpdateSubmoduleList()
        {
            SubmoduleCheckList.Items.Clear();

            if( ShowModifiedSubmodulesOnlyCheck.Checked
             && _modifiedSubmodules != null )
            {
                SubmoduleCheckList.Items.AddRange( _modifiedSubmodules.ToArray() );
            }
            else
            {
                SubmoduleCheckList.Items.AddRange( _submodules.ToArray() );
            }

            UpdateChecked();
        }

        private async Task UpdateSubmodules()
        {
            if( SubmoduleCheckList.CheckedItems.Count > 0 )
            {
                LOG.Debug( nameof( UpdateSubmodules ) );

                this.Hide();

                bool init = InitCheck.Checked;
                bool recursive = RecursiveCheck.Checked;
                bool force = ForceCheck.Checked;
                int maxProcesses = (int)MaxProcessCountNumeric.Value;

                List<String> checkedSubmodules = SubmoduleCheckList.CheckedItems.Cast<String>().ToList();
                IEnumerable<ProcessProgressTask> tasks = checkedSubmodules.Select( submodule => Git.CreateSubmoduleUpdateTask( Repo, submodule, init, recursive, force ) );

                ProgressDialog dialog = new ProgressDialog()
                {
                    Title = this.Text,
                    CompletedText = "Submodule Update Completed",
                    MaxTasks = maxProcesses
                };
                dialog.AddTasks( tasks );
                dialog.Show();
                dialog.DoProgress();

                await dialog.WaitForClose();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                LOG.Debug( $"{nameof( UpdateSubmodules )} - No Submodules Selected" );
                MessageBox.Show( "No submodules selected" );
            }
        }
    }
}
