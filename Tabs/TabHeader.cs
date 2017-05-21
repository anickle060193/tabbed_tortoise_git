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

        private int _tabWidth = 120;
        private int _selectedIndex = 0;

        public event EventHandler NewTabClick;
        public event EventHandler<TabClickEventArgs> TabClick;

        [DefaultValue( 120 )]
        public int TabWidth
        {
            get { return _tabWidth; }
            set
            {
                _tabWidth = value;
                Invalidate();
            }
        }

        [Browsable( false )]
        public TabCollection Tabs { get { return _collection; } }

        [DefaultValue( 0 )]
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
        public Tab SelectedTab
        {
            get
            {
                if( 0 <= SelectedIndex )
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

        public TabHeader()
        {
            _dragDropHelper = new TabHeaderDragDropHelper();
            _dragDropHelper.AddControl( this );

            _collection = new TabCollection( this );

            this.DoubleBuffered = true;

            CreateBaseTabDrawPath();
            CreateNewTabButtonPath();

            for( int i = 0; i < 5; i++ )
            {
                Tab t = new Tab( String.Format( "Tab {0}", i ) );
                t.Owner = this;
                Tabs.Add( t );
            }
        }

        private void CreateBaseTabDrawPath()
        {
            int h = this.Height - BOTTOM_BORDER_HEIGHT;
            int tabInclineWidth = (int)( h / Math.Tan( TAB_INCLINE_ANGLE ) );
            _tabOverlapWidth = tabInclineWidth / 2;
            int bY = h;
            int tY = 0;
            int blX = _tabOverlapWidth;
            int tlX = blX + tabInclineWidth;
            int brX = blX + this.TabWidth;
            int trX = brX - tabInclineWidth;

            _tabGraphicsPath.Reset();
            _tabGraphicsPath.AddLine( blX, bY, tlX, tY );
            _tabGraphicsPath.AddLine( tlX, tY, trX, tY );
            _tabGraphicsPath.AddLine( trX, tY, brX, bY );
        }

        private GraphicsPath CreateTabDrawPath( int index )
        {
            Matrix m = new Matrix();
            m.Translate( ( this.TabWidth - 2 * _tabOverlapWidth ) * index, 0 );

            GraphicsPath p = (GraphicsPath)_tabGraphicsPath.Clone();
            p.Transform( m );
            return p;
        }

        private GraphicsPath CreateTabPath( int index )
        {
            GraphicsPath p = CreateTabDrawPath( index );
            p.CloseFigure();
            return p;
        }

        private Tab GetTabFromPoint( Point p )
        {
            if( SelectedTab != null )
            {
                if( SelectedTab.IsUnderPoint( p ) )
                {
                    return SelectedTab;
                }
            }

            foreach( Tab t in Tabs )
            {
                if( t.IsUnderPoint( p ) )
                {
                    return t;
                }
            }

            return null;
        }

        protected override void OnPaint( PaintEventArgs e )
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

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

            PaintNewTab( g );
        }

        private void PaintTab( Graphics g, Tab t, int index, bool selected )
        {
            GraphicsPath p = CreateTabDrawPath( index );

            GraphicsPath tPath = (GraphicsPath)p.Clone();
            tPath.CloseAllFigures();
            t.SetPath( tPath );

            RectangleF bounds = p.GetBounds();
            if( selected )
            {
                int bY = this.Height - BOTTOM_BORDER_HEIGHT;
                p.LineTo( this.Width, bY );
                p.LineTo( this.Width, this.Height - 1 );
                p.LineTo( -1, this.Height - 1 );
                p.LineTo( -1, bY );
                p.CloseFigure();
                g.FillPath( SystemBrushes.ControlLightLight, p );
                g.DrawPath( SystemPens.ControlDark, p );
            }
            else
            {
                p.CloseAllFigures();
                g.FillPath( SystemBrushes.ControlLight, p );
                g.DrawPath( SystemPens.ControlDark, p );
            }

            SizeF size = g.MeasureString( t.Text, this.Font );
            float sX = bounds.Left + ( bounds.Width - size.Width ) / 2;
            float sY = bounds.Top + ( bounds.Height - size.Height ) / 2;
            using( SolidBrush b = new SolidBrush( this.ForeColor ) )
            {
                g.DrawString( t.Text, this.Font, b, sX, sY );
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

            g.FillPath( SystemBrushes.ControlLight, _newTabGraphicsPath );
            g.DrawPath( SystemPens.ControlDark, _newTabGraphicsPath );

            SizeF size = g.MeasureString( "+", this.Font );
            float sX = bounds.Left + ( bounds.Width - size.Width ) / 2;
            float sY = bounds.Top + ( bounds.Height - size.Height ) / 2;
            using( SolidBrush b = new SolidBrush( this.ForeColor ) )
            {
                g.DrawString( "+", this.Font, b, sX, sY );
            }
        }

        protected override void OnMouseClick( MouseEventArgs e )
        {
            if( _newTabGraphicsPath.IsVisible( e.Location ) )
            {
                OnNewTabClick( EventArgs.Empty );
                return;
            }

            Tab t = GetTabFromPoint( e.Location );
            if( t != null )
            {
                SelectedIndex = Tabs.IndexOf( t );
                OnTabClick( new TabClickEventArgs( t, e ) );
                return;
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
                t.Owner = _owner;
                this.Add( t );
                _owner.Invalidate();
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

    public class Tab
    {
        private GraphicsPath _path;
        private RectangleF _bounds;

        public String Text { get; set; }
        public TabHeader Owner { get; set; }

        public Tab( String text )
        {
            Text = text;
        }

        public void SetPath( GraphicsPath p )
        {
            _path = p;
            _bounds = _path.GetBounds();
        }

        public bool IsUnderPoint( Point p )
        {
            return _bounds.Contains( p.X, p.Y ) && _path.IsVisible( p );
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
