using System;
using System.Windows.Forms;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Specialized;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Testdummy.Reference.MyStringTest
{
    public class Example {
       public static void Main() {
            //    Process.Start("H:\\BackupData\\Selftraning\\Programmieren\\ahk\\Sniperfury\\AutoSFAssistent.ahk");
            //    TaskWait(2000);
            //    Process.Start("H:\\BackupData\\Selftraning\\Programmieren\\ahk\\Sniperfury\\KillAutoSFscript.ahk");
            RndMethod();
        }
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        //public static async void TaskWait(int DelayInMS) {
        //    await Task.Delay(DelayInMS);
        //}

        public static void RndMethod() {
            //var process = Process.GetProcessById(4044);
            //  MessageBox.Show(process.ProcessName);
            //process.Kill();

            foreach(var process in Process.GetProcessesByName("mcfw")) {
                SetForegroundWindow(process.MainWindowHandle);
            }
        }
    }
}
