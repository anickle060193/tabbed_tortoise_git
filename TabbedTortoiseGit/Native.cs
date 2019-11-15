using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabbedTortoiseGit
{
    static class Native
    {
        public static class WindowMessage
        {
            public const int NCHITTEST = 0x0084;
            public const int WM_KEYDOWN = 0x100;

            public const int PBM_SETSTATE = 0x0410;
        }

        public static class HitTestValues
        {
            public const int ERROR = -2;
            public const int TRANSPARENT = -1;
            public const int NOWHERE = 0;
            public const int CLIENT = 1;
            public const int CAPTION = 2;
            public const int SYSMENU = 3;
            public const int GROWBOX = 4;
            public const int MENU = 5;
            public const int HSCROLL = 6;
            public const int VSCROLL = 7;
            public const int MINBUTTON = 8;
            public const int MAXBUTTON = 9;
            public const int LEFT = 10;
            public const int RIGHT = 11;
            public const int TOP = 12;
            public const int TOPLEFT = 13;
            public const int TOPRIGHT = 14;
            public const int BOTTOM = 15;
            public const int BOTTOMLEFT = 16;
            public const int BOTTOMRIGHT = 17;
            public const int BORDER = 18;
            public const int OBJECT = 19;
            public const int CLOSE = 20;
            public const int HELP = 21;
        }

        public enum ProgressBarState
        {
            Normal = 1,
            Error = 2,
            Paused = 3
        }

        public const int GWL_WNDPROC = -4;
        public const int GWL_HINSTANCE = -6;
        public const int GWL_HWNDPARENT = -8;
        public const int GWL_STYLE = -16;
        public const int GWL_EXSTYLE = -20;
        public const int GWL_USERDATA = -21;
        public const int GWL_ID = -12;

        public const uint WS_OVERLAPPED = 0x00000000;
        public const uint WS_POPUP = 0x80000000;
        public const uint WS_CHILD = 0x40000000;
        public const uint WS_MINIMIZE = 0x20000000;
        public const uint WS_VISIBLE = 0x10000000;
        public const uint WS_DISABLED = 0x08000000;
        public const uint WS_CLIPSIBLINGS = 0x04000000;
        public const uint WS_CLIPCHILDREN = 0x02000000;
        public const uint WS_MAXIMIZE = 0x01000000;
        public const uint WS_CAPTION = 0x00C00000;     /* WS_BORDER | WS_DLGFRAME  */
        public const uint WS_BORDER = 0x00800000;
        public const uint WS_DLGFRAME = 0x00400000;
        public const uint WS_VSCROLL = 0x00200000;
        public const uint WS_HSCROLL = 0x00100000;
        public const uint WS_SYSMENU = 0x00080000;
        public const uint WS_THICKFRAME = 0x00040000;
        public const uint WS_GROUP = 0x00020000;
        public const uint WS_TABSTOP = 0x00010000;

        public const uint WS_MINIMIZEBOX = 0x00020000;
        public const uint WS_MAXIMIZEBOX = 0x00010000;

        public const uint WS_TILED = WS_OVERLAPPED;
        public const uint WS_ICONIC = WS_MINIMIZE;
        public const uint WS_SIZEBOX = WS_THICKFRAME;
        public const uint WS_TILEDWINDOW = WS_OVERLAPPEDWINDOW;

        // Common Window Styles

        public const uint WS_OVERLAPPEDWINDOW =
            ( WS_OVERLAPPED |
                WS_CAPTION |
                WS_SYSMENU |
                WS_THICKFRAME |
                WS_MINIMIZEBOX |
                WS_MAXIMIZEBOX );

        public const uint WS_POPUPWINDOW =
            ( WS_POPUP |
                WS_BORDER |
                WS_SYSMENU );

        public const uint WS_CHILDWINDOW = WS_CHILD;

        //Extended Window Styles

        public const uint WS_EX_DLGMODALFRAME = 0x00000001;
        public const uint WS_EX_NOPARENTNOTIFY = 0x00000004;
        public const uint WS_EX_TOPMOST = 0x00000008;
        public const uint WS_EX_ACCEPTFILES = 0x00000010;
        public const uint WS_EX_TRANSPARENT = 0x00000020;

        //#if(WINVER >= 0x0400)
        public const uint WS_EX_MDICHILD = 0x00000040;
        public const uint WS_EX_TOOLWINDOW = 0x00000080;
        public const uint WS_EX_WINDOWEDGE = 0x00000100;
        public const uint WS_EX_CLIENTEDGE = 0x00000200;
        public const uint WS_EX_CONTEXTHELP = 0x00000400;

        public const uint WS_EX_RIGHT = 0x00001000;
        public const uint WS_EX_LEFT = 0x00000000;
        public const uint WS_EX_RTLREADING = 0x00002000;
        public const uint WS_EX_LTRREADING = 0x00000000;
        public const uint WS_EX_LEFTSCROLLBAR = 0x00004000;
        public const uint WS_EX_RIGHTSCROLLBAR = 0x00000000;

        public const uint WS_EX_CONTROLPARENT = 0x00010000;
        public const uint WS_EX_STATICEDGE = 0x00020000;
        public const uint WS_EX_APPWINDOW = 0x00040000;

        public const uint WS_EX_OVERLAPPEDWINDOW = ( WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE );
        public const uint WS_EX_PALETTEWINDOW = ( WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST );
        //#endif /* WINVER >= 0x0400 */

        //#if(_WIN32_WINNT >= 0x0500)
        public const uint WS_EX_LAYERED = 0x00080000;
        //#endif /* _WIN32_WINNT >= 0x0500 */

        //#if(WINVER >= 0x0500)
        public const uint WS_EX_NOINHERITLAYOUT = 0x00100000; // Disable inheritence of mirroring by children
        public const uint WS_EX_LAYOUTRTL = 0x00400000; // Right to left mirroring
                                                        //#endif /* WINVER >= 0x0500 */

        //#if(_WIN32_WINNT >= 0x0500)
        public const uint WS_EX_COMPOSITED = 0x02000000;
        public const uint WS_EX_NOACTIVATE = 0x08000000;
        //#endif /* _WIN32_WINNT >= 0x0500 */

        public static readonly IntPtr HWND_MESSAGE = new IntPtr( -3 );

        public const int HWND_BROADCAST = 0xffff;

        [DllImport( "user32" )]
        public static extern bool PostMessage( IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam );

        [DllImport( "user32" )]
        public static extern int RegisterWindowMessage( string message );

        [DllImport( "user32.dll", SetLastError = true )]
        internal static extern bool MoveWindow( IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint );

        [DllImport( "user32.dll", SetLastError = true )]
        static extern IntPtr FindWindow( string lpClassName, string lpWindowName );

        [DllImport( "user32.dll", SetLastError = true )]
        public static extern IntPtr SetParent( IntPtr hWndChild, IntPtr hWndNewParent );

        [DllImport( "user32.dll", ExactSpelling = true, CharSet = CharSet.Auto )]
        public static extern IntPtr GetParent( IntPtr hWnd );

        [DllImport( "user32.dll", EntryPoint = "GetWindowLong", CharSet = CharSet.Auto )]
        private static extern int GetWindowLong32( IntPtr hWnd, int nIndex );

        [DllImport( "user32.dll", EntryPoint = "GetWindowLongPtr", CharSet = CharSet.Auto )]
        private static extern int GetWindowLongPtr64( IntPtr hWnd, int nIndex );

        public static int GetWindowLongPtr( IntPtr hWnd, int nIndex )
        {
            if( IntPtr.Size == 4 )
            {
                return GetWindowLong32( hWnd, nIndex );
            }
            else
            {
                return GetWindowLongPtr64( hWnd, nIndex );
            }
        }

        [DllImport( "user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto )]
        private static extern int SetWindowLong32( IntPtr hWnd, int nIndex, int dwNewLong );

        [DllImport( "user32.dll", EntryPoint = "SetWindowLongPtr", CharSet = CharSet.Auto )]
        private static extern int SetWindowLongPtr64( IntPtr hWnd, int nIndex, int dwNewLong );

        public static int SetWindowLongPtr( IntPtr hWnd, int nIndex, int dwNewLong )
        {
            if( IntPtr.Size == 4 )
            {
                return SetWindowLong32( hWnd, nIndex, dwNewLong );
            }
            else
            {
                return SetWindowLongPtr64( hWnd, nIndex, dwNewLong );
            }
        }

        public const int TCM_SETMINTABWIDTH = 0x1300 + 49;

        [DllImport( "user32.dll" )]
        public static extern IntPtr SendMessage( IntPtr hWnd, int msg, IntPtr wp, IntPtr lp );

        public static void RemoveBorder( IntPtr windowHandle )
        {
            int style = GetWindowLongPtr( windowHandle, GWL_STYLE );
            SetWindowLongPtr( windowHandle, GWL_STYLE, (int)( ( style & ~( WS_CAPTION ) ) | WS_EX_WINDOWEDGE ) );
        }

        public static void SetWindowParent( IntPtr windowHandle, Control parent )
        {
            SetParent( windowHandle, parent.Handle );
        }

        public static Size ResizeToParent( IntPtr windowHandle, Control parent )
        {
            int width = parent.Width + 23;
            int height = parent.Height + 23;
            MoveWindow( windowHandle, -8, -8, width, height, true );

            RECT size = new RECT();
            if( GetWindowRect( windowHandle, ref size ) )
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

        [StructLayout( LayoutKind.Sequential )]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [DllImport( "user32.dll", SetLastError = true )]
        static extern bool GetWindowRect( IntPtr hWnd, ref RECT Rect );

        [DllImport( "user32.dll", SetLastError = true )]
        public static extern IntPtr GetForegroundWindow();

        [DllImport( "user32.dll" )]
        public static extern bool SetForegroundWindow( IntPtr hWnd );

        public static void SendKeyDown( IntPtr windowHandle, Keys key )
        {
            PostMessage( windowHandle, WindowMessage.WM_KEYDOWN, (IntPtr)key, IntPtr.Zero );
        }

        public static void SetState( this ProgressBar bar, ProgressBarState state )
        {
            SendMessage( bar.Handle, WindowMessage.PBM_SETSTATE, (IntPtr)state, IntPtr.Zero );
        }
    }
}
