using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabbedTortoiseGit
{
    [Flags]
    public enum KeyModifier
    {
        None = 0x0000,
        Alt = 0x0001,
        Control = 0x0002,
        NoRepeat = 0x4000,
        Shift = 0x0004,
        Win = 0x0008
    }

    public class HotKey : IDisposable
    {
        private static readonly ILog LOG = LogManager.GetLogger( typeof( HotKey ) );

        private static int _nextId = 0;

        private event EventHandler HotKeyPressedInternal;

        private readonly ISet<IntPtr> _handles = new HashSet<IntPtr>();
        private bool _registered;

        public event EventHandler HotKeyPressed
        {
            add
            {
                if( _disposed )
                {
                    throw new ObjectDisposedException( nameof( HotKey ) );
                }

                HotKeyPressedInternal += value;

                if( !_registered )
                {
                    Register();
                }
            }

            remove
            {
                if( _disposed )
                {
                    throw new ObjectDisposedException( nameof( HotKey ) );
                }

                HotKeyPressedInternal -= value;

                if( _registered && HotKeyPressedInternal == null )
                {
                    Unregister();
                }
            }
        }

        public KeyModifier Modifiers { get; private set; }
        public Keys Key { get; private set; }
        public int Id { get; private set; }

        public HotKey( KeyModifier modifiers, Keys key )
        {
            Modifiers = modifiers;
            Key = key;
            Id = Interlocked.Increment( ref _nextId ); ;

            _registered = false;
        }

        private void OnHotKeyPressed( EventArgs e )
        {
            HotKeyPressedInternal( this, e );
        }

        public void AddHandle( IntPtr handle )
        {
            if( _disposed )
            {
                throw new ObjectDisposedException( nameof( HotKey ) );
            }

            _handles.Add( handle );
        }

        public void RemoveHandle( IntPtr handle )
        {
            if( _disposed )
            {
                throw new ObjectDisposedException( nameof( HotKey ) );
            }

            _handles.Remove( handle );
        }

        private void Register()
        {
            if( _disposed )
            {
                throw new ObjectDisposedException( nameof( HotKey ) );
            }

            if( !_registered )
            {
                if( WndProcMessageQueue.RegisterHotKey( this ) )
                {
                    WndProcMessageQueue.HotKeyMessageReceived += WndProcMessageQueue_HotKeyMessageReceived;

                    _registered = true;
                }
                else
                {
                    LOG.ErrorFormat( "Register - Failed to Register HotKey - Id: {0} - ModifierKeys: {1} - Key: {2}", this.Id, this.Modifiers, this.Key );
                }
            }
        }

        private void Unregister()
        {
            if( _disposed )
            {
                throw new ObjectDisposedException( nameof( HotKey ) );
            }

            if( _registered )
            {
                WndProcMessageQueue.UnregisterHotKey( this );
                WndProcMessageQueue.HotKeyMessageReceived -= WndProcMessageQueue_HotKeyMessageReceived;
            }
        }

        private void WndProcMessageQueue_HotKeyMessageReceived( object sender, HotKeyMessageReceivedEventArgs e )
        {
            if( _handles.Contains( Native.GetForegroundWindow() ) )
            {
                OnHotKeyPressed( EventArgs.Empty );
            }
        }

        #region IDisposable Support
        private bool _disposed = false;

        protected virtual void Dispose( bool disposing )
        {
            if( !_disposed )
            {
                if( disposing )
                {
                    Unregister();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }
        #endregion
    }
}
