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
using System.Diagnostics;

namespace Alarm {
    public partial class Alarm : Form {

        //Important Variables
        private Timer t = null;
        NotifyIcon MyNotifyIcon = new NotifyIcon();
        string DB_Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Alarm\\AlarmHistory.csv");
        bool AlarmActive = false; //ActivateAlarm Button pressed = ?
        DateTime CountdownTimeADD = DateTime.Now; //Get CurrentTime + CountdownTime
        DateTime StopFlash = DateTime.Now.AddYears(-2000); //Var for the Alarm+15sec to stop flashing
        //bool FlashActive; //when alarm goes off FlashActive gets "true". When StopFlash time is reached FlashActive will be set "false".
        string AlarmTime = "";
        string DisplayInfo = "";
        //int LastRowIndex = 1000;
        //public int CellCnt; //Counts the Cells of the active Row
        DataSet ADS;
        DataTable ADT;

        //Gather DisplayInfo
        int ScreenCnt = 0;
        List<Screen> Myscreens = new List<Screen>(); //creates a new list containing objects of type "Screen"


        //Old controlls - Vars
        DateTime numAlarmHour = DateTime.Now;
        DateTime numAlarmMin = DateTime.Now;
        //string tbNote = "";

        public Alarm() {
            InitializeComponent();

            //Dataset
            ADS = new DataSet("ADS"); //AlarmDataSet (ADS)
            ADT= ADS.Tables.Add("ADT"); //AlarmDataTable (ADT)
            DataColumn ColDate = ADT.Columns.Add("Date");
            ColDate.DefaultValue = DateTime.Now.ToString("dd.MM.yyyy");
            ColDate.AllowDBNull = false; //Date must not be empty
            //ADT.Columns.Add("Date");
            DataColumn ColHour = ADT.Columns.Add("Hour"); //, typeof(int));
            ColHour.DefaultValue = "10";
            DataColumn ColMin = ADT.Columns.Add("Minute"); //, typeof(int));
            ColMin.DefaultValue = "00";
            DataColumn ColAlarmActive = ADT.Columns.Add("AlarmActive", typeof(bool));
            ColAlarmActive.DefaultValue = true;
            ADT.Columns.Add("Note");
            DataColumn ColPathActiv = ADT.Columns.Add("PathActiv", typeof(bool));
            ColPathActiv.DefaultValue = false;
            ADT.Columns.Add("ProgPath"); //Path to start Programm
            DataColumn ColSoundActive = ADT.Columns.Add("SoundActive", typeof(bool));
            ColSoundActive.DefaultValue = false;
            ADT.Columns.Add("SoundSource"); //Radiobtn "ringtone", "soundfile", "youtube"
            DataColumn ColID = ADT.Columns.Add("ID");
            ColID.AllowDBNull = false;
            ColID.DefaultValue = 000000;
            DataColumn ColYoutubePath = ADT.Columns.Add("YoutubePath");
            ColYoutubePath.DefaultValue = "";
            DataColumn ColAlarmSound = ADT.Columns.Add("AlarmSound");
            ColAlarmSound.DefaultValue = "Applause";
            DataColumn ColMon = ADT.Columns.Add("Mon", typeof(bool));
            ColMon.DefaultValue = false;
            DataColumn ColTue = ADT.Columns.Add("Tue", typeof(bool));
            ColTue.DefaultValue = false;
            DataColumn ColWed = ADT.Columns.Add("Wed", typeof(bool));
            ColWed.DefaultValue = false;
            DataColumn ColThu = ADT.Columns.Add("Thu", typeof(bool));
            ColThu.DefaultValue = false;
            DataColumn ColFri = ADT.Columns.Add("Fri", typeof(bool));
            ColFri.DefaultValue = false;
            DataColumn ColSat = ADT.Columns.Add("Sat", typeof(bool));
            ColSat.DefaultValue = false;
            DataColumn ColSun = ADT.Columns.Add("Sun", typeof(bool));
            ColSun.DefaultValue = false;
            DataColumn ColRepeat = ADT.Columns.Add("Repeat", typeof(bool));
            ColRepeat.DefaultValue = false;
            DataColumn ColFlash = ADT.Columns.Add("Flash", typeof(bool));
            ColFlash.DefaultValue = false;
            DataColumn ColShutdown = ADT.Columns.Add("Shutdown", typeof(bool));
            ColShutdown.DefaultValue = false;
            DataColumn ColOverwrite = ADT.Columns.Add("Overwrite", typeof(bool));
            ColOverwrite.DefaultValue = false;
            DataColumn ColNextAlarm = ADT.Columns.Add("NextAlarm");
            ColNextAlarm.DefaultValue = "";
            DataColumn ColActSoundSource = ADT.Columns.Add("ActSoundSource");
            ColActSoundSource.DefaultValue = "";
            //ColID.Unique = true;
            //DataColumn DCbool = new DataColumn("AActive",typeof(bool));
            //ADT.Columns.Add(DCbool);

            //Get DBpath without storing a value.
            if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Alarm\\AlarmHistory.csv"))) {
                DB_Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Alarm\\AlarmHistory.csv");

            }
            else if (File.Exists(Application.StartupPath + "\\AlarmHistory.csv")) {
                DB_Path = Application.StartupPath + "\\AlarmHistory.csv";
                programmPathToolStripMenuItem.Checked = true;
                userDocumentsToolStripMenuItem.Checked = false;
            }

            DataRow ADR = ADT.NewRow();
            //ADR["AlarmISActive"] = true;
            //ADR["Date"] = "02.12.2016 00:00:00";
            DataTable LoadData = new DataTable();
            //if (File.Exists("C:\\MyTemp\\VS\\AlarmList.csv")) {
            if (File.Exists(DB_Path)) {
                LoadData =  CsvImport.GetDataTableFromCsv(DB_Path, true);

                int RowCnt = 0;
                foreach (DataRow Row in LoadData.Rows) {
                    RowCnt++;
                    DataRow RowName = ADT.NewRow();
                    RowName["Date"] = Row["Date"];
                    RowName["Hour"] = Row["Hour"];
                    RowName["Minute"] = Row["Minute"];
                    RowName["AlarmActive"] = Row["AlarmActive"];
                    RowName["Note"] = Row["Note"];
                    RowName["PathActiv"] = Row["PathActiv"];
                    RowName["ProgPath"] = Row["ProgPath"];
                    RowName["SoundActive"] = Row["SoundActive"];
                    RowName["SoundSource"] = Row["SoundSource"];
                    RowName["ID"] = Row["ID"];
                    RowName["YoutubePath"] = Row["YoutubePath"];
                    RowName["Mon"] = Row["Mon"];
                    RowName["Tue"] = Row["Tue"];
                    RowName["Wed"] = Row["Wed"];
                    RowName["Thu"] = Row["Thu"];
                    RowName["Fri"] = Row["Fri"];
                    RowName["Sat"] = Row["Sat"];
                    RowName["Sun"] = Row["Sun"];
                    RowName["Repeat"] = Row["Repeat"];
                    RowName["Flash"] = Row["Flash"];
                    RowName["Shutdown"] = Row["Shutdown"];
                    RowName["Overwrite"] = Row["Overwrite"];
                    RowName["NextAlarm"] = Row["NextAlarm"];
                    RowName["ActSoundSource"] = Row["ActSoundSource"];

                    ADT.Rows.Add(RowName);
                }
            }
            else {
                ADR["Hour"] = 10;
                ADR["Minute"] = 23;
                ADR["AlarmActive"] = true;
                ADR["Note"] = "WhatsMyName";
                ADR["PathActiv"] = true;
                ADR["ProgPath"] = "C:\\Temp";
                ADR["SoundActive"] = true;
                ADR["SoundSource"] = "C:\\Smart\\Temp";
                ADR["ID"] = "00001";
                ADR["YoutubePath"] = "";
                ADR["Mon"] = false;
                ADR["Tue"] = false;
                ADR["Wed"] = false;
                ADR["Thu"] = false;
                ADR["Fri"] = false;
                ADR["Sat"] = false;
                ADR["Sun"] = false;
                ADR["Repeat"] = false;
                ADR["Flash"] = false;
                ADR["Shutdown"] = false;
                ADR["Overwrite"] = false;
                ADR["NextAlarm"] = "";
                ADR["ActSoundSource"] = "";


                ADT.Rows.Add(ADR);
            }
            
            dataGridView1.DataSource = ADS.Tables[0];

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

            //Set Tooltip
            System.Windows.Forms.ToolTip ToolTipbtnDelete = new System.Windows.Forms.ToolTip();
            ToolTipbtnDelete.SetToolTip(btnDelete, "This will delete the selected row.");


            //Gather DisplayInfo
            foreach (var screen in Screen.AllScreens) {
                DisplayInfo += screen.DeviceName + "\n" + screen.Bounds.ToString() + "\n" + screen.Bounds.X.ToString() + "\n" + screen.Bounds.Y.ToString() + "\n" + screen.Bounds.Width.ToString() + "\n" + screen.Bounds.Height.ToString() + "\n" + screen.GetType().ToString() + "\n" + screen.WorkingArea.ToString() + "\n" + screen.Primary.ToString() + "\n" + screen.WorkingArea.ToString() + "\n\n\n";
                //string[] Array = new string "a" [cnt];
                ScreenCnt++;
                Myscreens.Add(screen);
            }
            //MessageBox.Show(DisplayInfo);
            //GetNextAlarm();

        }

        int CountdownChecked = 0;
        private void CountdownRadio(Object sender, EventArgs e) {
            CountdownChecked = 1;
            if (sender == numCountdownHour || sender == numCountdownMin) {
                rbCustom.Checked = true;
            }
        }

        void tTick(object sender, EventArgs e) {
            Console.Write("tick");

            foreach (DataGridViewRow Row in dataGridView1.Rows) {
                string source = "";
                string DateString = string.Format("{0:dd.MM.yyyy}", DateTime.Now.ToString());
                if (Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[3].Value)) {
                    //If AlarmActive = 1
                    string CurrentAlarmDate = dataGridView1.Rows[Row.Index].Cells[0].Value.ToString() + " " + dataGridView1.Rows[Row.Index].Cells[1].Value.ToString() + ":" + dataGridView1.Rows[Row.Index].Cells[2].Value.ToString() + ":00";
                    string CurrentTime = string.Format("{0:dd.MM.yyyy HH:mm}", DateTime.Now.ToString());
                    //CurrentTime = CurrentTime.Remove(16, 3);
                    string currentday = DateTime.Now.DayOfWeek.ToString();
                    
                    if (Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[12].Value) == false &&
                        Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[13].Value) == false &&
                        Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[14].Value) == false &&
                        Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[15].Value) == false &&
                        Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[16].Value) == false &&
                        Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[17].Value) == false &&
                        Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[18].Value) == false) {
                        //if Alarm Active and all Days are inactive.
                        source = "DateTime";
                        if (MergeAlarm(source, dataGridView1.Rows[Row.Index].Cells[0].Value.ToString(), dataGridView1.Rows[Row.Index].Cells[1].Value.ToString(), dataGridView1.Rows[Row.Index].Cells[2].Value.ToString()) == CurrentTime) {
                            dataGridView1.Rows[Row.Index].Cells[3].Value = false; //deaktivate Alarm
                            AlarmGoesOff("Alarm", null, currentday, Row.Index);
                        }
                    }
                    else if (Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[19].Value) == true) {
                        //At least one Day is active - repeat is on as well
                        source = "Repeat";
                        if (MergeAlarm(source, string.Format("{0:dd.MM.yyyy}", DateTime.Now.ToString()), dataGridView1.Rows[Row.Index].Cells[1].Value.ToString(), dataGridView1.Rows[Row.Index].Cells[2].Value.ToString()) == CurrentTime) {
                            if (currentday == "Monday") {
                                if (Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[12].Value) == true) {
                                    AlarmGoesOff("Alarm", null, currentday, Row.Index);
                                }
                            }
                            else if (currentday == "Tuesday") {
                                if (Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[13].Value) == true) {
                                    AlarmGoesOff("Alarm", null, currentday, Row.Index);
                                }
                            }
                            else if (currentday == "Wednesday") {
                                if (Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[14].Value) == true) {
                                    AlarmGoesOff("Alarm", null, currentday, Row.Index);
                                }
                            }
                            else if (currentday == "Thursday") {
                                if (Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[15].Value) == true) {
                                    AlarmGoesOff("Alarm", null, currentday, Row.Index);
                                }
                            }
                            else if (currentday == "Friday") {
                                if (Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[16].Value) == true) {
                                    AlarmGoesOff("Alarm", null, currentday, Row.Index);
                                }
                            }
                            else if (currentday == "Saturday") {
                                if (Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[17].Value) == true) {
                                    AlarmGoesOff("Alarm", null, currentday, Row.Index);
                                }
                            }
                            else if (currentday == "Sunday") {
                                if (Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[18].Value) == true) {
                                    AlarmGoesOff("Alarm", null, currentday, Row.Index);
                                }
                            }
                        }
                    }
                    else {
                        //At least on Day is active - repeat is not
                        source = "NoRepeat";
                        if (MergeAlarm(source, DateString, dataGridView1.Rows[Row.Index].Cells[1].Value.ToString(), dataGridView1.Rows[Row.Index].Cells[2].Value.ToString()) == CurrentTime) {
                            if (currentday == "Monday") {
                                if (Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[12].Value) == true) {
                                    dataGridView1.Rows[Row.Index].Cells[12].Value = false; //Deaktivates cbMon
                                    AlarmGoesOff("Alarm", null, currentday, Row.Index);
                                }
                            }
                            else if (currentday == "Tuesday") {
                                if (Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[13].Value) == true) {
                                    dataGridView1.Rows[Row.Index].Cells[13].Value = false;
                                    AlarmGoesOff("Alarm", null, currentday, Row.Index);
                                }
                            }
                            else if (currentday == "Wednesday") {
                                if (Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[14].Value) == true) {
                                    dataGridView1.Rows[Row.Index].Cells[14].Value = false;
                                    AlarmGoesOff("Alarm", null, currentday, Row.Index);
                                }
                            }
                            else if (currentday == "Thursday") {
                                if (Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[15].Value) == true) {
                                    dataGridView1.Rows[Row.Index].Cells[15].Value = false;
                                    AlarmGoesOff("Alarm", null, currentday, Row.Index);
                                }
                            }
                            else if (currentday == "Friday") {
                                if (Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[16].Value) == true) {
                                    dataGridView1.Rows[Row.Index].Cells[16].Value = false;
                                    AlarmGoesOff("Alarm", null, currentday, Row.Index);
                                }
                            }
                            else if (currentday == "Saturday") {
                                if (Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[17].Value) == true) {
                                    dataGridView1.Rows[Row.Index].Cells[17].Value = false;
                                    AlarmGoesOff("Alarm", null, currentday, Row.Index);
                                }
                            }
                            else if (currentday == "Sunday") {
                                if (Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[18].Value) == true) {
                                    dataGridView1.Rows[Row.Index].Cells[18].Value = false;
                                    AlarmGoesOff("Alarm", null, currentday, Row.Index);
                                }
                            }
                        }
                    }
                    //File.AppendAllText("C:\\Temp\\Check.log","\n" + DateTime.Now.ToString() + " " + CurrentTime + " vs " + AlarmTime + " " + source);
                }
            }

            if ( DateTime.Now < StopFlash && DateTime.Now > StopFlash.AddSeconds(-15)) {
                FrameFlash(null, null,Myscreens,Myscreens.Count);
            }

            if (cbCountdown.Checked && AlarmActive && CountdownChecked == 1) {
                if (DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") == lblCountdownTime.Text) { //Format = "02.09.2016 15:29"
                    AlarmGoesOff("Countdown", null, CountdownTimeADD.ToString(), 0);
                }
            }

            if (StopFlash > DateTime.Now.AddYears(-1) && DateTime.Now > StopFlash.AddSeconds(2)) {
                //Hide all BoarderForms
                StopFlash = DateTime.Now.AddYears(-2000);
                for (int i = 0; i < Myscreens.Count; i++) {
                    bottomArray[i].Hide();
                    topArray[i].Hide();
                    leftArray[i].Hide();
                    rightArray[i].Hide();
                }
            }
        }

        private void GetNextAlarm() {
            foreach (DataGridViewRow Row in dataGridView1.Rows) {
                //string NextAlarm = "";
                DateTime firstDate = DateTime.Now.AddYears(-2000);
                DateTime Today = DateTime.Now;
                int cnt = 0;
                string source = "Repeat";
                if (Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[12].Value) == false &&
                            Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[13].Value) == false &&
                            Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[14].Value) == false &&
                            Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[15].Value) == false &&
                            Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[16].Value) == false &&
                            Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[17].Value) == false &&
                            Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[18].Value) == false) {
                    //if Alarm Active and all Days are inactive.
                    source = "DateTime";
                }

                while (cnt < 7) {
                    Today.AddDays(cnt);
                    if (Today.DayOfWeek.ToString() == "Monday" && Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[12].Value) == true) {
                        if (firstDate < DateTime.Now.AddYears(-1200) || DateTime.Now < firstDate) { //if firstDate is empty
                            dataGridView1.Rows[Row.Index].Cells[23].Value = MergeAlarm(source, Today.ToString(), dataGridView1.Rows[Row.Index].Cells[1].Value.ToString(), dataGridView1.Rows[Row.Index].Cells[2].Value.ToString());
                            break;
                        }
                    }
                    else if (Today.DayOfWeek.ToString() == "Tuesday" && Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[13].Value) == true) {
                        if (firstDate < DateTime.Now.AddYears(-1200) || DateTime.Now < firstDate) { //if firstDate is empty
                            dataGridView1.Rows[Row.Index].Cells[23].Value = MergeAlarm(source, Today.ToString(), dataGridView1.Rows[Row.Index].Cells[1].Value.ToString(), dataGridView1.Rows[Row.Index].Cells[2].Value.ToString());
                            break;
                        }
                    }
                    else if (Today.DayOfWeek.ToString() == "Wednesday" && Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[14].Value) == true) {
                        if (firstDate < DateTime.Now.AddYears(-1200) || DateTime.Now < firstDate) { //if firstDate is empty
                            dataGridView1.Rows[Row.Index].Cells[23].Value = MergeAlarm(source, Today.ToString(), dataGridView1.Rows[Row.Index].Cells[1].Value.ToString(), dataGridView1.Rows[Row.Index].Cells[2].Value.ToString());
                            break;
                        }
                    }
                    else if (Today.DayOfWeek.ToString() == "Thursday" && Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[15].Value) == true) {
                        if (firstDate < DateTime.Now.AddYears(-1200) || DateTime.Now < firstDate) { //if firstDate is empty
                            dataGridView1.Rows[Row.Index].Cells[23].Value = MergeAlarm(source, Today.ToString(), dataGridView1.Rows[Row.Index].Cells[1].Value.ToString(), dataGridView1.Rows[Row.Index].Cells[2].Value.ToString());
                            break;
                        }
                    }
                    else if (Today.DayOfWeek.ToString() == "Friday" && Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[16].Value) == true) {
                        if (firstDate < DateTime.Now.AddYears(-1200) || DateTime.Now < firstDate) { //if firstDate is empty
                            dataGridView1.Rows[Row.Index].Cells[23].Value = MergeAlarm(source, Today.ToString(), dataGridView1.Rows[Row.Index].Cells[1].Value.ToString(), dataGridView1.Rows[Row.Index].Cells[2].Value.ToString());
                            break;
                        }
                    }
                    else if (Today.DayOfWeek.ToString() == "Saturday" && Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[17].Value) == true) {
                        if (firstDate < DateTime.Now.AddYears(-1200) || DateTime.Now < firstDate) { //if firstDate is empty
                            dataGridView1.Rows[Row.Index].Cells[23].Value = MergeAlarm(source, Today.ToString(), dataGridView1.Rows[Row.Index].Cells[1].Value.ToString(), dataGridView1.Rows[Row.Index].Cells[2].Value.ToString());
                            break;
                        }
                    }
                    else if (Today.DayOfWeek.ToString() == "Sunday" && Convert.ToBoolean(dataGridView1.Rows[Row.Index].Cells[18].Value) == true) {
                        if (firstDate < DateTime.Now.AddYears(-1200) || DateTime.Now < firstDate) { //if firstDate is empty
                            dataGridView1.Rows[Row.Index].Cells[23].Value = MergeAlarm(source, Today.ToString(), dataGridView1.Rows[Row.Index].Cells[1].Value.ToString(), dataGridView1.Rows[Row.Index].Cells[2].Value.ToString());
                            break;
                        }
                    }
                    cnt++;
                }
            }

            //return NextAlarm;
        }

        //Merges Date variables to a DateString with correct Format
        private string MergeAlarm (string source, string DateDay, string Hour, string Minute) {
            if (source == "DateTime") {
                AlarmTime = DateDay + " " + Hour + ":" + Minute + ":00";
            }
            else if (source == "Repeat") {
                AlarmTime = DateDay.Remove(10, 9) + " " + Hour + ":" + Minute + ":00";
            }
            else if (source == "NoRepeat") {
                AlarmTime = DateDay.Remove(10, 9) + " " + Hour + ":" + Minute + ":00";
            }
            return AlarmTime;
        }

        private void AlarmGoesOff (string sender, EventArgs e, string day, int index) {
            if (sender == "Alarm") {
                if (dataGridView1.Rows[index].Cells[24].Value.ToString() == "Alarm") { //ProgPathActiv is active
                    if (dataGridView1.Rows[index].Cells[11].Value.ToString() != "" && dataGridView1.Rows[index].Cells[11].Value.ToString() != null) {
                        if (dataGridView1.Rows[index].Cells[11].Value.ToString() == "Phonering") {
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.calleering); //@"string" means interpret the following string as literal. Meaning, the \ in the string will actually be a "\" in the output, rather than having to put "\\" to mean the literal character
                            player.Play();
                        }
                        else if (dataGridView1.Rows[index].Cells[11].Value.ToString() == "Applause") {
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.APPLAUSE);
                            player.Play();
                        }
                        else if (dataGridView1.Rows[index].Cells[11].Value.ToString() == "Callring") {
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.ELPHRG01);
                            player.Play();
                        }
                    }
                }
                else if (dataGridView1.Rows[index].Cells[24].Value.ToString() == "File") { //SoundActive is active
                    if (dataGridView1.Rows[index].Cells[8].Value.ToString() != "" || dataGridView1.Rows[index].Cells[8].Value.ToString() != null) { //SoundSource-tbASFilePath = the chosen soundfile path  -> is not empty
                        AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayerSoundFile = new AxWMPLib.AxWindowsMediaPlayer();
                        axWindowsMediaPlayerSoundFile.URL = dataGridView1.Rows[index].Cells[8].Value.ToString();
                        axWindowsMediaPlayerSoundFile.Visible = false;
                        axWindowsMediaPlayerSoundFile.settings.setMode("loop", false);
                    }
                }
                else if (dataGridView1.Rows[index].Cells[24].Value.ToString() == "Youtube") { //YoutubePath is active
                    if (dataGridView1.Rows[index].Cells[10].Value.ToString() != "" || dataGridView1.Rows[index].Cells[10].Value.ToString() != null) { //Youtubepath-tbASYoutubepath = the youtube Url  -> is not empty
                        Process.Start(dataGridView1.Rows[index].Cells[10].Value.ToString());
                    }
                }
                //if Overwrite is enabled
                if (Convert.ToBoolean(dataGridView1.Rows[index].Cells[22].Value) == true){
                    //load Settings from Alarm
                    if (Convert.ToBoolean(dataGridView1.Rows[index].Cells[20].Value)) {
                        //If Flash is activated
                        StopFlash = DateTime.Now;
                        StopFlash = StopFlash.AddSeconds(15);
                    }
                    if (Convert.ToBoolean(dataGridView1.Rows[index].Cells[21].Value)) {
                        //If Shutdown is activated
                        Process.Start(System.Environment.SystemDirectory + "\\shutdown.exe", "-s -t 600");
                    }
                }
                else {
                    if (cbFlashscreen.Checked) {
                        StopFlash = DateTime.Now;
                        StopFlash = StopFlash.AddSeconds(15);
                    }
                    if (cbShutdown.Checked) {
                        Process.Start(System.Environment.SystemDirectory + "\\shutdown.exe", "-s -t 600");
                    }
                }
                //MessageBox.Show("sender: " + sender.ToString() + "\nDay: " + day + "\nIndex: " + index, "Alarm", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MessageBox.Show("Day: " + day + "\n\n" + dataGridView1.Rows[index].Cells[4].Value.ToString(), "Alarm", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else { //sender == "Countdown"
                if (cbFlashscreen.Checked) {
                    StopFlash = DateTime.Now;
                    StopFlash = StopFlash.AddSeconds(15);
                }
                if (cbShutdown.Checked) {
                    Process.Start(System.Environment.SystemDirectory + "\\shutdown.exe", "-s -t 600");
                }
                DialogResult AlarmMsgResult = MessageBox.Show("Day: " + day, "Countdown", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (AlarmMsgResult == DialogResult.OK) {
                    StopFlash = StopFlash.AddSeconds(-15);
                }
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

        private void btnDelete_Click(object sender, EventArgs e) {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows) {
                if (item.IsNewRow == false) {
                    dataGridView1.Rows.RemoveAt(item.Index);
                }
            }
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
                btnAcivateAlarm.Text = "Activate Countdown";
                AlarmActive = false;
                t.Enabled = false; //disables Timer
                lblCountdownTime.Text = "";
            }
            else {
                btnAcivateAlarm.Text = "Deactivate Countdown";
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
        //ScreenOverlay2
        Bottom FrmBottm2 = new Bottom();
        Top FrmTop2 = new Top();
        LeftSide FrmLeft2 = new LeftSide();
        RightSide FrmRight2 = new RightSide();
        //ScreenOverlay3
        Bottom FrmBottm3 = new Bottom();
        Top FrmTop3 = new Top();
        LeftSide FrmLeft3 = new LeftSide();
        RightSide FrmRight3 = new RightSide();

        Bottom[] bottomArray = { new Bottom(), new Bottom(), new Bottom() };
        Top[] topArray = { new Top(), new Top(), new Top() };
        LeftSide[] leftArray = { new LeftSide(), new LeftSide(), new LeftSide() };
        RightSide[] rightArray = { new RightSide(), new RightSide(), new RightSide() };



        private void FrameFlash(object sender, EventArgs e, List<Screen> MyScreens, int ScreenCounter) {
            for (int i = 0; i < MyScreens.Count; i++) {
                //Bottom
                if (bottomArray[i].Visible) {
                    Point MyLoc = new Point(Myscreens[i].Bounds.Location.X, bottomArray[i].Location.Y);
                    bottomArray[i].Location = MyLoc;
                    bottomArray[i].Hide();
                }
                else {
                    Point MyLoc = new Point(Myscreens[i].Bounds.Location.X, bottomArray[i].Location.Y);
                    bottomArray[i].Location = MyLoc;
                    bottomArray[i].Show();
                    bottomArray[i].TopMost = true;
                }

                //Top
                if (topArray[i].Visible) {
                    Point MyLoc = new Point(Myscreens[i].Bounds.Location.X, topArray[i].Location.Y);
                    topArray[i].Location = MyLoc;
                    topArray[i].Hide();
                }
                else {
                    Point MyLoc = new Point(Myscreens[i].Bounds.Location.X, topArray[i].Location.Y);
                    topArray[i].Location = MyLoc;
                    topArray[i].Show();
                    topArray[i].TopMost = true;
                }

                //Left
                if (leftArray[i].Visible) {
                    Point MyLoc = new Point(Myscreens[i].Bounds.Location.X, leftArray[i].Location.Y);
                    leftArray[i].Location = MyLoc;
                    leftArray[i].Hide();
                }
                else {
                    Point MyLoc = new Point(Myscreens[i].Bounds.Location.X, leftArray[i].Location.Y);
                    leftArray[i].Location = MyLoc;
                    leftArray[i].Show();
                    leftArray[i].TopMost = true;
                }

                //Right
                if (rightArray[i].Visible) {
                    Point MyLoc = new Point(Myscreens[i].Bounds.Location.X + 1905, rightArray[i].Location.Y);
                    rightArray[i].Location = MyLoc;
                    rightArray[i].Hide();
                }
                else {
                    Point MyLoc = new Point(Myscreens[i].Bounds.Location.X + 1905, rightArray[i].Location.Y);
                    rightArray[i].Location = MyLoc;
                    rightArray[i].Show();
                    rightArray[i].TopMost = true;
                }
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {
            dataGridView1.Columns["ID"].Visible = false; //hides ID Column in DataGridView
            dataGridView1.RowHeadersVisible = true; //hides the first gray row in DataGridView
            dataGridView1.RowHeadersWidth = 10;
            dataGridView1.AutoResizeColumns();
            //dataGridView1.Sort(dataGridView1.Columns["Hour"], ListSortDirection.Ascending);
            //dataGridView1.Sort(dataGridView1.Columns["NextAlarm"], ListSortDirection.Ascending);
            dataGridView1.Columns["Hour"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; //Text of this Column will be alligned to the right side
            dataGridView1.Columns["Hour"].Width = 35; //Sets Column Width
            dataGridView1.Columns["Minute"].Width = 45;
            dataGridView1.Columns["Flash"].Visible = false;
            dataGridView1.Columns["Shutdown"].Visible = false;
            dataGridView1.Columns["Overwrite"].Visible = false;
        }
        
        public void UpdateRowDetails(AlarmSettings settings) {
            dataGridView1.Rows[settings.LastRowIndex].Cells[0].Value = string.Format ("{0:dd.MM.yyyy}",settings.Date);
            dataGridView1.Rows[settings.LastRowIndex].Cells[1].Value = settings.Hour;
            if (dataGridView1.Rows[settings.LastRowIndex].Cells[2].Value != null) {
                dataGridView1.Rows[settings.LastRowIndex].Cells[2].Value = settings.Minute;
            }
            if (dataGridView1.Rows[settings.LastRowIndex].Cells[3].Value != null) {
                dataGridView1.Rows[settings.LastRowIndex].Cells[3].Value = settings.AlarmActive;
            }
            dataGridView1.Rows[settings.LastRowIndex].Cells[4].Value = settings.Note;
            if (dataGridView1.Rows[settings.LastRowIndex].Cells[5].Value != null) {
                dataGridView1.Rows[settings.LastRowIndex].Cells[5].Value = settings.ProgPathActiv;
            }
            dataGridView1.Rows[settings.LastRowIndex].Cells[6].Value = settings.ProgPath;
            if (dataGridView1.Rows[settings.LastRowIndex].Cells[7].Value != null) {
                dataGridView1.Rows[settings.LastRowIndex].Cells[7].Value = settings.SoundActive;
            }
            dataGridView1.Rows[settings.LastRowIndex].Cells[8].Value = settings.SoundSource;
            if (dataGridView1.Rows[settings.LastRowIndex].Cells[9].Value != null) {
                dataGridView1.Rows[settings.LastRowIndex].Cells[9].Value = settings.ID;
            }
            dataGridView1.Rows[settings.LastRowIndex].Cells[10].Value = settings.YoutubePath;
            if (dataGridView1.Rows[settings.LastRowIndex].Cells[11].Value != null) {
                dataGridView1.Rows[settings.LastRowIndex].Cells[11].Value = settings.AlarmSound;
            }
            dataGridView1.Rows[settings.LastRowIndex].Cells[12].Value = settings.Mon;
            dataGridView1.Rows[settings.LastRowIndex].Cells[13].Value = settings.Tue;
            dataGridView1.Rows[settings.LastRowIndex].Cells[14].Value = settings.Wed;
            dataGridView1.Rows[settings.LastRowIndex].Cells[15].Value = settings.Thu;
            dataGridView1.Rows[settings.LastRowIndex].Cells[16].Value = settings.Fri;
            dataGridView1.Rows[settings.LastRowIndex].Cells[17].Value = settings.Sat;
            dataGridView1.Rows[settings.LastRowIndex].Cells[18].Value = settings.Sun;
            dataGridView1.Rows[settings.LastRowIndex].Cells[19].Value = settings.Repeat;
            dataGridView1.Rows[settings.LastRowIndex].Cells[20].Value = settings.Flash;
            dataGridView1.Rows[settings.LastRowIndex].Cells[21].Value = settings.Shutdown; 
            dataGridView1.Rows[settings.LastRowIndex].Cells[22].Value = settings.Overwrite;
            //23 = Nextalarm
            dataGridView1.Rows[settings.LastRowIndex].Cells[24].Value = settings.ActSoundSource;

            StringBuilder sb = new StringBuilder();

            IEnumerable<string> columnNames = ADT.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in ADT.Rows) {
                IEnumerable<string> fields = row.ItemArray.Select(field => string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\""));
                sb.AppendLine(string.Join(",", fields));
            }

            if (!Directory.Exists(Path.GetDirectoryName(DB_Path))) { //this removes the Filepattern from the pathfile and checkes if directory does NOT exist then create it.
                 Directory.CreateDirectory(Path.GetDirectoryName(DB_Path));
            }
            File.WriteAllText(DB_Path, sb.ToString());
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            //Load DatagridView into AlarmSettings Form
            AlarmSettings AlarmSettingsGui = new AlarmSettings(this);
            AlarmSettingsGui.LastRowIndex = e.RowIndex;

            if (dataGridView1.Rows[e.RowIndex].Cells[0].Value != null) {
                AlarmSettingsGui.Date = string.Format("{0:dd.MM.yyyy}", dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null) {
                AlarmSettingsGui.Hour = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[2].Value != null) {
                AlarmSettingsGui.Minute = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[3].Value != null) {
                AlarmSettingsGui.AlarmActive = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[4].Value != null) {
                AlarmSettingsGui.Note = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[5].Value != null) {
                AlarmSettingsGui.ProgPathActiv = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[6].Value != null) {
                AlarmSettingsGui.ProgPath = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString(); //Path to start Programm
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[7].Value != null) {
                AlarmSettingsGui.SoundActive = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[8].Value != null) {
                AlarmSettingsGui.SoundSource = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString(); //Radiobtn "ringtone", "soundfile", "youtube"
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[9].Value != null) {
                AlarmSettingsGui.ID = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString(); ;
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[10].Value != null) {
                AlarmSettingsGui.YoutubePath = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[11].Value != null) {
                AlarmSettingsGui.AlarmSound = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[12].Value != null) {
                AlarmSettingsGui.Mon = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[12].Value);
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[13].Value != null) {
                AlarmSettingsGui.Tue = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[13].Value);
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[14].Value != null) {
                AlarmSettingsGui.Wed = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[14].Value);
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[15].Value != null) {
                AlarmSettingsGui.Thu = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[15].Value);
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[16].Value != null) {
                AlarmSettingsGui.Fri = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[16].Value);
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[17].Value != null) {
                AlarmSettingsGui.Sat = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[17].Value);
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[18].Value != null) {
                AlarmSettingsGui.Sun = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[18].Value);
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[19].Value != null) {
                AlarmSettingsGui.Repeat = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[19].Value);
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[20].Value != null) {
                AlarmSettingsGui.Flash = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[20].Value);
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[21].Value != null) {
                AlarmSettingsGui.Shutdown = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[21].Value);
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[22].Value != null) {
                AlarmSettingsGui.Overwrite = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[22].Value); 
            }
            //23 = NextAlarm
            if (dataGridView1.Rows[e.RowIndex].Cells[24].Value != null) {
                AlarmSettingsGui.ActSoundSource = dataGridView1.Rows[e.RowIndex].Cells[24].Value.ToString();
            }

            if (AlarmSettingsGui.Mon == true || AlarmSettingsGui.Mon == true || AlarmSettingsGui.Mon == true || AlarmSettingsGui.Mon == true || AlarmSettingsGui.Mon == true || AlarmSettingsGui.Mon == true || AlarmSettingsGui.Mon == true) {
                AlarmSettingsGui.DayActive = true;
            }
            else {
                AlarmSettingsGui.DayActive = false;
            }

            AlarmSettingsGui.Show();

           
        }

        //Menu Strings
        private void quitToolStripMenuItem_Click(object sender, EventArgs e) {
            Dispose();
        }
        private void AlarmTestToolStripMenuItem_Click(object sender, EventArgs e) {
            AlarmGoesOff("Countdown", null, CountdownTimeADD.ToString(), 0);
        }
        private void DatabasePathToolStripMenuItem_Click(object sender, EventArgs e) {
            if(sender == userDocumentsToolStripMenuItem) {
                userDocumentsToolStripMenuItem.Checked = true;
                programmPathToolStripMenuItem.Checked = false;
                DB_Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Alarm\\AlarmHistory.csv");
                if (!File.Exists(DB_Path)) {
                    if (File.Exists(Application.StartupPath + "\\AlarmHistory.csv")) {
                        File.Move(Application.StartupPath + "\\AlarmHistory.csv", DB_Path);
                    }
                }
            }
            else if (sender == programmPathToolStripMenuItem) {
                userDocumentsToolStripMenuItem.Checked = false;
                programmPathToolStripMenuItem.Checked = true;
                DB_Path = Application.StartupPath + "\\AlarmHistory.csv";
                if (!File.Exists(DB_Path)) {
                    if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Alarm\\AlarmHistory.csv"))) {
                        File.Move(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Alarm\\AlarmHistory.csv"), DB_Path);
                    }
                }
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e) {
            StringBuilder sb = new StringBuilder();

            IEnumerable<string> columnNames = ADT.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in ADT.Rows) {
                IEnumerable<string> fields = row.ItemArray.Select(field => string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\""));
                sb.AppendLine(string.Join(",", fields));
            }

            if (!Directory.Exists(Path.GetDirectoryName(DB_Path))) { //this removes the Filepattern from the pathfile and checkes if directory does NOT exist then create it.
                Directory.CreateDirectory(Path.GetDirectoryName(DB_Path));
            }
            File.WriteAllText(DB_Path, sb.ToString());
            Hide();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e) {

        }

        /*TODO
        
        order by - new field combinded of date/time/allways active - vorraussetzung um überschreiben von NextAlarm zu verhindern noch nicht gegeben
        -Check for double entries on OK button
            >Function: Check for double entries on OK button
            >Menustring 
        -Warning - if Alarm/countdown changed while active -> MsgBox -> reload Alarm|keep active Alarm and changes|cancel changes
        -choose soundoutput for Countdown?
        -Add Note to Countdown
        -Add icon and usefull information to AlarmMsg (AlarmTime,Note
        -Counter Note field tooltip
        


        Changelog

        +Screen Flashing is now working for All horizontal alligned screens
        +Added Option -> DB-Path -> store *.db in Userfolder |  store *.db at same path as Alarm.exe

        +Adjust flashing for multiple Screens -> Frame positioning is missing.
        */

        /* Snigget
        
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
         
            ////Create FileDirectory (MyDocuments)
            //  string DB_Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Alarm\\AlarmHistory.csv");
            //    if (!Directory.Exists(Path.GetDirectoryName(DB_Path))) { //this removes the Filepattern from the pathfile and checkes if directory does NOT exist then create it.
            //        Directory.CreateDirectory(Path.GetDirectoryName(DB_Path));
            //    }
            //    File.WriteAllText(DB_Path, HistoryListExport);
        */
    }
}
