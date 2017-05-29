using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tabs
{
    public partial class TestTabForm : Form
    {
        private int tabNumber = 0;

        public TestTabForm()
        {
            InitializeComponent();

            this.MaximizedBounds = Screen.FromControl( this ).WorkingArea;

            tabHeader1.TabClick += TabHeader1_TabClick;
            tabHeader1.NewTabClick += TabHeader1_NewTabClick;
        }

        private void TabHeader1_NewTabClick( object sender, EventArgs e )
        {
            textBox1.AppendText( "New Tab" + Environment.NewLine );
            tabHeader1.Tabs.Add( "New Tab " + ( tabNumber++ ).ToString() );
        }

        private void TabHeader1_TabClick( object sender, TabClickEventArgs e )
        {
            if( e.Button == MouseButtons.Middle )
            {
                tabHeader1.Tabs.Remove( e.Tab );
                textBox1.AppendText( e.Tab.Text + " - Removed" + Environment.NewLine );
            }
            else
            {
                textBox1.AppendText( e.Tab.Text + Environment.NewLine );
            }
        }
    }
}
