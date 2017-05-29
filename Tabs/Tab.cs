using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tabs
{
    public class Tab : Panel
    {
        public override string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                base.Text = value;
                
                if( this.Parent != null )
                {
                    this.Parent.Invalidate();
                }
            }
        }

        public Tab() : this( "" )
        {
        }

        public Tab( String text )
        {
            Text = text;
        }
    }
}
