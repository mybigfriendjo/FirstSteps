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

namespace Testdummy.Reference.MyStringTest
{
    public class Example {
        public static void Main() {
            Process.Start("H:\\BackupData\\Selftraning\\Programmieren\\ahk\\Sniperfury\\AutoSFAssistent.ahk");
            TaskWait(2000);
            Process.Start("H:\\BackupData\\Selftraning\\Programmieren\\ahk\\Sniperfury\\KillAutoSFscript.ahk");
        }

        public static async void TaskWait(int DelayInMS) {
            await Task.Delay(DelayInMS);
        }
    }

    
}
