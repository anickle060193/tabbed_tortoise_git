using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabbedTortoiseGit
{
    class KeyHook
    {
        public static readonly int MOD_ALT = 0x0001;
        public static readonly int MOD_CONTROL = 0x0002;
        public static readonly int MOD_NOREPEAT = 0x4000;
        public static readonly int MOD_SHIFT = 0x0004;
        public static readonly int MOD_WIN = 0x0008;

        public static readonly int WM_HOTKEY = 0x0312;

        public static readonly int HOTKEY_NEW_TAB = 1;

        [DllImport( "user32.dll" )]
        private static extern bool RegisterHotKey( IntPtr hWnd, int id, int fsModifiers, int vlc );

        [DllImport( "user32.dll" )]
        private static extern bool UnregisterHotKey( IntPtr hWnd, int id );

        public static void RegisterNewTabHotKey( IntPtr hWnd )
        {
            KeyHook.RegisterHotKey( hWnd, HOTKEY_NEW_TAB, MOD_CONTROL, (int)Keys.T );
        }
    }
}
