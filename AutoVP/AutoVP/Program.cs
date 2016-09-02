using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AutoVP
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Save ProgrammStartTime into Reg
            //string DateNowValue;
            //DateNowValue = DateTime.Now.ToString();

            ////Creates a File named "Config" 
            //TODO: Write to SysConfigfile > Check for best way to retrive values afterwards
            File.WriteAllText("C:\\Temp\\Config.txt", DateTime.Now.ToString("dd.MM.yyyy HH:mm"));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
