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
                    return new CustomAction( ActionName.Text, Program.Text, Arguments.Text );
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
                }
                else
                {
                    ActionName.Text = value.Name;
                    Program.Text = value.Program;
                    Arguments.Text = value.Arguments;
                }
            }
        }

        public CustomActionDialog()
        {
            InitializeComponent();

            this.DialogResult = DialogResult.Cancel;
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
                  && !String.IsNullOrWhiteSpace( Program.Text ) );
        }

        private void UpdateOk()
        {
            Ok.Enabled = this.IsValidAction();
        }

        private void ActionName_TextChanged( object sender, EventArgs e )
        {
            this.UpdateOk();
        }

        private void Program_TextChanged( object sender, EventArgs e )
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
