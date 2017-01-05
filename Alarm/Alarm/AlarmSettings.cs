using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alarm {
    public partial class AlarmSettings : Form {

        private Alarm mainWindow;
        private static bool isOpen=false;

        //Var CellCnt
        private int _CellCnt;
        public int CellCnt {
            get { return _CellCnt; }
            set {
                _CellCnt = value;
            }
        }

        

        private int _LastRowIndex;
        public int LastRowIndex {
            get { return _LastRowIndex; }
            set {
                _LastRowIndex = value;
            }
        }

        //Var Notification (Cell 0)
        private string _Date;
        public string Date {
            get { return _Date; }
            set {
                _Date = value;
                if(value != null && value != "") {
                    dtASDate.Format = DateTimePickerFormat.Long;
                    dtASDate.CustomFormat = "dd.MM.yyyy";
                    dtASDate.Value = Convert.ToDateTime (value);
                }
            }
        }
        //Var Notification (Cell 1)
        private string _Hour;
        public string Hour {
            get { return _Hour; }
            set {
                _Hour = value;
                numASHour.Value = Convert.ToInt32(value);
            }
        }
        //Var Notification (Cell 2)
        private string _Minute;
        public string Minute {
            get { return _Minute; }
            set {
                _Minute = value;
                numASMin.Value = Convert.ToInt32(value);
            }
        }
        //Var Notification (Cell 3)
        private bool _AlarmActive;
        public bool AlarmActive {
            get { return _AlarmActive; }
            set {
                _AlarmActive = value;
                cbASActive.Checked = value;
            }
        }
        //Var Notification (Cell 4)
        private string _note;
        public string Note {
            get {return _note;}
            set {
                _note = value;
                tbASNote.Text = value;
            }
        }
    
        //Var ProgPathActiv (Cell 5)
        private bool _ProgPathActiv;
        public bool ProgPathActiv {
            get { return _ProgPathActiv; }
            set {
                _ProgPathActiv = value;
                cbStartProg.Checked = value;
            }
        }

        //Var ProgPath (Cell 6)
        private string _ProgPath;
        public string ProgPath {
            get { return _ProgPath; }
            set {
                _ProgPath = value;
                tbASProgPath.Text = value;
            }
        }

        //Var SoundActive (Cell 7)
        private bool _SoundActive;
        public bool SoundActive {
            get { return _SoundActive; }
            set {
                _SoundActive = value;
                rbASSoundFilePath.Checked = value;
            }
        }

        //Var SoundSource (Cell 8)
        private string _SoundSource;
        public string SoundSource {
            get { return _SoundSource; }
            set {
                _SoundSource = value;
                tbASFilePath.Text = value;
            }
        }

        //Var ID (Cell 9)
        private string _ID;
        public string ID {
            get { return _ID; }
            set {
                _ID = value;
            }
        }

        //Var YoutubePath (Cell 10)
        private string _YoutubePath;
        public string YoutubePath {
            get { return _YoutubePath; }
            set {
                _YoutubePath = value;
                tbASYoutubePath.Text = value;
            }
        }

        //Var AlarmSound (Cell 11)
        private string _AlarmSound;
        public string AlarmSound {
            get { return _AlarmSound; }
            set {
                _AlarmSound = value;
                combASAlarmSound.SelectedItem = value;
            }
        }

        //Var Mon (Cell 12)
        private bool _Mon;
        public bool Mon {
            get { return _Mon; }
            set {
                _Mon = value;
                cbASMon.Checked = value;
            }
        }

        //Var Tue (Cell 13)
        private bool _Tue;
        public bool Tue {
            get { return _Tue; }
            set {
                _Tue = value;
                cbASTue.Checked = value;
            }
        }
        //Var Wed (Cell 14)
        private bool _Wed;
        public bool Wed {
            get { return _Wed; }
            set {
                _Wed = value;
                cbASWed.Checked = value;
            }
        }
        //Var Thu (Cell 15)
        private bool _Thu;
        public bool Thu {
            get { return _Thu; }
            set {
                _Thu = value;
                cbASThu.Checked = value;
            }
        }
        //Var Fri (Cell 16)
        private bool _Fri;
        public bool Fri {
            get { return _Fri; }
            set {
                _Fri = value;
                cbASFri.Checked = value;
            }
        }
        //Var Sat (Cell 17)
        private bool _Sat;
        public bool Sat {
            get { return _Sat; }
            set {
                _Sat = value;
                cbASSat.Checked = value;
            }
        }
        //Var Sun (Cell 18)
        private bool _Sun;
        public bool Sun {
            get { return _Sun; }
            set {
                _Sun = value;
                cbASSun.Checked = value;
            }
        }
        //Var Repeat (Cell 19)
        private bool _Repeat;
        public bool Repeat {
            get { return _Repeat; }
            set {
                _Repeat = value;
                if (cbASOverwrite.Checked == false) {
                    cbASRepeat.Checked = value;
                }
            }
        }


        //Var Repeat (Cell 20)
        private bool _Flash;
        public bool Flash {
            get { return _Flash; }
            set {
                _Flash = value;
                if (cbASOverwrite.Checked == false) {
                    cbASFlash.Checked = value;
                }
            }
        }

        //Var Repeat (Cell 21)
        private bool _Shutdown;
        public bool Shutdown {
            get { return _Shutdown; }
            set {
                _Shutdown = value;
                cbASShutdown.Checked = value;
            }
        }

        //Var Overwrite (Cell 22)
        private bool _Overwrite;
        public bool Overwrite {
            get { return _Overwrite; }
            set {
                _Overwrite = value;
                cbASOverwrite.Checked = value;
            }
        }

        //Var ActSoundSource (Cell 23)

        //Var ActSoundSource (Cell 24)
        private string _ActSoundSource;
        public string ActSoundSource {
            get { return _ActSoundSource; }
            set {
                _ActSoundSource = value;
                //if source fits and the path aint empty...
                if (value.ToString() == "Alarm") { // && AlarmSound != "") {
                    rbAlarmSound.Checked = true;
                    //ActSoundSource = "Alarm";
                }
                else if (value.ToString() == "File") { // && SoundSource != "") {
                        rbASSoundFilePath.Checked = true;
                    //ActSoundSource = "File";
                }
                else if (value.ToString() == "Youtube") { // && YoutubePath != "") {
                    rbASYoutubepath.Checked = true;
                    //ActSoundSource = "Youtube";
                }
            }
        }


        public AlarmSettings(Alarm alarmWindow) {
            if (isOpen) {
                return;
            }
            InitializeComponent();


            cbASFlash.Enabled = Flash;
            cbASShutdown.Enabled = Shutdown;
            isOpen = true;
            mainWindow = alarmWindow;

            //Tooltips
            System.Windows.Forms.ToolTip ToolTipdtASDate = new System.Windows.Forms.ToolTip();
            System.Windows.Forms.ToolTip ToolTipnumASHour = new System.Windows.Forms.ToolTip();
            System.Windows.Forms.ToolTip ToolTipnumASMin = new System.Windows.Forms.ToolTip();
            System.Windows.Forms.ToolTip ToolTiptbASYoutubePath = new System.Windows.Forms.ToolTip();
            System.Windows.Forms.ToolTip ToolTiptbASFilePath = new System.Windows.Forms.ToolTip();
            System.Windows.Forms.ToolTip ToolTipcbASAlarmSound = new System.Windows.Forms.ToolTip();
            System.Windows.Forms.ToolTip ToolTiptbASNote = new System.Windows.Forms.ToolTip();
            System.Windows.Forms.ToolTip ToolTipcbAlarmActive = new System.Windows.Forms.ToolTip();
            System.Windows.Forms.ToolTip ToolTiplblASHelp = new System.Windows.Forms.ToolTip();
            System.Windows.Forms.ToolTip ToolTipcbASRepeat = new System.Windows.Forms.ToolTip();
            ToolTipdtASDate.SetToolTip(dtASDate, "Please insert your Note that should be attatched to the Alarm.");
            ToolTipnumASHour.SetToolTip(numASHour, "Here you can Set the Alarm hour.");
            ToolTipnumASMin.SetToolTip(numASMin, "Here you can Set the Alarm minute.");
            ToolTiptbASYoutubePath.SetToolTip(tbASYoutubePath, "Please insert your Note that should be attatched to the Alarm.");
            ToolTiptbASFilePath.SetToolTip(tbASFilePath, "Please insert your Note that should be attatched to the Alarm.");
            ToolTipcbASAlarmSound.SetToolTip(combASAlarmSound, "Please insert your Note that should be attatched to the Alarm.");
            ToolTiptbASNote.SetToolTip(tbASNote, "Please insert your Note that should be attatched to the Alarm.");
            ToolTipcbAlarmActive.SetToolTip(cbASActive, "Alarm will be triggered in the following cases: \n\n -Alarm Checkbox is checked\n\n    -a day checkbox is checked (makes Date field inactive)\n    -a day checkbox is checked AND the repeat checkbox as well (makes Date field inactive) \n    -no day checkbox is checked (makes Date field active) - and the Date+Time is in the future");
            ToolTipcbAlarmActive.AutoPopDelay = 20000;
            ToolTiplblASHelp.SetToolTip(lblASHelp, "Alarm will be triggered in the following cases: \n\n -Alarm Checkbox is checked\n\n    -a day checkbox is checked (makes Date field inactive)\n    -a day checkbox is checked AND the repeat checkbox as well (makes Date field inactive) \n    -no day checkbox is checked (makes Date field active) - and the Date+Time is in the future");
            ToolTiplblASHelp.AutoPopDelay = 20000;
            ToolTiplblASHelp.InitialDelay = 100;
            ToolTipcbASRepeat.SetToolTip(cbASRepeat, "Attention! Repeat function is only working if a Day is selected\nDate won't be affected by the option.");
        }

        private void ActiveSoundSource(object sender, EventArgs e) {
            if (rbAlarmSound.Checked) {
                ActSoundSource = "Alarm";
            }
            else if (rbASSoundFilePath.Checked) {
                ActSoundSource = "File";
            }
            else if (rbASYoutubepath.Checked) {
                ActSoundSource = "Youtube";
            }
            //return ActiveSoundSource;
        }

        private void btnASOk_Click(object sender, EventArgs e) {
            Date = string.Format ("{0:dd.MM.yyyy}", dtASDate.Value.ToShortDateString());
            Hour = string.Format("{0:00}", numASHour.Value);
            Minute = string.Format("{0:00}", numASMin.Value);
            AlarmActive = cbASActive.Checked;
            Note = tbASNote.Text;
            ProgPathActiv = cbStartProg.Checked;
            ProgPath = tbASProgPath.Text;
            SoundActive = rbASSoundFilePath.Checked;
            SoundSource = tbASFilePath.Text;
            YoutubePath = tbASYoutubePath.Text;
            AlarmSound = combASAlarmSound.SelectedItem.ToString();
            Mon = cbASMon.Checked;
            Tue = cbASTue.Checked;
            Wed = cbASWed.Checked;
            Thu = cbASThu.Checked;
            Fri = cbASFri.Checked;
            Sat = cbASSat.Checked;
            Sun = cbASSun.Checked;
            Flash = cbASFlash.Checked;
            Shutdown = cbASShutdown.Checked;
            Repeat = cbASRepeat.Checked;
            Overwrite = cbASOverwrite.Checked;
            

            mainWindow.UpdateRowDetails(this);
            isOpen = false;
            Dispose();
        }

        private void AlarmSettings_FormClosing(object sender, FormClosingEventArgs e) {
            isOpen = false;
        }

        private void btnASRingtone_Click(object sender, EventArgs e) {
            if (combASAlarmSound.SelectedItem != null) {
                if (combASAlarmSound.SelectedItem.ToString() == "Phonering") {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.calleering); //@ means interpret the following string as literal. Meaning, the \ in the string will actually be a "\" in the output, rather than having to put "\\" to mean the literal character
                    player.Play();
                }
                else if (combASAlarmSound.SelectedItem.ToString() == "Applause") {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.APPLAUSE);
                    player.Play();
                }
                else if (combASAlarmSound.SelectedItem.ToString() == "Callring") {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.ELPHRG01);
                    player.Play();
                }
            }
        }

        //Youtube
        private void btnASYoutube_Click(object sender, EventArgs e) {
            if (tbASYoutubePath.Text != null && tbASYoutubePath.Text != "") {
                Process.Start(@tbASYoutubePath.Text);
            }
            else {
                MessageBox.Show("You have to enter a URL first.");
            }
        }

        //ProgramPath
        private void btnASstartProgram_Click(object sender, EventArgs e) {
            if (tbASProgPath.Text != null && tbASProgPath.Text != "") {
                Process.Start(@tbASProgPath.Text);
            }
            else {
                OpenFileDialog ChooseFile = new OpenFileDialog();
                DialogResult result = ChooseFile.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                    tbASProgPath.Text = ChooseFile.InitialDirectory + ChooseFile.FileName;
                }
                else {
                    //Console.WriteLine(result); // <-- For debugging use.
                }
            }
        }

        //Soundfile
        private void btbASFileDialog_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                if (tbASFilePath.Text != null && tbASFilePath.Text != "") {
                    axWindowsMediaPlayerSoundFile.URL = tbASFilePath.Text;
                    axWindowsMediaPlayerSoundFile.Visible = false;
                    axWindowsMediaPlayerSoundFile.settings.setMode("loop", false);
                    //System.Threading.Thread.Sleep(2000);

                    //axWindowsMediaPlayerSoundFile.Ctlcontrols.play();
                    //axWindowsMediaPlayerSoundFile.Ctlcontrols.stop();
                    //axWindowsMediaPlayerSoundFile.settings.volume = 100; // 0 = kein Ton, 100 = volle Lautstärke
                }
                else {
                    OpenFileDialog ChooseFile = new OpenFileDialog();
                    DialogResult result = ChooseFile.ShowDialog();
                    if (result == DialogResult.OK) // Test result.
                    {
                        tbASFilePath.Text = ChooseFile.InitialDirectory + ChooseFile.FileName;
                    }
                    else {
                        //Console.WriteLine(result); // <-- For debugging use.
                    }
                }
            }
            else { //mouse rightclick
                //contextMenuStripFileDialog.Text = "Select File";
                //contextMenuStripFileDialog.Show(Cursor.Position);

                OpenFileDialog ChooseFile = new OpenFileDialog();
                DialogResult result = ChooseFile.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                    tbASFilePath.Text = ChooseFile.InitialDirectory + ChooseFile.FileName;
                }
            }
        }

        private void cbASOverwrite_CheckedChanged(object sender, EventArgs e) {
            if (cbASOverwrite.Checked) {
                cbASFlash.Enabled = true;
                cbASShutdown.Enabled = true;
            }
        }
    }
}
