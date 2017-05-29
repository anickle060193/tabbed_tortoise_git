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
        private int tabCount = 0;

        public TestTabForm()
        {
            InitializeComponent();

            tabControl1.NewTabClick += TabControl1_NewTabClick;
            addTabToolStripMenuItem.Click += TabControl1_NewTabClick;
            tabControl1.Click += TabControl1_Click;
        }

        private void TabControl1_Click( object sender, EventArgs e )
        {
            Console.WriteLine( "Tab Control Clicked" );
        }

        private void TabControl1_NewTabClick( object sender, EventArgs e )
        {
            Tab t = tabControl1.Tabs.Add( ( tabCount++ ).ToString() );
            t.Controls.Add( new Button()
            {
                Text = String.Format( "Tab {0}", t.Text ),
                Visible = true
            } );
            t.Click += T_Click;
        }

        private void T_Click( object sender, EventArgs e )
        {
            Console.WriteLine( ( (Tab)sender ).Text );
        }
    }
}
