using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabbedTortoiseGit
{
    abstract class DragDropHelper<TControl, T> where TControl : Control
    {
        private readonly List<TControl> _controls;

        private bool _hasItem;
        private T _dragItem;
        private int _dragItemIndex;
        private TControl _dragItemParent;
        private Point _dragStart;

        public DragDropHelper( params TControl[] controls )
        {
            _controls = new List<TControl>( controls );
            foreach( TControl c in _controls )
            {
                c.AllowDrop = true;
                c.MouseDown += Control_MouseDown;
                c.MouseMove += Control_MouseMove;
                c.MouseUp += Control_MouseUp;
                c.DragOver += Control_DragOver;
            }
        }

        protected abstract bool GetItemFromPoint( TControl parent, Point p, out T item, out int itemIndex );

        protected abstract void SwapItems( TControl dragParent, T dragItem, int dragItemIndex, TControl pointedParent, T pointedItem, int pointedItemIndex );

        private void ClearDragDrop()
        {
            _hasItem = false;
            _dragItem = default( T );
            _dragItemIndex = 0;
            _dragItemParent = null;
            _dragStart = Point.Empty;
        }

        private void Control_MouseDown( object sender, MouseEventArgs e )
        {
            TControl parent = (TControl)sender;

            T item;
            int itemIndex;
            if( GetItemFromPoint( parent, e.Location, out item, out itemIndex ) )
            {
                _hasItem = true;
                _dragItem = item;
                _dragItemIndex = itemIndex;
                _dragItemParent = parent;
                _dragStart = parent.PointToClient( e.Location );
            }
        }

        private void Control_MouseMove( object sender, MouseEventArgs e )
        {
            TControl parent = (TControl)sender;

            Point p = parent.PointToScreen( e.Location );

            if( _hasItem
             && ( p.X - _dragStart.X ) > SystemInformation.DragSize.Width
             && ( p.Y - _dragStart.Y ) > SystemInformation.DragSize.Height )
            {
                DragDropEffects effects = parent.DoDragDrop( _dragItem, DragDropEffects.Move );
                if( effects == DragDropEffects.Move )
                {
                    ClearDragDrop();
                }
            }
        }

        private void Control_MouseUp( object sender, MouseEventArgs e )
        {
            ClearDragDrop();
        }

        private void Control_DragOver( object sender, DragEventArgs e )
        {
            TControl pointedParent = (TControl)sender;

            T pointedItem;
            int pointedItemIndex;
            if( GetItemFromPoint( pointedParent, pointedParent.PointToClient( new Point( e.X, e.Y ) ), out pointedItem, out pointedItemIndex )
             && ( ( pointedParent != _dragItemParent ) || ( pointedItemIndex != _dragItemIndex ) )
             && e.AllowedEffect == DragDropEffects.Move )
            {
                e.Effect = DragDropEffects.Move;
                SwapItems( _dragItemParent, _dragItem, _dragItemIndex, pointedParent, pointedItem, pointedItemIndex );
                _dragItemIndex = pointedItemIndex;
            }
        }
    }
}
