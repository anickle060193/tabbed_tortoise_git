using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabbedTortoiseGit
{
    public static class Util
    {
        public static String NormalizePath( String path )
        {
            return Path.GetFullPath( new Uri( path ).LocalPath ).TrimEnd( Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar );
        }
    }
}
