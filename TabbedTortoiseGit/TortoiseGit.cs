using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabbedTortoiseGit
{
    public static class TortoiseGit
    {
        private static readonly String TORTOISE_GIT_EXE = "TortoiseGitProc.exe";

        private static Process PathCommand( String command, String path )
        {
            ProcessStartInfo info = new ProcessStartInfo()
            {
                FileName = TORTOISE_GIT_EXE,
                Arguments = "/command:{0} /path:\"{1}\"".XFormat( command, path ),
                WorkingDirectory = path
            };
            return Process.Start( info );
        }

        public static Process Fetch( String path )
        {
            return PathCommand( "fetch", path );
        }

        public static Process Commit( String path )
        {
            return PathCommand( "commit", path );
        }

        public static Process Log( String path )
        {
            return PathCommand( "log", path );
        }

        public static Process Switch( String path )
        {
            return PathCommand( "switch", path );
        }

        public static Process Pull( String path )
        {
            return PathCommand( "pull", path );
        }

        public static Process Push( String path )
        {
            return PathCommand( "push", path );
        }

        public static Process Rebase( String path )
        {
            return PathCommand( "rebase", path );
        }

        public static Process Sync( String path )
        {
            return PathCommand( "sync", path );
        }

        public static Process SubmoduleUpdate( String path )
        {
            return PathCommand( "subupdate", path );
        }
    }
}
