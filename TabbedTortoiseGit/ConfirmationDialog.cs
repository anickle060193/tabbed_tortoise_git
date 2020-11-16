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
    public partial class ConfirmationDialog : Form
    {
        public String Title
        {
            set
            {
                Text = value;
            }
        }

        public String Message
        {
            set
            {
                messageLabel.Text = value;
            }
        }

        public bool DoNotAskAgain
        {
            get
            {
                return doNotAskAgainCheckBox.Checked;
            }
        }

        public ConfirmationDialog( String title, String message)
        {
            InitializeComponent();

            Icon = Resources.TortoiseIcon;

            Title = title;
            Message = message;
        }
    }
}
