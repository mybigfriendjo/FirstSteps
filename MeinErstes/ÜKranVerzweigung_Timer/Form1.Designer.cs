namespace ÜKranVerzweigung_Timer {
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
            this.components = new System.ComponentModel.Container();
            this.btnHookUp = new System.Windows.Forms.Button();
            this.btnHookDown = new System.Windows.Forms.Button();
            this.btnAuslegerL = new System.Windows.Forms.Button();
            this.lblAnzeige = new System.Windows.Forms.Label();
            this.lblAnzeige2 = new System.Windows.Forms.Label();
            this.btnAuslegerR = new System.Windows.Forms.Button();
            this.btnKranL = new System.Windows.Forms.Button();
            this.btnKranDown = new System.Windows.Forms.Button();
            this.btnKranUp = new System.Windows.Forms.Button();
            this.btnKranR = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbHookDown = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbKranDown = new System.Windows.Forms.CheckBox();
            this.cbKranUp = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbAuslegerR = new System.Windows.Forms.CheckBox();
            this.cbAuslegerL = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbKranR = new System.Windows.Forms.CheckBox();
            this.cbKranL = new System.Windows.Forms.CheckBox();
            this.timAnzeige = new System.Windows.Forms.Timer(this.components);
            this.cbHookUP = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnHookUp
            // 
            this.btnHookUp.Location = new System.Drawing.Point(12, 12);
            this.btnHookUp.Name = "btnHookUp";
            this.btnHookUp.Size = new System.Drawing.Size(59, 23);
            this.btnHookUp.TabIndex = 0;
            this.btnHookUp.Text = "HookUP";
            this.btnHookUp.UseVisualStyleBackColor = true;
            this.btnHookUp.Click += new System.EventHandler(this.btnHookUp_Click);
            // 
            // btnHookDown
            // 
            this.btnHookDown.Location = new System.Drawing.Point(77, 12);
            this.btnHookDown.Name = "btnHookDown";
            this.btnHookDown.Size = new System.Drawing.Size(72, 23);
            this.btnHookDown.TabIndex = 1;
            this.btnHookDown.Text = "HookDown";
            this.btnHookDown.UseVisualStyleBackColor = true;
            this.btnHookDown.Click += new System.EventHandler(this.btnHookDown_Click);
            // 
            // btnAuslegerL
            // 
            this.btnAuslegerL.Location = new System.Drawing.Point(155, 12);
            this.btnAuslegerL.Name = "btnAuslegerL";
            this.btnAuslegerL.Size = new System.Drawing.Size(75, 23);
            this.btnAuslegerL.TabIndex = 2;
            this.btnAuslegerL.Text = "AuslegerL";
            this.btnAuslegerL.UseVisualStyleBackColor = true;
            this.btnAuslegerL.Click += new System.EventHandler(this.btnAuslegerL_Click);
            // 
            // lblAnzeige
            // 
            this.lblAnzeige.AutoSize = true;
            this.lblAnzeige.Location = new System.Drawing.Point(9, 303);
            this.lblAnzeige.Name = "lblAnzeige";
            this.lblAnzeige.Size = new System.Drawing.Size(35, 13);
            this.lblAnzeige.TabIndex = 3;
            this.lblAnzeige.Text = "label1";
            // 
            // lblAnzeige2
            // 
            this.lblAnzeige2.AutoSize = true;
            this.lblAnzeige2.Location = new System.Drawing.Point(54, 303);
            this.lblAnzeige2.Name = "lblAnzeige2";
            this.lblAnzeige2.Size = new System.Drawing.Size(35, 13);
            this.lblAnzeige2.TabIndex = 4;
            this.lblAnzeige2.Text = "label2";
            // 
            // btnAuslegerR
            // 
            this.btnAuslegerR.Location = new System.Drawing.Point(236, 12);
            this.btnAuslegerR.Name = "btnAuslegerR";
            this.btnAuslegerR.Size = new System.Drawing.Size(75, 23);
            this.btnAuslegerR.TabIndex = 5;
            this.btnAuslegerR.Text = "AuslegerR";
            this.btnAuslegerR.UseVisualStyleBackColor = true;
            this.btnAuslegerR.Click += new System.EventHandler(this.btnAuslegerR_Click);
            // 
            // btnKranL
            // 
            this.btnKranL.Location = new System.Drawing.Point(12, 41);
            this.btnKranL.Name = "btnKranL";
            this.btnKranL.Size = new System.Drawing.Size(59, 23);
            this.btnKranL.TabIndex = 6;
            this.btnKranL.Text = "KranL";
            this.btnKranL.UseVisualStyleBackColor = true;
            this.btnKranL.Click += new System.EventHandler(this.btnKranL_Click);
            // 
            // btnKranDown
            // 
            this.btnKranDown.Location = new System.Drawing.Point(236, 41);
            this.btnKranDown.Name = "btnKranDown";
            this.btnKranDown.Size = new System.Drawing.Size(75, 23);
            this.btnKranDown.TabIndex = 9;
            this.btnKranDown.Text = "KranDown";
            this.btnKranDown.UseVisualStyleBackColor = true;
            this.btnKranDown.Click += new System.EventHandler(this.btnKranDown_Click);
            // 
            // btnKranUp
            // 
            this.btnKranUp.Location = new System.Drawing.Point(155, 41);
            this.btnKranUp.Name = "btnKranUp";
            this.btnKranUp.Size = new System.Drawing.Size(75, 23);
            this.btnKranUp.TabIndex = 8;
            this.btnKranUp.Text = "KranUp";
            this.btnKranUp.UseVisualStyleBackColor = true;
            this.btnKranUp.Click += new System.EventHandler(this.btnKranUp_Click);
            // 
            // btnKranR
            // 
            this.btnKranR.Location = new System.Drawing.Point(77, 41);
            this.btnKranR.Name = "btnKranR";
            this.btnKranR.Size = new System.Drawing.Size(72, 23);
            this.btnKranR.TabIndex = 7;
            this.btnKranR.Text = "KranR";
            this.btnKranR.UseVisualStyleBackColor = true;
            this.btnKranR.Click += new System.EventHandler(this.btnKranR_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.Location = new System.Drawing.Point(189, 122);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(21, 148);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Location = new System.Drawing.Point(174, 270);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(76, 17);
            this.panel2.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel3.Location = new System.Drawing.Point(92, 112);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(118, 13);
            this.panel3.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Yellow;
            this.panel4.Location = new System.Drawing.Point(109, 122);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 45);
            this.panel4.TabIndex = 0;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(413, 290);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 13;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(332, 290);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 12;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbHookUP);
            this.groupBox1.Controls.Add(this.cbHookDown);
            this.groupBox1.Location = new System.Drawing.Point(359, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(129, 63);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // cbHookDown
            // 
            this.cbHookDown.AutoSize = true;
            this.cbHookDown.Location = new System.Drawing.Point(6, 42);
            this.cbHookDown.Name = "cbHookDown";
            this.cbHookDown.Size = new System.Drawing.Size(79, 17);
            this.cbHookDown.TabIndex = 15;
            this.cbHookDown.TabStop = true;
            this.cbHookDown.Text = "HookDown";
            this.cbHookDown.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbKranDown);
            this.groupBox2.Controls.Add(this.cbKranUp);
            this.groupBox2.Location = new System.Drawing.Point(359, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(129, 63);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // cbKranDown
            // 
            this.cbKranDown.AutoSize = true;
            this.cbKranDown.Location = new System.Drawing.Point(6, 42);
            this.cbKranDown.Name = "cbKranDown";
            this.cbKranDown.Size = new System.Drawing.Size(75, 17);
            this.cbKranDown.TabIndex = 15;
            this.cbKranDown.TabStop = true;
            this.cbKranDown.Text = "KranDown";
            this.cbKranDown.UseVisualStyleBackColor = true;
            // 
            // cbKranUp
            // 
            this.cbKranUp.AutoSize = true;
            this.cbKranUp.Location = new System.Drawing.Point(6, 19);
            this.cbKranUp.Name = "cbKranUp";
            this.cbKranUp.Size = new System.Drawing.Size(61, 17);
            this.cbKranUp.TabIndex = 14;
            this.cbKranUp.TabStop = true;
            this.cbKranUp.Text = "KranUp";
            this.cbKranUp.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbAuslegerR);
            this.groupBox3.Controls.Add(this.cbAuslegerL);
            this.groupBox3.Location = new System.Drawing.Point(359, 150);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(129, 63);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // cbAuslegerR
            // 
            this.cbAuslegerR.AutoSize = true;
            this.cbAuslegerR.Location = new System.Drawing.Point(6, 42);
            this.cbAuslegerR.Name = "cbAuslegerR";
            this.cbAuslegerR.Size = new System.Drawing.Size(74, 17);
            this.cbAuslegerR.TabIndex = 15;
            this.cbAuslegerR.TabStop = true;
            this.cbAuslegerR.Text = "AuslegerR";
            this.cbAuslegerR.UseVisualStyleBackColor = true;
            // 
            // cbAuslegerL
            // 
            this.cbAuslegerL.AutoSize = true;
            this.cbAuslegerL.Location = new System.Drawing.Point(6, 19);
            this.cbAuslegerL.Name = "cbAuslegerL";
            this.cbAuslegerL.Size = new System.Drawing.Size(72, 17);
            this.cbAuslegerL.TabIndex = 14;
            this.cbAuslegerL.TabStop = true;
            this.cbAuslegerL.Text = "AuslegerL";
            this.cbAuslegerL.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbKranR);
            this.groupBox4.Controls.Add(this.cbKranL);
            this.groupBox4.Location = new System.Drawing.Point(359, 221);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(129, 63);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "groupBox4";
            // 
            // cbKranR
            // 
            this.cbKranR.AutoSize = true;
            this.cbKranR.Location = new System.Drawing.Point(6, 42);
            this.cbKranR.Name = "cbKranR";
            this.cbKranR.Size = new System.Drawing.Size(55, 17);
            this.cbKranR.TabIndex = 15;
            this.cbKranR.TabStop = true;
            this.cbKranR.Text = "KranR";
            this.cbKranR.UseVisualStyleBackColor = true;
            // 
            // cbKranL
            // 
            this.cbKranL.AutoSize = true;
            this.cbKranL.Location = new System.Drawing.Point(6, 19);
            this.cbKranL.Name = "cbKranL";
            this.cbKranL.Size = new System.Drawing.Size(53, 17);
            this.cbKranL.TabIndex = 14;
            this.cbKranL.TabStop = true;
            this.cbKranL.Text = "KranL";
            this.cbKranL.UseVisualStyleBackColor = true;
            // 
            // timAnzeige
            // 
            this.timAnzeige.Tick += new System.EventHandler(this.timAnzeige_Tick);
            // 
            // cbHookUP
            // 
            this.cbHookUP.AutoSize = true;
            this.cbHookUP.Location = new System.Drawing.Point(6, 19);
            this.cbHookUP.Name = "cbHookUP";
            this.cbHookUP.Size = new System.Drawing.Size(67, 17);
            this.cbHookUP.TabIndex = 16;
            this.cbHookUP.Text = "HookUP";
            this.cbHookUP.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 325);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnKranDown);
            this.Controls.Add(this.btnKranUp);
            this.Controls.Add(this.btnKranR);
            this.Controls.Add(this.btnKranL);
            this.Controls.Add(this.btnAuslegerR);
            this.Controls.Add(this.lblAnzeige2);
            this.Controls.Add(this.lblAnzeige);
            this.Controls.Add(this.btnAuslegerL);
            this.Controls.Add(this.btnHookDown);
            this.Controls.Add(this.btnHookUp);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHookUp;
        private System.Windows.Forms.Button btnHookDown;
        private System.Windows.Forms.Button btnAuslegerL;
        private System.Windows.Forms.Label lblAnzeige;
        private System.Windows.Forms.Label lblAnzeige2;
        private System.Windows.Forms.Button btnAuslegerR;
        private System.Windows.Forms.Button btnKranL;
        private System.Windows.Forms.Button btnKranDown;
        private System.Windows.Forms.Button btnKranUp;
        private System.Windows.Forms.Button btnKranR;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbHookDown;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbKranDown;
        private System.Windows.Forms.CheckBox cbKranUp;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbAuslegerR;
        private System.Windows.Forms.CheckBox cbAuslegerL;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox cbKranR;
        private System.Windows.Forms.CheckBox cbKranL;
        private System.Windows.Forms.Timer timAnzeige;
        private System.Windows.Forms.CheckBox cbHookUP;
    }
}

