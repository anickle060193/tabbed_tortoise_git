﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabs
{
    internal class TabPainter
    {
        private static readonly int TAB_HEIGHT = 26;
        private static readonly double TAB_INCLINE_ANGLE = 65 * ( Math.PI ) / 180;
        private static readonly int BOTTOM_BORDER_HEIGHT = 4;
        private static readonly int LEFT_PADDING = 6;

        private static readonly int NEW_TAB_BUTTON_WIDTH = 32;
        private static readonly float NEW_TAB_HEIGHT_PERCENTAGE = 0.65f;

        public TabControl Owner { get; private set; }

        public TabPainter( TabControl tabControl )
        {
            Owner = tabControl;
        }

        public PointPath GetTabPath( int index )
        {
            int tabInclineWidth = (int)( TAB_HEIGHT / Math.Tan( TAB_INCLINE_ANGLE ) );
            int tabOverlapWidth = tabInclineWidth / 2;

            int tabAreaWidth = this.Owner.Width - LEFT_PADDING - NEW_TAB_BUTTON_WIDTH;
            int tabWidth = this.Owner.MaximumTabWidth;
            if( this.Owner.TabCount == 0 )
            {
                tabWidth = Math.Min( tabWidth, tabAreaWidth );
            }
            else
            {
                tabWidth = Math.Min( tabWidth, (int)( (float)tabAreaWidth / this.Owner.TabCount ) + tabOverlapWidth );
            }

            int bY = TAB_HEIGHT;
            int tY = 0;
            int blX = LEFT_PADDING;
            int tlX = blX + tabInclineWidth;
            int brX = blX + tabWidth;
            int trX = brX - tabInclineWidth;

            int xShift = ( tabWidth - 2 * tabOverlapWidth ) * index;

            return new PointPath( new[]{
                new Point( blX + xShift, bY ),
                new Point( tlX + xShift, tY ),
                new Point( trX + xShift, tY ),
                new Point( brX + xShift, bY )
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
            int tY = ( TAB_HEIGHT - h ) / 2;
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

        private void PaintTab( Graphics g, Tab t, int index, bool selected )
        {
            PointPath path = GetTabPath( index );

            if( selected )
            {
                using( Brush b = new SolidBrush( this.Owner.SelectedTabColor ) )
                {
                    g.FillPointPath( b, path );
                }
                using( Pen p = new Pen( this.Owner.TabBorderColor ) )
                {
                    g.DrawPointPath( p, path, false );
                }
            }
            else
            {
                using( Brush b = new SolidBrush( this.Owner.TabColor ) )
                {
                    g.FillPointPath( b, path );
                }
                using( Pen p = new Pen( this.Owner.TabBorderColor ) )
                {
                    g.DrawPointPath( p, path, false );
                }
            }

            using( SolidBrush b = new SolidBrush( this.Owner.ForeColor ) )
            {
                StringFormat f = new StringFormat( StringFormatFlags.NoWrap )
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center,
                    Trimming = t.Text.Contains( Path.DirectorySeparatorChar ) || t.Text.Contains( Path.AltDirectorySeparatorChar ) ? StringTrimming.EllipsisPath : StringTrimming.EllipsisWord
                };
                g.DrawString( t.Text, this.Owner.Font, b, path.MinimumBounds, f );
            }
        }

        private void PaintNewTab( Graphics g )
        {
            PointPath newTabPath = GetNewTabPath();
            Rectangle bounds = newTabPath.Bounds;

            using( Brush b = new SolidBrush( this.Owner.TabColor ) )
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

        private void PaintBottomBorder( Graphics g )
        {
            int bY = TAB_HEIGHT;
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