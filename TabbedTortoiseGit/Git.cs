using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabbedTortoiseGit
{
    public static class Git
    {
        public static bool IsRepo( String path )
        {
            ProcessStartInfo info = new ProcessStartInfo( "git", "rev-parse --is-inside-work-tree" )
            {
                WorkingDirectory = path,
                CreateNoWindow = true,
                UseShellExecute = false
            };
            Process p = Process.Start( info );
            p.WaitForExit();
            return p.ExitCode == 0;
        }
    }
}
