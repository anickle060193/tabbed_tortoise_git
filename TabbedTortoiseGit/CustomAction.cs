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
    [method: JsonConstructor]
    public class CustomAction(
        String name,
        String program,
        String arguments,
        String workingDirectory,
        bool refreshLogAfter,
        bool showProgressDialog,
        bool createNoWindow
    )
    {
        public String Name { get; private set; } = name;
        public String Program { get; private set; } = program;
        public String Arguments { get; private set; } = arguments;

        [DefaultValue( "%r" )]
        public String WorkingDirectory { get; private set; } = workingDirectory;

        [DefaultValue( false )]
        public bool RefreshLogAfter { get; private set; } = refreshLogAfter;

        [DefaultValue( false )]
        public bool ShowProgressDialog { get; private set; } = showProgressDialog;

        [DefaultValue( false )]
        public bool CreateNoWindow { get; private set; } = createNoWindow;

        public override string ToString()
        {
            return $"{nameof( CustomAction )}( {nameof( Name )}={Name}, {nameof( Program )}=\"{Program}\", {nameof( Arguments )}=\"{Arguments}\", {nameof( WorkingDirectory )}=\"{WorkingDirectory}\", {nameof( RefreshLogAfter )}={RefreshLogAfter}, {nameof( ShowProgressDialog )}={ShowProgressDialog}, {nameof( CreateNoWindow )}={CreateNoWindow} )";
        }
    }
}
