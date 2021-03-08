using System;
using System.Diagnostics;
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
        if(MainWindow.CurrentHostName == "VMgr4ndpa") {
            posX += 1920; //Correts MousePosion for VM/SingleMonitor)
        }
        
            SetCursorPos(posX, posY);

            Click();
            System.Threading.Thread.Sleep(250);
            Click();
        }

        public static void SingleClickAtPosition(int posX, int posY) {
            if(MainWindow.CurrentHostName == "VMgr4ndpa") {
                posX += 1920; //Correts MousePosion for VM/SingleMonitor)
            }

            SetCursorPos(posX, posY);

            Click();
        }

        public static void Click() {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            //Not working....
            //mouse_event(MOUSEEVENTF_LEFTDOWN, Convert.ToUInt32(SystemInformation.VirtualScreen.Left), Convert.ToUInt32(SystemInformation.VirtualScreen.Top), 0, 0);
            //mouse_event(MOUSEEVENTF_LEFTUP, Convert.ToUInt32(SystemInformation.VirtualScreen.Left), Convert.ToUInt32(SystemInformation.VirtualScreen.Top), 0, 0);
        }

        public static void LeftMouseDown() {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
        }

        public static void LeftMouseUp() {
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }


        public static void ClickSpam(int AmountOfClicks, int PauseBetwClicksInMS) {

            for(int Clickcount = 0; Clickcount < AmountOfClicks; Clickcount++) {
                MouseActions.LeftMouseUp();
                MouseActions.LeftMouseDown();
                Stopwatch st = new Stopwatch();
                st.Start();
                while(st.Elapsed < TimeSpan.FromMilliseconds(PauseBetwClicksInMS)) {
                    //
                }
                st.Stop();
                //Requieres HelperClass KeyboardInput (Solution AutoSF)
                //if(Clickcount < 20) {
                //   KeyboardInput.Send(KeyboardInput.ScanCodeShort.KEY_F);
                //}
            }
        }

    }
}
