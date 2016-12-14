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
            ((System.ComponentModel.ISupportInitialize)(this.numASHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numASMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbASNote
            // 
            this.tbASNote.Location = new System.Drawing.Point(48, 180);
            this.tbASNote.Multiline = true;
            this.tbASNote.Name = "tbASNote";
            this.tbASNote.Size = new System.Drawing.Size(350, 85);
            this.tbASNote.TabIndex = 0;
            // 
            // tbASYoutubePath
            // 
            this.tbASYoutubePath.Location = new System.Drawing.Point(116, 48);
            this.tbASYoutubePath.Name = "tbASYoutubePath";
            this.tbASYoutubePath.Size = new System.Drawing.Size(387, 20);
            this.tbASYoutubePath.TabIndex = 1;
            // 
            // tbASFilePath
            // 
            this.tbASFilePath.Location = new System.Drawing.Point(116, 74);
            this.tbASFilePath.Name = "tbASFilePath";
            this.tbASFilePath.Size = new System.Drawing.Size(387, 20);
            this.tbASFilePath.TabIndex = 2;
            // 
            // btnASOk
            // 
            this.btnASOk.Location = new System.Drawing.Point(451, 242);
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
            this.lblASNote.Location = new System.Drawing.Point(9, 180);
            this.lblASNote.Name = "lblASNote";
            this.lblASNote.Size = new System.Drawing.Size(33, 13);
            this.lblASNote.TabIndex = 4;
            this.lblASNote.Text = "Note:";
            // 
            // cbASFlash
            // 
            this.cbASFlash.AutoSize = true;
            this.cbASFlash.Location = new System.Drawing.Point(426, 180);
            this.cbASFlash.Name = "cbASFlash";
            this.cbASFlash.Size = new System.Drawing.Size(88, 17);
            this.cbASFlash.TabIndex = 5;
            this.cbASFlash.Text = "Flash Screen";
            this.cbASFlash.UseVisualStyleBackColor = true;
            // 
            // cbASShutdown
            // 
            this.cbASShutdown.AutoSize = true;
            this.cbASShutdown.Location = new System.Drawing.Point(426, 203);
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
            this.dtASDate.Location = new System.Drawing.Point(256, 12);
            this.dtASDate.Name = "dtASDate";
            this.dtASDate.Size = new System.Drawing.Size(189, 20);
            this.dtASDate.TabIndex = 8;
            // 
            // numASHour
            // 
            this.numASHour.Location = new System.Drawing.Point(447, 12);
            this.numASHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numASHour.Name = "numASHour";
            this.numASHour.Size = new System.Drawing.Size(42, 20);
            this.numASHour.TabIndex = 9;
            // 
            // numASMin
            // 
            this.numASMin.Location = new System.Drawing.Point(492, 12);
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
            this.rbASYoutubepath.Location = new System.Drawing.Point(12, 49);
            this.rbASYoutubepath.Name = "rbASYoutubepath";
            this.rbASYoutubepath.Size = new System.Drawing.Size(90, 17);
            this.rbASYoutubepath.TabIndex = 13;
            this.rbASYoutubepath.TabStop = true;
            this.rbASYoutubepath.Text = "Youtube URL";
            this.rbASYoutubepath.UseVisualStyleBackColor = true;
            // 
            // rbASSoundFilePath
            // 
            this.rbASSoundFilePath.AutoSize = true;
            this.rbASSoundFilePath.Location = new System.Drawing.Point(12, 75);
            this.rbASSoundFilePath.Name = "rbASSoundFilePath";
            this.rbASSoundFilePath.Size = new System.Drawing.Size(94, 17);
            this.rbASSoundFilePath.TabIndex = 14;
            this.rbASSoundFilePath.TabStop = true;
            this.rbASSoundFilePath.Text = "Soundfile Path";
            this.rbASSoundFilePath.UseVisualStyleBackColor = true;
            // 
            // rbAlarmSound
            // 
            this.rbAlarmSound.AutoSize = true;
            this.rbAlarmSound.Location = new System.Drawing.Point(12, 101);
            this.rbAlarmSound.Name = "rbAlarmSound";
            this.rbAlarmSound.Size = new System.Drawing.Size(68, 17);
            this.rbAlarmSound.TabIndex = 15;
            this.rbAlarmSound.TabStop = true;
            this.rbAlarmSound.Text = "Ringtone";
            this.rbAlarmSound.UseVisualStyleBackColor = true;
            // 
            // combASAlarmSound
            // 
            this.combASAlarmSound.FormattingEnabled = true;
            this.combASAlarmSound.Items.AddRange(new object[] {
            "Phonering",
            "Applause",
            "Callring"});
            this.combASAlarmSound.Location = new System.Drawing.Point(116, 100);
            this.combASAlarmSound.Name = "combASAlarmSound";
            this.combASAlarmSound.Size = new System.Drawing.Size(174, 21);
            this.combASAlarmSound.TabIndex = 16;
            // 
            // tbASProgPath
            // 
            this.tbASProgPath.Location = new System.Drawing.Point(116, 140);
            this.tbASProgPath.Name = "tbASProgPath";
            this.tbASProgPath.Size = new System.Drawing.Size(387, 20);
            this.tbASProgPath.TabIndex = 17;
            // 
            // cbStartProg
            // 
            this.cbStartProg.AutoSize = true;
            this.cbStartProg.Location = new System.Drawing.Point(12, 140);
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
            this.btbASYoutube.Location = new System.Drawing.Point(509, 46);
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
            this.btbASFileDialog.Location = new System.Drawing.Point(509, 72);
            this.btbASFileDialog.Name = "btbASFileDialog";
            this.btbASFileDialog.Size = new System.Drawing.Size(25, 23);
            this.btbASFileDialog.TabIndex = 20;
            this.btbASFileDialog.Text = "...";
            this.btbASFileDialog.UseVisualStyleBackColor = true;
            // 
            // btnASstartProgram
            // 
            this.btnASstartProgram.Image = global::Alarm.Properties.Resources.Play1;
            this.btnASstartProgram.Location = new System.Drawing.Point(509, 138);
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
            this.btnASRingtone.Location = new System.Drawing.Point(296, 98);
            this.btnASRingtone.Name = "btnASRingtone";
            this.btnASRingtone.Size = new System.Drawing.Size(25, 23);
            this.btnASRingtone.TabIndex = 22;
            this.btnASRingtone.Text = "...";
            this.btnASRingtone.UseVisualStyleBackColor = true;
            this.btnASRingtone.Click += new System.EventHandler(this.btnASRingtone_Click);
            // 
            // AlarmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 277);
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
            this.Text = "Alarm Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlarmSettings_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numASHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numASMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
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
    }
}