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
    public partial class CloseConfirmationDialog : Form
    {
        public bool DontAskAgain
        {
            get
            {
                return DontAskAgainCheck.Checked;
            }
        }

        public CloseConfirmationDialog( bool parentVisible )
        {
            InitializeComponent();

            if( parentVisible )
            {
                this.StartPosition = FormStartPosition.CenterParent;
                this.ShowInTaskbar = false;
            }
            else
            {
                this.StartPosition = FormStartPosition.CenterScreen;
                this.ShowInTaskbar = true;
            }
        }
    }
}
