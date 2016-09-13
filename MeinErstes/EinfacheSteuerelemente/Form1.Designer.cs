namespace EinfacheSteuerelemente {
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
            this.btnUpperLeft = new System.Windows.Forms.Button();
            this.btnUpperRight = new System.Windows.Forms.Button();
            this.btnLowerLeft = new System.Windows.Forms.Button();
            this.btnLowerRight = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnUpperLeft
            // 
            this.btnUpperLeft.Location = new System.Drawing.Point(12, 12);
            this.btnUpperLeft.Name = "btnUpperLeft";
            this.btnUpperLeft.Size = new System.Drawing.Size(75, 23);
            this.btnUpperLeft.TabIndex = 0;
            this.btnUpperLeft.Text = "Links Oben";
            this.btnUpperLeft.UseVisualStyleBackColor = true;
            this.btnUpperLeft.Click += new System.EventHandler(this.btnUpperLeft_Click);
            // 
            // btnUpperRight
            // 
            this.btnUpperRight.Location = new System.Drawing.Point(312, 12);
            this.btnUpperRight.Name = "btnUpperRight";
            this.btnUpperRight.Size = new System.Drawing.Size(84, 23);
            this.btnUpperRight.TabIndex = 1;
            this.btnUpperRight.Text = "Rechts Oben";
            this.btnUpperRight.UseVisualStyleBackColor = true;
            this.btnUpperRight.Click += new System.EventHandler(this.btnUpperRight_Click);
            // 
            // btnLowerLeft
            // 
            this.btnLowerLeft.Location = new System.Drawing.Point(12, 227);
            this.btnLowerLeft.Name = "btnLowerLeft";
            this.btnLowerLeft.Size = new System.Drawing.Size(75, 23);
            this.btnLowerLeft.TabIndex = 2;
            this.btnLowerLeft.Text = "Links Unten";
            this.btnLowerLeft.UseVisualStyleBackColor = true;
            this.btnLowerLeft.Click += new System.EventHandler(this.btnLowerLeft_Click);
            // 
            // btnLowerRight
            // 
            this.btnLowerRight.Location = new System.Drawing.Point(312, 227);
            this.btnLowerRight.Name = "btnLowerRight";
            this.btnLowerRight.Size = new System.Drawing.Size(84, 23);
            this.btnLowerRight.TabIndex = 3;
            this.btnLowerRight.Text = "Rechts Unten";
            this.btnLowerRight.UseVisualStyleBackColor = true;
            this.btnLowerRight.Click += new System.EventHandler(this.btnLowerRight_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.Location = new System.Drawing.Point(145, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 100);
            this.panel1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 280);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnLowerRight);
            this.Controls.Add(this.btnLowerLeft);
            this.Controls.Add(this.btnUpperRight);
            this.Controls.Add(this.btnUpperLeft);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUpperLeft;
        private System.Windows.Forms.Button btnUpperRight;
        private System.Windows.Forms.Button btnLowerLeft;
        private System.Windows.Forms.Button btnLowerRight;
        private System.Windows.Forms.Panel panel1;
    }
}

