using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tabs
{
    [ToolboxItem( false )]
    public class Tab : Panel
    {
        private Bitmap _icon;

        private bool _dragging = false;
        private int _draggingOffset = 0;
        private int _draggingX = 0;

        [DefaultValue( "" )]
        [Browsable( true )]
        public override String Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                if( this.Text != value )
                {
                    base.Text = value;
                    this.Parent?.Invalidate();
                }
            }
        }

        public override Font Font
        {
            get
            {
                return base.Font;
            }

            set
            {
                if( Font != value )
                {
                    base.Font = value;
                    this.Parent?.Invalidate();
                }
            }
        }

        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }

            set
            {
                if( ForeColor != value )
                {
                    base.ForeColor = value;
                    this.Parent?.Invalidate();
                }
            }
        }

        [DefaultValue( typeof( Bitmap ), "" )]
        [Browsable( true )]
        public Bitmap Icon
        {
            get
            {
                return _icon;
            }

            set
            {
                if( _icon != value )
                {
                    _icon = value;
                    this.Parent?.Invalidate();
                }
            }
        }

        [Browsable( false )]
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        internal bool Dragging
        {
            get
            {
                return _dragging;
            }

            set
            {
                if( _dragging != value )
                {
                    _dragging = value;
                    this.Parent?.Invalidate();
                }
            }
        }

        [Browsable( false )]
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        internal int DraggingOffset
        {
            get
            {
                return _draggingOffset;
            }

            set
            {
                if( _draggingOffset != value )
                {
                    _draggingOffset = value;
                    this.Parent?.Invalidate();
                }
            }
        }

        [Browsable( false )]
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        internal int DraggingX
        {
            get
            {
                return _draggingX;
            }

            set
            {
                if( _draggingX != value )
                {
                    _draggingX = value;
                    this.Parent?.Invalidate();
                }
            }
        }


        public Tab() : this( "" )
        {
            Dragging = false;
            DraggingOffset = 0;
            DraggingX = 0;
        }

        public Tab( String text )
        {
            Text = text;
        }

        public override string ToString()
        {
            return "Tab( Text=\"{0}\" )".XFormat( Text );
        }

        protected override void SetBoundsCore( int x, int y, int width, int height, BoundsSpecified specified )
        {
            Control parent = this.Parent;
            if( parent is TabControl && parent.IsHandleCreated )
            {
                Rectangle r = parent.DisplayRectangle;

                base.SetBoundsCore( r.X, r.Y, r.Width, r.Height, specified == BoundsSpecified.None ? BoundsSpecified.None : BoundsSpecified.All );
            }
            else
            {
                base.SetBoundsCore( x, y, width, height, specified );
            }
        }
    }
}
