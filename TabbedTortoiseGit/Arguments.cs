using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabbedTortoiseGit
{
    [Verb( "run", isDefault: true )]
    class DefaultArguments
    {
        [Option( "startup", Default = false, Required = false, HelpText = "Indicates Tabbed TortoiseGit is being opened from startup." )]
        public bool Startup { get; set; }
    }

    [Verb( "commit", isDefault: false )]
    class CommitInstallArguments
    {
    }
}
