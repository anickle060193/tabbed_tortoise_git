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
    public partial class InputDialog : Form
    {
        public String Input
        {
            get
            {
                return InputBox.Text;
            }

            set
            {
                InputBox.Text = value;
            }
        }

        public String Title
        {
            set
            {
                this.Text = value;
            }
        }

        public String Description
        {
            set
            {
                InputBoxLabel.Text = value;
            }
        }

        public InputDialog()
        {
            InitializeComponent();
        }

        public static String ShowInput( String title, String description, String defaultValue )
        {
            InputDialog d = new InputDialog();
            d.Title = title;
            d.Description = description;
            d.Input = defaultValue;
            if( d.ShowDialog() == DialogResult.OK )
            {
                return d.Input;
            }
            else
            {
                return null;
            }
        }
    }
}
