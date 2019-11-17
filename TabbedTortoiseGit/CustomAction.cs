#nullable enable

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

        [DefaultValue( "%r" )]
        public String WorkingDirectory { get; private set; }

        [DefaultValue( false )]
        public bool RefreshLogAfter { get; private set; }

        [DefaultValue( false )]
        public bool ShowProgressDialog { get; private set; }

        [DefaultValue( false )]
        public bool CreateNoWindow { get; private set; }

        [JsonConstructor]
        public CustomAction( String name, String program, String arguments, String workingDirectory, bool refreshLogAfter, bool showProgressDialog, bool createNoWindow )
        {
            Name = name;
            Program = program;
            Arguments = arguments;
            WorkingDirectory = workingDirectory;
            RefreshLogAfter = refreshLogAfter;
            ShowProgressDialog = showProgressDialog;
            CreateNoWindow = createNoWindow;
        }

        public override string ToString()
        {
            return $"{nameof( CustomAction )}( {nameof( Name )}={Name}, {nameof( Program )}=\"{Program}\", {nameof( Arguments )}=\"{Arguments}\", {nameof( WorkingDirectory )}=\"{WorkingDirectory}\", {nameof( RefreshLogAfter )}={RefreshLogAfter}, {nameof( ShowProgressDialog )}={ShowProgressDialog}, {nameof( CreateNoWindow )}={CreateNoWindow} )";
        }
    }
}
