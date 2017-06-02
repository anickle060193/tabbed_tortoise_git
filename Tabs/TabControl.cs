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
    public class TabControl : Control
    {
        private readonly List<Tab> _tabs = new List<Tab>();
        private readonly TabCollection _collection;
        private readonly TabPainter _painter;
        private readonly TabHeaderDragDropHelper _dragDropHelper;

        private int _maximumTabWidth = 200;
        private Color _tabColor = Color.FromArgb( 218, 218, 218 );
        private Color _selectedTabColor = Color.FromArgb( 242, 242, 242 );
        private Color _tabBorderColor = Color.FromArgb( 181, 181, 181 );
        private int _selectedIndex = -1;

        public event EventHandler NewTabClick;
        public event EventHandler<TabClickEventArgs> TabClick;
        public event EventHandler SelectedIndexChanged;
        public event EventHandler<TabClosedEventArgs> TabClosed;

        private bool InsertingItem { get; set; }
        private bool RemovingItem { get; set; }

        [DefaultValue( typeof( ContextMenuStrip ), "(none)" )]
        public ContextMenuStrip TabContextMenu { get; set; }

        [DefaultValue( typeof( ContextMenuStrip ), "(none)" )]
        public ContextMenuStrip NewTabContextMenu { get; set; }

        [DefaultValue( true )]
        public bool CloseTabOnMiddleClick { get; set; }

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
                if( _selectedIndex != value )
                {
                    _selectedIndex = value;
                    OnSelectedIndexChanged( EventArgs.Empty );

                    PerformLayout();
                    Invalidate();
                }
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

        [Browsable( false )]
        [EditorBrowsable( EditorBrowsableState.Never )]
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public new String Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                base.Text = value;
            }
        }

        [Browsable( false )]
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        protected override Padding DefaultMargin
        {
            get
            {
                return Padding.Empty;
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
        protected override bool DoubleBuffered
        {
            get
            {
                return base.DoubleBuffered;
            }

            set
            {
                base.DoubleBuffered = value;
            }
        }

        public TabControl()
        {
            this.AllowDrop = true;
            this.BackColor = Color.White;
            this.DoubleBuffered = true;

            this.CloseTabOnMiddleClick = true;

            _collection = new TabCollection( this );

            _painter = new TabPainter( this );

            _dragDropHelper = new TabHeaderDragDropHelper();
            _dragDropHelper.AddControl( this );
        }

        protected override Control.ControlCollection CreateControlsInstance()
        {
            return new ControlCollection( this );
        }

        private Tab GetTabFromPoint( Point p )
        {
            if( SelectedTab != null )
            {
                if( _painter.GetTabPath( SelectedIndex ).HitTest( p ) )
                {
                    return SelectedTab;
                }
            }

            for( int i = 0; i < this.TabCount; i++ )
            {
                if( i != SelectedIndex )
                {
                    if( _painter.GetTabPath( i ).HitTest( p ) )
                    {
                        return this.Tabs[ i ];
                    }
                }
            }

            return null;
        }

        protected override void OnPaint( PaintEventArgs e )
        {
            _painter.Paint( e.Graphics );
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
                    Refresh();
                    OnTabClick( new TabClickEventArgs( t, e ) );
                    return;
                }
            }
        }

        protected override void OnMouseClick( MouseEventArgs e )
        {
            if( _painter.GetNewTabPath().HitTest( e.Location ) )
            {
                if( e.Button == MouseButtons.Left )
                {
                    OnNewTabClick( EventArgs.Empty );
                    return;
                }
                else if( e.Button == MouseButtons.Right
                      && NewTabContextMenu != null )
                {
                    NewTabContextMenu.Show( this, e.Location );
                    return;
                }
            }

            if( e.Button != MouseButtons.Left )
            {
                Tab t = GetTabFromPoint( e.Location );
                if( t != null )
                {
                    if( e.Button == MouseButtons.Middle
                     && this.CloseTabOnMiddleClick )
                    {
                        SelectedIndex = Tabs.IndexOf( t );
                        this.Tabs.Remove( t );
                        return;
                    }
                    else if( e.Button == MouseButtons.Right
                          && TabContextMenu != null )
                    {
                        SelectedIndex = Tabs.IndexOf( t );
                        TabContextMenu.Show( this, e.Location );
                        return;
                    }
                    else
                    {
                        SelectedIndex = Tabs.IndexOf( t );
                        OnTabClick( new TabClickEventArgs( t, e ) );
                        return;
                    }
                }
            }

            base.OnMouseClick( e );
        }

        protected override void OnLayout( LayoutEventArgs e )
        {
            base.OnLayout( e );

            foreach( Tab t in Tabs )
            {
                t.Visible = false;
            }

            if( this.SelectedTab != null )
            {
                this.SelectedTab.Bounds = _painter.GetTabPanelBounds();
                this.SelectedTab.Visible = true;
                this.SelectedTab.BringToFront();
            }

            this.Invalidate();
        }

        protected void OnNewTabClick( EventArgs e )
        {
            NewTabClick?.Invoke( this, e );
        }

        protected void OnTabClick( TabClickEventArgs e )
        {
            TabClick?.Invoke( this, e );
        }

        protected void OnSelectedIndexChanged( EventArgs e )
        {
            SelectedIndexChanged?.Invoke( this, e );
        }

        protected void OnTabClosed( TabClosedEventArgs e )
        {
            TabClosed?.Invoke( this, e );
        }

        public class TabCollection : IList<Tab>
        {
            private readonly TabControl _owner;

            public TabCollection( TabControl owner )
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
                    if( this[ index ] != value )
                    {
                        _owner.RemovingItem = true;
                        _owner.Controls.Remove( this[ index ] );
                        _owner.RemovingItem = false;
                        _owner.InsertingItem = true;
                        _owner.Controls.Add( value );
                        _owner.InsertingItem = false;
                        _owner._tabs[ index ] = value;
                    }
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
                try
                {
                    _owner.InsertingItem = true;
                    _owner._tabs.Insert( index, item );
                    _owner.Controls.Add( item );
                    _owner.SelectedIndex = index;
                    _owner.Invalidate();
                }
                finally
                {
                    _owner.InsertingItem = false;
                }
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
                Tab tab = _owner._tabs[ index ];
                _owner._tabs.RemoveAt( index );
                _owner.RemovingItem = true;
                _owner.Controls.Remove( tab );
                _owner.RemovingItem = false;
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

                _owner.OnTabClosed( new TabClosedEventArgs( tab ) );
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ( (IEnumerable)_owner._tabs ).GetEnumerator();
            }
        }

        class TabHeaderDragDropHelper : DragDropHelper<TabControl, Tab>
        {
            public TabHeaderDragDropHelper()
            {
                AllowReSwap = true;
            }

            protected override bool AllowDrag( TabControl parent, Tab item, int index )
            {
                return true;
            }

            protected override bool GetItemFromPoint( TabControl parent, Point p, out Tab item, out int itemIndex )
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

            protected override bool SwapItems( TabControl dragParent, Tab dragItem, int dragItemIndex, TabControl pointedParent, Tab pointedItem, int pointedItemIndex )
            {
                if( dragParent == pointedParent )
                {
                    dragParent._tabs[ dragItemIndex ] = pointedItem;
                    dragParent._tabs[ pointedItemIndex ] = dragItem;
                    dragParent.SelectedIndex = pointedItemIndex;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public new class ControlCollection : Control.ControlCollection
        {
            public new TabControl Owner
            {
                get
                {
                    return (TabControl)base.Owner;
                }
            }

            public ControlCollection( TabControl owner ) : base( owner )
            {
            }

            public override void Add( Control value )
            {
                if( value is Tab )
                {
                    if( !this.Owner.InsertingItem )
                    {
                        this.Owner.Tabs.Add( (Tab)value );
                    }

                    value.Visible = false;
                    base.Add( value );
                }
                else
                {
                    throw new ArgumentException( "Only Tabs can be added to a TabControl." );
                }
            }

            public override void Remove( Control value )
            {
                base.Remove( value );

                if( value is Tab )
                {
                    if( !Owner.RemovingItem )
                    {
                        Owner.Tabs.Remove( (Tab)value );
                    }
                }
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

    public class TabClosedEventArgs : EventArgs
    {
        public Tab Tab { get; private set; }

        public TabClosedEventArgs( Tab tab )
        {
            Tab = tab;
        }
    }
}
