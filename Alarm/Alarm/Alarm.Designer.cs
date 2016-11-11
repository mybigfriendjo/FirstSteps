namespace Alarm
{
    partial class Alarm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Alarm));
            this.cbCountdown = new System.Windows.Forms.CheckBox();
            this.rb5min = new System.Windows.Forms.RadioButton();
            this.rb10min = new System.Windows.Forms.RadioButton();
            this.rb15min = new System.Windows.Forms.RadioButton();
            this.rb30min = new System.Windows.Forms.RadioButton();
            this.rb1hour = new System.Windows.Forms.RadioButton();
            this.rbCustom = new System.Windows.Forms.RadioButton();
            this.cbAlarm = new System.Windows.Forms.CheckBox();
            this.timerCountdown = new System.Windows.Forms.Timer(this.components);
            this.numCountdownHour = new System.Windows.Forms.NumericUpDown();
            this.numCountdownMin = new System.Windows.Forms.NumericUpDown();
            this.numAlarmMin = new System.Windows.Forms.NumericUpDown();
            this.numAlarmHour = new System.Windows.Forms.NumericUpDown();
            this.lbHistory = new System.Windows.Forms.ListBox();
            this.lblHistory = new System.Windows.Forms.Label();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblNote = new System.Windows.Forms.Label();
            this.cbFlashscreen = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.panelCountdown = new System.Windows.Forms.Panel();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblCountdownTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numCountdownHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCountdownMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAlarmMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAlarmHour)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panelCountdown.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbCountdown
            // 
            this.cbCountdown.AutoSize = true;
            this.cbCountdown.Location = new System.Drawing.Point(488, 31);
            this.cbCountdown.Name = "cbCountdown";
            this.cbCountdown.Size = new System.Drawing.Size(80, 17);
            this.cbCountdown.TabIndex = 0;
            this.cbCountdown.Text = "Countdown";
            this.cbCountdown.UseVisualStyleBackColor = true;
            this.cbCountdown.CheckedChanged += new System.EventHandler(this.cbCountdown_CheckedChanged);
            // 
            // rb5min
            // 
            this.rb5min.AutoSize = true;
            this.rb5min.Location = new System.Drawing.Point(18, 4);
            this.rb5min.Name = "rb5min";
            this.rb5min.Size = new System.Drawing.Size(50, 17);
            this.rb5min.TabIndex = 1;
            this.rb5min.TabStop = true;
            this.rb5min.Text = "5 min";
            this.rb5min.UseVisualStyleBackColor = true;
            // 
            // rb10min
            // 
            this.rb10min.AutoSize = true;
            this.rb10min.Location = new System.Drawing.Point(18, 27);
            this.rb10min.Name = "rb10min";
            this.rb10min.Size = new System.Drawing.Size(56, 17);
            this.rb10min.TabIndex = 2;
            this.rb10min.TabStop = true;
            this.rb10min.Text = "10 min";
            this.rb10min.UseVisualStyleBackColor = true;
            // 
            // rb15min
            // 
            this.rb15min.AutoSize = true;
            this.rb15min.Location = new System.Drawing.Point(18, 50);
            this.rb15min.Name = "rb15min";
            this.rb15min.Size = new System.Drawing.Size(56, 17);
            this.rb15min.TabIndex = 3;
            this.rb15min.TabStop = true;
            this.rb15min.Text = "15 min";
            this.rb15min.UseVisualStyleBackColor = true;
            // 
            // rb30min
            // 
            this.rb30min.AutoSize = true;
            this.rb30min.Location = new System.Drawing.Point(18, 73);
            this.rb30min.Name = "rb30min";
            this.rb30min.Size = new System.Drawing.Size(56, 17);
            this.rb30min.TabIndex = 4;
            this.rb30min.TabStop = true;
            this.rb30min.Text = "30 min";
            this.rb30min.UseVisualStyleBackColor = true;
            // 
            // rb1hour
            // 
            this.rb1hour.AutoSize = true;
            this.rb1hour.Location = new System.Drawing.Point(18, 96);
            this.rb1hour.Name = "rb1hour";
            this.rb1hour.Size = new System.Drawing.Size(55, 17);
            this.rb1hour.TabIndex = 5;
            this.rb1hour.TabStop = true;
            this.rb1hour.Text = "1 hour";
            this.rb1hour.UseVisualStyleBackColor = true;
            // 
            // rbCustom
            // 
            this.rbCustom.AutoSize = true;
            this.rbCustom.Location = new System.Drawing.Point(18, 119);
            this.rbCustom.Name = "rbCustom";
            this.rbCustom.Size = new System.Drawing.Size(14, 13);
            this.rbCustom.TabIndex = 6;
            this.rbCustom.TabStop = true;
            this.rbCustom.UseVisualStyleBackColor = true;
            // 
            // cbAlarm
            // 
            this.cbAlarm.AutoSize = true;
            this.cbAlarm.Location = new System.Drawing.Point(36, 30);
            this.cbAlarm.Name = "cbAlarm";
            this.cbAlarm.Size = new System.Drawing.Size(52, 17);
            this.cbAlarm.TabIndex = 7;
            this.cbAlarm.Text = "Alarm";
            this.cbAlarm.UseVisualStyleBackColor = true;
            this.cbAlarm.CheckedChanged += new System.EventHandler(this.cbAlarm_CheckedChanged);
            // 
            // numCountdownHour
            // 
            this.numCountdownHour.Location = new System.Drawing.Point(36, 119);
            this.numCountdownHour.Name = "numCountdownHour";
            this.numCountdownHour.Size = new System.Drawing.Size(35, 20);
            this.numCountdownHour.TabIndex = 8;
            // 
            // numCountdownMin
            // 
            this.numCountdownMin.Location = new System.Drawing.Point(76, 119);
            this.numCountdownMin.Name = "numCountdownMin";
            this.numCountdownMin.Size = new System.Drawing.Size(37, 20);
            this.numCountdownMin.TabIndex = 9;
            // 
            // numAlarmMin
            // 
            this.numAlarmMin.Location = new System.Drawing.Point(134, 30);
            this.numAlarmMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numAlarmMin.Name = "numAlarmMin";
            this.numAlarmMin.Size = new System.Drawing.Size(37, 20);
            this.numAlarmMin.TabIndex = 11;
            // 
            // numAlarmHour
            // 
            this.numAlarmHour.Location = new System.Drawing.Point(94, 30);
            this.numAlarmHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numAlarmHour.Name = "numAlarmHour";
            this.numAlarmHour.Size = new System.Drawing.Size(35, 20);
            this.numAlarmHour.TabIndex = 10;
            // 
            // lbHistory
            // 
            this.lbHistory.FormattingEnabled = true;
            this.lbHistory.Location = new System.Drawing.Point(36, 75);
            this.lbHistory.Name = "lbHistory";
            this.lbHistory.Size = new System.Drawing.Size(428, 121);
            this.lbHistory.Sorted = true;
            this.lbHistory.TabIndex = 12;
            // 
            // lblHistory
            // 
            this.lblHistory.AutoSize = true;
            this.lblHistory.Location = new System.Drawing.Point(33, 59);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Size = new System.Drawing.Size(68, 13);
            this.lblHistory.TabIndex = 13;
            this.lblHistory.Text = "Alarm History";
            // 
            // tbNote
            // 
            this.tbNote.Location = new System.Drawing.Point(36, 215);
            this.tbNote.Name = "tbNote";
            this.tbNote.Size = new System.Drawing.Size(428, 20);
            this.tbNote.TabIndex = 14;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(589, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.englishToolStripMenuItem.Text = "English";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(33, 199);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(60, 13);
            this.lblNote.TabIndex = 17;
            this.lblNote.Text = "Notification";
            // 
            // cbFlashscreen
            // 
            this.cbFlashscreen.AutoSize = true;
            this.cbFlashscreen.Location = new System.Drawing.Point(36, 287);
            this.cbFlashscreen.Name = "cbFlashscreen";
            this.cbFlashscreen.Size = new System.Drawing.Size(88, 17);
            this.cbFlashscreen.TabIndex = 18;
            this.cbFlashscreen.Text = "Flash Screen";
            this.cbFlashscreen.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(297, 241);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panelCountdown
            // 
            this.panelCountdown.Controls.Add(this.rb5min);
            this.panelCountdown.Controls.Add(this.rb10min);
            this.panelCountdown.Controls.Add(this.rb15min);
            this.panelCountdown.Controls.Add(this.rb30min);
            this.panelCountdown.Controls.Add(this.rb1hour);
            this.panelCountdown.Controls.Add(this.rbCustom);
            this.panelCountdown.Controls.Add(this.numCountdownHour);
            this.panelCountdown.Controls.Add(this.numCountdownMin);
            this.panelCountdown.Location = new System.Drawing.Point(470, 59);
            this.panelCountdown.Name = "panelCountdown";
            this.panelCountdown.Size = new System.Drawing.Size(116, 148);
            this.panelCountdown.TabIndex = 20;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(506, 283);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 21;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // lblCountdownTime
            // 
            this.lblCountdownTime.AutoSize = true;
            this.lblCountdownTime.Location = new System.Drawing.Point(485, 210);
            this.lblCountdownTime.Name = "lblCountdownTime";
            this.lblCountdownTime.Size = new System.Drawing.Size(0, 13);
            this.lblCountdownTime.TabIndex = 22;
            // 
            // Alarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 316);
            this.Controls.Add(this.lblCountdownTime);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.cbCountdown);
            this.Controls.Add(this.panelCountdown);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbFlashscreen);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.tbNote);
            this.Controls.Add(this.lblHistory);
            this.Controls.Add(this.lbHistory);
            this.Controls.Add(this.numAlarmMin);
            this.Controls.Add(this.numAlarmHour);
            this.Controls.Add(this.cbAlarm);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Alarm";
            this.Text = "Alarm";
            ((System.ComponentModel.ISupportInitialize)(this.numCountdownHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCountdownMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAlarmMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAlarmHour)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelCountdown.ResumeLayout(false);
            this.panelCountdown.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbCountdown;
        private System.Windows.Forms.RadioButton rb5min;
        private System.Windows.Forms.RadioButton rb10min;
        private System.Windows.Forms.RadioButton rb15min;
        private System.Windows.Forms.RadioButton rb30min;
        private System.Windows.Forms.RadioButton rb1hour;
        private System.Windows.Forms.RadioButton rbCustom;
        private System.Windows.Forms.CheckBox cbAlarm;
        private System.Windows.Forms.Timer timerCountdown;
        private System.Windows.Forms.NumericUpDown numCountdownHour;
        private System.Windows.Forms.NumericUpDown numCountdownMin;
        private System.Windows.Forms.NumericUpDown numAlarmMin;
        private System.Windows.Forms.NumericUpDown numAlarmHour;
        private System.Windows.Forms.ListBox lbHistory;
        private System.Windows.Forms.Label lblHistory;
        private System.Windows.Forms.TextBox tbNote;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.CheckBox cbFlashscreen;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.Panel panelCountdown;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblCountdownTime;
    }
}

