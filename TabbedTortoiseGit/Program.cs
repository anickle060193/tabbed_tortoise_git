using CommandLine;
using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tabs;

namespace TabbedTortoiseGit
{
    static class Program
    {
        private static readonly ILog LOG = LogManager.GetLogger( typeof( Program ) );

        private static readonly Mutex _mutex = new Mutex( true, "{fa53bc4a-ae04-444f-9c4e-0cf94346e62e}" );

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main( String[] args )
        {
            LOG.Debug( $"Application Startup - Args: {String.Join( ", ", args )}" );
            LOG.Debug( $"Version: {Assembly.GetExecutingAssembly().GetName().Version}" );

            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            if( !TTG.VerifyAssemblyVersions() )
            {
                return 1;
            }

            Parser.Default.ParseArguments<CommitInstallArguments, DefaultArguments>( args )
                .WithParsed<CommitInstallArguments>( ( args ) =>
                {
                    var exe = TTG.GetExe();
                    LOG.Debug( $"Starting application after install: {exe}" );
                    Process.Start( exe );
                } )
                .WithParsed<DefaultArguments>( ( a ) =>
                {
                    if( _mutex.WaitOne( TimeSpan.Zero, true ) )
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault( false );

                        LOG.Debug( "Starting Tabbed TortoiseGit" );
                        Application.Run( ProgramForm.Create( a.Startup ) );
                        _mutex.ReleaseMutex();
                    }
                    else
                    {
                        LOG.Debug( "Tabbed TortoiseGit instance already exists" );
                        Native.PostMessage( (IntPtr)Native.HWND_BROADCAST, ProgramForm.WM_SHOWME, IntPtr.Zero, IntPtr.Zero );
                    }
                } )
                .WithNotParsed( ( errors ) =>
                {
                    LOG.Error( "Invalid command line arguments:" + String.Join( "", errors.Select( ( e ) => $"\n\t{e}: {e.Tag}" ) ) );
                } );

            LOG.Debug( "Application End" );
            return 0;
        }

        private static void CurrentDomain_UnhandledException( object? sender, UnhandledExceptionEventArgs e )
        {
            LOG.Fatal( "AppDomain UnhandledException Occurred", (Exception)e.ExceptionObject );

            HandleConfigurationException( (Exception)e.ExceptionObject );
        }

        private static void Application_ThreadException( object? sender, ThreadExceptionEventArgs e )
        {
            LOG.Fatal( "Application ThreadException Occurred", e.Exception );

            HandleConfigurationException( e.Exception );
        }

        private static void HandleConfigurationException( Exception e )
        {
            if( e is System.Configuration.ConfigurationException )
            {
                if( e.InnerException is System.Configuration.ConfigurationException ex )
                {
                    MessageBox.Show( $"Failed to read settings: '{ex.Filename}'. Fix/delete invalid settings file and restart Tabbed TortoiseGit.\n{ex.Message}", "An error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
        }
    }
}
