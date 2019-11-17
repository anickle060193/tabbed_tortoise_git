#nullable enable

using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
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

        public static void AppendText( this RichTextBox box, String text, Color color )
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText( text );
            box.SelectionColor = box.ForeColor;
        }

        public static void UiBeginInvoke( this Control control, Delegate d, params Object[] args )
        {
            if( control.InvokeRequired )
            {
                control.BeginInvoke( d, args );
            }
            else
            {
                d.DynamicInvoke( args );
            }
        }

        public static void FillCircle( this Graphics graphics, Brush brush, float x, float y, float radius )
        {
            graphics.FillEllipse( brush, x - radius, y - radius, radius * 2, radius * 2 );
        }

        public static String GetDescription( this Enum value )
        {
            Type type = value.GetType();
            String name = Enum.GetName( type, value );
            if( name != null )
            {
                FieldInfo field = type.GetField( name );
                if( field != null )
                {
                    DescriptionAttribute? attr = Attribute.GetCustomAttribute( field, typeof( DescriptionAttribute ) ) as DescriptionAttribute;
                    if( attr != null )
                    {
                        return attr.Description;
                    }
                }
            }
            return name ?? "";
        }

        public static Icon ToIcon( this Bitmap bitmap )
        {
            IntPtr hIcon = bitmap.GetHicon();
            using( Icon icon = Icon.FromHandle( hIcon ) )
            {
                Icon clonedIcon = (Icon)icon.Clone();
                DestroyIcon( hIcon );
                return clonedIcon;
            }
        }

        [DllImport( "user32.dll", CharSet = CharSet.Auto )]
        private static extern bool DestroyIcon( IntPtr handle );

        public static Task WaitForClose( this Form form )
        {
            TaskCompletionSource<bool> completionSource = new TaskCompletionSource<bool>();

            form.FormClosed += ( sender, e ) => completionSource.SetResult( true );

            return completionSource.Task;
        }
    }
}
