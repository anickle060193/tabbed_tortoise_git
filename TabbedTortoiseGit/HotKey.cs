using Common;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

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

        private static readonly KeyValuePair<Keys, KeyModifier>[] MODIFIER_MAPPING = new[]
        {
            new KeyValuePair<Keys, KeyModifier>( Keys.Control, KeyModifier.Control ),
            new KeyValuePair<Keys, KeyModifier>( Keys.Shift, KeyModifier.Shift ),
            new KeyValuePair<Keys, KeyModifier>( Keys.Alt, KeyModifier.Alt )
        };

        private static int _nextId = 0;
        private static MessageFilter _filter;

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

        public IntPtr WindowHandle { get; private set; }
        public Shortcut Shortcut { get; private set; }
        public int Id { get; private set; }

        public KeyModifier Modifiers
        {
            get
            {
                return MODIFIER_MAPPING
                    .Where( modifier => Shortcut?.Modifiers.HasFlag( modifier.Key ) ?? false )
                    .Select( modifier => modifier.Value )
                    .Aggregate( KeyModifier.None, ( m1, m2 ) => m1 | m2 );
            }
        }

        public Keys Key
        {
            get
            {
                return Shortcut?.Key ?? Keys.None;
            }
        }

        public HotKey( IntPtr windowHandle )
        {
            WindowHandle = windowHandle;

            Shortcut = null;
            Id = Interlocked.Increment( ref _nextId );

            _registered = false;
        }

        private void OnHotKeyPressed( HotKeyPressedEventArgs e )
        {
            if( _handles.Contains( Native.GetForegroundWindow() ) )
            {
                HotKeyPressedInternal?.Invoke( this, e );
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        public void SetShortcut( Shortcut shortcut )
        {
            bool wasRegistered = _registered;
            if( _registered )
            {
                Unregister();
            }

            Shortcut = shortcut;

            if( ( wasRegistered || ( HotKeyPressedInternal != null ) )
             && ( Shortcut?.IsValid ?? false ) )
            {
                Register();
            }
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

            if( Shortcut == null )
            {
                return;
            }

            if( Shortcut?.IsValid != true )
            {
                LOG.ErrorFormat( "Register - Invalid shortcut - {0}", Shortcut );
                return;
            }

            if( !_registered )
            {
                if( _filter == null )
                {
                    _filter = new MessageFilter( WindowHandle );
                    Application.AddMessageFilter( _filter );
                }
                
                if( _filter.RegisterHotKey( this ) )
                {
                    _registered = true;
                }
                else
                {
                    LOG.ErrorFormat( "Register - Failed to Register HotKey - Id: {0} - HotKey: {1}", this.Id, this );
                }
            }
            else
            {
                throw new InvalidOperationException( "HotKey has already been registered." );
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
                if( _filter.UnregisterHotKey( this ) )
                {
                    _registered = false;
                }
            }
            else
            {
                throw new InvalidOperationException( "HotKey has already been unregistered." );
            }
        }

        public override string ToString()
        {
            return "{{ {0}, {1} }}".XFormat( Modifiers, Key );
        }

        #region IDisposable Support
        private bool _disposed = false;

        protected virtual void Dispose( bool disposing )
        {
            if( !_disposed )
            {
                if( disposing && _registered )
                {
                    Unregister();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose( true );
        }
        #endregion

        class MessageFilter : IMessageFilter
        {
            private static readonly int WM_HOTKEY = 0x0312;

            private static readonly InputSimulator INPUT_SIMULATOR = new InputSimulator();

            private readonly IntPtr _mainWindowHandle;
            private readonly Dictionary<int, HotKey> _hotKeys = new Dictionary<int, HotKey>();

            public MessageFilter( IntPtr mainWindowHandle )
            {
                _mainWindowHandle = mainWindowHandle;
            }

            public bool RegisterHotKey( HotKey hotkey )
            {
                if( RegisterHotKey( _mainWindowHandle, hotkey.Id, (int)hotkey.Modifiers, (int)hotkey.Key ) )
                {
                    _hotKeys[ hotkey.Id ] = hotkey;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool UnregisterHotKey( HotKey hotkey )
            {
                if( UnregisterHotKey( _mainWindowHandle, hotkey.Id ) )
                {
                    _hotKeys.Remove( hotkey.Id );
                    return true;
                }
                else
                {
                    return false;
                }
            }

            [DllImport( "user32.dll" )]
            private static extern bool RegisterHotKey( IntPtr hWnd, int id, int fsModifiers, int vlc );

            [DllImport( "user32.dll" )]
            private static extern bool UnregisterHotKey( IntPtr hWnd, int id );

            public bool PreFilterMessage( ref Message m )
            {
                if( m.Msg == WM_HOTKEY )
                {
                    int hotkeyId = m.WParam.ToInt32();
                    HotKey hotkey;
                    if( _hotKeys.TryGetValue( hotkeyId, out hotkey ) )
                    {
                        HotKeyPressedEventArgs e = new HotKeyPressedEventArgs();
                        hotkey.OnHotKeyPressed( e );
                        if( !e.Handled )
                        {
                            LOG.DebugFormat( "Fowarding unhandled HotKey: {0}", hotkey.Shortcut.Text );

                            hotkey.Unregister();

                            LOG.DebugFormat( "InputSimulator - KeyPress: {0}", (VirtualKeyCode)hotkey.Key );
                            INPUT_SIMULATOR.Keyboard.KeyPress( (VirtualKeyCode)hotkey.Key );

                            hotkey.Register();
                        }
                        else
                        {
                            LOG.DebugFormat( "Handled HotKey: {0}", hotkey );
                        }
                        return true;
                    }
                }

                return false;
            }
        }
    }

    public class HotKeyPressedEventArgs : EventArgs
    {
        public bool Handled { get; set; }

        public HotKeyPressedEventArgs()
        {
            Handled = false;
        }
    }
}
