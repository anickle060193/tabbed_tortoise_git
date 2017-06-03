using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public static class Extensions
    {
        public static TValue Pluck<TKey, TValue>( this Dictionary<TKey, TValue> self, TKey key )
        {
            TValue v = self[ key ];
            self.Remove( key );
            return v;
        }

        public static String XFormat( this String format, params Object[] args )
        {
            return String.Format( format, args );
        }

        public static void AppendText( this RichTextBox box, String text, Color color )
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText( text );
            box.SelectionColor = box.ForeColor;
        }
    }
}
