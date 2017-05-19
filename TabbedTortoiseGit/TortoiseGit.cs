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
    public delegate void TortoiseGitCommandFunc( String path );

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
                new TortoiseGitCommand( "Submodule Update", TortoiseGit.SubmoduleUpdate, Resources.SubmoduleUpdate ),
                new TortoiseGitCommand( "Fast Submodule Update", TortoiseGit.FastSubmoduleUpdate, Resources.SubmoduleUpdate )
            };
            ACTIONS = commands.ToImmutableDictionary( command => command.Name );
        }

        private static readonly String TORTOISE_GIT_EXE = "TortoiseGitProc.exe";

        private static Process TortoiseGitCommand( String command, String workingDirectroy )
        {
            ProcessStartInfo info = new ProcessStartInfo()
            {
                FileName = TORTOISE_GIT_EXE,
                Arguments = command,
                WorkingDirectory = workingDirectroy
            };
            return Process.Start( info );
        }

        private static Process PathCommand( String command, String path )
        {
            return TortoiseGitCommand( "/command:{0} /path:\"{1}\"".XFormat( command, path ), path );
        }

        public static Process Log( String path )
        {
            return PathCommand( "log", path );
        }

        public static void Fetch( String path )
        {
            PathCommand( "fetch", path );
        }

        public static void Commit( String path )
        {
            PathCommand( "commit", path );
        }

        public static void Switch( String path )
        {
            PathCommand( "switch", path );
        }

        public static void Pull( String path )
        {
            PathCommand( "pull", path );
        }

        public static void Push( String path )
        {
            PathCommand( "push", path );
        }

        public static void Rebase( String path )
        {
            PathCommand( "rebase", path );
        }

        public static void Sync( String path )
        {
            PathCommand( "sync", path );
        }

        public static void SubmoduleUpdate( String path )
        {
            TortoiseGitCommand( "/command:subupdate /path:\"{0}\" /bkpath:\"{0}\"".XFormat( path ), path );
        }

        public static void FastSubmoduleUpdate( String path )
        {
            FastSubmoduleUpdateForm.UpdateSubmodules( path );
        }
    }
}
