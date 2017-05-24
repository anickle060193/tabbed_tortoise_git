using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TabbedTortoiseGit
{
    static class TTG
    {
        public static bool RunOnStartup
        {
            get
            {
                using( RegistryKey run = Registry.CurrentUser.OpenSubKey( @"Software\Microsoft\Windows\CurrentVersion\Run", false ) )
                {
                    return run.GetValue( "Tabbed TortoiseGit" ) != null;
                }
            }

            set
            {
                using( RegistryKey run = Registry.CurrentUser.OpenSubKey( @"Software\Microsoft\Windows\CurrentVersion\Run", true ) )
                {
                    if( value )
                    {
                        String exe = new Uri( Assembly.GetExecutingAssembly().CodeBase ).LocalPath;
                        run.SetValue( "Tabbed TortoiseGit", "\"{0}\" --startup".XFormat( exe ) );
                    }
                    else
                    {
                        run.DeleteValue( "Tabbed TortoiseGit" );
                    }
                }
            }
        }
    }
}
