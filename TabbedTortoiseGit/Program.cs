using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabbedTortoiseGit
{
    static class Program
    {
        static Mutex _mutex = new Mutex( true, "{fa53bc4a-ae04-444f-9c4e-0cf94346e62e}" );

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [ STAThread]
        static void Main()
        {
            if( _mutex.WaitOne( TimeSpan.Zero, true ) )
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault( false );
                Application.Run( new TabbedTortoiseGitForm() );
                _mutex.ReleaseMutex();
            }
            else
            {
                Native.PostMessage( (IntPtr)Native.HWND_BROADCAST, Native.WM_SHOWME, IntPtr.Zero, IntPtr.Zero );
            }
        }
    }
}
