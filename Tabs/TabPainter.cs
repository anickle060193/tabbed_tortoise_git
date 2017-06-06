using Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tabs
{
    internal class TabPainter
    {
        private static readonly int TAB_HEIGHT = 26;
        private static readonly double TAB_INCLINE_ANGLE = 65 * ( Math.PI ) / 180;
        private static readonly int BOTTOM_BORDER_HEIGHT = 4;
        private static readonly int TOP_PADDING = 1;
        private static readonly int LEFT_PADDING = 6;
        private static readonly int RIGHT_PADDING = 6;

        private static readonly int NEW_TAB_BUTTON_WIDTH = 32;
        private static readonly float NEW_TAB_HEIGHT_PERCENTAGE = 0.65f;

        private static readonly int OPTIONS_MENU_BUTTON_WIDTH = 24;
        private static readonly float OPTIONS_MENU_BUTTON_HEIGHT_PERCENTAGE = 0.90f;

        public Point OptionsMenuLocation
        {
            get
            {
                int x = this.Owner.Width - this.Owner.OptionsMenu.Width;
                int y = TOP_PADDING + TAB_HEIGHT;
                return new Point( x, y );
            }
        }

        public TabControl Owner { get; private set; }

        public TabPainter( TabControl tabControl )
        {
            Owner = tabControl;
        }

        public PointPath GetTabPath( int index )
        {
            Tab tab = this.Owner.Tabs[ index ];

            int tabInclineWidth = (int)( TAB_HEIGHT / Math.Tan( TAB_INCLINE_ANGLE ) );
            int tabOverlapWidth = tabInclineWidth / 2;

            int tabAreaWidth = this.Owner.Width - LEFT_PADDING - NEW_TAB_BUTTON_WIDTH - RIGHT_PADDING;
            if( this.Owner.OptionsMenu != null )
            {
                tabAreaWidth -= OPTIONS_MENU_BUTTON_WIDTH + RIGHT_PADDING;
            }

            int tabWidth = this.Owner.MaximumTabWidth;
            if( this.Owner.TabCount == 0 )
            {
                tabWidth = Math.Min( tabWidth, tabAreaWidth );
            }
            else
            {
                tabWidth = Math.Min( tabWidth, (int)( (float)tabAreaWidth / this.Owner.TabCount ) + tabOverlapWidth );
            }

            int blX;
            if( tab.Dragging )
            {
                blX = tab.DraggingX - tab.DraggingOffset;
                blX = Math.Max( LEFT_PADDING, blX );
                blX = Math.Min( blX, LEFT_PADDING + tabAreaWidth - tabWidth - RIGHT_PADDING );
            }
            else
            {
                blX = LEFT_PADDING + ( tabWidth - 2 * tabOverlapWidth ) * index;
            }
            int tlX = blX + tabInclineWidth;
            int brX = blX + tabWidth;
            int trX = brX - tabInclineWidth;
            int tY = TOP_PADDING;
            int bY = tY + TAB_HEIGHT;

            return new PointPath( new[]{
                new Point( blX, bY ),
                new Point( tlX, tY ),
                new Point( trX, tY ),
                new Point( brX, bY )
            } );
        }

        public PointPath GetNewTabPath()
        {
            int left = LEFT_PADDING;
            if( this.Owner.TabCount > 0 )
            {
                left = GetTabPath( this.Owner.TabCount - 1 ).Bounds.Right;
            }

            int h = (int)( TAB_HEIGHT * NEW_TAB_HEIGHT_PERCENTAGE );
            int tY = TOP_PADDING + ( TAB_HEIGHT - h ) / 2;
            int bY = tY + h;

            int tabInclineWidth = (int)( h / Math.Tan( TAB_INCLINE_ANGLE ) );

            int tlX = left;
            int blX = tlX + tabInclineWidth;
            int brX = tlX + NEW_TAB_BUTTON_WIDTH;
            int trX = brX - tabInclineWidth;

            return new PointPath( new[]
            {
                new Point( blX, bY ),
                new Point( tlX, tY ),
                new Point( trX, tY ),
                new Point( brX, bY )
            } );
        }

        public PointPath GetOptionsPath()
        {
            int height = (int)( TAB_HEIGHT * OPTIONS_MENU_BUTTON_HEIGHT_PERCENTAGE );
            int right = this.Owner.Width - RIGHT_PADDING;
            int left = right - OPTIONS_MENU_BUTTON_WIDTH;
            int top = TOP_PADDING + ( TAB_HEIGHT - height ) / 2;
            int bottom = top + height;

            return new PointPath( new[]
            {
                new Point( left, top ),
                new Point( right, top ),
                new Point( right, bottom ),
                new Point( left, bottom )
            } );
        }

        public Rectangle GetTabPanelBounds()
        {
            int y = TOP_PADDING + TAB_HEIGHT + BOTTOM_BORDER_HEIGHT;
            Size clientSize = this.Owner.ClientSize;
            return new Rectangle( 0, y, clientSize.Width, clientSize.Height - y );
        }

        public void Paint( Graphics g )
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.Clear( SystemColors.ControlLightLight );

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

            if( this.Owner.OptionsMenu != null )
            {
                PaintOptionsMenuButton( g );
            }
        }

        private void PaintTab( Graphics g, Tab t, int index, bool selected )
        {
            PointPath path = GetTabPath( index );

            Color tabColor = selected ? this.Owner.SelectedTabColor : this.Owner.TabColor;

            if( ( !selected || this.Owner.ShowHitTest )
             && this.Owner.Focused
             && path.HitTest( this.Owner.PointToClient( Control.MousePosition ) ) )
            {
                if( this.Owner.ShowHitTest )
                {
                    tabColor = Color.LightBlue;
                }
                else
                {
                    tabColor = ControlPaint.Light( tabColor, 0.60f );
                }
            }

            using( Brush b = new SolidBrush( tabColor ) )
            {
                g.FillPointPath( b, path );
                using( Pen bp = new Pen( b ) )
                {
                    g.DrawPointPath( bp, path, true );
                }
            }

            using( Pen p = new Pen( this.Owner.TabBorderColor ) )
            {
                g.DrawPointPath( p, path, false );
            }

            using( SolidBrush b = new SolidBrush( t.ForeColor ) )
            {
                bool isPath = t.Text.Contains( Path.DirectorySeparatorChar ) || t.Text.Contains( Path.AltDirectorySeparatorChar );
                StringFormat f = new StringFormat( StringFormatFlags.NoWrap )
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center,
                    Trimming = isPath ? StringTrimming.EllipsisPath : StringTrimming.EllipsisWord
                };
                g.DrawString( t.Text, t.Font, b, path.MinimumBounds, f );
            }
        }

        private void PaintNewTab( Graphics g )
        {
            PointPath newTabPath = GetNewTabPath();
            Rectangle bounds = newTabPath.Bounds;

            Color newTabButtonColor = this.Owner.TabColor;

            if( this.Owner.Focused
             && newTabPath.HitTest( this.Owner.PointToClient( Control.MousePosition ) ) )
            {
                if( this.Owner.ShowHitTest )
                {
                    newTabButtonColor = Color.LightBlue;
                }
                else
                {
                    newTabButtonColor = ControlPaint.Light( newTabButtonColor, 0.5f );
                }
            }

            using( Brush b = new SolidBrush( newTabButtonColor ) )
            {
                g.FillPointPath( b, newTabPath );
            }
            using( Pen p = new Pen( this.Owner.TabBorderColor ) )
            {
                g.DrawPointPath( p, newTabPath, true );
            }
            
            using( SolidBrush b = new SolidBrush( this.Owner.ForeColor ) )
            {
                StringFormat f = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString( "+", this.Owner.Font, b, newTabPath.MinimumBounds, f );
            }
        }

        private void PaintOptionsMenuButton( Graphics g )
        {
            PointPath path = GetOptionsPath();

            Color background = Color.Transparent;

            if( this.Owner.Focused
             && path.HitTest( this.Owner.PointToClient( Control.MousePosition ) ) )
            {
                if( this.Owner.ShowHitTest )
                {
                    background = Color.LightBlue;
                }
                else
                {
                    background = Color.FromArgb( 222, 222, 222 );
                }
            }

            using( SolidBrush b = new SolidBrush( background ) )
            {
                g.FillPointPath( b, path );
            }

            using( SolidBrush b = new SolidBrush( Color.FromArgb( 60, 60, 60 ) ) )
            {
                float radius = 1.5f;
                float x = path.Bounds.Left + path.Bounds.Width / 2.0f;
                float midY = path.Bounds.Top + path.Bounds.Height / 2.0f;
                float topY = midY - 2 * radius - 2;
                float botY = midY + 2 * radius + 2;

                g.FillCircle( b, x, topY, radius );
                g.FillCircle( b, x, midY, radius );
                g.FillCircle( b, x, botY, radius );
            }
        }

        private void PaintBottomBorder( Graphics g )
        {
            int bY = TOP_PADDING + TAB_HEIGHT;
            Point left = new Point( 0, bY );
            Point right = new Point( this.Owner.Width, bY );

            using( Brush b = new SolidBrush( this.Owner.SelectedTabColor ) )
            {
                g.FillRectangle( b, 0, bY, this.Owner.Width, this.Owner.Height - bY );
            }

            if( this.Owner.SelectedIndex != -1 )
            {
                Rectangle tabBounds = GetTabPath( this.Owner.SelectedIndex ).Bounds;
                using( Pen p = new Pen( this.Owner.TabBorderColor ) )
                {
                    g.DrawLines( p, new[] { left, new Point( tabBounds.Left, bY ) } );
                    g.DrawLines( p, new[] { new Point( tabBounds.Right, bY ), right } );
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
