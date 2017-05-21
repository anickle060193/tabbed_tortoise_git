using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabs
{
    static class Extensions
    {
        public static void MoveTo( this GraphicsPath path, int x, int y )
        {
            path.StartFigure();
            path.AddLine( x, y, x, y );
        }

        public static void LineTo( this GraphicsPath path, int x, int y )
        {
            PointF last = path.GetLastPoint();
            path.AddLine( last.X, last.Y, (float)x, (float)y );
        }
    }
}
