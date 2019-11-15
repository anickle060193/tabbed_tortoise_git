using log4net;
using System;
using System.Collections.Generic;
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
        private static ILog LOG = LogManager.GetLogger( typeof( Program ) );

        private static readonly Mutex _mutex = new Mutex( true, "{fa53bc4a-ae04-444f-9c4e-0cf94346e62e}" );

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main( String[] args )
        {
            LOG.Debug( $"Application Startup - Args: {String.Join( ", ", args )}" );
            LOG.Debug( $"Version: {Assembly.GetExecutingAssembly().GetName().Version}" );

            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            if( !TTG.VerifyAssemblyVersions() )
            {
                return;
            }

            Arguments a = new Arguments();
            if( CommandLine.Parser.Default.ParseArguments( args, a ) )
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
            }

            LOG.Debug( "Application End" );
        }

        private static void CurrentDomain_UnhandledException( object sender, UnhandledExceptionEventArgs e )
        {
            LOG.Fatal( "AppDomain UnhandledException Occurred", (Exception)e.ExceptionObject );

            HandleConfigurationException( (Exception)e.ExceptionObject );
        }

        private static void Application_ThreadException( object sender, ThreadExceptionEventArgs e )
        {
            LOG.Fatal( "Application ThreadException Occurred", e.Exception );

            HandleConfigurationException( e.Exception );
        }

        private static void HandleConfigurationException( Exception e )
        {
            if( e is System.Configuration.ConfigurationException )
            {
                if( e.InnerException is System.Configuration.ConfigurationException )
                {
                    var ex = (System.Configuration.ConfigurationException)e.InnerException;
                    MessageBox.Show( $"Failed to read settings: '{ex.Filename}'. Fix/delete invalid settings file and restart Tabbed TortoiseGit.\n{ex.Message}", "An error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
        }
    }
}
