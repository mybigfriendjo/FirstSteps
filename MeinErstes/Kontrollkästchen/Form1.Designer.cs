namespace Kontrollkästchen {
    partial class Form1 {
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
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnSwitchSwitch = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lblColorChk = new System.Windows.Forms.Label();
            this.lblColorSwitch = new System.Windows.Forms.Label();
            this.btnSetRed = new System.Windows.Forms.Button();
            this.btnChkColor = new System.Windows.Forms.Button();
            this.rbRed = new System.Windows.Forms.RadioButton();
            this.rbGreen = new System.Windows.Forms.RadioButton();
            this.rbBlue = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(208, 12);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(111, 23);
            this.btnCheck.TabIndex = 0;
            this.btnCheck.Text = "Schalter prüfen";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnSwitchSwitch
            // 
            this.btnSwitchSwitch.Location = new System.Drawing.Point(208, 64);
            this.btnSwitchSwitch.Name = "btnSwitchSwitch";
            this.btnSwitchSwitch.Size = new System.Drawing.Size(111, 23);
            this.btnSwitchSwitch.TabIndex = 1;
            this.btnSwitchSwitch.Text = "Schalter umschalten";
            this.btnSwitchSwitch.UseVisualStyleBackColor = true;
            this.btnSwitchSwitch.Click += new System.EventHandler(this.btnSwitchSwitch_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(208, 41);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(65, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Schalter";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(151, 42);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(25, 13);
            this.lbl1.TabIndex = 4;
            this.lbl1.Text = "Aus";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(151, 17);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(25, 13);
            this.lbl2.TabIndex = 5;
            this.lbl2.Text = "Aus";
            // 
            // lblColorChk
            // 
            this.lblColorChk.AutoSize = true;
            this.lblColorChk.Location = new System.Drawing.Point(9, 140);
            this.lblColorChk.Name = "lblColorChk";
            this.lblColorChk.Size = new System.Drawing.Size(25, 13);
            this.lblColorChk.TabIndex = 10;
            this.lblColorChk.Text = "Aus";
            // 
            // lblColorSwitch
            // 
            this.lblColorSwitch.AutoSize = true;
            this.lblColorSwitch.Location = new System.Drawing.Point(9, 235);
            this.lblColorSwitch.Name = "lblColorSwitch";
            this.lblColorSwitch.Size = new System.Drawing.Size(25, 13);
            this.lblColorSwitch.TabIndex = 9;
            this.lblColorSwitch.Text = "Aus";
            // 
            // btnSetRed
            // 
            this.btnSetRed.Location = new System.Drawing.Point(66, 230);
            this.btnSetRed.Name = "btnSetRed";
            this.btnSetRed.Size = new System.Drawing.Size(111, 23);
            this.btnSetRed.TabIndex = 7;
            this.btnSetRed.Text = "Rot schalten";
            this.btnSetRed.UseVisualStyleBackColor = true;
            this.btnSetRed.Click += new System.EventHandler(this.btnSetRed_Click);
            // 
            // btnChkColor
            // 
            this.btnChkColor.Location = new System.Drawing.Point(66, 135);
            this.btnChkColor.Name = "btnChkColor";
            this.btnChkColor.Size = new System.Drawing.Size(111, 23);
            this.btnChkColor.TabIndex = 6;
            this.btnChkColor.Text = "Farbe prüfen";
            this.btnChkColor.UseVisualStyleBackColor = true;
            this.btnChkColor.Click += new System.EventHandler(this.btnChkColor_Click);
            // 
            // rbRed
            // 
            this.rbRed.AutoSize = true;
            this.rbRed.Location = new System.Drawing.Point(66, 164);
            this.rbRed.Name = "rbRed";
            this.rbRed.Size = new System.Drawing.Size(42, 17);
            this.rbRed.TabIndex = 11;
            this.rbRed.TabStop = true;
            this.rbRed.Text = "Rot";
            this.rbRed.UseVisualStyleBackColor = true;
            this.rbRed.CheckedChanged += new System.EventHandler(this.rbRed_CheckedChanged);
            // 
            // rbGreen
            // 
            this.rbGreen.AutoSize = true;
            this.rbGreen.Location = new System.Drawing.Point(66, 187);
            this.rbGreen.Name = "rbGreen";
            this.rbGreen.Size = new System.Drawing.Size(48, 17);
            this.rbGreen.TabIndex = 12;
            this.rbGreen.TabStop = true;
            this.rbGreen.Text = "Grün";
            this.rbGreen.UseVisualStyleBackColor = true;
            this.rbGreen.CheckedChanged += new System.EventHandler(this.rbGreen_CheckedChanged);
            // 
            // rbBlue
            // 
            this.rbBlue.AutoSize = true;
            this.rbBlue.Location = new System.Drawing.Point(66, 207);
            this.rbBlue.Name = "rbBlue";
            this.rbBlue.Size = new System.Drawing.Size(46, 17);
            this.rbBlue.TabIndex = 13;
            this.rbBlue.TabStop = true;
            this.rbBlue.Text = "Blau";
            this.rbBlue.UseVisualStyleBackColor = true;
            this.rbBlue.CheckedChanged += new System.EventHandler(this.rbBlue_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(85, 17);
            this.radioButton1.TabIndex = 14;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(85, 17);
            this.radioButton2.TabIndex = 15;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Location = new System.Drawing.Point(12, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(133, 84);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 262);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rbBlue);
            this.Controls.Add(this.rbGreen);
            this.Controls.Add(this.rbRed);
            this.Controls.Add(this.lblColorChk);
            this.Controls.Add(this.lblColorSwitch);
            this.Controls.Add(this.btnSetRed);
            this.Controls.Add(this.btnChkColor);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnSwitchSwitch);
            this.Controls.Add(this.btnCheck);
            this.Name = "Form1";
            this.Text = "Kontrollkästchen_chk_radiobtn";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnSwitchSwitch;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lblColorChk;
        private System.Windows.Forms.Label lblColorSwitch;
        private System.Windows.Forms.Button btnSetRed;
        private System.Windows.Forms.Button btnChkColor;
        private System.Windows.Forms.RadioButton rbRed;
        private System.Windows.Forms.RadioButton rbGreen;
        private System.Windows.Forms.RadioButton rbBlue;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

