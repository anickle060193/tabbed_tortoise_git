using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
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

        public static Bitmap ColorBitmap( Bitmap icon, Color color )
        {
            Bitmap colorIcon = new Bitmap( icon );
            using( Graphics g = Graphics.FromImage( colorIcon ) )
            {
                ImageAttributes attributes = new ImageAttributes();

                float redScale = color.R / 255.0f;
                float greenScale = color.G / 255.0f;
                float blueScale = color.B / 255.0f;

                float[][] matrix =
                {
                    new float[] { 1, 0, 0, 0, 0 },
                    new float[] { 0, 1, 0, 0, 0 },
                    new float[] { 0, 0, 1, 0, 0 },
                    new float[] { 0, 0, 0, 1, 0 },
                    new float[] { redScale, greenScale, blueScale, 0, 1 }
                };

                attributes.SetColorMatrix( new ColorMatrix( matrix ), ColorMatrixFlag.Default, ColorAdjustType.Bitmap );

                g.DrawImage( icon, new Rectangle( 0, 0, icon.Width, icon.Height ), 0, 0, icon.Width, icon.Height, GraphicsUnit.Pixel, attributes );
            }
            return colorIcon;
        }
    }
}
