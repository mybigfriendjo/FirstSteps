using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alarm {
    public partial class AlarmSettings : Form {

        private Alarm mainWindow;
        private static bool isOpen=false;

        private string _notification;
        public string Notification {
            get {return _notification;}
            set {
                _notification = value;
                textNotification.Text = value;
            }
        }
              
        
        public AlarmSettings(Alarm alarmWindow) {
            if (isOpen) {
                return;
            }
            InitializeComponent();

            isOpen = true;
            mainWindow = alarmWindow;
        }


        private void button1_Click(object sender, EventArgs e) {
            mainWindow.UpdateRowDetails(this);
        }

        private void AlarmSettings_FormClosing(object sender, FormClosingEventArgs e) {
            isOpen = false;
        }
    }
}
