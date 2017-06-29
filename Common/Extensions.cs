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

        public static void DebugInject( this ILog log, String formatString, Object injectionObject )
        {
            log.Debug( formatString.Inject( injectionObject ) );
        }

        public static void FatalInject( this ILog log, String formatString, Object injectionObject )
        {
            log.Fatal( formatString.Inject( injectionObject ) );
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
                    DescriptionAttribute attr = Attribute.GetCustomAttribute( field, typeof( DescriptionAttribute ) ) as DescriptionAttribute;
                    if( attr != null )
                    {
                        return attr.Description;
                    }
                }
            }
            return name;
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

    // From http://mo.notono.us/2008/07/c-stringinject-format-strings-by-key.html
    public static class StringInjectExtension
    {
        /// <summary>
        /// Extension method that replaces keys in a string with the values of matching object properties.
        /// <remarks>Uses <see cref="String.Format()"/> internally; custom formats should match those used for that method.</remarks>
        /// </summary>
        /// <param name="formatString">The format string, containing keys like {foo} and {foo:SomeFormat}.</param>
        /// <param name="injectionObject">The object whose properties should be injected in the string</param>
        /// <returns>A version of the formatString string with keys replaced by (formatted) key values.</returns>
        public static string Inject( this string formatString, object injectionObject )
        {
            return formatString.Inject( GetPropertyHash( injectionObject ) );
        }

        /// <summary>
        /// Extension method that replaces keys in a string with the values of matching dictionary entries.
        /// <remarks>Uses <see cref="String.Format()"/> internally; custom formats should match those used for that method.</remarks>
        /// </summary>
        /// <param name="formatString">The format string, containing keys like {foo} and {foo:SomeFormat}.</param>
        /// <param name="dictionary">An <see cref="IDictionary"/> with keys and values to inject into the string</param>
        /// <returns>A version of the formatString string with dictionary keys replaced by (formatted) key values.</returns>
        public static string Inject( this string formatString, IDictionary dictionary )
        {
            return formatString.Inject( new Hashtable( dictionary ) );
        }

        /// <summary>
        /// Extension method that replaces keys in a string with the values of matching hashtable entries.
        /// <remarks>Uses <see cref="String.Format()"/> internally; custom formats should match those used for that method.</remarks>
        /// </summary>
        /// <param name="formatString">The format string, containing keys like {foo} and {foo:SomeFormat}.</param>
        /// <param name="attributes">A <see cref="Hashtable"/> with keys and values to inject into the string</param>
        /// <returns>A version of the formatString string with hastable keys replaced by (formatted) key values.</returns>
        public static string Inject( this string formatString, Hashtable attributes )
        {
            string result = formatString;
            if( attributes == null || formatString == null )
                return result;

            foreach( string attributeKey in attributes.Keys )
            {
                result = result.InjectSingleValue( attributeKey, attributes[ attributeKey ] );
            }
            return result;
        }

        /// <summary>
        /// Replaces all instances of a 'key' (e.g. {foo} or {foo:SomeFormat}) in a string with an optionally formatted value, and returns the result.
        /// </summary>
        /// <param name="formatString">The string containing the key; unformatted ({foo}), or formatted ({foo:SomeFormat})</param>
        /// <param name="key">The key name (foo)</param>
        /// <param name="replacementValue">The replacement value; if null is replaced with an empty string</param>
        /// <returns>The input string with any instances of the key replaced with the replacement value</returns>
        public static string InjectSingleValue( this string formatString, string key, object replacementValue )
        {
            string result = formatString;
            //regex replacement of key with value, where the generic key format is:
            //Regex foo = new Regex("{(foo)(?:}|(?::(.[^}]*)}))");
            Regex attributeRegex = new Regex( "{(" + key + ")(?:}|(?::(.[^}]*)}))" );  //for key = foo, matches {foo} and {foo:SomeFormat}

            //loop through matches, since each key may be used more than once (and with a different format string)
            foreach( Match m in attributeRegex.Matches( formatString ) )
            {
                string replacement = m.ToString();
                if( m.Groups[ 2 ].Length > 0 ) //matched {foo:SomeFormat}
                {
                    //do a double string.Format - first to build the proper format string, and then to format the replacement value
                    string attributeFormatString = string.Format( CultureInfo.InvariantCulture, "{{0:{0}}}", m.Groups[ 2 ] );
                    replacement = string.Format( CultureInfo.CurrentCulture, attributeFormatString, replacementValue );
                }
                else //matched {foo}
                {
                    replacement = ( replacementValue ?? string.Empty ).ToString();
                }
                //perform replacements, one match at a time
                result = result.Replace( m.ToString(), replacement );  //attributeRegex.Replace(result, replacement, 1);
            }
            return result;

        }

        /// <summary>
        /// Creates a HashTable based on current object state.
        /// <remarks>Copied from the MVCToolkit HtmlExtensionUtility class</remarks>
        /// </summary>
        /// <param name="properties">The object from which to get the properties</param>
        /// <returns>A <see cref="Hashtable"/> containing the object instance's property names and their values</returns>
        private static Hashtable GetPropertyHash( object properties )
        {
            Hashtable values = null;
            if( properties != null )
            {
                values = new Hashtable();
                PropertyDescriptorCollection props = TypeDescriptor.GetProperties( properties );
                foreach( PropertyDescriptor prop in props )
                {
                    values.Add( prop.Name, prop.GetValue( properties ) );
                }
            }
            return values;
        }
    }
}
