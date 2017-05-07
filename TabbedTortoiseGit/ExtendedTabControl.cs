using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabbedTortoiseGit
{
    class ExtendedTabControl : TabControl
    {
        private const int TCM_SETMINTABWIDTH = 0x1300 + 49;

        public event EventHandler NewTabClicked;
        public event EventHandler<TabClosedEventArgs> TabClosed;

        private readonly TabPage _newTab;

        private bool _inhibitControlActions = false;

        public ExtendedTabControl()
        {
            _newTab = new TabPage( "+" );

            this.TabPages.Add( _newTab );
        }

        protected void OnNewTabClicked( EventArgs e )
        {
            NewTabClicked( this, e );
        }

        protected void OnTabClosed( TabClosedEventArgs e )
        {
            TabClosed( this, e );
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
                    _inhibitControlActions = true;
                    this.TabPages.Remove( t );
                    this.TabPages.Insert( this.TabCount - 1, t );
                    _inhibitControlActions = false;
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

        [DllImport( "user32.dll" )]
        private static extern IntPtr SendMessage( IntPtr hWnd, int msg, IntPtr wp, IntPtr lp );

        protected override void OnHandleCreated( EventArgs e )
        {
            SendMessage( this.Handle, TCM_SETMINTABWIDTH, IntPtr.Zero, (IntPtr)20 );

            base.OnHandleCreated( e );
        }

        protected override void OnMouseDown( MouseEventArgs e )
        {
            int lastIndex = this.TabCount - 1;

            if( !this.DesignMode && this.GetTabRect( lastIndex ).Contains( e.Location ) )
            {
                OnNewTabClicked( EventArgs.Empty );
            }
            else
            {
                base.OnMouseDown( e );
            }
        }

        protected override void OnSelecting( TabControlCancelEventArgs e )
        {
            if( e.TabPage == _newTab )
            {
                e.Cancel = true;
            }
            else
            {
                base.OnSelecting( e );
            }
        }

        protected override void OnMouseClick( MouseEventArgs e )
        {
            if( e.Button == MouseButtons.Middle )
            {
                TabPage tab = this.TabPages.Cast<TabPage>().Where( ( t, i ) => this.GetTabRect( i ).Contains( e.Location ) ).FirstOrDefault();
                if( tab != null && tab != _newTab )
                {
                    this.TabPages.Remove( tab );
                    OnTabClosed( new TabClosedEventArgs( tab ) );
                    return;
                }
            }

            base.OnMouseClick( e );
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
