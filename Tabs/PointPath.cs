using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabs
{
    public class PointPath
    {
        private readonly Point[] _points;
        private readonly Rectangle _bounds;
        private readonly Rectangle _minimumBounds;

        public Point[] Points { get { return _points; } }

        public Rectangle Bounds { get { return _bounds; } }
        public Rectangle MinimumBounds { get { return _minimumBounds; } }

        public PointPath( IEnumerable<Point> points )
        {
            _points = points.ToArray();

            int minX = int.MaxValue;
            int minY = int.MaxValue;
            int maxX = int.MinValue;
            int maxY = int.MinValue;
            foreach( Point p in _points )
            {
                minX = Math.Min( minX, p.X );
                minY = Math.Min( minY, p.Y );
                maxX = Math.Max( maxX, p.X );
                maxY = Math.Max( maxY, p.Y );
            }
            _bounds = new Rectangle( minX, minY, maxX - minX, maxY - minY );

            int averageX = (int)_points.Average( p => p.X );
            int averageY = (int)_points.Average( p => p.Y );

            int leftX = int.MinValue;
            int topY = int.MinValue;
            int rightX = int.MaxValue;
            int bottomY = int.MaxValue;

            foreach( Point p in _points )
            {
                if( p.X < averageX && p.X > leftX )
                {
                    leftX = p.X;
                }
                else if( p.X > averageX && p.X < rightX )
                {
                    rightX = p.X;
                }

                if( p.Y < averageY && p.Y > topY )
                {
                    topY = p.Y;
                }
                else if( p.Y > averageY && p.Y < bottomY )
                {
                    bottomY = p.Y;
                }
            }

            _minimumBounds = new Rectangle( leftX, topY, rightX - leftX, bottomY - topY );
        }

        public bool HitTest( Point p )
        {
            // From http://alienryderflex.com/polygon/

            bool oddNodes = false;

            for( int i = 0, j = _points.Length - 1; i < _points.Length; i++ )
            {
                if( ( _points[ i ].Y < p.Y && _points[ j ].Y >= p.Y
                   || _points[ j ].Y < p.Y && _points[ i ].Y >= p.Y )
                 && ( _points[ i ].X <= p.X
                   || _points[ j ].X <= p.X ) )
                {
                    oddNodes ^= ( _points[ i ].X + (float)( p.Y - _points[ i ].Y ) / ( _points[ j ].Y - _points[ i ].Y ) * ( _points[ j ].X - _points[ i ].X ) < p.X );
                }
                j = i;
            }

            return oddNodes;
        }

        public PointPath Offset( int x, int y )
        {
            return new PointPath( _points.Select( p => new Point( p.X + x, p.Y + y ) ) );
        }
    }

    public static class PointPathExtensions
    {
        public static void FillPointPath( this Graphics graphics, Brush brush, PointPath pointPath )
        {
            graphics.FillPolygon( brush, pointPath.Points );
        }

        public static void DrawPointPath( this Graphics graphics, Pen pen, PointPath pointPath, bool closed )
        {
            if( closed )
            {
                graphics.DrawPolygon( pen, pointPath.Points );
            }
            else
            {
                graphics.DrawLines( pen, pointPath.Points );
            }
        }
    }
}
