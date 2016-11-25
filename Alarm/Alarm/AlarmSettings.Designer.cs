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
            this.cbShutdown = new System.Windows.Forms.CheckBox();
            this.cbFlashscreen = new System.Windows.Forms.CheckBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbNoDoubleEntry = new System.Windows.Forms.CheckBox();
            this.numAlarmMin = new System.Windows.Forms.NumericUpDown();
            this.numAlarmHour = new System.Windows.Forms.NumericUpDown();
            this.cbAlarm = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numAlarmMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAlarmHour)).BeginInit();
            this.SuspendLayout();
            // 
            // cbShutdown
            // 
            this.cbShutdown.AutoSize = true;
            this.cbShutdown.Location = new System.Drawing.Point(119, 233);
            this.cbShutdown.Name = "cbShutdown";
            this.cbShutdown.Size = new System.Drawing.Size(91, 17);
            this.cbShutdown.TabIndex = 27;
            this.cbShutdown.Text = "PC-Shutdown";
            this.cbShutdown.UseVisualStyleBackColor = true;
            // 
            // cbFlashscreen
            // 
            this.cbFlashscreen.AutoSize = true;
            this.cbFlashscreen.Checked = true;
            this.cbFlashscreen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFlashscreen.Location = new System.Drawing.Point(12, 233);
            this.cbFlashscreen.Name = "cbFlashscreen";
            this.cbFlashscreen.Size = new System.Drawing.Size(88, 17);
            this.cbFlashscreen.TabIndex = 26;
            this.cbFlashscreen.Text = "Flash Screen";
            this.cbFlashscreen.UseVisualStyleBackColor = true;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(9, 210);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(60, 13);
            this.lblNote.TabIndex = 29;
            this.lblNote.Text = "Notification";
            // 
            // tbNote
            // 
            this.tbNote.Enabled = false;
            this.tbNote.Location = new System.Drawing.Point(70, 207);
            this.tbNote.Name = "tbNote";
            this.tbNote.Size = new System.Drawing.Size(370, 20);
            this.tbNote.TabIndex = 28;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(481, 235);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(48, 23);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // cbNoDoubleEntry
            // 
            this.cbNoDoubleEntry.AutoSize = true;
            this.cbNoDoubleEntry.Checked = true;
            this.cbNoDoubleEntry.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNoDoubleEntry.Location = new System.Drawing.Point(328, 15);
            this.cbNoDoubleEntry.Name = "cbNoDoubleEntry";
            this.cbNoDoubleEntry.Size = new System.Drawing.Size(109, 17);
            this.cbNoDoubleEntry.TabIndex = 34;
            this.cbNoDoubleEntry.Text = "No double entries";
            this.cbNoDoubleEntry.UseVisualStyleBackColor = true;
            // 
            // numAlarmMin
            // 
            this.numAlarmMin.Enabled = false;
            this.numAlarmMin.Location = new System.Drawing.Point(115, 12);
            this.numAlarmMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numAlarmMin.Name = "numAlarmMin";
            this.numAlarmMin.Size = new System.Drawing.Size(37, 20);
            this.numAlarmMin.TabIndex = 33;
            // 
            // numAlarmHour
            // 
            this.numAlarmHour.Enabled = false;
            this.numAlarmHour.Location = new System.Drawing.Point(75, 12);
            this.numAlarmHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numAlarmHour.Name = "numAlarmHour";
            this.numAlarmHour.Size = new System.Drawing.Size(35, 20);
            this.numAlarmHour.TabIndex = 32;
            // 
            // cbAlarm
            // 
            this.cbAlarm.AutoSize = true;
            this.cbAlarm.Location = new System.Drawing.Point(185, 124);
            this.cbAlarm.Name = "cbAlarm";
            this.cbAlarm.Size = new System.Drawing.Size(52, 17);
            this.cbAlarm.TabIndex = 35;
            this.cbAlarm.Text = "Alarm";
            this.cbAlarm.UseVisualStyleBackColor = true;
            // 
            // AlarmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 270);
            this.Controls.Add(this.cbAlarm);
            this.Controls.Add(this.cbNoDoubleEntry);
            this.Controls.Add(this.numAlarmMin);
            this.Controls.Add(this.numAlarmHour);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.tbNote);
            this.Controls.Add(this.cbShutdown);
            this.Controls.Add(this.cbFlashscreen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AlarmSettings";
            this.Text = "Alarm Settings";
            ((System.ComponentModel.ISupportInitialize)(this.numAlarmMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAlarmHour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbShutdown;
        private System.Windows.Forms.CheckBox cbFlashscreen;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox tbNote;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox cbNoDoubleEntry;
        private System.Windows.Forms.NumericUpDown numAlarmMin;
        private System.Windows.Forms.NumericUpDown numAlarmHour;
        private System.Windows.Forms.CheckBox cbAlarm;
    }
}