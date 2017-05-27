using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabbedTortoiseGit
{
    class HotKeyMessageReceivedEventArgs : EventArgs
    {
        public int HotKeyId { get; private set; }

        public HotKeyMessageReceivedEventArgs( int hotKeyId )
        {
            HotKeyId = hotKeyId;
        }
    }

    class WndProcMessageQueue
    {
        private static readonly ManualResetEvent _windowReadyEvent = new ManualResetEvent( false );

        private static MessageWindow _messageWindow;
        static WndProcMessageQueue()
        {
            Thread messageLoop = new Thread( delegate ()
            {
                _messageWindow = new MessageWindow();
                _windowReadyEvent.Set();
                Application.Run( _messageWindow );
            } );
            messageLoop.Name = "WndProcMessageQueueLoopThread";
            messageLoop.IsBackground = true;
            messageLoop.Start();
        }

        public static event EventHandler<HotKeyMessageReceivedEventArgs> HotKeyMessageReceived;

        public static bool RegisterHotKey( HotKey hotkey )
        {
            _windowReadyEvent.WaitOne();
            return RegisterHotKey( _messageWindow.Handle, hotkey.Id, (int)hotkey.Modifiers, (int)hotkey.Key );
        }

        public static bool UnregisterHotKey( HotKey hotkey )
        {
            _windowReadyEvent.WaitOne();
            return UnregisterHotKey( _messageWindow.Handle, hotkey.Id );
        }

        [DllImport( "user32.dll" )]
        private static extern bool RegisterHotKey( IntPtr hWnd, int id, int fsModifiers, int vlc );

        [DllImport( "user32.dll" )]
        private static extern bool UnregisterHotKey( IntPtr hWnd, int id );

        private class MessageWindow : Form
        {
            private static readonly int WM_HOTKEY = 0x0312;

            public MessageWindow()
            {
            }

            protected override void WndProc( ref Message m )
            {
                if( m.Msg == WM_HOTKEY )
                {
                    OnHotKeyMessageReceived( new HotKeyMessageReceivedEventArgs( m.WParam.ToInt32() ) );
                }

                base.WndProc( ref m );
            }

            protected void OnHotKeyMessageReceived( HotKeyMessageReceivedEventArgs e )
            {
                HotKeyMessageReceived( this, e );
            }

            protected override void SetVisibleCore( bool value )
            {
                base.SetVisibleCore( false );
            }
        }
    }
}
