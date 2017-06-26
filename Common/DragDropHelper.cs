using log4net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public abstract class DragDropHelper<TControl, T> where TControl : Control
    {
        private static readonly ILog LOG = LogManager.GetLogger( typeof( DragDropHelper<TControl, T> ) );

        private static readonly int DRAG_THRESHOLD = 4;

        private bool _mouseDown;
        private Point _mouseDownLocation;

        private T _mouseDownItem;
        private int _mouseDownItemIndex;
        private TControl _mouseDownParent;

        public bool MoveOnDragDrop { get; set; }

        public DragDropHelper()
        {
            MoveOnDragDrop = false;

            ClearDragDrop();
        }

        public void AddControl( TControl c )
        {
            c.AllowDrop = true;
            c.MouseDown += Control_MouseDown;
            c.MouseMove += Control_MouseMove;
            c.MouseUp += Control_MouseUp;
            c.DragOver += Control_DragOver;
            c.DragDrop += Control_DragDrop;
        }

        protected abstract bool GetItemFromPoint( TControl parent, Point p, out T item, out int itemIndex );

        protected abstract bool AllowDrag( TControl parent, T item, int index );

        protected abstract bool AllowDrop( TControl dragParent, T dragItem, int dragItemIndex, TControl pointedParent, T pointedItem, int pointedItemIndex );

        protected abstract void MoveItem( TControl dragParent, T dragItem, int dragItemIndex, TControl pointedParent, T pointedItem, int pointedItemIndex );

        protected virtual bool ItemsEqual( TControl parent1, T item1, int itemIndex1, TControl parent2, T item2, int itemIndex2 )
        {
            return Object.Equals( item1, item2 );
        }

        protected virtual void OnDragStart( DragStartEventArgs<TControl, T> e )
        {
        }

        protected virtual void OnDragMove( DragMoveEventArgs<TControl, T> e )
        {
        }

        protected virtual void OnDragMoveOver( DragMoveOverEventArgs<TControl, T> e )
        {
        }

        protected virtual void OnDragEnd( DragEndEventArgs<TControl, T> e )
        {
        }

        private void ClearDragDrop()
        {
            _mouseDown = false;
            _mouseDownLocation = Point.Empty;

            _mouseDownItem = default( T );
            _mouseDownItemIndex = -1;
            _mouseDownParent = null;
        }

        private bool MoveItemInternal( TControl pointedParent, DragDropItem<TControl, T> d, DragEventArgs e, bool dropping )
        {
            try
            {
                Point p = new Point( e.X, e.Y );

                T pointedItem;
                int pointedItemIndex;
                if( GetItemFromPoint( pointedParent, pointedParent.PointToClient( p ), out pointedItem, out pointedItemIndex )
                 && e.AllowedEffect == DragDropEffects.Move )
                {
                    OnDragMoveOver( new DragMoveOverEventArgs<TControl, T>( d.DragParent, d.DragItem, d.DragItemIndex, d.DragStart, p, pointedParent, pointedItem, pointedItemIndex ) );

                    if( AllowDrop( d.DragParent, d.DragItem, d.DragItemIndex, pointedParent, pointedItem, pointedItemIndex ) )
                    {
                        e.Effect = DragDropEffects.Move;

                        if( dropping
                         || !MoveOnDragDrop )
                        {
                            MoveItem( d.DragParent, d.DragItem, d.DragItemIndex, pointedParent, pointedItem, pointedItemIndex );

                            d.UpdateSwapped( pointedParent, pointedItemIndex );

                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch( Exception ex )
            {
                LOG.Error( "MoveItemInternal - An error occurred while moving item", ex );
            }

            e.Effect = DragDropEffects.None;
            return false;
        }

        private void Control_MouseDown( object sender, MouseEventArgs e )
        {
            try
            {
                if( e.Button == MouseButtons.Left )
                {
                    TControl parent = (TControl)sender;

                    T item;
                    int itemIndex;
                    if( GetItemFromPoint( parent, e.Location, out item, out itemIndex )
                     && AllowDrag( parent, item, itemIndex ) )
                    {
                        _mouseDown = true;
                        _mouseDownLocation = parent.PointToScreen( e.Location );

                        _mouseDownItem = item;
                        _mouseDownItemIndex = itemIndex;
                        _mouseDownParent = parent;
                    }
                }
            }
            catch( Exception ex )
            {
                LOG.Error( "Control_MouseDown - An error occurred while mousing down", ex );
            }
        }

        private void Control_MouseUp( object sender, MouseEventArgs e )
        {
            if( _mouseDown )
            {
                ClearDragDrop();
            }
        }

        private void Control_MouseMove( object sender, MouseEventArgs e )
        {
            try
            {
                if( _mouseDown )
                {
                    TControl parent = (TControl)sender;
                    Point p = parent.PointToScreen( e.Location );

                    if( Math.Sqrt( Math.Pow( p.X - _mouseDownLocation.X, 2 ) + Math.Pow( p.Y - _mouseDownLocation.Y, 2 ) ) >= DRAG_THRESHOLD )
                    {
                        T item;
                        int itemIndex;
                        if( GetItemFromPoint( parent, e.Location, out item, out itemIndex )
                         && ItemsEqual( _mouseDownParent, _mouseDownItem, _mouseDownItemIndex, parent, item, itemIndex ) )
                        {
                            _mouseDown = false;

                            OnDragStart( new DragStartEventArgs<TControl, T>( parent, item, itemIndex, _mouseDownLocation ) );

                            DragDropItem<TControl, T> dragDropItem = new DragDropItem<TControl, T>( parent, item, itemIndex, _mouseDownLocation );
                            DragDropEffects effects = parent.DoDragDrop( dragDropItem, DragDropEffects.Move );

                            OnDragEnd( new DragEndEventArgs<TControl, T>( parent, item, itemIndex, _mouseDownLocation, Control.MousePosition, effects ) );

                            ClearDragDrop();
                        }
                        else
                        {
                            ClearDragDrop();
                        }
                    }
                }
            }
            catch( Exception ex )
            {
                LOG.Error( "Control_MouseMove - An error occurred while mousing moving", ex );
            }
        }

        private void Control_DragOver( object sender, DragEventArgs e )
        {
            try
            {
                if( e.Data.GetDataPresent( typeof( DragDropItem<TControl, T> ) ) )
                {
                    DragDropItem<TControl, T> d = (DragDropItem<TControl, T>)e.Data.GetData( typeof( DragDropItem<TControl, T> ) );

                    TControl pointedParent = (TControl)sender;

                    OnDragMove( new DragMoveEventArgs<TControl, T>( d.DragParent, d.DragItem, d.DragItemIndex, d.DragStart, new Point( e.X, e.Y ) ) );

                    MoveItemInternal( pointedParent, d, e, false );
                }
            }
            catch( Exception ex )
            {
                LOG.Error( "Control_DragOver - An error occurred while dragging over", ex );
            }
        }

        private void Control_DragDrop( object sender, DragEventArgs e )
        {
            try
            {
                if( e.Data.GetDataPresent( typeof( DragDropItem<TControl, T> ) ) )
                {
                    DragDropItem<TControl, T> d = (DragDropItem<TControl, T>)e.Data.GetData( typeof( DragDropItem<TControl, T> ) );

                    TControl pointedParent = (TControl)sender;

                    MoveItemInternal( pointedParent, d, e, true );
                }
            }
            catch( Exception ex )
            {
                LOG.Error( "Control_DragDrop - An error occurred while drag dropping", ex );
            }
        }
    }

    public class DragDropItem<TControl, T> where TControl : Control
    {
        public TControl DragParent { get; private set; }
        public T DragItem { get; private set; }
        public int DragItemIndex { get; private set; }
        public Point DragStart { get; private set; }

        public DragDropItem( TControl dragParent, T dragItem, int dragItemIndex, Point dragStart )
        {
            DragParent = dragParent;
            DragItem = dragItem;
            DragItemIndex = dragItemIndex;
            DragStart = dragStart;
        }

        public void UpdateSwapped( TControl newDragParent, int newDragItemIndex )
        {
            DragParent = newDragParent;
            DragItemIndex = newDragItemIndex;
        }
    }

    public class DragEventArgs<TControl, T> : EventArgs where TControl : Control
    {
        public TControl DragParent { get; private set; }
        public T DragItem { get; private set; }
        public int DragItemIndex { get; private set; }

        protected DragEventArgs( TControl dragParent, T dragItem, int dragItemIndex )
        {
            DragParent = dragParent;
            DragItem = dragItem;
            DragItemIndex = dragItemIndex;
        } 
    }

    public class DragStartEventArgs<TControl, T> : DragEventArgs<TControl, T> where TControl : Control
    {
        public Point DragStartPosition { get; private set; }

        public DragStartEventArgs( TControl dragParent, T dragItem, int dragItemIndex, Point dragStartPosition )
            : base( dragParent, dragItem, dragItemIndex )
        {
            DragStartPosition = dragStartPosition;
        }
    }

    public class DragMoveEventArgs<TControl, T> : DragStartEventArgs<TControl, T> where TControl : Control
    {
        public Point DragCurrentPosition { get; private set; }

        public DragMoveEventArgs( TControl dragParent, T dragItem, int dragItemIndex, Point dragStartPosition, Point dragCurrentPosition )
            : base( dragParent, dragItem, dragItemIndex, dragStartPosition )
        {
            DragCurrentPosition = dragCurrentPosition;
        }
    }

    public class DragMoveOverEventArgs<TControl, T> : DragMoveEventArgs<TControl, T> where TControl : Control
    {
        public TControl PointedParent { get; private set; }
        public T PointedItem { get; private set; }
        public int PointedItemIndex { get; private set; }

        public DragMoveOverEventArgs( TControl dragParent, T dragItem, int dragItemIndex, Point dragStartPosition, Point dragCurrentPosition, TControl pointedParent, T pointedItem, int pointedItemIndex )
            : base( dragParent, dragItem, dragItemIndex, dragStartPosition, dragCurrentPosition )
        {
            PointedParent = pointedParent;
            PointedItem = pointedItem;
            PointedItemIndex = pointedItemIndex;
        }
    }

    public class DragEndEventArgs<TControl, T> : DragStartEventArgs<TControl, T> where TControl : Control
    {
        public Point DragEndPosition { get; private set; }
        public DragDropEffects Effects { get; private set; }

        public DragEndEventArgs( TControl dragParent, T dragItem, int dragItemIndex, Point dragStartPosition, Point dragEndPosition, DragDropEffects effects )
            : base( dragParent, dragItem, dragItemIndex, dragStartPosition )
        {
            DragEndPosition = dragEndPosition;
            Effects = effects;
        }
    }
}
