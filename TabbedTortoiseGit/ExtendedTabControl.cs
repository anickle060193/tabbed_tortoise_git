using log4net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabbedTortoiseGit
{
    class ExtendedTabControl : TabControl
    {
        public event EventHandler NewTabClicked;
        public event EventHandler<TabClosedEventArgs> TabClosed;

        public ContextMenuStrip NewTabContextMenu { get; set; }
        public ContextMenuStrip TabContextMenu { get; set; }

        private static readonly ILog LOG = LogManager.GetLogger( typeof( ExtendedTabControl ) );

        private readonly TabPage _newTab;

        private bool _inhibitControlActions = false;
        private TabPage _draggingTab;
        private TabPage _lastSwapped;

        public ExtendedTabControl()
        {
            LOG.Debug( "Control Constructor" );

            this.AllowDrop = true;

            _newTab = new TabPage( "+" );

            this.TabPages.Add( _newTab );
        }

        protected override void OnControlAdded( ControlEventArgs e )
        {
            if( _inhibitControlActions )
            {
                return;
            }

            if( e.Control == _newTab )
            {
                return;
            }

            TabPage t = e.Control as TabPage;

            if( t != null )
            {
                if( this.TabPages.IndexOf( t ) == this.TabCount - 1 )
                {
                    LOG.DebugFormat( "Tab Inserted After New Tab - Tab Text: {0}", t.Text );
                    _inhibitControlActions = true;
                    this.TabPages.Remove( t );
                    this.TabPages.Insert( this.TabCount - 1, t );
                    _inhibitControlActions = false;
                    return;
                }
            }

            base.OnControlAdded( e );
        }

        protected override void OnControlRemoved( ControlEventArgs e )
        {
            if( _inhibitControlActions )
            {
                return;
            }

            base.OnControlRemoved( e );
        }

        protected override void OnHandleCreated( EventArgs e )
        {
            Native.SendMessage( this.Handle, Native.TCM_SETMINTABWIDTH, IntPtr.Zero, (IntPtr)20 );

            base.OnHandleCreated( e );
        }

        protected override void OnSelecting( TabControlCancelEventArgs e )
        {
            if( e.TabPage == _newTab )
            {
                LOG.Debug( "Cancelled selection of New Tab" );
                e.Cancel = true;
            }
            else
            {
                base.OnSelecting( e );
            }
        }

        protected override void OnMouseClick( MouseEventArgs e )
        {
            if( !this.DesignMode )
            {
                TabPage tab = this.GetTabFromPoint( e.Location );

                if( tab != null )
                {
                    if( e.Button == MouseButtons.Middle )
                    {
                        if( tab != _newTab )
                        {
                            this.SelectedIndex = Math.Max( 0, this.TabPages.IndexOf( tab ) - 1 );
                            this.TabPages.Remove( tab );
                            OnTabClosed( new TabClosedEventArgs( tab ) );
                            return;
                        }
                    }
                    else if( e.Button == MouseButtons.Left )
                    {
                        if( tab == _newTab )
                        {
                            OnNewTabClicked( EventArgs.Empty );
                            return;
                        }
                    }
                    else if( e.Button == MouseButtons.Right )
                    {
                        if( tab == _newTab )
                        {
                            if( NewTabContextMenu != null )
                            {
                                NewTabContextMenu.Show( this, e.Location );
                                return;
                            }
                        }
                        else
                        {
                            this.SelectedTab = tab;
                            if( TabContextMenu != null )
                            {
                                TabContextMenu.Show( this, e.Location );
                                return;
                            }
                        }
                    }
                }
            }

            base.OnMouseClick( e );
        }

        protected override void OnMouseDown( MouseEventArgs e )
        {
            TabPage t = GetTabFromPoint( e.Location );
            if( t != _newTab )
            {
                _draggingTab = t;
            }
            else
            {
                _draggingTab = null;
            }
            _lastSwapped = null;

            base.OnMouseDown( e );
        }

        protected override void OnMouseUp( MouseEventArgs e )
        {
            _draggingTab = null;
            _lastSwapped = null;

            base.OnMouseUp( e );
        }

        protected override void OnMouseMove( MouseEventArgs e )
        {
            if( e.Button == MouseButtons.Left && _draggingTab != null )
            {
                LOG.DebugFormat( "Do Drag Drop - Dragging Tab Text: {0}", _draggingTab.Text );
                this.DoDragDrop( _draggingTab, DragDropEffects.Move );
            }

            base.OnMouseMove( e );
        }

        protected override void OnDragOver( DragEventArgs e )
        {
            TabPage draggedTab = (TabPage)e.Data.GetData( typeof( TabPage ) );
            TabPage pointedTab = GetTabFromPoint( this.PointToClient( new Point( e.X, e.Y ) ) );

            if( pointedTab != draggedTab
             && pointedTab != _lastSwapped )
            {
                _lastSwapped = null;
            }

            if( draggedTab == _draggingTab
             && pointedTab != null
             && pointedTab != _newTab
             && pointedTab != draggedTab
             && pointedTab != _lastSwapped
             && e.AllowedEffect == DragDropEffects.Move )
            {
                LOG.DebugFormat( "Drag Over - Tabs Swapped - Dragging Tab: {0} - Other Tab: {1}", draggedTab.Text, pointedTab.Text );
                e.Effect = DragDropEffects.Move;
                SwapTabs( pointedTab, draggedTab );
                _lastSwapped = pointedTab;
            }

            base.OnDragOver( e );
        }

        protected void OnNewTabClicked( EventArgs e )
        {
            NewTabClicked( this, e );
        }

        protected void OnTabClosed( TabClosedEventArgs e )
        {
            TabClosed( this, e );
        }

        private void SwapTabs( TabPage source, TabPage destination )
        {
            _inhibitControlActions = true;

            int sourceIndex = this.TabPages.IndexOf( source );
            int destinationIndex = this.TabPages.IndexOf( destination );

            this.TabPages[ sourceIndex ] = destination;
            this.TabPages[ destinationIndex ] = source;

            if( this.SelectedIndex == sourceIndex )
            {
                this.SelectedIndex = destinationIndex;
            }
            else if( this.SelectedIndex == destinationIndex )
            {
                this.SelectedIndex = sourceIndex;
            }

            this.Refresh();

            _inhibitControlActions = false;
        }

        private TabPage GetTabFromPoint( Point p )
        {
            for( int i = 0; i < this.TabCount; i++ )
            {
                if( this.GetTabRect( i ).Contains( p ) )
                {
                    return this.TabPages[ i ];
                }
            }
            return null;
        }
    }

    public class TabClosedEventArgs : EventArgs
    {
        public TabPage Tab { get; private set; }

        public TabClosedEventArgs( TabPage t )
        {
            Tab = t;
        }
    }
}
