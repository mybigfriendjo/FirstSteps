using System;
using System.Globalization;
using System.Windows.Forms;

namespace AutoVP
{
    class checkTime
    {
        private Timer t = null;

        public checkTime()
        {
            t = new Timer();
            t.Tick += new EventHandler(tTick);

            // Calculate first start
            DateTime startTime = DateTime.ParseExact("2010-07-01 23:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            t.Interval = (startTime - DateTime.Now).Milliseconds;

            t.Start();
        }

        void tTick(object sender, EventArgs e)
        {
            // Set the next interval
            //t.Interval = 1000 * 60 * 60 * 24; // Every day
            t.Interval = 6000; //Every Minute

            // Do it
        }
    }
}
