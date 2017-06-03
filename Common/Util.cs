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
        public static String NormalizePath( String path )
        {
            return Path.GetFullPath( new Uri( path ).LocalPath ).TrimEnd( Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar );
        }

        public static bool OpenInExplorer( String path )
        {
            if( Directory.Exists( path ) )
            {
                Process.Start( "explorer.exe", "\"{0}\"".XFormat( path ) );
                return true;
            }
            else if( File.Exists( path ) )
            {
                Process.Start( "explorer.exe", "/select, \"{0}\"".XFormat( path ) );
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
