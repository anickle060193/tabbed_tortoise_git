﻿using Common;
using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

        public static String? GetBaseRepoDirectory( String path )
        {
            String repo = Repository.Discover( path );
            if( repo != null )
            {
                using Repository repository = new Repository( repo );
                return Util.NormalizePath( repository.Info.WorkingDirectory );
            }
            else
            {
                return null;
            }
        }

        public static String GetBaseRepoDirectoryOrError( String path )
        {
            return GetBaseRepoDirectory( path ) ?? throw new ArgumentException( $"Path is not a repo: '{path}'" );
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

            String? repo = GetBaseRepoDirectory( path );
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

        public static async Task<List<String>> GetModifiedSubmodules( String path, List<String> submodules, bool treatUninitializedSubmodulesAsModified )
        {
            String? repo = GetBaseRepoDirectory( path );
            if( repo == null )
            {
                return new List<String>();
            }

            ProcessStartInfo info = CreateGitProcessStartInfo( repo, "status --porcelain --ignore-submodules=none" );
            info.CreateNoWindow = true;
            info.UseShellExecute = false;
            info.RedirectStandardOutput = true;
            Process p = Process.Start( info )!;
            await p.WaitForExitAsync();

            if( p.ExitCode != 0 )
            {
                return new List<String>();
            }

            SortedSet<String> modifiedSubmodules = new SortedSet<String>();

            while( !p.StandardOutput.EndOfStream )
            {
                if( p.StandardOutput.ReadLine() is String line
                 && GIT_STATUS_REGEX.Match( line ) is Match m
                 && m.Success )
                {
                    bool modified = m.Groups[ "submoduleStatus" ].Value == "M";
                    String name = m.Groups[ "name" ].Value;
                    if( submodules.Contains( name ) && modified )
                    {
                        modifiedSubmodules.Add( name );
                    }
                }
            }

            if( treatUninitializedSubmodulesAsModified )
            {
                foreach( String submodule in submodules )
                {
                    if( !modifiedSubmodules.Contains( submodule )
                     && !File.Exists( Path.Combine( repo, submodule, ".git" ) ) )
                    {
                        modifiedSubmodules.Add( submodule );
                    }
                }
            }

            return modifiedSubmodules.ToList();
        }

        public static async Task<bool> IsModified( String path )
        {
            String? repo = GetBaseRepoDirectory( path );
            if( repo == null )
            {
                return false;
            }

            ProcessStartInfo info = CreateGitProcessStartInfo( repo, $"diff-index --quiet HEAD -- \"{path}\"" );
            Process p = Process.Start( info )!;
            await p.WaitForExitAsync();

            return p.ExitCode == 1;
        }

        public static ProcessProgressTask CreateSubmoduleUpdateTask( String repoPath, String submodulePath, bool init, bool recursive, bool force )
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
            return new ProcessProgressTask( p, true );
        }

        public static Task<String[]> GetReferences( String repo )
        {
            return Task.Run( () =>
            {
                using Repository repository = new Repository( Git.GetBaseRepoDirectory( repo ) );
                return repository.Refs.Select( ( r ) => r.CanonicalName ).ToArray();
            } );
        }

        public static Task<String?> GetCurrentBranch( String repo )
        {
            return Task.Run( () =>
            {
                using var repository = new Repository( Git.GetBaseRepoDirectory( repo ) );
                var currentBranch = repository.Head.CanonicalName;
                return currentBranch switch
                {
                    null => null,
                    "(no branch)" => null,
                    _ => currentBranch
                };
            } );
        }
    }
}
