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
            this.textHour = new System.Windows.Forms.TextBox();
            this.textMinute = new System.Windows.Forms.TextBox();
            this.btnASOk = new System.Windows.Forms.Button();
            this.lblASNote = new System.Windows.Forms.Label();
            this.cbASFlash = new System.Windows.Forms.CheckBox();
            this.cbASShutdown = new System.Windows.Forms.CheckBox();
            this.cbASActive = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbASNote
            // 
            this.tbASNote.Location = new System.Drawing.Point(51, 173);
            this.tbASNote.Multiline = true;
            this.tbASNote.Name = "tbASNote";
            this.tbASNote.Size = new System.Drawing.Size(350, 85);
            this.tbASNote.TabIndex = 0;
            // 
            // textHour
            // 
            this.textHour.Location = new System.Drawing.Point(356, 12);
            this.textHour.Name = "textHour";
            this.textHour.Size = new System.Drawing.Size(100, 20);
            this.textHour.TabIndex = 1;
            // 
            // textMinute
            // 
            this.textMinute.Location = new System.Drawing.Point(429, 38);
            this.textMinute.Name = "textMinute";
            this.textMinute.Size = new System.Drawing.Size(100, 20);
            this.textMinute.TabIndex = 2;
            // 
            // btnASOk
            // 
            this.btnASOk.Location = new System.Drawing.Point(454, 235);
            this.btnASOk.Name = "btnASOk";
            this.btnASOk.Size = new System.Drawing.Size(75, 23);
            this.btnASOk.TabIndex = 3;
            this.btnASOk.Text = "OK";
            this.btnASOk.UseVisualStyleBackColor = true;
            this.btnASOk.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblASNote
            // 
            this.lblASNote.AutoSize = true;
            this.lblASNote.Location = new System.Drawing.Point(12, 173);
            this.lblASNote.Name = "lblASNote";
            this.lblASNote.Size = new System.Drawing.Size(33, 13);
            this.lblASNote.TabIndex = 4;
            this.lblASNote.Text = "Note:";
            // 
            // cbASFlash
            // 
            this.cbASFlash.AutoSize = true;
            this.cbASFlash.Location = new System.Drawing.Point(429, 173);
            this.cbASFlash.Name = "cbASFlash";
            this.cbASFlash.Size = new System.Drawing.Size(88, 17);
            this.cbASFlash.TabIndex = 5;
            this.cbASFlash.Text = "Flash Screen";
            this.cbASFlash.UseVisualStyleBackColor = true;
            // 
            // cbASShutdown
            // 
            this.cbASShutdown.AutoSize = true;
            this.cbASShutdown.Location = new System.Drawing.Point(429, 196);
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
            // AlarmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 280);
            this.Controls.Add(this.cbASActive);
            this.Controls.Add(this.cbASShutdown);
            this.Controls.Add(this.cbASFlash);
            this.Controls.Add(this.lblASNote);
            this.Controls.Add(this.btnASOk);
            this.Controls.Add(this.textMinute);
            this.Controls.Add(this.textHour);
            this.Controls.Add(this.tbASNote);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AlarmSettings";
            this.Text = "Alarm Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlarmSettings_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbASNote;
        private System.Windows.Forms.TextBox textHour;
        private System.Windows.Forms.TextBox textMinute;
        private System.Windows.Forms.Button btnASOk;
        private System.Windows.Forms.Label lblASNote;
        private System.Windows.Forms.CheckBox cbASFlash;
        private System.Windows.Forms.CheckBox cbASShutdown;
        private System.Windows.Forms.CheckBox cbASActive;
    }
}