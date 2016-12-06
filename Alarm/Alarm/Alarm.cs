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
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Alarm {
    public partial class Alarm : Form {

        //Important Variables
        private Timer t = null;
        NotifyIcon MyNotifyIcon = new NotifyIcon();
        string DB_Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Alarm\\AlarmHistory.db");
        bool AlarmActive = false; //ActivateAlarm Button pressed = ?
        DateTime CountdownTimeADD = DateTime.Now; //Get CurrentTime + CountdownTime
        DateTime StopFlash = DateTime.Now;
        string DisplayInfo = "";
        //int LastRowIndex = 1000;
        //public int CellCnt; //Counts the Cells of the active Row
        DataSet ADS;
        DataTable ADT;


        //Old controlls - Vars
        DateTime numAlarmHour = DateTime.Now;
        DateTime numAlarmMin = DateTime.Now;
        string tbNote = "";

        public Alarm() {
            InitializeComponent();

            //Dataset
            ADS = new DataSet("ADS"); //AlarmDataSet (ADS)
            ADT= ADS.Tables.Add("ADT"); //AlarmDataTable (ADT)
            DataColumn ColDate = ADT.Columns.Add("Date");
            ColDate.DefaultValue = DateTime.Now;
            ColDate.AllowDBNull = false; //Date must not be empty
            //ADT.Columns.Add("Date");
            DataColumn ColHour = ADT.Columns.Add("Hour", typeof(int));
            ColHour.DefaultValue = 10;
            DataColumn ColMin = ADT.Columns.Add("Minute", typeof(int));
            ColMin.DefaultValue = 00;
            ADT.Columns.Add("AlarmActiv", typeof(bool));
            ADT.Columns.Add("Note");
            ADT.Columns.Add("PathActiv", typeof(bool));
            ADT.Columns.Add("ProgPath"); //Path to start Programm
            ADT.Columns.Add("SoundActive", typeof(bool));
            ADT.Columns.Add("SoundSource"); //Radiobtn "ringtone", "soundfile", "youtube"
            DataColumn ColID = ADT.Columns.Add("ID");
            ColID.AllowDBNull = false;
            ColID.DefaultValue = 000000;
            //ColID.Unique = true;
            //DataColumn DCbool = new DataColumn("AActive",typeof(bool));
            //ADT.Columns.Add(DCbool);

            DataRow ADR = ADT.NewRow();
            //ADR["AlarmISActive"] = true;
            //ADR["Date"] = "02.12.2016 00:00:00";
            DataTable LoadData = new DataTable();
            if (File.Exists("C:\\Temp\\AlarmList.csv")) {
                LoadData =  CsvImport.GetDataTableFromCsv("C:\\Temp\\AlarmList.csv",true);

                int RowCnt = 0;
                foreach (DataRow Row in LoadData.Rows) {
                    RowCnt++;
                    DataRow RowName = ADT.NewRow();
                    RowName["Hour"] = Row["Hour"];
                    RowName["Minute"] = Row["Minute"];
                    RowName["AlarmActiv"] = Row["AlarmActiv"];
                    RowName["Note"] = Row["Note"];
                    RowName["PathActiv"] = Row["PathActiv"];
                    RowName["ProgPath"] = Row["ProgPath"];
                    RowName["SoundActive"] = Row["SoundActive"];
                    RowName["SoundSource"] = Row["SoundSource"];
                    RowName["ID"] = Row["ID"];
                    ADT.Rows.Add(RowName);
                }
            }
            else {
                ADR["Hour"] = 10;
                ADR["Minute"] = 23;
                ADR["AlarmActiv"] = true;
                ADR["Note"] = "WhatsMyName";
                ADR["PathActiv"] = true;
                ADR["ProgPath"] = "C:\\Temp";
                ADR["SoundActive"] = true;
                ADR["SoundSource"] = "C:\\Smart\\Temp";
                ADR["ID"] = "00001";
                ADT.Rows.Add(ADR);
            }
            
            dataGridView1.DataSource = ADS.Tables[0];


            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dataGridView1.DataBindingComplete = 

            dataGridView2.DataSource = dataSet1.Tables[0];


            //Tooltips - if it would be bound to an Event like MouseEnter it would show up every few millisec
            //System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            //ToolTip1.SetToolTip(tbNote, "Please insert your Note that should be attatched to the Alarm.");

            //Loadlist - with Exceptionhandling (try/catch)
            try {
                if (File.Exists(DB_Path)) {
                    string[] HistoryListImport = File.ReadAllLines(DB_Path);
                    foreach (string History in HistoryListImport) {
                        lbHistory.Items.Add(History);
                    }
                }  
            }
            catch (FileNotFoundException HistoryLoadError) {
                // Write error.
                Console.WriteLine(HistoryLoadError);
            }

            //Set startvalues
            //numAlarmHour.Value = DateTime.Now.Hour;
            //numAlarmMin.Value = DateTime.Now.Minute;

            //TimerSettings
            t = new Timer();
            t.Tick += new EventHandler(tTick);
            t.Interval = 1000; //Number is ms 500 -> 0,5 sec
            t.Enabled = true;
            t.Start();

            //Systray
            MyNotifyIcon.Icon = Properties.Resources.Alarm;
            MyNotifyIcon.Visible = true;
            MyNotifyIcon.BalloonTipText = "minimized"; //noclue - GPO disables it at copany
            MyNotifyIcon.ShowBalloonTip(500); //Time Systray helptext is shown - GPO disables it at copany
            MyNotifyIcon.Text = "double leftclick to maximize Program."; //systray helptext
            MyNotifyIcon.DoubleClick += MyNotifyIcon_MouseDoubleClick; //Easy create method when first set += Methodname -> rightclick it afterwards "create method". //At doubleclick load methode

            //Gather DisplayInfo
            int cnt = 0;
            foreach (var screen in Screen.AllScreens) {
                DisplayInfo += screen.DeviceName + "\n" + screen.Bounds.ToString() + "\n" + screen.Bounds.X.ToString() + "\n" + screen.Bounds.Y.ToString() + "\n" + screen.Bounds.Width.ToString() + "\n" + screen.Bounds.Height.ToString() + "\n" + screen.GetType().ToString() + "\n" + screen.WorkingArea.ToString() + "\n" + screen.Primary.ToString() + "\n\n\n";
                //string[] Array = new string "a" [cnt];
                cnt++;
            }
            //MessageBox.Show(DisplayInfo);
        }

        //private void btnSave_Click(object sender, EventArgs e) {

        //    //Save Historylist:  Foreach Item in lbHistory Append String to VarExport
        //    string Space = new string(' ', 20);
        //    string NewHistoryEntry = string.Format("{0:00}", numAlarmHour.Value) + ":" + numAlarmMin.Value.ToString("00") + Space + tbNote.Text + "";
        //    //Check for double entries
        //    int DoubleEntry = 0;
        //    if (cbNoDoubleEntry.Checked) {
        //        foreach (string History in lbHistory.Items) {
        //            if (History == NewHistoryEntry) {
        //                DoubleEntry = 1;
        //            }
        //        }
        //    }
        //    if (DoubleEntry == 0) {
        //        lbHistory.Items.Add(NewHistoryEntry);
        //        HistoryExport();
        //    }
        //}

        int CountdownChecked = 0;
        private void CountdownRadio(Object sender, EventArgs e) {
            CountdownChecked = 1;
            if (sender == numCountdownHour || sender == numCountdownMin) {
                rbCustom.Checked = true;
            }
        }

        void tTick(object sender, EventArgs e) {
            Console.Write("tick");
            //var CountdownChecked = Container.Co
            if (cbCountdown.Checked && AlarmActive && CountdownChecked == 1) {
                if (DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") == lblCountdownTime.Text) { //Format = "02.09.2016 15:29"    
                    StopFlash = Convert.ToDateTime(lblCountdownTime.Text);
                    StopFlash = StopFlash.AddSeconds(15);
                    MessageBox.Show(" U da CountdownMan");
                }
            }
            //string TodaysDate = DateTime.Now.ToString("dd.MM.yyyy"); //As long as there is no DateField includet or it is NULL
            //string AlarmValue = TodaysDate + " " + numAlarmHour.Value.ToString("00") + ":" + numAlarmMin.Value.ToString("00") + ":00";
            //string CountdownValue = TodaysDate + " " + numCountdownHour.Value.ToString("00") + ":" + numCountdownMin.Value.ToString("00") + ":00";
            //if (DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") == AlarmValue && cbAlarm.Checked && AlarmActive) { //Format = "02.09.2016 15:29"
            //    //File.AppendAllText("C:\\Temp\\Config.txt", Environment.NewLine + "WayToGo");
            //    StopFlash = Convert.ToDateTime(AlarmValue);
            //    StopFlash = StopFlash.AddSeconds(15);

            //    MessageBox.Show("It´s an Alarm! Watcha gonna do" + tbNote.Text);
            //}
            
            ////Alarm went off - FlashScreen Activated
            //if (cbAlarm.Checked && cbFlashscreen.Checked && DateTime.Now < StopFlash && AlarmActive && ( DateTime.Now > Convert.ToDateTime(AlarmValue))) { //If Time is between Alarm and Stopflash(Alarm +15sec)
            //    FrameFlash(null, null);
            //}
            //Countdown went off - FlashScreen Activated
            if (lblCountdownTime.Text != "") {
                if (cbCountdown.Checked && cbFlashscreen.Checked && DateTime.Now < StopFlash && AlarmActive && (DateTime.Now > Convert.ToDateTime(lblCountdownTime.Text))) { //If Time is between Countdown and Stopflash(Alarm +15sec)
                    FrameFlash(null, null);
                }
            }
            if (DateTime.Now > StopFlash.AddSeconds(2)) {
                //Hide all BoarderForms
                FrmBottm.Hide();
                FrmLeft.Hide();
                FrmRight.Hide();
                FrmTop.Hide();
            }
        }

        //private void cbAlarm_CheckedChanged(object sender, EventArgs e) {
        //    if (cbAlarm.Checked) {
        //        numAlarmHour.Enabled = true;
        //        numAlarmMin.Enabled = true;
        //        tbNote.Enabled = true;
        //    }
        //    else {
        //        numAlarmHour.Enabled = false;
        //        numAlarmMin.Enabled = false;
        //        tbNote.Enabled = false;
        //    }
        //}

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
            if (!Directory.Exists(Path.GetDirectoryName(DB_Path))) { //this removes the Filepattern from the pathfile and checkes if directory does NOT exist then create it.
                Directory.CreateDirectory(Path.GetDirectoryName(DB_Path));
            }
            File.WriteAllText(DB_Path, HistoryListExport);
        }

        //Systray + RestoreFromTray
        private void Alarm_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }

        void MyNotifyIcon_MouseDoubleClick(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Normal;
            Show();
        }

        private void contextMenuStripSystray_Opening(object sender, CancelEventArgs e) {
            MyNotifyIcon.Visible = false; //do remove systray icon at close
            Application.Exit(); //Exits programm
        }

        //AlarmActive button toggle
        private void btnAcivateAlarm_Click(object sender, EventArgs e) {
            if (AlarmActive) {
                btnAcivateAlarm.Text = "Activate Alarm";
                AlarmActive = false;
                t.Enabled = false; //disables Timer
                lblCountdownTime.Text = "";
            }
            else {
                btnAcivateAlarm.Text = "Deactivate Alarm";
                AlarmActive = true;
                t.Enabled = true; //enables Timer

                CountdownTimeADD = DateTime.Now;
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
        }

        //ScreenOverlay
        Bottom FrmBottm = new Bottom();
        Top FrmTop = new Top();
        LeftSide FrmLeft = new LeftSide();
        RightSide FrmRight = new RightSide();
        private void FrameFlash(object sender, EventArgs e) {
            
           //Bottom
            if (FrmBottm.Visible) {
                FrmBottm.Hide();
            }
            else {
                FrmBottm.Show();
            }

            //Top
            if (FrmTop.Visible) {
                FrmTop.Hide();
            }
            else {
                FrmTop.Show();
            }

            //Left
            if (FrmLeft.Visible) {
                FrmLeft.Hide();
            }
            else {
                FrmLeft.Show();
            }

            //Right
            if (FrmRight.Visible) {
                FrmRight.Hide();
            }
            else {
                FrmRight.Show();
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {
            dataGridView1.Columns["Hour"].Visible = false; //hides ID Column in DataGridView
            dataGridView1.Columns["Minute"].Visible = false; //hides ID Column in DataGridView
            dataGridView1.Columns["ID"].Visible = false; //hides ID Column in DataGridView
            dataGridView1.RowHeadersVisible = false; //hides the first gray row in DataGridView
            dataGridView1.AutoResizeColumns();
        }
        
        public void UpdateRowDetails(AlarmSettings settings) {
            //dataGridView1.Rows[LastRowIndex].Cells[0].Value = settings.Date;
            //dataGridView1.Rows[settings.LastRowIndex].Cells[1].Value = settings.Hour;
            //AlarmSettingsGui.Hour = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
            //AlarmSettingsGui.Minute = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            //AlarmSettingsGui.AlarmActiv = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            //AlarmSettingsGui.Note = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            //AlarmSettingsGui.ProgPathActiv = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
            //AlarmSettingsGui.ProgPath = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString(); //Path to start Programm
            //AlarmSettingsGui.SoundActive = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
            //AlarmSettingsGui.SoundSource = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString(); //Radiobtn "ringtone", "soundfile", "youtube"
            //AlarmSettingsGui.ID = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString(); 

            StringBuilder sb = new StringBuilder();

            IEnumerable<string> columnNames = ADT.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in ADT.Rows) {
                IEnumerable<string> fields = row.ItemArray.Select(field => string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\""));
                sb.AppendLine(string.Join(",", fields));
            }

            File.WriteAllText("C:\\Temp\\AlarmList.csv", sb.ToString());
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            AlarmSettings AlarmSettingsGui = new AlarmSettings(this);

            //AlarmSettingsGui.Notification = "test";
            AlarmSettingsGui.LastRowIndex = e.RowIndex;
            if( != null) {

            }
            AlarmSettingsGui.Date = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null) {
                AlarmSettingsGui.Hour = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            }
            AlarmSettingsGui.Hour = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            AlarmSettingsGui.Minute = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            AlarmSettingsGui.AlarmActiv = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            AlarmSettingsGui.Note = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            AlarmSettingsGui.ProgPathActiv = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
            AlarmSettingsGui.ProgPath = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString(); //Path to start Programm
            AlarmSettingsGui.SoundActive = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
            AlarmSettingsGui.SoundSource = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString(); //Radiobtn "ringtone", "soundfile", "youtube"
            AlarmSettingsGui.ID = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString(); ;
            AlarmSettingsGui.Show();


            ////MASSASSIGNEMENT
            ////Fill VarList
            //AlarmSettingsGui.CellCnt = dataGridView1.Rows[e.RowIndex].Cells.Count;
            //int i = 0;
            //while (dataGridView1.Rows[e.RowIndex].Cells.Count > i) {
            //    string VarValue = dataGridView1.Rows[e.RowIndex].Cells[i].Value.ToString();
            //    i++;
            //    if (VarValue != null && VarValue != "") {
            //        AlarmSettingsGui.VarList.Items.Add(VarValue);
            //    }
            //}
             


            ///
            // Manuel way to Set up a Form + Controls
            ///
            //Form GridForm = new Form();
            //GridForm.Visible = true;
            //GridForm.Show();

            ////GridNote
            //TextBox GridNote = new TextBox();
            //GridNote.Location = new Point(70, 5);
            //GridNote.Size = new System.Drawing.Size(210, 25);
            //GridNote.BackColor = Color.HotPink;
            //GridNote.Text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            //GridForm.Controls.Add(GridNote);

            ////GridNoteLabel
            //Label GlblNote = new Label();
            //GlblNote.Text = "Note:";
            //GlblNote.Location = new Point(5,5);
            //GridForm.Controls.Add(GlblNote);
        }

        //TODO
        /*
        SoundPath
        YoutubePath
        config/registry -> save Properties.Settings.Default.Save();
        Activate Alarm/Countdown Button
        start programm @ Alarm
        option -> raidobutton -> store *.db in Userfolder |  store *.db at same path as Alarm.exe
        ~~~doubleclick List Entry -> activate Alarm and set hour/min/note
        Change List into a List Containing Alarm + chkbox, days, + upcomming alarms for example: http://freealarmclocksoftware.com/images/alarmclock.png
        Warning - if Alarm/countdown changed while active -> MsgBox -> reload Alarm|keep active Alarm and changes|cancel changes
        repeat alarm - else deaktivate it after it was triggered
        Seperate Stopflash for Alarm and Counter else it will get overwritten if both are active(still works though)
        **Code to get amount of Variables(Columns in Rows) still needs to be written.
        **Code to get variable Type to set Fields in AlarmSettings Form as well


        Changelog

        +Csv will now be imported and loaded into AlarmSettings

        +DataTable will now be stored in a csv.file

        +OK Button is closing Gui now.
        +Started to code Datatransfer from AlarmSettings back to Alarm

        +Reworked AlarmSettings Gui
        +Cells Data is now shown in AlarmSettingsGui
        +Addet Testbutton fopr paths - no function yet


        +Added Controlls and Variables for Dataexchange betweem Alarm and AlarmSettings

        +Klomi code for data exchange between Alarm and Alarmsettings
        -Code to get amount of Variables(Columns in Rows) still needs to be written.

        +choosing between manuall configured Form(ManualForm) and Form with Gui(created in project) "GuiForm"
        +added controlls to both
        -issues accessing new GuiForm


        +Added DataSet, DataTable, DataColumn, DataGridView

        +Alarm trigger can seperate countdown from Alarm now.
        +Started to implement multiple monitor support
        +Added ScreenFlashing - For 1 Monitor
        +Countdown now working

        +Check Path if exists - else create path
        +DB-file will be stored in User\mydocuments
        +Startvalues are now set directly in GUI
        +SystrayIcon is now correctly shown
        +reopen programm out of systray is now working
        +added menu to systray
        +added menu shortcuts (Alt+ .....)
        -DB-file won´t be stored with the *exe

        +Alarm Time startValue is changed to current time at start
        +new funktion "No double entries"
        -systray in progress
        +notiz is now show in AlarmMsg
        
        */
    }
}
