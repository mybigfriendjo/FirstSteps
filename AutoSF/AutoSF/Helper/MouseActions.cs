using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;

namespace AutoSF {
    class MouseActions {
        private const UInt32 MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const UInt32 MOUSEEVENTF_LEFTUP = 0x0004;

        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, uint dwExtraInf);

        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int x, int y);

        //SearchPixelInArea
        private bool SearchPixelInArea(object sender) {
            for(int x = 0; x < SystemInformation.VirtualScreen.Width; x++) {

            }

            for(int y = 0; y < SystemInformation.VirtualScreen.Height; y++) {

            }
            return false;
        }
    }
}
