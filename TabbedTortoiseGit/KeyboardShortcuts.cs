using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabbedTortoiseGit.Properties;

namespace TabbedTortoiseGit
{
    public enum KeyboardShortcuts
    {
        [Description( "New Tab" )]
        NewTab,
        [Description( "Next Tab" )]
        NextTab,
        [Description( "Previous Tab" )]
        PreviousTab,
        [Description( "Close Tab" )]
        CloseTab,
        [Description( "Reopen Closed Tab" )]
        ReopenClosedTab,

        [Description( "Commit" )]
        Commit,
        [Description( "Fast Fetch" )]
        FastFetch,
        [Description( "Faster Fetch" )]
        FasterFetch,
        [Description( "Fast Submodule Update" )]
        FastSubmoduleUpdate,
        [Description( "Faster Submodule Update" )]
        FasterSubmoduleUpdate,
        [Description( "Fetch" )]
        Fetch,
        [Description( "Pull" )]
        Pull,
        [Description( "Push" )]
        Push,
        [Description( "Rebase" )]
        Rebase,
        [Description( "Submodule Update" )]
        SubmoduleUpdate,
        [Description( "Switch/Checkout" )]
        SwitchCheckout
    }

    class KeyboardShortcutPressedEventArgs : EventArgs
    {
        public KeyboardShortcuts KeyboardShortcut { get; private set; }

        public KeyboardShortcutPressedEventArgs( KeyboardShortcuts keyboardShortcut )
        {
            KeyboardShortcut = keyboardShortcut;
        }
    }

    class KeyboardShortcutsManager : IDisposable
    {
        private static readonly ILog LOG = LogManager.GetLogger( typeof( KeyboardShortcutsManager ) );

        private static KeyboardShortcutsManager _instance;

        public static KeyboardShortcutsManager Instance
        {
            get
            {
                if( _instance == null )
                {
                    LOG.Fatal( $"{nameof( Instance )} - Attempted to retrieve instance before calling Create()." );
                    throw new InvalidOperationException( $"{nameof( Instance )} cannot be accessed before calling KeyboardShortcutsManager.Create()." );
                }

                return _instance;
            }
        }

        public static KeyboardShortcutsManager Create( IntPtr windowHandle )
        {
            LOG.Debug( $"{nameof( Create )} - Window Handle: {windowHandle}" );

            if( _instance != null )
            {
                LOG.Fatal( $"{nameof( Create )} - Attempted to re-call Create()." );
                throw new InvalidOperationException( "KeyboardShortcutsManager.Create() can only be called once." );
            }

            _instance = new KeyboardShortcutsManager( windowHandle );

            return Instance;
        }

        public event EventHandler<KeyboardShortcutPressedEventArgs> KeyboardShortcutPressed;

        private readonly Dictionary<KeyboardShortcuts, HotKey> _hotkeys = new Dictionary<KeyboardShortcuts, HotKey>();
        private readonly IntPtr _windowHandle;

        private KeyboardShortcutsManager( IntPtr windowHandle )
        {
            LOG.Debug( $"Constructor - Window Handle: {windowHandle}" );

            _windowHandle = windowHandle;

            foreach( KeyboardShortcuts keyboardShortcut in Enum.GetValues( typeof( KeyboardShortcuts ) ) )
            {
                HotKey hotkey = new HotKey( _windowHandle );
                hotkey.HotKeyPressed += Hotkey_HotKeyPressed;
                _hotkeys[ keyboardShortcut ] = hotkey;
            }

            UpdateShortcuts();

            Settings.Default.PropertyChanged += Settings_PropertyChanged;
        }

        private void Settings_PropertyChanged( object sender, PropertyChangedEventArgs e )
        {
            if( e.PropertyName == nameof( Settings.Default.KeyboardShortcutsString ) )
            {
                LOG.Debug( "KeyboardShortcutsString setting changed" );

                UpdateShortcuts();
            }
        }

        private void Hotkey_HotKeyPressed( object sender, EventArgs e )
        {
            HotKey hotkey = (HotKey)sender;

            KeyboardShortcuts keyboardShortcut = _hotkeys.Where( pair => pair.Value == hotkey ).First().Key;

            OnKeyboardShortcutPressed( new KeyboardShortcutPressedEventArgs( keyboardShortcut ) );
        }

        public void UpdateShortcuts()
        {
            LOG.Debug( nameof( UpdateShortcuts ) );

            this.ThrowIfDisposed();

            Dictionary<KeyboardShortcuts, Shortcut> shortcuts = Settings.Default.KeyboardShortcuts;

            foreach( KeyboardShortcuts keyboardShortcut in Enum.GetValues( typeof( KeyboardShortcuts ) ) )
            {
                Shortcut shortcut;
                if( shortcuts.TryGetValue( keyboardShortcut, out shortcut ) )
                {
                    LOG.Debug( $"{nameof( UpdateShortcuts )} - KeyboardShortuct: {keyboardShortcut} - Shortcut: {shortcut}" );
                    _hotkeys[ keyboardShortcut ].SetShortcut( shortcut );
                }
                else
                {
                    LOG.Debug( $"{nameof( UpdateShortcuts )} - KeyboardShortuct: {keyboardShortcut} - No shortcut" );
                    _hotkeys[ keyboardShortcut ].SetShortcut( Shortcut.Empty );
                }
            }
        }

        public void AddHandle( IntPtr handle )
        {
            LOG.Debug( $"{nameof( AddHandle )} - Handle: {handle}" );

            this.ThrowIfDisposed();

            foreach( HotKey hotkey in _hotkeys.Values )
            {
                hotkey.AddHandle( handle );
            }
        }

        public void RemoveHandle( IntPtr handle )
        {
            LOG.Debug( $"{nameof( RemoveHandle )} - Handle: {handle}" );

            this.ThrowIfDisposed();

            foreach( HotKey hotkey in _hotkeys.Values )
            {
                hotkey.RemoveHandle( handle );
            }
        }

        protected void OnKeyboardShortcutPressed( KeyboardShortcutPressedEventArgs e )
        {
            KeyboardShortcutPressed?.Invoke( this, e );
        }

        #region IDisposable Support
        private bool _disposed = false;

        private void ThrowIfDisposed()
        {
            if( _disposed )
            {
                throw new ObjectDisposedException( nameof( KeyboardShortcutsManager ) );
            }
        }

        protected virtual void Dispose( bool disposing )
        {
            if( !_disposed )
            {
                if( disposing )
                {
                    foreach( HotKey hotkey in _hotkeys.Values )
                    {
                        hotkey.Dispose();
                    }
                    _hotkeys.Clear();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose( true );
        }
        #endregion
    }
}
