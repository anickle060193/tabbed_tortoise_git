using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tabs
{
    public class TabControl : Control
    {
        private readonly TabCollection _tabCollection;
        private readonly TabPainter _painter;
        private readonly TabControlDragDropHelper _dragDropHelper;
        private readonly ToolTip _tabToolTip;

        private Tab[] _tabs;
        private int _tabCount = 0;

        private int _maximumTabWidth = 200;
        private Color _tabColor = Color.FromArgb( 218, 218, 218 );
        private Color _selectedTabColor = Color.FromArgb( 242, 242, 242 );
        private Color _tabBorderColor = Color.FromArgb( 181, 181, 181 );
        private int _selectedIndex = -1;
        private bool _showTabHitTest = false;
        private bool _insertingItem = false;
        private bool _currentlyScaling = false;
        private ContextMenuStrip _optionsMenu;
        private CancellationTokenSource _tabToolTipCancellationToken;

        public event EventHandler NewTabClick;
        public event EventHandler<TabClickEventArgs> TabClick;
        public event EventHandler SelectedTabChanged;
        public event EventHandler<TabAddedEventArgs> TabAdded;
        public event EventHandler<TabRemovedEventArgs> TabRemoved;
        public event EventHandler<TabClosedEventArgs> TabClosed;
        public event EventHandler<TabPulledOutEventArgs> TabPulledOut;

        [Browsable( false )]
        [EditorBrowsable( EditorBrowsableState.Never )]
        new public event EventHandler TextChanged
        {
            add
            {
                base.TextChanged += value;
            }

            remove
            {
                base.TextChanged -= value;
            }
        }

        private bool RemovingItem { get; set; }
        private bool SupressTabEvents { get; set; }
        private bool ClosingTab { get; set; }

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
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if( value < -1 )
                {
                    throw new ArgumentOutOfRangeException( "SelectedIndex" );
                }
                if( SelectedIndex != value )
                {
                    if( !IsHandleCreated )
                    {
                        _selectedIndex = value;
                    }
                    else
                    {
                        _selectedIndex = value;
                        OnSelectedTabChanged( EventArgs.Empty );
                    }
                }
            }
        }

        [Browsable( false )]
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public Tab SelectedTab
        {
            get
            {
                return SelectedTabInternal;
            }

            set
            {
                SelectedTabInternal = value;
            }
        }

        internal Tab SelectedTabInternal
        {
            get
            {
                int index = SelectedIndex;
                if( index == -1 )
                {
                    return null;
                }
                else
                {
                    return _tabs[ index ];
                }
            }

            set
            {
                int index = FindTab( value );
                SelectedIndex = index;
            }
        }

        [Browsable( false )]
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public int TabCount
        {
            get
            {
                return _tabCount;
            }
        }

        [Browsable( false )]
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public TabCollection Tabs
        {
            get
            {
                return _tabCollection;
            }
        }

        [DefaultValue( typeof( Color ), "218, 218, 218" )]
        public Color TabColor
        {
            get
            {
                return _tabColor;
            }

            set
            {
                if( _tabColor != value )
                {
                    _tabColor = value;
                    this.Invalidate();
                }
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
                if( _selectedTabColor != value )
                {
                    _selectedTabColor = value;
                    this.Invalidate();
                }
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
                if( _tabBorderColor != value )
                {
                    _tabBorderColor = value;
                    this.Invalidate();
                }
            }
        }

        [Browsable( false )]
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public bool ShowHitTest
        {
            get
            {
                return _showTabHitTest;
            }

            set
            {
                if( _showTabHitTest != value )
                {
                    _showTabHitTest = value;
                }
            }
        }

        [DefaultValue( typeof( ContextMenuStrip ), "(none)" )]
        public ContextMenuStrip OptionsMenu
        {
            get
            {
                return _optionsMenu;
            }

            set
            {
                if( _optionsMenu != value )
                {
                    if( _optionsMenu != null )
                    {
                        _optionsMenu.Closed -= OptionsMenu_Closed;
                        _optionsMenu.Close();
                    }

                    _optionsMenu = value;

                    if( _optionsMenu != null )
                    {
                        _optionsMenu.Closed += OptionsMenu_Closed;
                    }
                }
            }
        }

        private bool InsertingItem
        {
            get
            {
                return _insertingItem;
            }

            set
            {
                _insertingItem = value;
            }
        }

        [Browsable( false )]
        [EditorBrowsable( EditorBrowsableState.Never )]
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        [Bindable( false )]
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

        protected override Size DefaultSize
        {
            get
            {
                return new Size( 200, 200 );
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

        public override Rectangle DisplayRectangle
        {
            get
            {
                return _painter.GetTabPanelBounds();
            }
        }

        public TabControl() : base()
        {
            this.AllowDrop = true;
            this.BackColor = Color.White;
            this.DoubleBuffered = true;

            this.CloseTabOnMiddleClick = true;

            _tabCollection = new TabCollection( this );

            _painter = new TabPainter( this );

            _dragDropHelper = new TabControlDragDropHelper( this );
            _dragDropHelper.AddControl( this );

            _tabToolTip = new ToolTip()
            {
                AutomaticDelay = 750
            };
        }

        public void NextTab()
        {
            if( this.TabCount > 1 )
            {
                if( this.SelectedIndex == this.TabCount - 1 )
                {
                    this.SelectedIndex = 0;
                }
                else
                {
                    this.SelectedIndex++;
                }
            }
        }

        public void PreviousTab()
        {
            if( this.TabCount > 1 )
            {
                if( this.SelectedIndex == 0 )
                {
                    this.SelectedIndex = this.TabCount - 1;
                }
                else
                {
                    this.SelectedIndex--;
                }
            }
        }

        public Rectangle GetTabRect( int index )
        {
            return _painter.GetTabPath( index ).Bounds;
        }

        internal int FindTab( Tab tab )
        {
            if( _tabs != null )
            {
                for( int i = 0; i < _tabCount; i++ )
                {
                    if( _tabs[ i ] == tab )
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public Control GetControl( int index )
        {
            return (Control)GetTab( index );
        }

        internal Tab GetTab( int index )
        {
            if( index < 0 || index >= _tabCount )
            {
                throw new ArgumentOutOfRangeException( "index" );
            }
            return _tabs[ index ];
        }

        protected virtual object[] GetItems()
        {
            Tab[] result = new Tab[ _tabCount ];
            if( _tabCount > 0 )
            {
                Array.Copy( _tabs, result, _tabCount );
            }
            return result;
        }

        internal Tab[] GetTabs()
        {
            return (Tab[])GetItems();
        }

        private Tab GetTabFromPoint( Point p )
        {
            Tab selected = SelectedTab;
            if( selected != null )
            {
                if( !selected.Dragging && _painter.GetTabPath( SelectedIndex ).HitTest( p ) )
                {
                    return selected;
                }
            }

            for( int i = 0; i < _tabCount; i++ )
            {
                if( i != SelectedIndex )
                {
                    if( _painter.GetTabPath( i ).HitTest( p ) )
                    {
                        return _tabs[ i ];
                    }
                }
            }

            return null;
        }

        private Tab GetTabCloseFromPoint( Point p )
        {
            for( int i = 0; i < _tabCount; i++ )
            {
                if( _painter.GetTabClosePath( i ).HitTest( p ) )
                {
                    return _tabs[ i ];
                }
            }
            return null;
        }

        internal void Insert( int index, Tab tab )
        {
            if( _tabs == null )
            {
                _tabs = new Tab[ 4 ];
            }
            else if( _tabs.Length == _tabCount )
            {
                Tab[] newTabs = new Tab[ _tabCount * 2 ];
                Array.Copy( _tabs, newTabs, _tabCount );
                _tabs = newTabs;
            }

            if( index < _tabCount )
            {
                Array.Copy( _tabs, index, _tabs, index + 1, _tabCount - index );
            }

            _tabs[ index ] = tab;
            _tabCount++;

            if( index < _selectedIndex )
            {
                _selectedIndex++;
            }

            Invalidate();

            OnTabAdded( new TabAddedEventArgs( tab ) );
        }

        private void InsertItem( int index, Tab tab )
        {
            if( index < 0 || index > _tabCount )
            {
                throw new ArgumentOutOfRangeException( "index" );
            }
            if( tab == null )
            {
                throw new ArgumentNullException( "tab" );
            }

            Insert( index, tab );
        }

        protected void RemoveAll()
        {
            this.Controls.Clear();
            _tabs = null;
            _tabCount = 0;
        }

        internal void RemoveTab( int index )
        {
            if( index < 0 || index >= _tabCount )
            {
                throw new ArgumentOutOfRangeException( "index" );
            }

            Tab tab = _tabs[ index ];

            _tabCount--;
            if( index < _tabCount )
            {
                Array.Copy( _tabs, index + 1, _tabs, index, _tabCount - index );
            }
            
            if( index == _selectedIndex )
            {
                if( _tabCount == 0 )
                {
                    _selectedIndex = -1;
                    OnSelectedTabChanged( EventArgs.Empty );
                }
                else if( _selectedIndex == _tabCount )
                {
                    _selectedIndex = _tabCount - 1;
                    OnSelectedTabChanged( EventArgs.Empty );
                }
            }
            else if( index < _selectedIndex )
            {
                _selectedIndex--;
            }

            _tabs[ _tabCount ] = null;

            this.UpdateTabSelection();

            OnTabRemoved( new TabRemovedEventArgs( tab ) );
        }

        private void ResizeTabs()
        {
            Rectangle rect = DisplayRectangle;
            Tab[] tabs = GetTabs();
            for( int i = 0; i < tabs.Length; i++ )
            {
                tabs[ i ].Bounds = rect;
            }
        }

        internal void SetTab( int index, Tab tab )
        {
            if( index < 0 || index >= _tabCount )
            {
                throw new ArgumentOutOfRangeException( "index" );
            }
            _tabs[ index ] = tab;
        }

        private void UpdateTabSelection()
        {
            int index = SelectedIndex;

            Tab[] tabs = GetTabs();
            if( index != -1 )
            {
                if( _currentlyScaling )
                {
                    _tabs[ index ].SuspendLayout();
                }

                tabs[ index ].Bounds = DisplayRectangle;
                tabs[ index ].Invalidate();

                if( _currentlyScaling )
                {
                    _tabs[ index ].ResumeLayout( false );
                }

                tabs[ index ].Visible = true;
            }

            for( int i = 0; i < tabs.Length; i++ )
            {
                if( i != SelectedIndex )
                {
                    tabs[ i ].Visible = false;
                }
            }

            Invalidate();
        }

        internal void UpdateTab( Tab tab )
        {
            int index = FindTab( tab );
            SetTab( index, tab );
            UpdateTabSelection();
        }

        private void ShowTabToolTip( Tab tab )
        {
            int index = this.Tabs.IndexOf( tab );
            if( index != -1 )
            {
                Rectangle bounds = this.GetTabRect( index );
                int x = this.PointToClient( MousePosition ).X;
                _tabToolTip.Show( tab.Text, this, x, bounds.Bottom );
            }
        }

        private void HideTabToolTip()
        {
            _tabToolTipCancellationToken?.Cancel();

            _tabToolTip.Tag = null;
            if( !this.IsDisposed )
            {
                _tabToolTip.Hide( this );
            }
        }

        protected override Control.ControlCollection CreateControlsInstance()
        {
            return new ControlCollection( this );
        }

        [EditorBrowsable( EditorBrowsableState.Never )]
        protected override void ScaleCore( float dx, float dy )
        {
            _currentlyScaling = true;
            base.ScaleCore( dx, dy );
            _currentlyScaling = false;
        }

        protected override void OnResize( EventArgs e )
        {
            base.OnResize( e );

            UpdateTabSelection();
        }

        protected override void OnPaint( PaintEventArgs e )
        {
            _painter.Paint( e.Graphics );

            base.OnPaint( e );
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
                }
            }
        }

        protected override void OnMouseMove( MouseEventArgs e )
        {
            base.OnMouseMove( e );

            this.Invalidate();

            Tab tab = this.GetTabFromPoint( e.Location );
            if( tab != null )
            {
                if( _tabToolTip.Tag != tab )
                {
                    this.HideTabToolTip();

                    _tabToolTip.Tag = tab;

                    if( !tab.Dragging )
                    {
                        _tabToolTipCancellationToken = new CancellationTokenSource();

                        Task.Delay( _tabToolTip.InitialDelay, _tabToolTipCancellationToken.Token )
                            .ContinueWith( task => ShowTabToolTip( tab ), TaskScheduler.FromCurrentSynchronizationContext() );
                    }
                }
            }
            else
            {
                this.HideTabToolTip();
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

            if( this.OptionsMenu != null
             && e.Button == MouseButtons.Left )
            {
                PointPath optionsPath = _painter.GetOptionsPath();
                if( optionsPath.HitTest( e.Location ) )
                {
                    OptionsMenu.Show( this, _painter.OptionsMenuLocation );
                    return;
                }
            }

            if( e.Button == MouseButtons.Left )
            {
                Tab closeTab = this.GetTabCloseFromPoint( e.Location );
                if( closeTab != null )
                {
                    ClosingTab = true;
                    this.Tabs.Remove( closeTab );
                    OnTabClosed( new TabClosedEventArgs( closeTab ) );
                    ClosingTab = false;
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
                        ClosingTab = true;
                        this.Tabs.Remove( t );
                        OnTabClosed( new TabClosedEventArgs( t ) );
                        ClosingTab = false;
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

        protected void OnNewTabClick( EventArgs e )
        {
            NewTabClick?.Invoke( this, e );
        }

        protected void OnTabClick( TabClickEventArgs e )
        {
            TabClick?.Invoke( this, e );
        }

        protected void OnSelectedTabChanged( EventArgs e )
        {
            UpdateTabSelection();

            SelectedTabChanged?.Invoke( this, e );
        }

        protected void OnTabAdded( TabAddedEventArgs e )
        {
            if( !SupressTabEvents )
            {
                TabAdded?.Invoke( this, e );
            }
        }

        protected void OnTabRemoved( TabRemovedEventArgs e )
        {
            if( !SupressTabEvents && !ClosingTab )
            {
                TabRemoved?.Invoke( this, e );
            }
        }

        protected void OnTabClosed( TabClosedEventArgs e )
        {
            TabClosed?.Invoke( this, e );
        }

        protected void OnTabPulledOut( TabPulledOutEventArgs e )
        {
            TabPulledOut?.Invoke( this, e );
        }

        private void OptionsMenu_Closed( object sender, ToolStripDropDownClosedEventArgs e )
        {
            this.Invalidate();
        }

        public class TabCollection : IList<Tab>
        {
            private readonly TabControl _owner;

            public TabCollection( TabControl owner )
            {
                _owner = owner;
            }

            public virtual Tab this[ int index ]
            {
                get
                {
                    return _owner.GetTab( index );
                }

                set
                {
                    _owner.SetTab( index, value );
                }
            }

            Tab IList<Tab>.this[ int index ]
            {
                get
                {
                    return this[ index ];
                }

                set
                {
                    this[ index ] = value;
                }
            }

            public virtual Tab this[ String key ]
            {
                get
                {
                    if( String.IsNullOrEmpty( key ) )
                    {
                        return null;
                    }
                    int index = IndexOfKey( key );
                    if( IsValidIndex( index ) )
                    {
                        return this[ index ];
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            [Browsable( false )]
            public int Count
            {
                get
                {
                    return _owner._tabCount;
                }
            }

            int ICollection<Tab>.Count
            {
                get
                {
                    return this.Count;
                }
            }

            bool ICollection<Tab>.IsReadOnly
            {
                get
                {
                    return false;
                }
            }

            public void Add( Tab value )
            {
                if( value == null )
                {
                    throw new ArgumentNullException( "value" );
                }
                _owner.Controls.Add( value );
            }

            void ICollection<Tab>.Add( Tab item )
            {
                this.Add( item );
            }

            public void Add( String text )
            {
                Tab tab = new Tab();
                tab.Text = text;
                Add( tab );
            }

            public void Add( String key, String text )
            {
                Tab tab = new Tab();
                tab.Name = key;
                tab.Text = text;
                Add( tab );
            }

            public void AddRange( Tab[] tabs )
            {
                if( tabs == null )
                {
                    throw new ArgumentNullException( "tabs" );
                }
                foreach( Tab tab in tabs )
                {
                    Add( tab );
                }
            }

            public bool Contains( Tab tab )
            {
                if( tab == null )
                {
                    throw new ArgumentNullException( "tab" );
                }
                return IsValidIndex( IndexOf( tab ) );
            }

            bool ICollection<Tab>.Contains( Tab item )
            {
                return this.Contains( item );
            }

            public virtual bool ContainsKey( String key )
            {
                return IsValidIndex( IndexOfKey( key ) );
            }

            public int IndexOf( Tab tab )
            {
                if( tab == null )
                {
                    throw new ArgumentNullException( "tab" );
                }

                for( int i = 0; i < this.Count; i++ )
                {
                    if( this[ i ] == tab )
                    {
                        return i;
                    }
                }

                return -1;
            }

            int IList<Tab>.IndexOf( Tab item )
            {
                return this.IndexOf( item );
            }

            public virtual int IndexOfKey( String key )
            {
                if( String.IsNullOrEmpty( key ) )
                {
                    return -1;
                }
                
                for( int i = 0; i < this.Count; i++ )
                {
                    if( this[ i ].Name == key )
                    {
                        return i;
                    }
                }

                return -1;
            }

            public void Insert( int index, Tab tab )
            {
                _owner.InsertItem( index, tab );
                try
                {
                    _owner.InsertingItem = true;
                    _owner.Controls.Add( tab );
                }
                finally
                {
                    _owner.InsertingItem = false;
                }
                _owner.Controls.SetChildIndex( tab, index );
            }

            void IList<Tab>.Insert( int index, Tab item )
            {
                this.Insert( index, item );
            }

            public void Insert( int index, String text )
            {
                Tab tab = new Tab();
                tab.Text = text;
                Insert( index, tab );
            }

            public void Insert( int index, String key, String text )
            {
                Tab tab = new Tab();
                tab.Name = key;
                tab.Text = text;
                Insert( index, tab );
            }

            private bool IsValidIndex( int index )
            {
                return ( ( index >= 0 ) && ( index < this.Count ) );
            }

            public virtual void Clear()
            {
                _owner.RemoveAll();
            }

            void ICollection<Tab>.Clear()
            {
                this.Clear();
            }

            void ICollection<Tab>.CopyTo( Tab[] array, int arrayIndex )
            {
                if( this.Count > 0 )
                {
                    Array.Copy( _owner.GetTabs(), 0, array, arrayIndex, this.Count );
                }
            }

            IEnumerator<Tab> IEnumerable<Tab>.GetEnumerator()
            {
                Tab[] tabs = _owner.GetTabs();
                if( tabs != null )
                {
                    return tabs.AsEnumerable().GetEnumerator();
                }
                else
                {
                    return new Tab[ 0 ].AsEnumerable().GetEnumerator();
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ( (IEnumerable<Tab>)this ).GetEnumerator();
            }

            public void Remove( Tab tab )
            {
                if( tab == null )
                {
                    throw new ArgumentNullException( "tab" );
                }
                _owner.Controls.Remove( tab );
            }

            bool ICollection<Tab>.Remove( Tab item )
            {
                int count = this.Count;
                this.Remove( item );
                return count != this.Count;
            }

            public void RemoveAt( int index )
            {
                _owner.Controls.RemoveAt( index );
            }

            void IList<Tab>.RemoveAt( int index )
            {
                this.RemoveAt( index );
            }

            public virtual void RemoveByKey( String key )
            {
                int index = IndexOfKey( key );
                if( IsValidIndex( index ) )
                {
                    RemoveAt( index );
                }
            }
        }

        public new class ControlCollection : Control.ControlCollection
        {
            private readonly TabControl _owner;

            public ControlCollection( TabControl owner ) : base( owner )
            {
                _owner = owner;
            }

            public override void Add( Control value )
            {
                if( !( value is Tab ) )
                {
                    throw new ArgumentException( "Only Tabs are allowed to be added to TabControl", value.GetType().Name );
                }

                Tab tab = (Tab)value;
                if( !_owner.InsertingItem )
                {
                    _owner.Insert( _owner.TabCount, tab );
                }

                base.Add( tab );
                tab.Visible = false;

                if( _owner.IsHandleCreated )
                {
                    tab.Bounds = _owner.DisplayRectangle;
                }

                _owner.UpdateTabSelection();
            }

            public override void Remove( Control value )
            {
                base.Remove( value );

                if( !( value is Tab ) )
                {
                    return;
                }

                int index = _owner.FindTab( (Tab)value );

                if( index != -1 )
                {
                    _owner.RemoveTab( index );
                }

                _owner.UpdateTabSelection();
            }
        }

        class TabControlDragDropHelper : DragDropHelper<TabControl, Tab>
        {
            private readonly TabControl _owner;

            private bool _partialMatch = false;

            public TabControlDragDropHelper( TabControl owner )
            {
                _owner = owner;
            }

            protected override bool AllowDrag( TabControl parent, Tab item, int index )
            {
                return !_partialMatch;
            }

            protected override bool GetItemFromPoint( TabControl parent, Point p, out Tab item, out int itemIndex )
            {
                _partialMatch = false;

                if( parent.TabCount == 0 )
                {
                    if( !parent._painter.GetTabPanelBounds().Contains( p ) )
                    {
                        _partialMatch = true;
                        item = null;
                        itemIndex = 0;
                        return true;
                    }
                }

                if( parent.SelectedTab != null )
                {
                    if( !parent.SelectedTab.Dragging
                     && parent._painter.GetTabPath( parent.SelectedIndex ).Bounds.Contains( p ) )
                    {
                        item = parent.SelectedTab;
                        itemIndex = parent.SelectedIndex;
                        return true;
                    }
                }

                for( int i = 0; i < parent.TabCount; i++ )
                {
                    if( i != parent.SelectedIndex )
                    {
                        if( parent._painter.GetTabPath( i ).Bounds.Contains( p ) )
                        {
                            item = parent.Tabs[ i ];
                            itemIndex = i;
                            return true;
                        }
                    }
                }

                if( parent.TabCount >= 1 )
                {
                    if( p.X < parent._painter.GetTabPath( 0 ).Bounds.Left )
                    {
                        _partialMatch = true;
                        item = parent.Tabs[ 0 ];
                        itemIndex = 0;
                        return true;
                    }
                    else if( p.X > parent._painter.GetTabPath( parent.TabCount - 1 ).Bounds.Right )
                    {
                        _partialMatch = true;
                        item = parent.Tabs[ parent.TabCount - 1 ];
                        itemIndex = parent.TabCount - 1;
                        return true;
                    }
                }

                if( parent.SelectedTab != null
                 && parent.SelectedTab.Dragging )
                {
                    item = parent.SelectedTab;
                    itemIndex = parent.SelectedIndex;
                    return true;
                }

                item = null;
                itemIndex = -1;
                return false;
            }

            protected override bool AllowDrop( TabControl dragParent, Tab dragItem, int dragItemIndex, TabControl pointedParent, Tab pointedItem, int pointedItemIndex )
            {
                return true;
            }

            protected override void MoveItem( TabControl dragParent, Tab dragItem, int dragItemIndex, TabControl pointedParent, Tab pointedItem, int pointedItemIndex )
            {
                if( dragItem == pointedItem )
                {
                    return;
                }

                if( dragParent == pointedParent )
                {
                    _owner.SupressTabEvents = true;
                }

                dragParent.Tabs.RemoveAt( dragItemIndex );
                pointedParent.Tabs.Insert( pointedItemIndex, dragItem );
                pointedParent.SelectedIndex = pointedItemIndex;

                _owner.SupressTabEvents = false;
            }

            protected override void OnDragStart( DragStartEventArgs<TabControl, Tab> e )
            {
                Point tabLocation = e.DragParent.PointToScreen( e.DragParent._painter.GetTabPath( e.DragItemIndex ).Bounds.Location );
                int draggingOffset = e.DragStartPosition.X - tabLocation.X;
                e.DragItem.Dragging = true;
                e.DragItem.DraggingOffset = draggingOffset;
                e.DragItem.DraggingX = 0;
            }

            protected override void OnDragMove( DragMoveEventArgs<TabControl, Tab> e )
            {
                _owner.HideTabToolTip();

                e.DragItem.DraggingX = e.DragParent.PointToClient( e.DragCurrentPosition ).X;
            }

            protected override void OnDragEnd( DragEndEventArgs<TabControl, Tab> e )
            {
                e.DragItem.Dragging = false;
                e.DragItem.DraggingOffset = 0;
                e.DragItem.DraggingX = 0;

                if( e.Effects == DragDropEffects.None )
                {
                    _owner.OnTabPulledOut( new TabPulledOutEventArgs( e.DragItem, e.DragEndPosition ) );
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

    public class TabAddedEventArgs : EventArgs
    {
        public Tab Tab { get; private set; }

        public TabAddedEventArgs( Tab tab )
        {
            Tab = tab;
        }
    }

    public class TabRemovedEventArgs : EventArgs
    {
        public Tab Tab { get; private set; }

        public TabRemovedEventArgs( Tab tab )
        {
            Tab = tab;
        }
    }

    public class TabClosedEventArgs : EventArgs
    {
        public Tab Tab { get; private set; }

        public TabClosedEventArgs( Tab tab )
        {
            Tab = tab;
        }
    }

    public class TabPulledOutEventArgs : EventArgs
    {
        public Tab Tab { get; private set; }
        public Point Location { get; private set; }

        public TabPulledOutEventArgs( Tab tab, Point location )
        {
            Tab = tab;
            Location = location;
        }
    }
}
