using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AutoSF.Helper {
    public static class MouseActions {
        public const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        public const uint MOUSEEVENTF_LEFTUP = 0x0004;

        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, uint dwExtraInf);

        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int x, int y);

        public static void DoubleClickAtPosition(int posX, int posY) {
            SetCursorPos(posX, posY);

            Click();
            System.Threading.Thread.Sleep(250);
            Click();
        }

        public static void Click() {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            //Not working....
            //mouse_event(MOUSEEVENTF_LEFTDOWN, Convert.ToUInt32(SystemInformation.VirtualScreen.Left), Convert.ToUInt32(SystemInformation.VirtualScreen.Top), 0, 0);
            //mouse_event(MOUSEEVENTF_LEFTUP, Convert.ToUInt32(SystemInformation.VirtualScreen.Left), Convert.ToUInt32(SystemInformation.VirtualScreen.Top), 0, 0);
        }
    }
}
