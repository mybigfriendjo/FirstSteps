namespace ÜName {
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
            this.btnPosRel = new System.Windows.Forms.Button();
            this.btnSizeRel = new System.Windows.Forms.Button();
            this.btnPosAbs = new System.Windows.Forms.Button();
            this.btnSizeAbs = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnAnzeige = new System.Windows.Forms.Button();
            this.lblSize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPosRel
            // 
            this.btnPosRel.Location = new System.Drawing.Point(12, 12);
            this.btnPosRel.Name = "btnPosRel";
            this.btnPosRel.Size = new System.Drawing.Size(73, 22);
            this.btnPosRel.TabIndex = 0;
            this.btnPosRel.Text = "Position Rel";
            this.btnPosRel.UseVisualStyleBackColor = true;
            this.btnPosRel.Click += new System.EventHandler(this.btnPosRel_Click);
            // 
            // btnSizeRel
            // 
            this.btnSizeRel.Location = new System.Drawing.Point(12, 40);
            this.btnSizeRel.Name = "btnSizeRel";
            this.btnSizeRel.Size = new System.Drawing.Size(73, 22);
            this.btnSizeRel.TabIndex = 1;
            this.btnSizeRel.Text = "Größe Rel";
            this.btnSizeRel.UseVisualStyleBackColor = true;
            this.btnSizeRel.Click += new System.EventHandler(this.btnSizeRel_Click);
            // 
            // btnPosAbs
            // 
            this.btnPosAbs.Location = new System.Drawing.Point(91, 12);
            this.btnPosAbs.Name = "btnPosAbs";
            this.btnPosAbs.Size = new System.Drawing.Size(73, 22);
            this.btnPosAbs.TabIndex = 3;
            this.btnPosAbs.Text = "Position Abs";
            this.btnPosAbs.UseVisualStyleBackColor = true;
            this.btnPosAbs.Click += new System.EventHandler(this.btnPosAbs_Click);
            // 
            // btnSizeAbs
            // 
            this.btnSizeAbs.Location = new System.Drawing.Point(91, 40);
            this.btnSizeAbs.Name = "btnSizeAbs";
            this.btnSizeAbs.Size = new System.Drawing.Size(73, 22);
            this.btnSizeAbs.TabIndex = 4;
            this.btnSizeAbs.Text = "Größe Abs";
            this.btnSizeAbs.UseVisualStyleBackColor = true;
            this.btnSizeAbs.Click += new System.EventHandler(this.btnSizeAbs_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(91, 192);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(73, 22);
            this.btnTest.TabIndex = 5;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            // 
            // btnAnzeige
            // 
            this.btnAnzeige.Location = new System.Drawing.Point(199, 26);
            this.btnAnzeige.Name = "btnAnzeige";
            this.btnAnzeige.Size = new System.Drawing.Size(73, 22);
            this.btnAnzeige.TabIndex = 6;
            this.btnAnzeige.Text = "Anzeige";
            this.btnAnzeige.UseVisualStyleBackColor = true;
            this.btnAnzeige.Click += new System.EventHandler(this.btnAnzeige_Click);
            // 
            // lblSize
            // 
            this.lblSize.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSize.Location = new System.Drawing.Point(12, 65);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(260, 40);
            this.lblSize.TabIndex = 7;
            this.lblSize.Text = "label1";
            this.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 329);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.btnAnzeige);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnSizeAbs);
            this.Controls.Add(this.btnPosAbs);
            this.Controls.Add(this.btnSizeRel);
            this.Controls.Add(this.btnPosRel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPosRel;
        private System.Windows.Forms.Button btnSizeRel;
        private System.Windows.Forms.Button btnPosAbs;
        private System.Windows.Forms.Button btnSizeAbs;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnAnzeige;
        private System.Windows.Forms.Label lblSize;
    }
}

