using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabbedTortoiseGit.Properties;

namespace TabbedTortoiseGit
{
    public delegate Process TortoiseGitCommandFunc( String path );

    public class TortoiseGitCommand
    {
        public String Name { get; private set; }
        public TortoiseGitCommandFunc Func { get; private set; }
        public Image Icon { get; private set; }

        public TortoiseGitCommand( String name, TortoiseGitCommandFunc func, Image icon )
        {
            Name = name;
            Func = func;
            Icon = icon;
        }
    }

    public static class TortoiseGit
    {
        public static readonly ImmutableDictionary<String, TortoiseGitCommand> ACTIONS;
        static TortoiseGit()
        {
            List<TortoiseGitCommand> commands = new List<TortoiseGitCommand>()
            {
                new TortoiseGitCommand( "Fetch", TortoiseGit.Fetch, Resources.Fetch ),
                new TortoiseGitCommand( "Commit", TortoiseGit.Commit, Resources.Commit ),
                new TortoiseGitCommand( "Switch/Checkout", TortoiseGit.Switch, Resources.Switch ),
                new TortoiseGitCommand( "Pull", TortoiseGit.Pull, Resources.Pull ),
                new TortoiseGitCommand( "Push", TortoiseGit.Push, Resources.Push ),
                new TortoiseGitCommand( "Rebase", TortoiseGit.Rebase, Resources.Rebase ),
                new TortoiseGitCommand( "Sync", TortoiseGit.Sync, Resources.Sync ),
                new TortoiseGitCommand( "Submodule Update", TortoiseGit.SubmoduleUpdate, Resources.SubmoduleUpdate )
            };
            ACTIONS = commands.ToImmutableDictionary( command => command.Name );
        }

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
