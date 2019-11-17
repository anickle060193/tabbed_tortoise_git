#nullable enable

using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabbedTortoiseGit
{
    class Arguments
    {
        [Option( 's', "startup", DefaultValue=false, HelpText="Indicates Tabbed TortoiseGit is being opened from startup." )]
        public bool Startup { get; set; }
    }
}
