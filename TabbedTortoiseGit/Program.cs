using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabbedTortoiseGit
{
    static class Program
    {
        private static ILog LOG = LogManager.GetLogger( typeof( Program ) );

        private static Mutex _mutex = new Mutex( true, "{fa53bc4a-ae04-444f-9c4e-0cf94346e62e}" );

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main( String[] args )
        {
            LOG.DebugFormat( "Application Startup - Args: {0}", args );
            LOG.DebugFormat( "Version: {0}", Assembly.GetExecutingAssembly().GetName().Version );

            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Arguments a = new Arguments();
            if( CommandLine.Parser.Default.ParseArguments( args, a ) )
            {
                if( _mutex.WaitOne( TimeSpan.Zero, true ) )
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault( false );

                    LOG.Debug( "Starting Tabbed TortoiseGit" );
                    TabbedTortoiseGitForm f = new TabbedTortoiseGitForm();
                    if( !a.Startup )
                    {
                        f.Show();
                    }
                    Application.Run();
                    _mutex.ReleaseMutex();
                }
                else
                {
                    LOG.Debug( "Tabbed TortoiseGit instance already exists" );
                    Native.PostMessage( (IntPtr)Native.HWND_BROADCAST, Native.WM_SHOWME, IntPtr.Zero, IntPtr.Zero );
                }
            }

            LOG.Debug( "Application End" );
        }

        private static void CurrentDomain_UnhandledException( object sender, UnhandledExceptionEventArgs e )
        {
            LOG.Fatal( "AppDomain UnhandledException Occurred", (Exception)e.ExceptionObject );
        }

        private static void Application_ThreadException( object sender, ThreadExceptionEventArgs e )
        {
            LOG.Fatal( "Application ThreadException Occurred", e.Exception );
        }
    }
}
