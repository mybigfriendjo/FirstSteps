using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Resources;

namespace Alarm {
    public partial class Alarm : Form {
        private Timer t = null;
        public Alarm() {
            InitializeComponent();

            //Tooltips - if it would be bound to an Event like MouseEnter it would show up every few millisec
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.tbNote, "Please insert your Note that should be attatched to the Alarm.");

            //Loadlist - with Exceptionhandling (try/catch)
            try {
                string[] HistoryListImport = File.ReadAllLines("C:\\Temp\\AlarmHistory.db");
                foreach (string History in HistoryListImport) {
                    lbHistory.Items.Add(History);
                }
            }
            catch (FileNotFoundException HistoryLoadError) {
                // Write error.
                Console.WriteLine(HistoryLoadError);
            }

            //Set startvalues
            numAlarmHour.Value = DateTime.Now.Hour;
            numAlarmMin.Value = DateTime.Now.Minute;

                //ToString("dd.MM.yyyy HH:mm:ss")
            cbNoDoubleEntry.Checked = true;
            cbAlarm.Checked = false;
            cbCountdown.Checked = false;
            //cbAlarm_CheckedChanged();
            //cbCountdown_CheckedChanged();

            //TimerSettings
            t = new Timer();
            t.Tick += new EventHandler(tTick);
            t.Interval = 1000; //Number is ms 500 -> 0,5 sec
            t.Enabled = true;
            t.Start();

   //         //Systray
   //         private NotifyIcon trayIcon;
   //         trayIcon = new NotifyIcon {
   //             Icon = Properties.Resources, 
   //             Text = "Alarm", 
   //             ContextMenu = trayMenu
   //         };
   // trayIcon.DoubleClick += trayIcon_DoubleClick;
   //trayIcon.Visible = true;
        

        }

        //Get CurrentTime + CountdownTime
        DateTime CountdownTimeADD = DateTime.Now;

        private void btnStop_Click(object sender, EventArgs e) {
            //StopTimer
            t.Enabled = false;
    }

        private void btnSave_Click(object sender, EventArgs e) {
            t.Enabled = true;

            //Save Historylist:  Foreach Item in lbHistory Append String to VarExport
            string Space = new string(' ', 20);

            string NewHistoryEntry = string.Format("{0:00}", numAlarmHour.Value) + ":" + numAlarmMin.Value.ToString("00") + Space + tbNote.Text + "";

            int DoubleEntry = 0;
            if (cbNoDoubleEntry.Checked) {
                foreach (string History in lbHistory.Items) {
                    if (History == NewHistoryEntry) {
                        DoubleEntry = 1;
                    }
                }
            }

            if (DoubleEntry == 0) {
                lbHistory.Items.Add(NewHistoryEntry);
                HistoryExport();
            }


            if (cbCountdown.Checked) {
                if (rb5min.Checked) {
                    CountdownTimeADD = CountdownTimeADD.AddMinutes(5);
                }
                else if (rb10min.Checked) {
                    CountdownTimeADD = CountdownTimeADD.AddMinutes(10);
                }
                else if (rb15min.Checked) {
                    CountdownTimeADD = CountdownTimeADD.AddMinutes(15);
                }
                else if (rb30min.Checked) {
                    CountdownTimeADD = CountdownTimeADD.AddMinutes(30);
                }
                else if (rb1hour.Checked) {
                    CountdownTimeADD = CountdownTimeADD.AddHours(1);
                }
                else if (rbCustom.Checked) {
                    CountdownTimeADD = CountdownTimeADD.AddMinutes(Convert.ToDouble(numCountdownMin.Value));
                    CountdownTimeADD = CountdownTimeADD.AddHours(Convert.ToDouble(numCountdownHour.Value));
                }
                lblCountdownTime.Text = CountdownTimeADD.ToString("dd.MM.yyyy HH:mm:ss");
            }
        }


        void tTick(object sender, EventArgs e) {
            Console.Write("tick");
            if (cbCountdown.Checked) {
                if (DateTime.Now == CountdownTimeADD) { //Format = "02.09.2016 15:29"                                                         
                    MessageBox.Show(" U da CountdownMan");
                }
            }
            string TodaysDate = DateTime.Now.ToString("dd.MM.yyyy"); //As long as there is no DateField includet or it is NULL
            string AlarmValue = TodaysDate + " " + numAlarmHour.Value.ToString("00") + ":" + numAlarmMin.Value.ToString("00") + ":00";
            string CountdownValue = TodaysDate + " " + numCountdownHour.Value.ToString("00") + ":" + numCountdownMin.Value.ToString("00") + ":00";
            if (DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") == AlarmValue) { //Format = "02.09.2016 15:29"
                //File.AppendAllText("C:\\Temp\\Config.txt", Environment.NewLine + "WayToGo");
                MessageBox.Show("It´s an Alarm! Watcha gonna do" + tbNote.Text);
            }
        }

        private void cbAlarm_CheckedChanged(object sender, EventArgs e) {
            if (cbAlarm.Checked) {
                numAlarmHour.Enabled = true;
                numAlarmMin.Enabled = true;
                tbNote.Enabled = true;
            }
            else {
                numAlarmHour.Enabled = false;
                numAlarmMin.Enabled = false;
                tbNote.Enabled = false;
            }
        }

        private void cbCountdown_CheckedChanged(object sender, EventArgs e) {
            //If a container like panel/Groupbox,... gets disabled all the contained controlls get disabled as well
            if (cbCountdown.Checked) {
                panelCountdown.Enabled = true;
            }
            else {
                panelCountdown.Enabled = false;
            }

        }

        private void btnDeleteAll_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("\"Ok\" will remove all entries in the Alarmlist!", "Clear whole List?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.OK) {
                lbHistory.Items.Clear();

                HistoryExport();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            lbHistory.Items.RemoveAt(lbHistory.SelectedIndex);

            HistoryExport();
        }

        //method HistoryListExport
        //int cnt = 0;
        private void HistoryExport() {
            string HistoryListExport = "";
            foreach (string History in lbHistory.Items) {
                HistoryListExport += History + "\n";
            }
            File.WriteAllText("C:\\Temp\\AlarmHistory.db", HistoryListExport);
        }

        private void Alarm_FormClosing(object sender, FormClosingEventArgs e) {

            if (e.CloseReason == CloseReason.UserClosing) {

                


                //Properties.Resources.Alarm.Visible = true; 
                e.Cancel = true;
                Hide();
                FormClosing += Alarm_FormClosing;
            }
        }

        //TODO
        /*
         Get .exe path to store DB there? Alternative %Userprofile%\App....
         SoundPath
         YoutubePath
         config/registry -> save 
         Activate Button
         SetStartValues (disable controls)
         start programm @ Alarm
         Doppelte Einträge - Abfrage
         Notiz in Meldung Anzeigen


        Changelog

         +Alarm Time startValue is changed to current time at start
         +new funktion "No double entries"
         -systray in progress
        
         */
    }
}
