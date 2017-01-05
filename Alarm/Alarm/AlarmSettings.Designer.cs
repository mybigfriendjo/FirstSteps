namespace Alarm {
    partial class AlarmSettings {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlarmSettings));
            this.tbASNote = new System.Windows.Forms.TextBox();
            this.tbASYoutubePath = new System.Windows.Forms.TextBox();
            this.tbASFilePath = new System.Windows.Forms.TextBox();
            this.btnASOk = new System.Windows.Forms.Button();
            this.lblASNote = new System.Windows.Forms.Label();
            this.cbASFlash = new System.Windows.Forms.CheckBox();
            this.cbASShutdown = new System.Windows.Forms.CheckBox();
            this.cbASActive = new System.Windows.Forms.CheckBox();
            this.dtASDate = new System.Windows.Forms.DateTimePicker();
            this.numASHour = new System.Windows.Forms.NumericUpDown();
            this.numASMin = new System.Windows.Forms.NumericUpDown();
            this.rbASYoutubepath = new System.Windows.Forms.RadioButton();
            this.rbASSoundFilePath = new System.Windows.Forms.RadioButton();
            this.rbAlarmSound = new System.Windows.Forms.RadioButton();
            this.combASAlarmSound = new System.Windows.Forms.ComboBox();
            this.tbASProgPath = new System.Windows.Forms.TextBox();
            this.cbStartProg = new System.Windows.Forms.CheckBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.btbASYoutube = new System.Windows.Forms.Button();
            this.btbASFileDialog = new System.Windows.Forms.Button();
            this.btnASstartProgram = new System.Windows.Forms.Button();
            this.btnASRingtone = new System.Windows.Forms.Button();
            this.contextMenuStripFileDialog = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axWindowsMediaPlayerSoundFile = new AxWMPLib.AxWindowsMediaPlayer();
            this.lblDays = new System.Windows.Forms.Label();
            this.cbASMon = new System.Windows.Forms.CheckBox();
            this.cbASTue = new System.Windows.Forms.CheckBox();
            this.cbASWed = new System.Windows.Forms.CheckBox();
            this.cbASThu = new System.Windows.Forms.CheckBox();
            this.cbASFri = new System.Windows.Forms.CheckBox();
            this.cbASSat = new System.Windows.Forms.CheckBox();
            this.cbASSun = new System.Windows.Forms.CheckBox();
            this.cbASRepeat = new System.Windows.Forms.CheckBox();
            this.lblASHelp = new System.Windows.Forms.Label();
            this.cbASOverwrite = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numASHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numASMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.contextMenuStripFileDialog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayerSoundFile)).BeginInit();
            this.SuspendLayout();
            // 
            // tbASNote
            // 
            this.tbASNote.Location = new System.Drawing.Point(50, 200);
            this.tbASNote.Multiline = true;
            this.tbASNote.Name = "tbASNote";
            this.tbASNote.Size = new System.Drawing.Size(350, 89);
            this.tbASNote.TabIndex = 0;
            // 
            // tbASYoutubePath
            // 
            this.tbASYoutubePath.Location = new System.Drawing.Point(113, 74);
            this.tbASYoutubePath.Name = "tbASYoutubePath";
            this.tbASYoutubePath.Size = new System.Drawing.Size(387, 20);
            this.tbASYoutubePath.TabIndex = 1;
            // 
            // tbASFilePath
            // 
            this.tbASFilePath.Location = new System.Drawing.Point(113, 100);
            this.tbASFilePath.Name = "tbASFilePath";
            this.tbASFilePath.Size = new System.Drawing.Size(387, 20);
            this.tbASFilePath.TabIndex = 2;
            // 
            // btnASOk
            // 
            this.btnASOk.Location = new System.Drawing.Point(448, 268);
            this.btnASOk.Name = "btnASOk";
            this.btnASOk.Size = new System.Drawing.Size(75, 23);
            this.btnASOk.TabIndex = 3;
            this.btnASOk.Text = "OK";
            this.btnASOk.UseVisualStyleBackColor = true;
            this.btnASOk.Click += new System.EventHandler(this.btnASOk_Click);
            // 
            // lblASNote
            // 
            this.lblASNote.AutoSize = true;
            this.lblASNote.Location = new System.Drawing.Point(9, 200);
            this.lblASNote.Name = "lblASNote";
            this.lblASNote.Size = new System.Drawing.Size(33, 13);
            this.lblASNote.TabIndex = 4;
            this.lblASNote.Text = "Note:";
            // 
            // cbASFlash
            // 
            this.cbASFlash.AutoSize = true;
            this.cbASFlash.Location = new System.Drawing.Point(423, 222);
            this.cbASFlash.Name = "cbASFlash";
            this.cbASFlash.Size = new System.Drawing.Size(88, 17);
            this.cbASFlash.TabIndex = 5;
            this.cbASFlash.Text = "Flash Screen";
            this.cbASFlash.UseVisualStyleBackColor = true;
            // 
            // cbASShutdown
            // 
            this.cbASShutdown.AutoSize = true;
            this.cbASShutdown.Location = new System.Drawing.Point(423, 245);
            this.cbASShutdown.Name = "cbASShutdown";
            this.cbASShutdown.Size = new System.Drawing.Size(77, 17);
            this.cbASShutdown.TabIndex = 6;
            this.cbASShutdown.Text = "Shut down";
            this.cbASShutdown.UseVisualStyleBackColor = true;
            // 
            // cbASActive
            // 
            this.cbASActive.AutoSize = true;
            this.cbASActive.Location = new System.Drawing.Point(12, 12);
            this.cbASActive.Name = "cbASActive";
            this.cbASActive.Size = new System.Drawing.Size(69, 17);
            this.cbASActive.TabIndex = 7;
            this.cbASActive.Text = "Alarm On";
            this.cbASActive.UseVisualStyleBackColor = true;
            // 
            // dtASDate
            // 
            this.dtASDate.Location = new System.Drawing.Point(9, 49);
            this.dtASDate.Name = "dtASDate";
            this.dtASDate.Size = new System.Drawing.Size(189, 20);
            this.dtASDate.TabIndex = 8;
            // 
            // numASHour
            // 
            this.numASHour.Location = new System.Drawing.Point(200, 49);
            this.numASHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numASHour.Name = "numASHour";
            this.numASHour.Size = new System.Drawing.Size(42, 20);
            this.numASHour.TabIndex = 9;
            this.numASHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numASMin
            // 
            this.numASMin.Location = new System.Drawing.Point(245, 49);
            this.numASMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numASMin.Name = "numASMin";
            this.numASMin.Size = new System.Drawing.Size(42, 20);
            this.numASMin.TabIndex = 10;
            // 
            // rbASYoutubepath
            // 
            this.rbASYoutubepath.AutoSize = true;
            this.rbASYoutubepath.Location = new System.Drawing.Point(9, 75);
            this.rbASYoutubepath.Name = "rbASYoutubepath";
            this.rbASYoutubepath.Size = new System.Drawing.Size(90, 17);
            this.rbASYoutubepath.TabIndex = 13;
            this.rbASYoutubepath.TabStop = true;
            this.rbASYoutubepath.Text = "Youtube URL";
            this.rbASYoutubepath.UseVisualStyleBackColor = true;
            this.rbASYoutubepath.CheckedChanged += new System.EventHandler(this.ActiveSoundSource);
            // 
            // rbASSoundFilePath
            // 
            this.rbASSoundFilePath.AutoSize = true;
            this.rbASSoundFilePath.Location = new System.Drawing.Point(9, 101);
            this.rbASSoundFilePath.Name = "rbASSoundFilePath";
            this.rbASSoundFilePath.Size = new System.Drawing.Size(94, 17);
            this.rbASSoundFilePath.TabIndex = 14;
            this.rbASSoundFilePath.TabStop = true;
            this.rbASSoundFilePath.Text = "Soundfile Path";
            this.rbASSoundFilePath.UseVisualStyleBackColor = true;
            this.rbASSoundFilePath.CheckedChanged += new System.EventHandler(this.ActiveSoundSource);
            // 
            // rbAlarmSound
            // 
            this.rbAlarmSound.AutoSize = true;
            this.rbAlarmSound.Location = new System.Drawing.Point(9, 127);
            this.rbAlarmSound.Name = "rbAlarmSound";
            this.rbAlarmSound.Size = new System.Drawing.Size(68, 17);
            this.rbAlarmSound.TabIndex = 15;
            this.rbAlarmSound.TabStop = true;
            this.rbAlarmSound.Text = "Ringtone";
            this.rbAlarmSound.UseVisualStyleBackColor = true;
            this.rbAlarmSound.CheckedChanged += new System.EventHandler(this.ActiveSoundSource);
            // 
            // combASAlarmSound
            // 
            this.combASAlarmSound.FormattingEnabled = true;
            this.combASAlarmSound.Items.AddRange(new object[] {
            "Phonering",
            "Applause",
            "Callring"});
            this.combASAlarmSound.Location = new System.Drawing.Point(113, 126);
            this.combASAlarmSound.Name = "combASAlarmSound";
            this.combASAlarmSound.Size = new System.Drawing.Size(174, 21);
            this.combASAlarmSound.TabIndex = 16;
            // 
            // tbASProgPath
            // 
            this.tbASProgPath.Location = new System.Drawing.Point(113, 166);
            this.tbASProgPath.Name = "tbASProgPath";
            this.tbASProgPath.Size = new System.Drawing.Size(387, 20);
            this.tbASProgPath.TabIndex = 17;
            // 
            // cbStartProg
            // 
            this.cbStartProg.AutoSize = true;
            this.cbStartProg.Location = new System.Drawing.Point(9, 166);
            this.cbStartProg.Name = "cbStartProg";
            this.cbStartProg.Size = new System.Drawing.Size(90, 17);
            this.cbStartProg.TabIndex = 18;
            this.cbStartProg.Text = "Start Program";
            this.cbStartProg.UseVisualStyleBackColor = true;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // btbASYoutube
            // 
            this.btbASYoutube.Image = global::Alarm.Properties.Resources.Play1;
            this.btbASYoutube.Location = new System.Drawing.Point(506, 72);
            this.btbASYoutube.Name = "btbASYoutube";
            this.btbASYoutube.Size = new System.Drawing.Size(25, 23);
            this.btbASYoutube.TabIndex = 19;
            this.btbASYoutube.Text = "...";
            this.btbASYoutube.UseVisualStyleBackColor = true;
            this.btbASYoutube.Click += new System.EventHandler(this.btnASYoutube_Click);
            // 
            // btbASFileDialog
            // 
            this.btbASFileDialog.Image = global::Alarm.Properties.Resources.Play1;
            this.btbASFileDialog.Location = new System.Drawing.Point(506, 98);
            this.btbASFileDialog.Name = "btbASFileDialog";
            this.btbASFileDialog.Size = new System.Drawing.Size(25, 23);
            this.btbASFileDialog.TabIndex = 20;
            this.btbASFileDialog.Text = "...";
            this.btbASFileDialog.UseVisualStyleBackColor = true;
            this.btbASFileDialog.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btbASFileDialog_MouseDown);
            // 
            // btnASstartProgram
            // 
            this.btnASstartProgram.Image = global::Alarm.Properties.Resources.Play1;
            this.btnASstartProgram.Location = new System.Drawing.Point(506, 164);
            this.btnASstartProgram.Name = "btnASstartProgram";
            this.btnASstartProgram.Size = new System.Drawing.Size(25, 23);
            this.btnASstartProgram.TabIndex = 21;
            this.btnASstartProgram.Text = "...";
            this.btnASstartProgram.UseVisualStyleBackColor = true;
            this.btnASstartProgram.Click += new System.EventHandler(this.btnASstartProgram_Click);
            // 
            // btnASRingtone
            // 
            this.btnASRingtone.Image = global::Alarm.Properties.Resources.Play1;
            this.btnASRingtone.Location = new System.Drawing.Point(293, 124);
            this.btnASRingtone.Name = "btnASRingtone";
            this.btnASRingtone.Size = new System.Drawing.Size(25, 23);
            this.btnASRingtone.TabIndex = 22;
            this.btnASRingtone.Text = "...";
            this.btnASRingtone.UseVisualStyleBackColor = true;
            this.btnASRingtone.Click += new System.EventHandler(this.btnASRingtone_Click);
            // 
            // contextMenuStripFileDialog
            // 
            this.contextMenuStripFileDialog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectFileToolStripMenuItem});
            this.contextMenuStripFileDialog.Name = "contextMenuStrip1";
            this.contextMenuStripFileDialog.Size = new System.Drawing.Size(127, 26);
            // 
            // selectFileToolStripMenuItem
            // 
            this.selectFileToolStripMenuItem.Name = "selectFileToolStripMenuItem";
            this.selectFileToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.selectFileToolStripMenuItem.Text = "Select File";
            this.selectFileToolStripMenuItem.ToolTipText = "opens a file select window";
            // 
            // axWindowsMediaPlayerSoundFile
            // 
            this.axWindowsMediaPlayerSoundFile.Enabled = true;
            this.axWindowsMediaPlayerSoundFile.Location = new System.Drawing.Point(8, 266);
            this.axWindowsMediaPlayerSoundFile.Name = "axWindowsMediaPlayerSoundFile";
            this.axWindowsMediaPlayerSoundFile.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayerSoundFile.OcxState")));
            this.axWindowsMediaPlayerSoundFile.Size = new System.Drawing.Size(21, 21);
            this.axWindowsMediaPlayerSoundFile.TabIndex = 23;
            this.axWindowsMediaPlayerSoundFile.Visible = false;
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.Location = new System.Drawing.Point(376, 12);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(162, 13);
            this.lblDays.TabIndex = 25;
            this.lblDays.Text = "Mon Tue Wed Thu  Fri  Sat  Sun";
            // 
            // cbASMon
            // 
            this.cbASMon.AutoSize = true;
            this.cbASMon.Location = new System.Drawing.Point(385, 29);
            this.cbASMon.Name = "cbASMon";
            this.cbASMon.Size = new System.Drawing.Size(15, 14);
            this.cbASMon.TabIndex = 26;
            this.cbASMon.UseVisualStyleBackColor = true;
            // 
            // cbASTue
            // 
            this.cbASTue.AutoSize = true;
            this.cbASTue.Location = new System.Drawing.Point(407, 29);
            this.cbASTue.Name = "cbASTue";
            this.cbASTue.Size = new System.Drawing.Size(15, 14);
            this.cbASTue.TabIndex = 27;
            this.cbASTue.UseVisualStyleBackColor = true;
            // 
            // cbASWed
            // 
            this.cbASWed.AutoSize = true;
            this.cbASWed.Location = new System.Drawing.Point(429, 29);
            this.cbASWed.Name = "cbASWed";
            this.cbASWed.Size = new System.Drawing.Size(15, 14);
            this.cbASWed.TabIndex = 28;
            this.cbASWed.UseVisualStyleBackColor = true;
            // 
            // cbASThu
            // 
            this.cbASThu.AutoSize = true;
            this.cbASThu.Location = new System.Drawing.Point(451, 29);
            this.cbASThu.Name = "cbASThu";
            this.cbASThu.Size = new System.Drawing.Size(15, 14);
            this.cbASThu.TabIndex = 29;
            this.cbASThu.UseVisualStyleBackColor = true;
            // 
            // cbASFri
            // 
            this.cbASFri.AutoSize = true;
            this.cbASFri.Location = new System.Drawing.Point(473, 29);
            this.cbASFri.Name = "cbASFri";
            this.cbASFri.Size = new System.Drawing.Size(15, 14);
            this.cbASFri.TabIndex = 30;
            this.cbASFri.UseVisualStyleBackColor = true;
            // 
            // cbASSat
            // 
            this.cbASSat.AutoSize = true;
            this.cbASSat.Location = new System.Drawing.Point(495, 29);
            this.cbASSat.Name = "cbASSat";
            this.cbASSat.Size = new System.Drawing.Size(15, 14);
            this.cbASSat.TabIndex = 31;
            this.cbASSat.UseVisualStyleBackColor = true;
            // 
            // cbASSun
            // 
            this.cbASSun.AutoSize = true;
            this.cbASSun.Location = new System.Drawing.Point(517, 29);
            this.cbASSun.Name = "cbASSun";
            this.cbASSun.Size = new System.Drawing.Size(15, 14);
            this.cbASSun.TabIndex = 32;
            this.cbASSun.UseVisualStyleBackColor = true;
            // 
            // cbASRepeat
            // 
            this.cbASRepeat.AutoSize = true;
            this.cbASRepeat.Location = new System.Drawing.Point(385, 49);
            this.cbASRepeat.Name = "cbASRepeat";
            this.cbASRepeat.Size = new System.Drawing.Size(122, 17);
            this.cbASRepeat.TabIndex = 33;
            this.cbASRepeat.Text = "Repeat every Week";
            this.cbASRepeat.UseVisualStyleBackColor = true;
            // 
            // lblASHelp
            // 
            this.lblASHelp.AutoSize = true;
            this.lblASHelp.Location = new System.Drawing.Point(110, 13);
            this.lblASHelp.Name = "lblASHelp";
            this.lblASHelp.Size = new System.Drawing.Size(52, 13);
            this.lblASHelp.TabIndex = 34;
            this.lblASHelp.Text = "\"HowTo\"";
            // 
            // cbASOverwrite
            // 
            this.cbASOverwrite.AutoSize = true;
            this.cbASOverwrite.Location = new System.Drawing.Point(407, 199);
            this.cbASOverwrite.Name = "cbASOverwrite";
            this.cbASOverwrite.Size = new System.Drawing.Size(112, 17);
            this.cbASOverwrite.TabIndex = 35;
            this.cbASOverwrite.Text = "Overwrite Settings";
            this.cbASOverwrite.UseVisualStyleBackColor = true;
            this.cbASOverwrite.CheckedChanged += new System.EventHandler(this.cbASOverwrite_CheckedChanged);
            // 
            // AlarmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 296);
            this.Controls.Add(this.cbASOverwrite);
            this.Controls.Add(this.lblASHelp);
            this.Controls.Add(this.cbASRepeat);
            this.Controls.Add(this.cbASSun);
            this.Controls.Add(this.cbASSat);
            this.Controls.Add(this.cbASFri);
            this.Controls.Add(this.cbASThu);
            this.Controls.Add(this.cbASWed);
            this.Controls.Add(this.cbASTue);
            this.Controls.Add(this.cbASMon);
            this.Controls.Add(this.lblDays);
            this.Controls.Add(this.axWindowsMediaPlayerSoundFile);
            this.Controls.Add(this.btnASRingtone);
            this.Controls.Add(this.btnASstartProgram);
            this.Controls.Add(this.btbASFileDialog);
            this.Controls.Add(this.btbASYoutube);
            this.Controls.Add(this.cbStartProg);
            this.Controls.Add(this.tbASProgPath);
            this.Controls.Add(this.combASAlarmSound);
            this.Controls.Add(this.rbAlarmSound);
            this.Controls.Add(this.rbASSoundFilePath);
            this.Controls.Add(this.rbASYoutubepath);
            this.Controls.Add(this.numASMin);
            this.Controls.Add(this.numASHour);
            this.Controls.Add(this.dtASDate);
            this.Controls.Add(this.cbASActive);
            this.Controls.Add(this.cbASShutdown);
            this.Controls.Add(this.cbASFlash);
            this.Controls.Add(this.lblASNote);
            this.Controls.Add(this.btnASOk);
            this.Controls.Add(this.tbASFilePath);
            this.Controls.Add(this.tbASYoutubePath);
            this.Controls.Add(this.tbASNote);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AlarmSettings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlarmSettings_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numASHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numASMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.contextMenuStripFileDialog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayerSoundFile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbASNote;
        private System.Windows.Forms.TextBox tbASYoutubePath;
        private System.Windows.Forms.TextBox tbASFilePath;
        private System.Windows.Forms.Button btnASOk;
        private System.Windows.Forms.Label lblASNote;
        private System.Windows.Forms.CheckBox cbASFlash;
        private System.Windows.Forms.CheckBox cbASShutdown;
        private System.Windows.Forms.CheckBox cbASActive;
        private System.Windows.Forms.DateTimePicker dtASDate;
        private System.Windows.Forms.NumericUpDown numASHour;
        private System.Windows.Forms.NumericUpDown numASMin;
        private System.Windows.Forms.RadioButton rbASYoutubepath;
        private System.Windows.Forms.RadioButton rbASSoundFilePath;
        private System.Windows.Forms.RadioButton rbAlarmSound;
        private System.Windows.Forms.ComboBox combASAlarmSound;
        private System.Windows.Forms.TextBox tbASProgPath;
        private System.Windows.Forms.CheckBox cbStartProg;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button btnASstartProgram;
        private System.Windows.Forms.Button btbASFileDialog;
        private System.Windows.Forms.Button btbASYoutube;
        private System.Windows.Forms.Button btnASRingtone;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFileDialog;
        private System.Windows.Forms.ToolStripMenuItem selectFileToolStripMenuItem;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayerSoundFile;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.CheckBox cbASRepeat;
        private System.Windows.Forms.CheckBox cbASSun;
        private System.Windows.Forms.CheckBox cbASSat;
        private System.Windows.Forms.CheckBox cbASFri;
        private System.Windows.Forms.CheckBox cbASThu;
        private System.Windows.Forms.CheckBox cbASWed;
        private System.Windows.Forms.CheckBox cbASTue;
        private System.Windows.Forms.CheckBox cbASMon;
        private System.Windows.Forms.Label lblASHelp;
        private System.Windows.Forms.CheckBox cbASOverwrite;
    }
}