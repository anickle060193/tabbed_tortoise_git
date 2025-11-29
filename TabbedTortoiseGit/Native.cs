using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.WindowsAndMessaging;

namespace Windows.Win32
{
    internal static partial class PInvoke
    {
        [DllImport( "USER32.dll", ExactSpelling = true, EntryPoint = "SendMessageW", SetLastError = true, CharSet = CharSet.Auto ), DefaultDllImportSearchPaths( DllImportSearchPath.System32 )]
        [SupportedOSPlatform( "windows5.0" )]
        internal static extern LRESULT SendMessage( HWND hWnd, uint Msg, WPARAM wParam, [MarshalAs( UnmanagedType.LPWStr )] string lParam );
    }
}

namespace TabbedTortoiseGit
{
    static class Native
    {
        public static void RemoveBorder( IntPtr windowHandle )
        {
            int style = PInvoke.GetWindowLong( (HWND)windowHandle, WINDOW_LONG_PTR_INDEX.GWL_STYLE );
            style &= ~(int)WINDOW_STYLE.WS_CAPTION;
            _ = PInvoke.SetWindowLong( (HWND)windowHandle, WINDOW_LONG_PTR_INDEX.GWL_STYLE, style );

            //int exstyle = PInvoke.GetWindowLong( (HWND)windowHandle, WINDOW_LONG_PTR_INDEX.GWL_EXSTYLE );
            //exstyle |= (int)WINDOW_EX_STYLE.WS_EX_WINDOWEDGE;
            //_ = PInvoke.SetWindowLong( (HWND)windowHandle, WINDOW_LONG_PTR_INDEX.GWL_EXSTYLE, exstyle );
        }

        public static void SetWindowParent( IntPtr windowHandle, Control parent )
        {
            PInvoke.SetParent( (HWND)windowHandle, (HWND)parent.Handle );
        }

        public static Size ResizeToParent( IntPtr windowHandle, Control parent )
        {
            int width = parent.Width + 23;
            int height = parent.Height + 23;
            PInvoke.MoveWindow( (HWND)windowHandle, -8, -8, width, height, true );

            if( PInvoke.GetWindowRect( (HWND)windowHandle, out RECT size ) )
            {
                int widthDiff = ( size.right - size.left ) - width;
                int heightDiff = ( size.bottom - size.top ) - height;
                if( widthDiff > 0 || heightDiff > 0 )
                {
                    return new Size( widthDiff, heightDiff );
                }
            }

            return Size.Empty;
        }

        public static void SendKeyDown( IntPtr windowHandle, Keys key )
        {
            PInvoke.PostMessage( (HWND)windowHandle, PInvoke.WM_KEYDOWN, (nuint)key, 0 );
        }

        public enum ProgressBarState: uint
        {
            Normal = PInvoke.PBST_NORMAL,
            Error = PInvoke.PBST_ERROR,
            Paused = PInvoke.PBST_PAUSED,
        }

        public static void SetState( this ProgressBar bar, ProgressBarState state )
        {
            PInvoke.SendMessage( (HWND)bar.Handle, PInvoke.PBM_SETSTATE, (uint)state, 0 );
        }

        public static void SetPlaceholder( this TextBox textBox, String placeholder )
        {
            PInvoke.SendMessage( (HWND)textBox.Handle, PInvoke.EM_SETCUEBANNER, 1, placeholder );
        }
    }
}
