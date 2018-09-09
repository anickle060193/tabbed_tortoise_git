using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabbedTortoiseGit
{
    [TypeConverter( typeof( ShortcutConverter ) )]
    [JsonConverter( typeof( ForceJsonConverter<CustomAction> ) )]
    [SettingsSerializeAs( SettingsSerializeAs.String )]
    public class CustomAction
    {
        public String Name { get; private set; }
        public String Program { get; private set; }
        public String Arguments { get; private set; }

        [JsonConstructor]
        public CustomAction( String name, String program, String arguments )
        {
            Name = name;
            Program = program;
            Arguments = arguments;
        }

        public override string ToString()
        {
            return $"{nameof( CustomAction )}( {nameof( Name )}={Name}, {nameof( Program )}=\"{Program}\", {nameof( Arguments )}=\"{Arguments}\" )";
        }
    }

    class CustomActionConverter : TypeConverter
    {
        public override bool CanConvertFrom( ITypeDescriptorContext context, Type sourceType )
        {
            return sourceType == typeof( String );
        }

        public override object ConvertFrom( ITypeDescriptorContext context, CultureInfo culture, object value )
        {
            if( value is String )
            {
                return JsonConvert.DeserializeObject<Shortcut>( (String)value );
            }
            else
            {
                return base.ConvertFrom( context, culture, value );
            }
        }

        public override bool CanConvertTo( ITypeDescriptorContext context, Type destinationType )
        {
            return destinationType == typeof( String );
        }

        public override object ConvertTo( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
        {
            if( destinationType == typeof( String ) )
            {
                return JsonConvert.SerializeObject( value );
            }
            else
            {
                return base.ConvertTo( context, culture, value, destinationType );
            }
        }
    }
}
