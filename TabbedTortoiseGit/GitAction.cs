﻿using Common;
using log4net;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TabbedTortoiseGit.Properties;

namespace TabbedTortoiseGit
{
    public delegate Task<bool> GitActionFunc( String path );

    public class GitAction
    {
        private static readonly ILog LOG = LogManager.GetLogger( typeof( GitAction ) );

        public static readonly ImmutableDictionary<String, GitAction> ACTIONS;
        static GitAction()
        {
            ACTIONS = new []
            {
                new GitAction( "Fetch",                 GitAction.Fetch,                Resources.Fetch             ),
                new GitAction( "Fast Fetch",            GitAction.FastFetch,            Resources.Fetch             ),
                new GitAction( "Faster Fetch",          GitAction.FasterFetch,          Resources.Fetch             ),
                new GitAction( "Commit",                GitAction.Commit,               Resources.Commit            ),
                new GitAction( "Switch/Checkout",       GitAction.Switch,               Resources.Switch            ),
                new GitAction( "Pull",                  GitAction.Pull,                 Resources.Pull              ),
                new GitAction( "Push",                  GitAction.Push,                 Resources.Push              ),
                new GitAction( "Rebase",                GitAction.Rebase,               Resources.Rebase            ),
                new GitAction( "Sync",                  GitAction.Sync,                 Resources.Sync              ),
                new GitAction( "Submodule Update",      GitAction.SubmoduleUpdate,      Resources.SubmoduleUpdate   ),
                new GitAction( "Fast Submodule Update", GitAction.FastSubmoduleUpdate,  Resources.SubmoduleUpdate   )
            }.ToImmutableDictionary( command => command.Name );
        }

        private static readonly String TORTOISE_GIT_EXE = "TortoiseGitProc.exe";

        public String Name { get; private set; }
        public GitActionFunc Func { get; private set; }
        public Image Icon { get; private set; }

        private GitAction( String name, GitActionFunc func, Image icon )
        {
            Name = name;
            Func = func;
            Icon = icon;
        }

        private static async Task<Process> TortoiseGitCommand( String command, String workingDirectory, bool waitForExit = true )
        {
            LOG.DebugFormat( "TortoiseGitCommand - Command: {0} - Working Directory: {1} - Wait for Exit: {2}", command, workingDirectory, waitForExit );
            Process p = Process.Start( new ProcessStartInfo()
            {
                FileName = TORTOISE_GIT_EXE,
                Arguments = command,
                WorkingDirectory = workingDirectory
            } );
            if( waitForExit )
            {
                await Task.Run( () => p.WaitForExit() );
                LOG.DebugFormat( "TortoiseGitCommand - Command: {0} - Working Directory: {1} - Exit Code: {2}", command, workingDirectory, p.ExitCode );
            }
            return p;
        }

        private static async Task<Process> PathCommand( String command, String path, bool waitForExit = true )
        {
            return await TortoiseGitCommand( "/command:{0} /path:\"{1}\"".XFormat( command, path ), path, waitForExit );
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
            return TortoiseGitCommand( command, path, false ).Result;
        }

        public static async Task<bool> Fetch( String path )
        {
            Process p = await PathCommand( "fetch", path );
            return p.ExitCode == 0;
        }

        public static async Task<bool> FastFetch( String path )
        {
            FastFetchDialog dialog = new FastFetchDialog( path );
            dialog.Show();
            await dialog.WaitForClose();
            return dialog.DialogResult == DialogResult.OK;
        }

        public static Task<bool> FasterFetch( String path )
        {
            return FastFetchDialog.FasterFetch( path );
        }

        public static async Task<bool> Commit( String path )
        {
            Process p = await PathCommand( "commit", path );
            return p.ExitCode == 0;
        }

        public static async Task<bool> Switch( String path )
        {
            Process p = await PathCommand( "switch", path );
            return p.ExitCode == 0;
        }

        public static async Task<bool> Pull( String path )
        {
            Process p = await PathCommand( "pull", path );
            return p.ExitCode == 0;
        }

        public static async Task<bool> Push( String path )
        {
            Process p = await PathCommand( "push", path );
            return p.ExitCode == 0;
        }

        public static async Task<bool> Rebase( String path )
        {
            Process p = await PathCommand( "rebase", path );
            return p.ExitCode == 0;
        }

        public static async Task<bool> Sync( String path )
        {
            Process p = await PathCommand( "sync", path );
            return p.ExitCode == 0;
        }

        public static async Task<bool> SubmoduleUpdate( String path )
        {
            Process p = await TortoiseGitCommand( "/command:subupdate /path:\"{0}\" /bkpath:\"{0}\"".XFormat( path ), path );
            return p.ExitCode == 0;
        }

        public static async Task<bool> FastSubmoduleUpdate( String path )
        {
            FastSubmoduleUpdateDialog dialog = new FastSubmoduleUpdateDialog( path );
            dialog.Show();
            await dialog.WaitForClose();
            return dialog.DialogResult == DialogResult.OK;
        }
    }
}