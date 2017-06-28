﻿using Common;
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
    public delegate Task TortoiseGitCommandFunc( String path );

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
                new TortoiseGitCommand( "Fast Fetch", TortoiseGit.FastFetch, Resources.Fetch ),
                new TortoiseGitCommand( "Faster Fetch", TortoiseGit.FasterFetch, Resources.Fetch ),
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

        private static async Task<Process> WaitForTortoiseGitCommandAsync( String command, String workingDirectory )
        {
            Process p = TortoiseGitCommand( command, workingDirectory );
            await Task.Run( () => p.WaitForExit() );
            return p;
        }

        private static Process PathCommand( String command, String path )
        {
            return TortoiseGitCommand( "/command:{0} /path:\"{1}\"".XFormat( command, path ), path );
        }

        private static async Task<Process> WaitForPathCommandAsync( String command, String path )
        {
            Process p = PathCommand( command, path );
            await Task.Run( () => p.WaitForExit() );
            return p;
        }

        public static Process Log( String path, IEnumerable<String> references = null )
        {
            String command = "/command:log /path:\"{0}\"".XFormat( path );
            if( references != null )
            {
                String[] refs = references.ToArray();
                if( refs.Length > 0 )
                {
                    command += " /range:\"{0}\"".XFormat( String.Join( " ", refs ) );
                }
            }
            return TortoiseGitCommand( command, path );
        }

        public static async Task Fetch( String path )
        {
            await WaitForPathCommandAsync( "fetch", path );
        }

        public static Task FastFetch( String path )
        {
            FastFetchDialog.FastFetch( path );
            return Task.FromResult( true );
        }

        public static Task FasterFetch( String path )
        {
            FastFetchDialog.FasterFetch( path );
            return Task.FromResult( true );
        }

        public static async Task Commit( String path )
        {
            await WaitForPathCommandAsync( "commit", path );
        }

        public static async Task Switch( String path )
        {
            await WaitForPathCommandAsync( "switch", path );
        }

        public static async Task Pull( String path )
        {
            await WaitForPathCommandAsync( "pull", path );
        }

        public static async Task Push( String path )
        {
            await WaitForPathCommandAsync( "push", path );
        }

        public static async Task Rebase( String path )
        {
            await WaitForPathCommandAsync( "rebase", path );
        }

        public static async Task Sync( String path )
        {
            await WaitForPathCommandAsync( "sync", path );
        }

        public static async Task SubmoduleUpdate( String path )
        {
            await WaitForTortoiseGitCommandAsync( "/command:subupdate /path:\"{0}\" /bkpath:\"{0}\"".XFormat( path ), path );
        }

        public static Task FastSubmoduleUpdate( String path )
        {
            FastSubmoduleUpdateForm.UpdateSubmodules( path );
            return Task.FromResult( true );
        }
    }
}
