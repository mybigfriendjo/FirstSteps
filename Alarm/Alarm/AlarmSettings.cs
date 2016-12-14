using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
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
        //AlarmSettingsGui.Date;
        //AlarmSettingsGui.Hour", typeof(int));
        //AlarmSettingsGui.Minute", typeof(int));
        //AlarmSettingsGui.AlarmActive", typeof(bool));
        //AlarmSettingsGui.Note = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        //AlarmSettingsGui.ProgPathActiv", typeof(bool));
        //AlarmSettingsGui.ProgPath; //Path to start Programm
        //AlarmSettingsGui.SoundActive", typeof(bool));
        //AlarmSettingsGui.SoundSource; //Radiobtn "ringtone", "soundfile", "youtube"
        //AlarmSettingsGui.ID;

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

        public AlarmSettings(Alarm alarmWindow) {
            if (isOpen) {
                return;
            }
            InitializeComponent();

            isOpen = true;
            mainWindow = alarmWindow;

            ////Create Amount of X Variables
            //int i = 0;
            //while (CellCnt >= i) {
            //    i++;
            //    string currentName = "Var" + i.ToString();
            //}

            //Tooltips
            System.Windows.Forms.ToolTip ToolTipdtASDate = new System.Windows.Forms.ToolTip();
            System.Windows.Forms.ToolTip ToolTipnumASHour = new System.Windows.Forms.ToolTip();
            System.Windows.Forms.ToolTip ToolTipnumASMin = new System.Windows.Forms.ToolTip();
            System.Windows.Forms.ToolTip ToolTiptbASYoutubePath = new System.Windows.Forms.ToolTip();
            System.Windows.Forms.ToolTip ToolTiptbASFilePath = new System.Windows.Forms.ToolTip();
            System.Windows.Forms.ToolTip ToolTipcbASAlarmSound = new System.Windows.Forms.ToolTip();
            System.Windows.Forms.ToolTip ToolTiptbASNote = new System.Windows.Forms.ToolTip();
            ToolTipdtASDate.SetToolTip(dtASDate, "Please insert your Note that should be attatched to the Alarm.");
            ToolTipnumASHour.SetToolTip(numASHour, "Here you can Set the Alarm hour.");
            ToolTipnumASMin.SetToolTip(numASMin, "Here you can Set the Alarm minute.");
            ToolTiptbASYoutubePath.SetToolTip(tbASYoutubePath, "Please insert your Note that should be attatched to the Alarm.");
            ToolTiptbASFilePath.SetToolTip(tbASFilePath, "Please insert your Note that should be attatched to the Alarm.");
            ToolTipcbASAlarmSound.SetToolTip(combASAlarmSound, "Please insert your Note that should be attatched to the Alarm.");
            ToolTiptbASNote.SetToolTip(tbASNote, "Please insert your Note that should be attatched to the Alarm.");
        }

        //Var VarList
        //private List<string> _VarList;
        //private ListBox _VarList;
        //public ListBox VarList {
        //    get { return _VarList; }
        //    set {
        //        _VarList = value;
        //    }
        //}

        private void btnASOk_Click(object sender, EventArgs e) {
            Date = string.Format ("{0:dd.MM.yyyy}", dtASDate.Value.ToShortDateString());
            Hour = string.Format("{0:00}", numASHour.Value);
            //Minute = Convert.ToInt32(numASMin.Value);
            Minute = string.Format("{0:00}", numASMin.Value);
            AlarmActive = cbASActive.Checked;
            Note = tbASNote.Text;
            ProgPathActiv = cbStartProg.Checked;
            ProgPath = tbASProgPath.Text;
            SoundActive = rbASSoundFilePath.Checked;
            SoundSource = tbASFilePath.Text;
            YoutubePath = tbASYoutubePath.Text;
            AlarmSound = combASAlarmSound.SelectedItem.ToString();

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
                    //System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"c:\Temp\alert1.wav"); //@ means interpret the following string as literal. Meaning, the \ in the string will actually be a "\" in the output, rather than having to put "\\" to mean the literal character
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\rsci060\Source\Repos\FirstSteps\Alarm\Alarm\Resources\calleering.wav");
                    player.Play();
                }
                else if (combASAlarmSound.SelectedItem.ToString() == "Applause") {
                    //System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"c:\Temp\alert2.wav");
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\rsci060\Source\Repos\FirstSteps\Alarm\Alarm\Resources\APPLAUSE.WAV");
                    player.Play();
                }
                else if (combASAlarmSound.SelectedItem.ToString() == "Callring") {
                    //System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"c:\Temp\alert3.wav");
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\rsci060\Source\Repos\FirstSteps\Alarm\Alarm\Resources\ELPHRG01.WAV");
                    player.Play();
                }
            }
        }

        private void btnASYoutube_Click(object sender, EventArgs e) {
            if (tbASYoutubePath.Text != null && tbASYoutubePath.Text != "") {
                Process.Start(@tbASYoutubePath.Text);
            }
            else {
                MessageBox.Show("You have to enter a URL first.");
            }
        }

        private void btnASstartProgram_Click(object sender, EventArgs e) {
            if (tbASProgPath.Text != null && tbASProgPath.Text != "") {
                Process.Start(@tbASProgPath.Text);
            }
            else {
                OpenFileDialog ChooseFile = new OpenFileDialog();
                DialogResult result = ChooseFile.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                    //tbASProgPath.Text = ChooseFile
                }
                else {
                    //Console.WriteLine(result); // <-- For debugging use.
                }
                
            }
        }
    }
}
