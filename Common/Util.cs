using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Util
    {
        private static readonly ILog LOG = LogManager.GetLogger( typeof( Util ) );

        public static String NormalizePath( String path )
        {
            return Path.GetFullPath( new Uri( path ).LocalPath ).TrimEnd( Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar );
        }

        public static bool OpenInExplorer( String path )
        {
            if( Directory.Exists( path ) )
            {
                LOG.DebugFormat( "OpenInExplorer - Directroy: {0}", path );

                Process.Start( "explorer.exe", "\"{0}\"".XFormat( path ) );
                return true;
            }
            else if( File.Exists( path ) )
            {
                LOG.DebugFormat( "OpenInExplorer - File: {0}", path );

                Process.Start( "explorer.exe", "/select, \"{0}\"".XFormat( path ) );
                return true;
            }
            else
            {
                LOG.ErrorFormat( "OpenInExplorer - Not a file or directroy - Path: {0}", path );

                return false;
            }
        }
    }
}
