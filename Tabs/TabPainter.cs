using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabs
{
    internal class TabPainter
    {
        private static readonly int TAB_HEIGHT = 28;
        private static readonly double TAB_INCLINE_ANGLE = 65 * ( Math.PI ) / 180;
        private static readonly int BOTTOM_BORDER_HEIGHT = 4;

        private static readonly int NEW_TAB_BUTTON_WIDTH = 28;
        private static readonly float NEW_TAB_HEIGHT_PERCENTAGE = 0.65f;

        private int _tabOverlapWidth;
        private readonly GraphicsPath _tabGraphicsPath = new GraphicsPath();
        private readonly GraphicsPath _newTabGraphicsPath = new GraphicsPath();

        public TabControl Owner { get; private set; }

        public TabPainter( TabControl tabControl )
        {
            Owner = tabControl;

            CreateBaseTabDrawPath();
            CreateNewTabButtonPath();
        }

        public GraphicsPath GetTabGraphicsPath( int index )
        {
            return CreateTabDrawPath( index );
        }

        public GraphicsPath GetNewTabGraphicsPath()
        {
            return _newTabGraphicsPath;
        }

        public Rectangle GetTabPanelBounds()
        {
            int y = TAB_HEIGHT + BOTTOM_BORDER_HEIGHT;
            Size clientSize = this.Owner.ClientSize;
            return new Rectangle( 0, y, clientSize.Width, clientSize.Height );
        }

        public void Paint( Graphics g )
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.Clear( SystemColors.ControlLightLight );

            CreateBaseTabDrawPath();
            for( int i = this.Owner.TabCount - 1; i >= 0; i-- )
            {
                if( i != this.Owner.SelectedIndex )
                {
                    PaintTab( g, this.Owner.Tabs[ i ], i, false );
                }
            }

            if( this.Owner.SelectedTab != null )
            {
                PaintTab( g, this.Owner.SelectedTab, this.Owner.SelectedIndex, true );
            }

            PaintBottomBorder( g );

            PaintNewTab( g );
        }

        private void CreateBaseTabDrawPath()
        {
            int tabInclineWidth = (int)( TAB_HEIGHT / Math.Tan( TAB_INCLINE_ANGLE ) );
            _tabOverlapWidth = tabInclineWidth / 2;

            int tabAreaWidth = this.Owner.Width - (int)_newTabGraphicsPath.GetBounds().Width - 2 * _tabOverlapWidth;
            int tabWidth = this.Owner.MaximumTabWidth;
            if( this.Owner.TabCount == 0 )
            {
                tabWidth = Math.Min( tabWidth, tabAreaWidth );
            }
            else
            {
                tabWidth = Math.Min( tabWidth, (int)( (float)tabAreaWidth / this.Owner.TabCount ) + _tabOverlapWidth );
            }

            int bY = TAB_HEIGHT;
            int tY = 0;
            int blX = _tabOverlapWidth;
            int tlX = blX + tabInclineWidth;
            int brX = blX + tabWidth;
            int trX = brX - tabInclineWidth;

            _tabGraphicsPath.Reset();
            _tabGraphicsPath.AddLine( blX, bY, tlX, tY );
            _tabGraphicsPath.AddLine( tlX, tY, trX, tY );
            _tabGraphicsPath.AddLine( trX, tY, brX, bY );
        }

        private GraphicsPath CreateTabDrawPath( int index )
        {
            float tabWidth = _tabGraphicsPath.GetBounds().Width;

            Matrix m = new Matrix();
            m.Translate( ( tabWidth - 2 * _tabOverlapWidth ) * index, 0 );

            GraphicsPath p = (GraphicsPath)_tabGraphicsPath.Clone();
            p.Transform( m );
            return p;
        }

        private void PaintTab( Graphics g, Tab t, int index, bool selected )
        {
            GraphicsPath path = CreateTabDrawPath( index );

            RectangleF bounds = path.GetBounds();
            if( selected )
            {
                using( Brush b = new SolidBrush( this.Owner.SelectedTabColor ) )
                {
                    g.FillPath( b, path );
                }
                using( Pen p = new Pen( this.Owner.TabBorderColor ) )
                {
                    g.DrawPath( p, path );
                }
            }
            else
            {
                using( Brush b = new SolidBrush( this.Owner.TabColor ) )
                {
                    g.FillPath( b, path );
                }
                using( Pen p = new Pen( this.Owner.TabBorderColor ) )
                {
                    g.DrawPath( p, path );
                }
            }

            SizeF size = g.MeasureString( t.Text, this.Owner.Font );
            float sX = bounds.Left + ( bounds.Width - size.Width ) / 2;
            float sY = bounds.Top + ( bounds.Height - size.Height ) / 2;
            using( SolidBrush b = new SolidBrush( this.Owner.ForeColor ) )
            {
                Region oldClip = g.Clip;
                g.Clip = new Region( path );
                g.DrawString( t.Text, this.Owner.Font, b, sX, sY );
                g.Clip = oldClip;
            }
        }

        private void CreateNewTabButtonPath()
        {
            RectangleF lastTabRect = CreateTabDrawPath( this.Owner.TabCount - 1 ).GetBounds();

            int h = (int)( TAB_HEIGHT * NEW_TAB_HEIGHT_PERCENTAGE );
            int tY = ( TAB_HEIGHT - h ) / 2;
            int bY = tY + h;

            int tabInclineWidth = (int)( h / Math.Tan( TAB_INCLINE_ANGLE ) );

            int tlX = (int)lastTabRect.Right - 3;
            int trX = tlX + NEW_TAB_BUTTON_WIDTH;
            int blX = tlX + tabInclineWidth;
            int brX = blX + NEW_TAB_BUTTON_WIDTH;

            _newTabGraphicsPath.Reset();
            _newTabGraphicsPath.MoveTo( blX, bY );
            _newTabGraphicsPath.LineTo( tlX, tY );
            _newTabGraphicsPath.LineTo( trX, tY );
            _newTabGraphicsPath.LineTo( brX, bY );
            _newTabGraphicsPath.CloseFigure();
        }

        private void PaintNewTab( Graphics g )
        {
            CreateNewTabButtonPath();
            RectangleF bounds = _newTabGraphicsPath.GetBounds();

            using( Brush b = new SolidBrush( this.Owner.TabColor ) )
            {
                g.FillPath( b, _newTabGraphicsPath );
            }
            using( Pen p = new Pen( this.Owner.TabBorderColor ) )
            {
                g.DrawPath( SystemPens.ControlDark, _newTabGraphicsPath );
            }

            SizeF size = g.MeasureString( "+", this.Owner.Font );
            float sX = bounds.Left + ( bounds.Width - size.Width ) / 2;
            float sY = bounds.Top + ( bounds.Height - size.Height ) / 2;
            using( SolidBrush b = new SolidBrush( this.Owner.ForeColor ) )
            {
                g.DrawString( "+", this.Owner.Font, b, sX, sY );
            }
        }

        private void PaintBottomBorder( Graphics g )
        {
            int bY = TAB_HEIGHT;
            PointF left = new PointF( 0.0f, bY );
            PointF right = new PointF( this.Owner.Width, bY );

            using( Brush b = new SolidBrush( this.Owner.SelectedTabColor ) )
            {
                g.FillRectangle( b, 0, bY, this.Owner.Width, this.Owner.Height - bY );
            }

            if( this.Owner.SelectedIndex != -1 )
            {
                GraphicsPath tabPath = CreateTabDrawPath( this.Owner.SelectedIndex );
                RectangleF tabBounds = tabPath.GetBounds();
                using( Pen p = new Pen( this.Owner.TabBorderColor ) )
                {
                    g.DrawLines( p, new[] { left, new PointF( tabBounds.Left, bY ) } );
                    g.DrawLines( p, new[] { new PointF( tabBounds.Right, bY ), right } );
                }
            }
            else
            {
                using( Pen p = new Pen( this.Owner.TabBorderColor ) )
                {
                    g.DrawLines( p, new[] { left, right } );
                }
            }
        }
    }
}
