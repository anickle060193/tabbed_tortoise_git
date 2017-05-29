using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tabs
{
    public class TabHeader : Control
    {
        private static readonly int TAB_HEIGHT = 28;
        private static readonly double TAB_INCLINE_ANGLE = 65 * ( Math.PI ) / 180;
        private static readonly int BOTTOM_BORDER_HEIGHT = 4;

        private static readonly int NEW_TAB_BUTTON_WIDTH = 28;
        private static readonly float NEW_TAB_HEIGHT_PERCENTAGE = 0.65f;

        private int _tabOverlapWidth;
        private readonly GraphicsPath _tabGraphicsPath = new GraphicsPath();
        private readonly GraphicsPath _newTabGraphicsPath = new GraphicsPath();
        private readonly List<Tab> _tabs = new List<Tab>();
        private readonly TabCollection _collection;
        private readonly TabHeaderDragDropHelper _dragDropHelper;

        private int _maximumTabWidth = 200;
        private Color _tabColor = Color.FromArgb( 218, 218, 218 );
        private Color _selectedTabColor = Color.FromArgb( 242, 242, 242 );
        private Color _tabBorderColor = Color.FromArgb( 181, 181, 181 );
        private int _selectedIndex = -1;

        public event EventHandler NewTabClick;
        public event EventHandler<TabClickEventArgs> TabClick;

        protected override Padding DefaultMargin
        {
            get
            {
                return Padding.Empty;
            }
        }

        [DefaultValue( 200 )]
        public int MaximumTabWidth
        {
            get { return _maximumTabWidth; }
            set
            {
                _maximumTabWidth = value;
                Invalidate();
            }
        }

        [Browsable( false )]
        public TabCollection Tabs { get { return _collection; } }

        [Browsable( false )]
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value;
                Invalidate();
            }
        }

        [Browsable( false )]
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public Tab SelectedTab
        {
            get
            {
                if( 0 <= SelectedIndex && SelectedIndex < this.TabCount )
                {
                    return Tabs[ SelectedIndex ];
                }
                else
                {
                    return null;
                }
            }
        }

        [Browsable( false )]
        public int TabCount { get { return _collection.Count; } }

        [DefaultValue( typeof( Color ), "218, 218, 218" )]
        public Color TabColor
        {
            get
            {
                return _tabColor;
            }

            set
            {
                this._tabColor = value;
                this.Invalidate();
            }
        }

        [DefaultValue( typeof( Color ), "242, 242, 242" )]
        public Color SelectedTabColor
        {
            get
            {
                return _selectedTabColor;
            }

            set
            {
                this._selectedTabColor = value;
                this.Invalidate();
            }
        }

        [DefaultValue( typeof( Color ), "181, 181, 181" )]
        public Color TabBorderColor
        {
            get
            {
                return _tabBorderColor;
            }

            set
            {
                this._tabBorderColor = value;
                this.Invalidate();
            }
        }

        [DefaultValue( typeof( Color ), "White" )]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }

            set
            {
                base.BackColor = value;
            }
        }

        [DefaultValue( true )]
        public override bool AllowDrop
        {
            get
            {
                return base.AllowDrop;
            }

            set
            {
                base.AllowDrop = value;
            }
        }

        public TabHeader()
        {
            this.BackColor = Color.White;

            _dragDropHelper = new TabHeaderDragDropHelper();
            _dragDropHelper.AddControl( this );

            _collection = new TabCollection( this );

            this.DoubleBuffered = true;

            CreateBaseTabDrawPath();
            CreateNewTabButtonPath();
        }

        private void CreateBaseTabDrawPath()
        {
            int h = this.Height - BOTTOM_BORDER_HEIGHT;
            int tabInclineWidth = (int)( h / Math.Tan( TAB_INCLINE_ANGLE ) );
            _tabOverlapWidth = tabInclineWidth / 2;

            int tabAreaWidth = this.Width - NEW_TAB_BUTTON_WIDTH - _tabOverlapWidth;
            int tabWidth = this.MaximumTabWidth;
            if( this.TabCount == 0 )
            {
                tabWidth = Math.Min( tabWidth, tabAreaWidth );
            }
            else
            {
                tabWidth = Math.Min( tabWidth, (int)( (float)tabAreaWidth / this.TabCount ) + _tabOverlapWidth );
            }

            int bY = h;
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

        private Tab GetTabFromPoint( Point p )
        {
            if( SelectedTab != null )
            {
                GraphicsPath path = CreateTabDrawPath( SelectedIndex );
                if( path.IsVisible( p ) )
                {
                    return SelectedTab;
                }
            }

            for( int i = 0; i < this.TabCount; i++ )
            {
                GraphicsPath path = CreateTabDrawPath( i );
                if( path.IsVisible( p ) )
                {
                    return this.Tabs[ i ];
                }
            }

            return null;
        }

        protected override void SetBoundsCore( int x, int y, int width, int height, BoundsSpecified specified )
        {
            base.SetBoundsCore( x, y, width, TAB_HEIGHT + BOTTOM_BORDER_HEIGHT, specified );
        }

        protected override void OnPaint( PaintEventArgs e )
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.Clear( SystemColors.ControlLightLight );

            CreateBaseTabDrawPath();
            for( int i = TabCount - 1; i >= 0; i-- )
            {
                if( i != SelectedIndex )
                {
                    PaintTab( g, Tabs[ i ], i, false );
                }
            }

            if( SelectedTab != null )
            {
                PaintTab( g, SelectedTab, SelectedIndex, true );
            }

            PaintBottomBorder( g );

            PaintNewTab( g );
        }

        private void PaintTab( Graphics g, Tab t, int index, bool selected )
        {
            GraphicsPath path = CreateTabDrawPath( index );

            RectangleF bounds = path.GetBounds();
            if( selected )
            {
                using( Brush b = new SolidBrush( SelectedTabColor ) )
                {
                    g.FillPath( b, path );
                }
                using( Pen p = new Pen( TabBorderColor ) )
                {
                    g.DrawPath( p, path );
                }
            }
            else
            {
                using( Brush b = new SolidBrush( TabColor ) )
                {
                    g.FillPath( b, path );
                }
                using( Pen p = new Pen( TabBorderColor ) )
                {
                    g.DrawPath( p, path );
                }
            }

            SizeF size = g.MeasureString( t.Text, this.Font );
            float sX = bounds.Left + ( bounds.Width - size.Width ) / 2;
            float sY = bounds.Top + ( bounds.Height - size.Height ) / 2;
            using( SolidBrush b = new SolidBrush( this.ForeColor ) )
            {
                Region oldClip = g.Clip;
                g.Clip = new Region( path );
                g.DrawString( t.Text, this.Font, b, sX, sY );
                g.Clip = oldClip;
            }
        }

        private void CreateNewTabButtonPath()
        {
            RectangleF lastTabRect = CreateTabDrawPath( this.TabCount - 1 ).GetBounds();

            int totalHeight = this.Height - BOTTOM_BORDER_HEIGHT;
            int h = (int)( totalHeight * NEW_TAB_HEIGHT_PERCENTAGE );
            int tY = ( totalHeight - h ) / 2;
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

            using( Brush b = new SolidBrush( TabColor ) )
            {
                g.FillPath( b, _newTabGraphicsPath );
            }
            using( Pen p = new Pen( TabBorderColor ) )
            {
                g.DrawPath( SystemPens.ControlDark, _newTabGraphicsPath );
            }

            SizeF size = g.MeasureString( "+", this.Font );
            float sX = bounds.Left + ( bounds.Width - size.Width ) / 2;
            float sY = bounds.Top + ( bounds.Height - size.Height ) / 2;
            using( SolidBrush b = new SolidBrush( this.ForeColor ) )
            {
                g.DrawString( "+", this.Font, b, sX, sY );
            }
        }

        private void PaintBottomBorder( Graphics g )
        {
            int bY = this.Height - BOTTOM_BORDER_HEIGHT - 1;
            PointF left = new PointF( 0.0f, bY );
            PointF right = new PointF( this.Width, bY );

            using( Brush b = new SolidBrush( SelectedTabColor ) )
            {
                g.FillRectangle( b, 0, bY, this.Width, BOTTOM_BORDER_HEIGHT + 1 );
            }

            if( SelectedIndex != -1 )
            {
                GraphicsPath tabPath = CreateTabDrawPath( SelectedIndex );
                RectangleF tabBounds = tabPath.GetBounds();
                using( Pen p = new Pen( TabBorderColor ) )
                {
                    g.DrawLines( p, new[] { left, new PointF( tabBounds.Left, bY ) } );
                    g.DrawLines( p, new[] { new PointF( tabBounds.Right, bY ), right } );
                }
            }
            else
            {
                using( Pen p = new Pen( TabBorderColor ) )
                {
                    g.DrawLines( p, new[] { left, right } );
                }
            }
        }

        protected override void OnMouseDown( MouseEventArgs e )
        {
            base.OnMouseDown( e );

            if( e.Button == MouseButtons.Left )
            {
                Tab t = GetTabFromPoint( e.Location );
                if( t != null )
                {
                    SelectedIndex = Tabs.IndexOf( t );
                    OnTabClick( new TabClickEventArgs( t, e ) );
                    return;
                }
            }
        }

        protected override void OnMouseClick( MouseEventArgs e )
        {
            if( e.Button == MouseButtons.Left
             && _newTabGraphicsPath.IsVisible( e.Location ) )
            {
                OnNewTabClick( EventArgs.Empty );
                return;
            }

            if( e.Button != MouseButtons.Left )
            {
                Tab t = GetTabFromPoint( e.Location );
                if( t != null )
                {
                    SelectedIndex = Tabs.IndexOf( t );
                    OnTabClick( new TabClickEventArgs( t, e ) );
                    return;
                }
            }

            base.OnMouseClick( e );
        }

        protected void OnNewTabClick( EventArgs e )
        {
            NewTabClick( this, e );
        }

        protected void OnTabClick( TabClickEventArgs e )
        {
            TabClick( this, e );
        }

        public class TabCollection : IList<Tab>
        {
            private readonly TabHeader _owner;

            public TabCollection( TabHeader owner )
            {
                _owner = owner;
            }

            public Tab this[ int index ]
            {
                get
                {
                    return _owner._tabs[ index ];
                }

                set
                {
                    _owner._tabs[ index ] = value;
                    _owner.Invalidate();
                }
            }

            public int Count
            {
                get
                {
                    return _owner._tabs.Count;
                }
            }

            public bool IsReadOnly
            {
                get
                {
                    return false;
                }
            }

            public void Add( Tab item )
            {
                this.Insert( this.Count, item );
                _owner.Invalidate();
            }

            public Tab Add( String text )
            {
                Tab t = new Tab( text );
                this.Add( t );
                return t;
            }

            public void Clear()
            {
                _owner._tabs.Clear();
                _owner.Invalidate();
            }

            public bool Contains( Tab item )
            {
                return _owner._tabs.Contains( item );
            }

            public void CopyTo( Tab[] array, int arrayIndex )
            {
                _owner._tabs.CopyTo( array, arrayIndex );
            }

            public IEnumerator<Tab> GetEnumerator()
            {
                return ( (IEnumerable<Tab>)_owner._tabs ).GetEnumerator();
            }

            public int IndexOf( Tab item )
            {
                return _owner._tabs.IndexOf( item );
            }

            public void Insert( int index, Tab item )
            {
                _owner._tabs.Insert( index, item );
                _owner.SelectedIndex = index;
                _owner.Invalidate();
            }

            public bool Remove( Tab item )
            {
                int index = this.IndexOf( item );
                if( index != -1 )
                {
                    this.RemoveAt( index );
                    _owner.Invalidate();
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void RemoveAt( int index )
            {
                _owner._tabs.RemoveAt( index );
                if( index == _owner.SelectedIndex )
                {
                    if( _owner.TabCount > 0 )
                    {
                        if( _owner.SelectedIndex > 0 )
                        {
                            _owner.SelectedIndex--;
                        }
                    }
                    else
                    {
                        _owner.SelectedIndex = -1;
                    }
                }
                _owner.Invalidate();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ( (IEnumerable)_owner._tabs ).GetEnumerator();
            }
        }

        class TabHeaderDragDropHelper : DragDropHelper<TabHeader, Tab>
        {
            public TabHeaderDragDropHelper()
            {
                AllowReSwap = true;
            }

            protected override bool AllowDrag( TabHeader parent, Tab item, int index )
            {
                return true;
            }

            protected override bool GetItemFromPoint( TabHeader parent, Point p, out Tab item, out int itemIndex )
            {
                Tab t = parent.GetTabFromPoint( p );
                if( t != null )
                {
                    item = t;
                    itemIndex = parent.Tabs.IndexOf( t );
                    return true;
                }
                else
                {
                    item = null;
                    itemIndex = -1;
                    return false;
                }
            }

            protected override bool SwapItems( TabHeader dragParent, Tab dragItem, int dragItemIndex, TabHeader pointedParent, Tab pointedItem, int pointedItemIndex )
            {
                dragParent.Tabs[ dragItemIndex ] = pointedItem;
                pointedParent.Tabs[ pointedItemIndex ] = dragItem;

                if( dragParent == pointedParent )
                {
                    dragParent.SelectedIndex = pointedItemIndex;
                }
                return true;
            }
        }
    }

    public class TabClickEventArgs : MouseEventArgs
    {
        public TabClickEventArgs( Tab t, MouseEventArgs e ) : base( e.Button, e.Clicks, e.X, e.Y, e.Delta )
        {
            Tab = t;
        }

        public Tab Tab { get; private set; }
    }
}
