using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TabbedTortoiseGit
{
    public static class Git
    {
        private static readonly Regex GIT_STATUS_REGEX = new Regex( @"\d .. (?<isSubmodule>.)(?<submoduleStatus>...) [0-7]{6} [0-7]{6} [0-7]{6} [0-9a-f]{40} [0-9a-f]{40} (?<name>.+?)$", RegexOptions.Compiled );

        public static bool IsRepo( String path )
        {
            if( Repository.IsValid( path ) )
            {
                return true;
            }
            else
            {
                String d = Repository.Discover( path );
                return d != null;
            }
        }

        public static String GetBaseRepoDirectory( String path )
        {
            String repo = Repository.Discover( path );
            if( repo != null )
            {
                return Util.NormalizePath( new Repository( repo ).Info.WorkingDirectory );
            }
            else
            {
                return null;
            }
        }

        public static async Task<List<String>> GetModifiedSubmodules( String path )
        {
            List<String> modifiedSubmodules = new List<String>();

            String repo = GetBaseRepoDirectory( path );
            if( repo == null )
            {
                return modifiedSubmodules;
            }

            ProcessStartInfo info = new ProcessStartInfo( "git.exe", "status --porcelain=2" )
            {
                WorkingDirectory = repo,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true
            };
            Process p = Process.Start( info );
            await Task.Run( () => p.WaitForExit() );

            if( p.ExitCode != 0 )
            {
                return modifiedSubmodules;
            }

            while( !p.StandardOutput.EndOfStream )
            {
                String line = p.StandardOutput.ReadLine();
                Match m = GIT_STATUS_REGEX.Match( line );
                if( m.Success )
                {
                    bool isSubmodule = m.Groups[ "isSubmodule" ].Value == "S";
                    bool modified = m.Groups[ "submoduleStatus" ].Value != "...";
                    String name = m.Groups[ "name" ].Value;
                    if( isSubmodule && modified )
                    {
                        modifiedSubmodules.Add( name );
                    }
                }
            }

            return modifiedSubmodules;
        }
    }
}
