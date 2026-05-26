using Common;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.Input.KeyboardAndMouse;
using WindowsInput;
using WindowsInput.Native;

namespace TabbedTortoiseGit
{
    [Flags]
    public enum KeyModifier : uint
    {
        None = 0x0000,
        Alt = HOT_KEY_MODIFIERS.MOD_ALT,
        Control = HOT_KEY_MODIFIERS.MOD_CONTROL,
        NoRepeat = HOT_KEY_MODIFIERS.MOD_NOREPEAT,
        Shift = HOT_KEY_MODIFIERS.MOD_SHIFT,
        Win = HOT_KEY_MODIFIERS.MOD_WIN,
    }

    public class HotKey( IntPtr windowHandle ) : IDisposable
    {
        private static readonly ILog LOG = LogManager.GetLogger( typeof( HotKey ) );

        private static readonly KeyValuePair<Keys, KeyModifier>[] MODIFIER_MAPPING = [
            new KeyValuePair<Keys, KeyModifier>( Keys.Control, KeyModifier.Control ),
            new KeyValuePair<Keys, KeyModifier>( Keys.Shift, KeyModifier.Shift ),
            new KeyValuePair<Keys, KeyModifier>( Keys.Alt, KeyModifier.Alt )
        ];

        private static int _nextId = 0;
        private static MessageFilter? _filter;

        private event EventHandler? HotKeyPressedInternal;

        private readonly HashSet<IntPtr> _handles = new HashSet<IntPtr>();
        private bool _registered = false;

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

        public IntPtr WindowHandle { get; private set; } = windowHandle;
        public Shortcut? Shortcut { get; private set; } = null;
        public int Id { get; private set; } = Interlocked.Increment( ref _nextId );

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

        private void OnHotKeyPressed( HotKeyPressedEventArgs e )
        {
            if( _handles.Contains( PInvoke.GetForegroundWindow() ) )
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
                LOG.Error( $"{nameof( Register )} - Invalid shortcut - {Shortcut}" );
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
                    LOG.Error( $"{nameof( Register )} - Failed to Register HotKey - Id: {this.Id} - HotKey: {this}" );
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
                if( _filter?.UnregisterHotKey( this ) != false )
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
            return $"{{ {Modifiers}, {Key} }}";
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

        class MessageFilter( IntPtr mainWindowHandle ) : IMessageFilter
        {
            private static readonly int WM_HOTKEY = 0x0312;

            private static readonly InputSimulator INPUT_SIMULATOR = new InputSimulator();

            private readonly IntPtr _mainWindowHandle = mainWindowHandle;
            private readonly Dictionary<int, HotKey> _hotKeys = [];

            public bool RegisterHotKey( HotKey hotkey )
            {
                if( PInvoke.RegisterHotKey( (HWND)_mainWindowHandle, hotkey.Id, (HOT_KEY_MODIFIERS)hotkey.Modifiers, (uint)hotkey.Key ) )
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
                if( PInvoke.UnregisterHotKey( (HWND)_mainWindowHandle , hotkey.Id ) )
                {
                    _hotKeys.Remove( hotkey.Id );
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool PreFilterMessage( ref Message m )
            {
                if( m.Msg == WM_HOTKEY )
                {
                    int hotkeyId = m.WParam.ToInt32();
                    if( _hotKeys.TryGetValue( hotkeyId, out HotKey? hotkey ) )
                    {
                        HotKeyPressedEventArgs e = new HotKeyPressedEventArgs();
                        hotkey.OnHotKeyPressed( e );
                        if( !e.Handled )
                        {
                            LOG.Debug( $"Fowarding unhandled HotKey: {hotkey.Shortcut?.Text ?? "Unknown Shortcut"}" );

                            hotkey.Unregister();

                            LOG.Debug( $"InputSimulator - KeyPress: {(VirtualKeyCode)hotkey.Key}" );
                            INPUT_SIMULATOR.Keyboard.KeyPress( (VirtualKeyCode)hotkey.Key );

                            hotkey.Register();
                        }
                        else
                        {
                            LOG.Debug( $"Handled HotKey: {hotkey}" );
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
