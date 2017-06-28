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
        private const int TOP_PADDING = 1;
        private const int LEFT_PADDING = 6;
        private const int RIGHT_PADDING = 6;

        private const int TAB_HEIGHT = 26;
        private const double TAB_INCLINE_ANGLE = 65 * ( Math.PI ) / 180;

        private const int TAB_ICON_PADDING = 3;
        private const int TAB_ICON_SIZE = 16;

        private const int TAB_CLOSE_BUTTON_RADIUS = 7;
        private const float TAB_CLOSE_X_INSET = 3.5f;

        private const int NEW_TAB_BUTTON_WIDTH = 32;
        private const float NEW_TAB_HEIGHT_PERCENTAGE = 0.65f;
        private const int NEW_TAB_PLUS_SIZE = 8;

        private const int OPTIONS_MENU_BUTTON_WIDTH = 24;
        private const float OPTIONS_MENU_BUTTON_HEIGHT_PERCENTAGE = 0.90f;

        private const int BOTTOM_BORDER_HEIGHT = 4;

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
            if( this.Owner.TabCount > 0 && this.Owner.Tabs[ index ].Dragging )
            {
                blX = this.Owner.Tabs[ index ].DraggingX - this.Owner.Tabs[ index ].DraggingOffset;
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

        public PointPath GetTabClosePath( int index )
        {
            PointPath tabPath = GetTabPath( index );

            int right = tabPath.MinimumBounds.Right;
            int left = right - 2 * TAB_CLOSE_BUTTON_RADIUS;
            int top = tabPath.Bounds.Top + ( tabPath.Bounds.Height / 2 - TAB_CLOSE_BUTTON_RADIUS );
            int bottom = top + 2 * TAB_CLOSE_BUTTON_RADIUS;
            return new PointPath( new[]
            {
                new Point( left, top ),
                new Point( right, top ),
                new Point( right, bottom ),
                new Point( left, bottom )
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

            int textAreaWidth = path.MinimumBounds.Width - 2 * TAB_CLOSE_BUTTON_RADIUS;
            int textAreaX = path.MinimumBounds.X;

            if( t.Icon != null )
            {
                int x = path.MinimumBounds.Left + TAB_ICON_PADDING;
                int y = path.MinimumBounds.Top + ( path.MinimumBounds.Height - TAB_ICON_SIZE ) / 2;
                g.DrawImage( t.Icon, new Rectangle( x, y, TAB_ICON_SIZE, TAB_ICON_SIZE ) );
                textAreaWidth -= TAB_ICON_SIZE + 2 * TAB_ICON_PADDING;
                textAreaX += TAB_ICON_SIZE + 2 * TAB_ICON_PADDING;
            }

            Rectangle bounds = new Rectangle( textAreaX, path.MinimumBounds.Y, textAreaWidth, path.MinimumBounds.Height );
            TextFormatFlags flags = TextFormatFlags.HorizontalCenter
                                  | TextFormatFlags.VerticalCenter
                                  | TextFormatFlags.SingleLine
                                  | TextFormatFlags.LeftAndRightPadding;
            if( t.Text.Contains( Path.DirectorySeparatorChar )
             || t.Text.Contains( Path.AltDirectorySeparatorChar ) )
            {
                flags |= TextFormatFlags.PathEllipsis;
            }
            else
            {
                flags |= TextFormatFlags.WordEllipsis;
            }
            TextRenderer.DrawText( g, t.Text, t.Font, bounds, t.ForeColor, flags );

            PaintTabClose( g, index );
        }

        private void PaintTabClose( Graphics g, int index )
        {
            PointPath path = GetTabClosePath( index );

            if( this.GetTabPath( index ).MinimumBounds.Width < 2 * TAB_CLOSE_BUTTON_RADIUS )
            {
                return;
            }

            Color xColor = Color.FromArgb( 90, 90, 90 );
            if( path.HitTest( this.Owner.PointToClient( Control.MousePosition ) ) )
            {
                xColor = Color.White;

                using( SolidBrush b = new SolidBrush( Color.FromArgb( 219, 68, 55 ) ) )
                {
                    g.FillCircle( b, path.Bounds.X + TAB_CLOSE_BUTTON_RADIUS, path.Bounds.Y + TAB_CLOSE_BUTTON_RADIUS, TAB_CLOSE_BUTTON_RADIUS );
                }
            }

            using( Pen p = new Pen( xColor, 1.75f ) )
            {
                float left = path.Bounds.Left + TAB_CLOSE_X_INSET;
                float right = path.Bounds.Right - TAB_CLOSE_X_INSET;
                float top = path.Bounds.Top + TAB_CLOSE_X_INSET;
                float bottom = path.Bounds.Bottom - TAB_CLOSE_X_INSET;
                g.DrawLine( p, left, top, right, bottom );
                g.DrawLine( p, right, top, left, bottom );
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

            using( Pen p = new Pen( Color.FromArgb( 90, 90, 90 ), 1.6f ) )
            {
                float top = bounds.Top + ( bounds.Height - NEW_TAB_PLUS_SIZE ) / 2.0f;
                float bottom = top + NEW_TAB_PLUS_SIZE;
                float midY = top + ( NEW_TAB_PLUS_SIZE / 2.0f );
                float left = bounds.Left + ( (float)bounds.Width - NEW_TAB_PLUS_SIZE ) / 2.0f;
                float right = left + NEW_TAB_PLUS_SIZE;
                float midX = left + ( NEW_TAB_PLUS_SIZE / 2.0f );
                g.DrawLine( p, left, midY, right, midY );
                g.DrawLine( p, midX, top, midX, bottom );
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
