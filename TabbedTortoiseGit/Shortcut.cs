using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabbedTortoiseGit
{
    [method: JsonConstructor]
    public class Shortcut( Keys modifiers, Keys key )
    {
        public static readonly Shortcut Empty = new Shortcut( Keys.None, Keys.None );

        private static readonly KeyValuePair<Keys, String>[] MODIFIER_MAPPING = [
            new KeyValuePair<Keys, string>( Keys.Control, "Ctrl" ),
            new KeyValuePair<Keys, string>( Keys.Shift, "Shift" ),
            new KeyValuePair<Keys, string>( Keys.Alt, "Alt" )
        ];

        public Keys Modifiers { get; private set; } = modifiers;
        public Keys Key { get; set; } = key;

        [JsonIgnore]
        public bool IsValid
        {
            get
            {
                return Key != Keys.None;
            }
        }

        [JsonIgnore]
        public String Text
        {
            get
            {
                List<String> keyStrings = MODIFIER_MAPPING
                                            .Where( modifier => Modifiers.HasFlag( modifier.Key ) )
                                            .Select( modifier => modifier.Value )
                                            .ToList();
                if( Key != Keys.None )
                {
                    keyStrings.Add( Key.ToString() );
                }
                return String.Join( "+", keyStrings );
            }
        }

        public static Shortcut FromKeyEventArgs( KeyEventArgs e )
        {
            Keys key = Keys.None;

            Keys modifiers = MODIFIER_MAPPING
                .Where( modifier => e.KeyData.HasFlag( modifier.Key ) )
                .Select( modifier => modifier.Key )
                .Aggregate( Keys.None, ( m1, m2 ) => m1 | m2 );

            if( ( 33 <= e.KeyValue && e.KeyValue <= 126 )
             || e.KeyValue == (int)Keys.Tab )
            {
                key = e.KeyCode;
            }

            return new Shortcut( modifiers, key );
        }

        public static Shortcut FromKeyEventArgs( PreviewKeyDownEventArgs e )
        {
            return FromKeyEventArgs( new KeyEventArgs( e.KeyData ) );
        }

        public override string ToString()
        {
            return $"Shortcut( {this.Text} )";
        }
    }
}
