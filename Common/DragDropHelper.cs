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
        private static readonly int DRAG_THRESHOLD = 4;

        private bool _mouseDown;
        private Point _mouseDownLocation;

        private T _mouseDownItem;
        private int _mouseDownItemIndex;
        private TControl _mouseDownParent;

        private bool _dragging;
        private Point _dragStart;

        private T _dragItem;
        private int _dragItemIndex;
        private TControl _dragItemParent;

        private T _lastSwappedItem;
        private int _lastSwappedIndex;
        private TControl _lastSwappedParent;

        public bool AllowReSwap { get; set; }
        public bool MoveOnDragDrop { get; set; }

        public DragDropHelper()
        {
            AllowReSwap = true;
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

        protected abstract bool MoveItem( TControl dragParent, T dragItem, int dragItemIndex, TControl pointedParent, T pointedItem, int pointedItemIndex );

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

            _dragging = false;
            _dragStart = Point.Empty;

            _dragItem = default( T );
            _dragItemIndex = -1;
            _dragItemParent = null;

            _lastSwappedItem = default( T );
            _lastSwappedIndex = -1;
            _lastSwappedParent = null;
        }

        private bool TryMoveItem( TControl pointedParent, DragEventArgs e )
        {
            T pointedItem;
            int pointedItemIndex;
            if( GetItemFromPoint( pointedParent, pointedParent.PointToClient( new Point( e.X, e.Y ) ), out pointedItem, out pointedItemIndex )
             && ( AllowReSwap
               || !ItemsEqual( _lastSwappedParent, _lastSwappedItem, _lastSwappedIndex, pointedParent, pointedItem, pointedItemIndex ) )
             && ( ( pointedParent != _dragItemParent )
               || ( pointedItemIndex != _dragItemIndex ) )
             && e.AllowedEffect == DragDropEffects.Move )
            {
                if( MoveItem( _dragItemParent, _dragItem, _dragItemIndex, pointedParent, pointedItem, pointedItemIndex ) )
                {
                    _dragItemIndex = pointedItemIndex;

                    _lastSwappedItem = pointedItem;
                    _lastSwappedIndex = _dragItemIndex;
                    _lastSwappedParent = _dragItemParent;

                    return true;
                }
            }
            return false;
        }

        private void Control_MouseDown( object sender, MouseEventArgs e )
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

        private void Control_MouseUp( object sender, MouseEventArgs e )
        {
            if( _mouseDown )
            {
                ClearDragDrop();
            }
        }

        private void Control_MouseMove( object sender, MouseEventArgs e )
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

                        _dragging = true;
                        _dragStart = _mouseDownLocation;

                        _dragItemParent = parent;
                        _dragItem = item;
                        _dragItemIndex = itemIndex;

                        OnDragStart( new DragStartEventArgs<TControl, T>( _dragItemParent, _dragItem, _dragItemIndex, _dragStart ) );

                        parent.DoDragDrop( _dragItem, DragDropEffects.Move );

                        OnDragEnd( new DragEndEventArgs<TControl, T>( _dragItemParent, _dragItem, _dragItemIndex, _dragStart, Control.MousePosition ) );

                        ClearDragDrop();
                    }
                    else
                    {
                        ClearDragDrop();
                    }
                }
            }
        }

        private void Control_DragOver( object sender, DragEventArgs e )
        {
            if( e.Data.GetDataPresent( typeof( T ) ) )
            {
                TControl pointedParent = (TControl)sender;
                Point p = new Point( e.X, e.Y );

                OnDragMove( new DragMoveEventArgs<TControl, T>( _dragItemParent, _dragItem, _dragItemIndex, _dragStart, p ) );

                e.Effect = DragDropEffects.Move;

                if( !MoveOnDragDrop )
                {
                    TryMoveItem( pointedParent, e );
                }
            }
        }

        private void Control_DragDrop( object sender, DragEventArgs e )
        {
            if( MoveOnDragDrop
             && e.Data.GetDataPresent( typeof( T ) ) )
            {
                TControl pointedParent = (TControl)sender;

                e.Effect = DragDropEffects.Move;

                TryMoveItem( pointedParent, e );
            }
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

    public class DragEndEventArgs<TControl, T> : DragStartEventArgs<TControl, T> where TControl : Control
    {
        public Point DragEndPosition { get; private set; }

        public DragEndEventArgs( TControl dragParent, T dragItem, int dragItemIndex, Point dragStartPosition, Point dragEndPosition )
            : base( dragParent, dragItem, dragItemIndex, dragStartPosition )
        {
            DragEndPosition = dragEndPosition;
        }
    }
}
