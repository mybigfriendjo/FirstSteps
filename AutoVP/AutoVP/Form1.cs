using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AutoVP
{
    public partial class Form1 : Form
    {
        private Timer t = null;
        public Form1()
        {
            InitializeComponent();

            
            t = new Timer();
            t.Tick += new EventHandler(tTick);
            t.Interval = 1000 * 60; //Every Minute
            t.Enabled = true;

            ////Calculate first start
            //DateTime startTime = DateTime.ParseExact("2016-09-02 11:15", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            //t.Interval = (startTime - DateTime.Now).Milliseconds;

            t.Start();
        }

        void tTick(object sender, EventArgs e)
        {
            //// Set the next interval
            //t.Interval = 1000 * 60 * 60 * 24; // Every day
            //t.Interval = 6000; //Every Minute
            Console.WriteLine("Hello World!");

            ////Creates a File named "Config" 
            
            //TODO: separate Block into Logging and SysConfig(LastRunTime)
            //TODO: IF condition -> switch to Read Text from cfg
            string FileContent = File.ReadAllText("C:\\Temp\\Config.txt");
            File.WriteAllText("C:\\Temp\\Config.txt", DateTime.Now.ToString("dd.MM.yyyy HH:mm"));
            File.AppendAllText("C:\\Temp\\Config.txt", Environment.NewLine + FileContent);
            if (DateTime.Now.ToString("dd.MM.yyyy HH:mm") == "02.09.2016 15:29")
            {
                File.AppendAllText("C:\\Temp\\Config.txt", Environment.NewLine + "WayToGo");
            }

            //// Do it
        }
    }
}
