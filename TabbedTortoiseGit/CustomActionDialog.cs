using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabbedTortoiseGit
{
    public partial class CustomActionDialog : Form
    {
        public CustomAction CustomAction
        {
            get
            {
                if( this.IsValidAction() )
                {
                    return new CustomAction(
                        ActionName.Text,
                        Program.Text,
                        Arguments.Text,
                        WorkingDirectory.Text,
                        RefreshLogAfter.Checked,
                        ShowProgressDialog.Checked,
                        CreateNoWindow.Checked
                    );
                }
                else
                {
                    return null;
                }
            }

            set
            {
                if( value == null )
                {
                    ActionName.Text = null;
                    Program.Text = null;
                    Arguments.Text = null;
                    WorkingDirectory.Text = null;
                    RefreshLogAfter.Checked = false;
                    ShowProgressDialog.Checked = false;
                    CreateNoWindow.Checked = false;
                }
                else
                {
                    ActionName.Text = value.Name;
                    Program.Text = value.Program;
                    Arguments.Text = value.Arguments;
                    WorkingDirectory.Text = value.WorkingDirectory;
                    RefreshLogAfter.Checked = value.RefreshLogAfter;
                    ShowProgressDialog.Checked = value.ShowProgressDialog;
                    CreateNoWindow.Checked = value.CreateNoWindow;
                }
            }
        }

        public CustomActionDialog()
        {
            InitializeComponent();

            this.DialogResult = DialogResult.Cancel;

            ActionName.TextChanged += ActionValue_TextChanged;
            Program.TextChanged += ActionValue_TextChanged;
            WorkingDirectory.TextChanged += ActionValue_TextChanged;

            this.UpdateOk();
        }

        private void ProgramBrowse_Click( object sender, EventArgs e )
        {
            if( ProgramBrowseDialog.ShowDialog() == DialogResult.OK )
            {
                Program.Text = ProgramBrowseDialog.FileName;
            }
        }

        private bool IsValidAction()
        {
            return ( !String.IsNullOrWhiteSpace( ActionName.Text )
                  && !String.IsNullOrWhiteSpace( Program.Text )
                  && !String.IsNullOrWhiteSpace( WorkingDirectory.Text ) );
        }

        private void UpdateOk()
        {
            Ok.Enabled = this.IsValidAction();
        }

        private void ActionValue_TextChanged( object sender, EventArgs e )
        {
            this.UpdateOk();
        }

        private void Ok_Click( object sender, EventArgs e )
        {
            if( this.IsValidAction() )
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
