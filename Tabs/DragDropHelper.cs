using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tabs
{
    abstract class DragDropHelper<TControl, T> where TControl : Control
    {
        private bool _hasItem;
        private Point _dragStart;

        private T _dragItem;
        private int _dragItemIndex;
        private TControl _dragItemParent;

        private T _lastSwappedItem;
        private int _lastSwappedIndex;
        private TControl _lastSwappedParent;

        public bool AllowReSwap { get; set; }

        public DragDropHelper()
        {
            ClearDragDrop();
        }

        public void AddControl( TControl c )
        {
            c.AllowDrop = true;
            c.MouseDown += Control_MouseDown;
            c.MouseMove += Control_MouseMove;
            c.MouseUp += Control_MouseUp;
            c.DragOver += Control_DragOver;
        }

        protected abstract bool GetItemFromPoint( TControl parent, Point p, out T item, out int itemIndex );

        protected abstract bool AllowDrag( TControl parent, T item, int index );

        protected abstract bool SwapItems( TControl dragParent, T dragItem, int dragItemIndex, TControl pointedParent, T pointedItem, int pointedItemIndex );

        protected virtual bool ItemsEqual( TControl parent1, T item1, int itemIndex1, TControl parent2, T item2, int itemIndex2 )
        {
            return Object.Equals( item1, item2 );
        }

        private void ClearDragDrop()
        {
            _hasItem = false;
            _dragStart = Point.Empty;

            _dragItem = default( T );
            _dragItemIndex = -1;
            _dragItemParent = null;

            _lastSwappedItem = default( T );
            _lastSwappedIndex = -1;
            _lastSwappedParent = null;
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
                    _hasItem = true;
                    _dragItem = item;
                    _dragItemIndex = itemIndex;
                    _dragItemParent = parent;
                    _dragStart = parent.PointToClient( e.Location );
                }
            }
        }

        private void Control_MouseMove( object sender, MouseEventArgs e )
        {
            if( _hasItem )
            {
                TControl parent = (TControl)sender;

                Point p = parent.PointToScreen( e.Location );

                if( ( p.X - _dragStart.X ) > SystemInformation.DragSize.Width
                 && ( p.Y - _dragStart.Y ) > SystemInformation.DragSize.Height )
                {
                    parent.DoDragDrop( _dragItem, DragDropEffects.Move );
                    ClearDragDrop();
                }
            }
        }

        private void Control_MouseUp( object sender, MouseEventArgs e )
        {
            if( _hasItem )
            {
                ClearDragDrop();
            }
        }

        private void Control_DragOver( object sender, DragEventArgs e )
        {
            if( e.Data.GetDataPresent( typeof( T ) ) )
            {
                TControl pointedParent = (TControl)sender;

                T pointedItem;
                int pointedItemIndex;
                if( GetItemFromPoint( pointedParent, pointedParent.PointToClient( new Point( e.X, e.Y ) ), out pointedItem, out pointedItemIndex )
                 && ( AllowReSwap
                   || !ItemsEqual( _lastSwappedParent, _lastSwappedItem, _lastSwappedIndex, pointedParent, pointedItem, pointedItemIndex ) )
                 && ( ( pointedParent != _dragItemParent )
                   || ( pointedItemIndex != _dragItemIndex ) )
                 && e.AllowedEffect == DragDropEffects.Move )
                {
                    if( SwapItems( _dragItemParent, _dragItem, _dragItemIndex, pointedParent, pointedItem, pointedItemIndex ) )
                    {
                        e.Effect = DragDropEffects.Move;

                        _dragItemIndex = pointedItemIndex;

                        _lastSwappedItem = pointedItem;
                        _lastSwappedIndex = _dragItemIndex;
                        _lastSwappedParent = _dragItemParent;
                    }
                }
            }
        }
    }
}
