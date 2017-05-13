using Microsoft.WindowsAPICodePack.Dialogs;
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
    public partial class SettingsForm : Form
    {
        private readonly CommonOpenFileDialog _folderDialog;

        public String[] DefaultRepos
        {
            get
            {
                return DefaultReposList.Items.Cast<String>().ToArray();
            }

            set
            {
                DefaultReposList.Items.Clear();
                DefaultReposList.Items.AddRange( value );
            }
        }

        public bool RetainLogsOnClose
        {
            get
            {
                return RetainLogsOnCloseCheck.Checked;
            }

            set
            {
                RetainLogsOnCloseCheck.Checked = value;
            }
        }

        public int MaxRecentRepos
        {
            get
            {
                return (int)MaxRecentReposNumeric.Value;
            }

            set
            {
                MaxRecentReposNumeric.Value = value;
            }
        }

        public static bool ShowSettingsDialog()
        {
            SettingsForm f = new SettingsForm();
            if( Settings.Default.DefaultRepos != null )
            {
                f.DefaultRepos = Settings.Default.DefaultRepos.ToArray();
            }
            f.RetainLogsOnClose = Settings.Default.RetainLogsOnClose;
            f.MaxRecentRepos = Settings.Default.MaxRecentRepos;

            if( f.ShowDialog() == DialogResult.OK )
            {
                Settings.Default.DefaultRepos = f.DefaultRepos.ToList();
                Settings.Default.RetainLogsOnClose = f.RetainLogsOnClose;
                Settings.Default.MaxRecentRepos = f.MaxRecentRepos;
                if( Settings.Default.RecentRepos != null )
                {
                    Settings.Default.RecentRepos = Settings.Default.RecentRepos.Take( Settings.Default.MaxRecentRepos ).ToList();
                }
                Settings.Default.Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public SettingsForm()
        {
            InitializeComponent();

            _folderDialog = new CommonOpenFileDialog();
            _folderDialog.IsFolderPicker = true;

            this.AddDefaultRepo.Click += AddDefaultRepo_Click;
            this.RemoveDefaultRepo.Click += RemoveDefaultRepo_Click;

            this.DefaultReposList.SelectedValueChanged += DefaultReposList_SelectedValueChanged;
        }

        private void AddDefaultRepo_Click( object sender, EventArgs e )
        {
            if( _folderDialog.ShowDialog() == CommonFileDialogResult.Ok )
            {
                String path = _folderDialog.FileName;
                if( Git.IsRepo( path ) )
                {
                    DefaultReposList.Items.Add( path );
                }
                else
                {
                    MessageBox.Show( "Directory is not a Git repo.", "Invalid Directory", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
        }

        private void RemoveDefaultRepo_Click( object sender, EventArgs e )
        {
            foreach( String defaultRepo in this.DefaultReposList.SelectedItems.Cast<String>().ToArray() )
            {
                this.DefaultReposList.Items.Remove( defaultRepo );
            }
        }

        private void DefaultReposList_SelectedValueChanged( object sender, EventArgs e )
        {
            UpdateDefaultReposActions();
        }

        private void UpdateDefaultReposActions()
        {
            if( this.DefaultReposList.SelectedItems.Count != 0 )
            {
                RemoveDefaultRepo.Enabled = true;
            }
            else
            {
                RemoveDefaultRepo.Enabled = false;
            }
        }
    }
}
