using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace TabbedTortoiseGit
{
    static class ProcessHelper
    {
        private static readonly ILog LOG = LogManager.GetLogger( typeof( TabbedTortoiseGitForm ) );

        public static void KillProcessTree( Process p )
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher( $"SELECT * FROM Win32_Process WHERE ParentProcessID={p.Id}" );
                ManagementObjectCollection moc = searcher.Get();
                foreach( ManagementObject mo in moc )
                {
                    int pid = Convert.ToInt32( mo[ "ProcessID" ] );
                    Process child = Process.GetProcessById( pid );
                    KillProcessTree( child );
                }
            }
            catch( Exception e )
            {
                LOG.Error( $"Failed to retrieve child processes for Process {p.Id}", e );
            }

            try
            {
                if( !p.HasExited )
                {
                    p.Kill();
                }
            }
            catch( Exception e )
            {
                LOG.Error( $"Failed to kill Process {p.Id}", e );
            }
        }
    }
}
