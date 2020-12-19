using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using HWND = System.IntPtr;

namespace AutoSF.Helper {
    class WinSystem {
        public static IDictionary<HWND, string> GetAllWindowTitles() {
            HWND shellWindow = GetShellWindow();
            Dictionary<HWND, string> windows = new Dictionary<HWND, string>();

            EnumWindows(delegate (HWND hWnd, int lParam) {
                if(hWnd == shellWindow) {
                    return true;
                }

                if(!IsWindowVisible(hWnd)) {
                    return true;
                }

                int length = GetWindowTextLength(hWnd);
                if(length == 0) {
                    return true;
                }

                StringBuilder builder = new StringBuilder(length);
                GetWindowText(hWnd, builder, length + 1);

                windows[hWnd] = builder.ToString();
                return true;
            }, 0);

            return windows;
        }

        [DllImport("USER32.DLL")]
        private static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);

        [DllImport("USER32.DLL")]
        private static extern int GetWindowText(HWND hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("USER32.DLL")]
        private static extern int GetWindowTextLength(HWND hWnd);

        [DllImport("USER32.DLL")]
        private static extern bool IsWindowVisible(HWND hWnd);

        [DllImport("USER32.DLL")]
        private static extern HWND GetShellWindow();

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(HWND hWnd);

        public static HWND WindowActivate() {
            //var process = Process.GetProcessById(4044);
            //  MessageBox.Show(process.ProcessName);
            //process.Kill();

            foreach(var process in Process.GetProcessesByName("mcfw")) {
                SetForegroundWindow(process.MainWindowHandle);
                return process.MainWindowHandle;
            }

            return HWND.Zero;
        }
        public static void WindowKill() {
            foreach(var process in Process.GetProcessesByName("mcfw")) {
                process.Kill();
            }
        }

        public static Rectangle GetWindowRect(HWND hWnd) {
            RECT rect = new RECT();
            GetWindowRect(hWnd, ref rect);
            return new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(HWND hWnd, ref RECT lpRect);

        private delegate bool EnumWindowsProc(HWND hWnd, int lParam);

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
    }
}
