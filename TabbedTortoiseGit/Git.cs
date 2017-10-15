using Common;
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
        private static readonly Regex GIT_STATUS_REGEX = new Regex( @"^[ MADRCU](?<submoduleStatus>[ MADRCU]) (?<name>.+?)$", RegexOptions.Compiled );

        public static bool IsInRepo( String path )
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

        private static ProcessStartInfo CreateGitProcessStartInfo( String repo, String args )
        {
            return new ProcessStartInfo( "git.exe", args )
            {
                WorkingDirectory = repo,
                CreateNoWindow = true,
                UseShellExecute = false
            };
        }

        public static async Task<List<String>> GetSubmodules( String path )
        {
            List<String> submodules = new List<String>();

            String repo = GetBaseRepoDirectory( path );
            if( repo == null )
            {
                return submodules;
            }

            using( Repository r = await Task.Run( () => new Repository( repo ) ) )
            {
                submodules.AddRange( r.Submodules.Select( s => s.Path ) );
            }
            return submodules;
        }

        public static async Task<List<String>> GetModifiedSubmodules( String path, List<String> submodules )
        {
            List<String> modifiedSubmodules = new List<String>();

            String repo = GetBaseRepoDirectory( path );
            if( repo == null )
            {
                return modifiedSubmodules;
            }

            ProcessStartInfo info = CreateGitProcessStartInfo( repo, "status --porcelain --ignore-submodules=none" );
            info.CreateNoWindow = true;
            info.UseShellExecute = false;
            info.RedirectStandardOutput = true;
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
                    bool modified = m.Groups[ "submoduleStatus" ].Value == "M";
                    String name = m.Groups[ "name" ].Value;
                    if( submodules.Contains( name ) && modified )
                    {
                        modifiedSubmodules.Add( name );
                    }
                }
            }

            return modifiedSubmodules;
        }

        public static async Task<bool> IsModified( String path )
        {
            String repo = GetBaseRepoDirectory( path );
            if( repo == null )
            {
                return false;
            }

            ProcessStartInfo info = CreateGitProcessStartInfo( repo, "diff-index --quiet HEAD -- \"{0}\"".XFormat( path ) );
            Process p = Process.Start( info );
            await Task.Run( () => p.WaitForExit() );

            return p.ExitCode == 1;
        }

        public static Process CreateSubmoduleUpdateProcess( String repoPath, String submodulePath, bool init, bool recursive, bool force )
        {
            StringBuilder args = new StringBuilder( "submodule update " );
            if( init )
            {
                args.Append( "--init " );
            }
            if( recursive )
            {
                args.Append( "--recursive " );
            }
            if( force )
            {
                args.Append( "--force " );
            }
            args.AppendFormat( "-- \"{0}\"", submodulePath );

            Process p = new Process();
            p.StartInfo.FileName = "git.exe";
            p.StartInfo.Arguments = args.ToString();
            p.StartInfo.WorkingDirectory = repoPath;
            return p;
        }
    }
}
