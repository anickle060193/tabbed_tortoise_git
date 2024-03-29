﻿using Common;
using log4net;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TabbedTortoiseGit.Properties;

namespace TabbedTortoiseGit
{
    public delegate Task<bool> GitActionFunc( String path );

    public class GitAction
    {
        private static readonly ILog LOG = LogManager.GetLogger( typeof( GitAction ) );

        public static readonly ImmutableDictionary<String, GitAction> ACTIONS = new[]
        {
            new GitAction( "Fetch",                     GitAction.Fetch,                    Resources.Fetch             ),
            new GitAction( "Fast Fetch",                GitAction.FastFetch,                Resources.Fetch             ),
            new GitAction( "Faster Fetch",              GitAction.FasterFetch,              Resources.Fetch             ),
            new GitAction( "Commit",                    GitAction.Commit,                   Resources.Commit            ),
            new GitAction( "Switch/Checkout",           GitAction.Switch,                   Resources.Switch            ),
            new GitAction( "Pull",                      GitAction.Pull,                     Resources.Pull              ),
            new GitAction( "Push",                      GitAction.Push,                     Resources.Push              ),
            new GitAction( "Rebase",                    GitAction.Rebase,                   Resources.Rebase            ),
            new GitAction( "Sync",                      GitAction.Sync,                     Resources.Sync              ),
            new GitAction( "Submodule Update",          GitAction.SubmoduleUpdate,          Resources.SubmoduleUpdate   ),
            new GitAction( "Fast Submodule Update",     GitAction.FastSubmoduleUpdate,      Resources.SubmoduleUpdate   ),
            new GitAction( "Faster Submodule Update",   GitAction.FasterSubmoduleUpdate,    Resources.SubmoduleUpdate   ),
            new GitAction( "Diff",                      GitAction.Diff,                     Resources.Diff              ),
        }.ToImmutableDictionary( command => command.Name );

        private static readonly String[] TORTOISE_GIT_EXES = new[]
        {
            @"C:\Program Files\TortoiseGit\bin\TortoiseGitProc.exe",
            @"C:\Program Files (x86)\TortoiseGit\bin\TortoiseGitProc.exe"
        };
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

        private static String FindTortoiseGitExe()
        {
            if( File.Exists( Settings.Default.TortoiseGitProcExeLocation )
             && Regex.IsMatch( Settings.Default.TortoiseGitProcExeLocation, @"\bTortoiseGitProc\.exe$" ) )
            {
                return Settings.Default.TortoiseGitProcExeLocation;
            }

            foreach( String exe in TORTOISE_GIT_EXES )
            {
                if( File.Exists( exe ) )
                {
                    return exe;
                }
            }

            return TORTOISE_GIT_EXE;
        }

        public static async Task<bool> CanAccessTortoiseGit()
        {
            LOG.Debug( $"{nameof( CanAccessTortoiseGit )}" );

            try
            {
                String exe = FindTortoiseGitExe();
                if( exe != TORTOISE_GIT_EXE )
                {
                    return true;
                }

                Process p = Process.Start( new ProcessStartInfo( "where.exe", exe )
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                } )!;

                await p.WaitForExitAsync();

                LOG.Debug( $"{nameof( CanAccessTortoiseGit )} - Exit Code: {p.ExitCode}" );
                return p.ExitCode == 0;
            }
            catch( Exception e )
            {
                LOG.Error( $"{nameof( CanAccessTortoiseGit )} - Failed to check if TortoiseGit is accessible:", e );
            }

            return false;
        }

        private static async Task<Process> TortoiseGitCommand( String command, String workingDirectory, bool waitForExit = true )
        {
            LOG.Debug( $"{nameof( TortoiseGitCommand )} - Command: {command} - Working Directory: {workingDirectory} - Wait for Exit: {waitForExit}" );
            Process p = Process.Start( new ProcessStartInfo()
            {
                FileName = FindTortoiseGitExe(),
                Arguments = command,
                WorkingDirectory = workingDirectory
            } )!;
            if( waitForExit )
            {
                await p.WaitForExitAsync();
                LOG.Debug( $"{nameof( TortoiseGitCommand )} - Command: {command} - Working Directory: {workingDirectory} - Exit Code: {p.ExitCode}" );
            }
            return p;
        }

        private static async Task<Process> PathCommand( String command, String path, bool waitForExit = true )
        {
            return await TortoiseGitCommand( $"/command:{command} /path:\"{path}\"", path, waitForExit );
        }

        public static Process Log( String path, IEnumerable<String>? references = null )
        {
            String command = $"/command:log /path:\"{path}\"";
            if( references != null )
            {
                String[] refs = references.ToArray();
                if( refs.Length > 0 )
                {
                    command += $" /range:\"{String.Join( " ", refs )}\"";
                }
            }
            return TortoiseGitCommand( command, path, false ).Result;
        }

        public static async Task<bool> Fetch( String path )
        {
            String repo = Git.GetBaseRepoDirectoryOrError( path );
            Process p = await PathCommand( "fetch", repo );
            return p.ExitCode == 0;
        }

        public static async Task<bool> FastFetch( String path )
        {
            String repo = Git.GetBaseRepoDirectoryOrError( path );
            FastFetchDialog dialog = new FastFetchDialog( repo );
            dialog.Show();
            await dialog.WaitForClose();
            return dialog.DialogResult == DialogResult.OK;
        }

        public static Task<bool> FasterFetch( String path )
        {
            String repo = Git.GetBaseRepoDirectoryOrError( path );
            return FastFetchDialog.FasterFetch( repo );
        }

        public static async Task<bool> Commit( String path )
        {
            Process p = await PathCommand( "commit", path );
            return p.ExitCode == 0;
        }

        public static async Task<bool> Switch( String path )
        {
            String repo = Git.GetBaseRepoDirectoryOrError( path );
            Process p = await PathCommand( "switch", repo );
            return p.ExitCode == 0;
        }

        public static async Task<bool> Pull( String path )
        {
            String repo = Git.GetBaseRepoDirectoryOrError( path );
            Process p = await PathCommand( "pull", repo );
            return p.ExitCode == 0;
        }

        public static async Task<bool> Push( String path )
        {
            String repo = Git.GetBaseRepoDirectoryOrError( path );
            Process p = await PathCommand( "push", repo );
            return p.ExitCode == 0;
        }

        public static async Task<bool> Rebase( String path )
        {
            String repo = Git.GetBaseRepoDirectoryOrError( path );
            Process p = await PathCommand( "rebase", repo );
            return p.ExitCode == 0;
        }

        public static async Task<bool> Sync( String path )
        {
            String repo = Git.GetBaseRepoDirectoryOrError( path );
            Process p = await PathCommand( "sync", repo );
            return p.ExitCode == 0;
        }

        public static async Task<bool> SubmoduleUpdate( String path )
        {
            String repo = Git.GetBaseRepoDirectoryOrError( path );
            Process p = await TortoiseGitCommand( $"/command:subupdate /path:\"{repo}\" /bkpath:\"{repo}\"", repo );
            return p.ExitCode == 0;
        }

        public static async Task<bool> FasterSubmoduleUpdate( String path )
        {
            String repo = Git.GetBaseRepoDirectoryOrError( path );
            FasterSubmoduleUpdateDialog dialog = new FasterSubmoduleUpdateDialog( repo );
            dialog.Show();
            await dialog.WaitForClose();
            return dialog.DialogResult == DialogResult.OK;
        }

        public static async Task<bool> FastSubmoduleUpdate( String path )
        {
            String repo = Git.GetBaseRepoDirectoryOrError( path );
            FastSubmoduleUpdateDialog dialog = new FastSubmoduleUpdateDialog( repo );
            dialog.Show();
            await dialog.WaitForClose();
            return dialog.DialogResult == DialogResult.OK;
        }

        public static async Task<bool> Diff( String path )
        {
            await TortoiseGitCommand( $"/command:diff /path:\"{path}\"", path );
            return false;
        }
    }
}
