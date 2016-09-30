namespace MethodeOhneEreignis {
    partial class MethodeOhneEreignis {
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
            this.lblDisplay = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbHotel = new System.Windows.Forms.RadioButton();
            this.rbPension = new System.Windows.Forms.RadioButton();
            this.rbAppartement = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbParis = new System.Windows.Forms.RadioButton();
            this.rbRom = new System.Windows.Forms.RadioButton();
            this.rbBerlin = new System.Windows.Forms.RadioButton();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDisplay
            // 
            this.lblDisplay.AutoSize = true;
            this.lblDisplay.Location = new System.Drawing.Point(12, 148);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(45, 13);
            this.lblDisplay.TabIndex = 5;
            this.lblDisplay.Text = "Anzeige";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbHotel);
            this.groupBox2.Controls.Add(this.rbPension);
            this.groupBox2.Controls.Add(this.rbAppartement);
            this.groupBox2.Location = new System.Drawing.Point(149, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(131, 106);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // rbHotel
            // 
            this.rbHotel.AutoSize = true;
            this.rbHotel.Location = new System.Drawing.Point(23, 68);
            this.rbHotel.Name = "rbHotel";
            this.rbHotel.Size = new System.Drawing.Size(50, 17);
            this.rbHotel.TabIndex = 5;
            this.rbHotel.TabStop = true;
            this.rbHotel.Text = "Hotel";
            this.rbHotel.UseVisualStyleBackColor = true;
            this.rbHotel.CheckedChanged += new System.EventHandler(this.optUnterkunft);
            // 
            // rbPension
            // 
            this.rbPension.AutoSize = true;
            this.rbPension.Location = new System.Drawing.Point(23, 45);
            this.rbPension.Name = "rbPension";
            this.rbPension.Size = new System.Drawing.Size(63, 17);
            this.rbPension.TabIndex = 4;
            this.rbPension.TabStop = true;
            this.rbPension.Text = "Pension";
            this.rbPension.UseVisualStyleBackColor = true;
            this.rbPension.CheckedChanged += new System.EventHandler(this.optUnterkunft);
            // 
            // rbAppartement
            // 
            this.rbAppartement.AutoSize = true;
            this.rbAppartement.Location = new System.Drawing.Point(23, 22);
            this.rbAppartement.Name = "rbAppartement";
            this.rbAppartement.Size = new System.Drawing.Size(85, 17);
            this.rbAppartement.TabIndex = 3;
            this.rbAppartement.TabStop = true;
            this.rbAppartement.Text = "Appartement";
            this.rbAppartement.UseVisualStyleBackColor = true;
            this.rbAppartement.CheckedChanged += new System.EventHandler(this.optUnterkunft);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbParis);
            this.groupBox1.Controls.Add(this.rbRom);
            this.groupBox1.Controls.Add(this.rbBerlin);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(131, 106);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // rbParis
            // 
            this.rbParis.AutoSize = true;
            this.rbParis.Location = new System.Drawing.Point(23, 68);
            this.rbParis.Name = "rbParis";
            this.rbParis.Size = new System.Drawing.Size(48, 17);
            this.rbParis.TabIndex = 8;
            this.rbParis.TabStop = true;
            this.rbParis.Text = "Paris";
            this.rbParis.UseVisualStyleBackColor = true;
            // 
            // rbRom
            // 
            this.rbRom.AutoSize = true;
            this.rbRom.Location = new System.Drawing.Point(23, 45);
            this.rbRom.Name = "rbRom";
            this.rbRom.Size = new System.Drawing.Size(47, 17);
            this.rbRom.TabIndex = 7;
            this.rbRom.TabStop = true;
            this.rbRom.Text = "Rom";
            this.rbRom.UseVisualStyleBackColor = true;
            // 
            // rbBerlin
            // 
            this.rbBerlin.AutoSize = true;
            this.rbBerlin.Location = new System.Drawing.Point(23, 22);
            this.rbBerlin.Name = "rbBerlin";
            this.rbBerlin.Size = new System.Drawing.Size(51, 17);
            this.rbBerlin.TabIndex = 6;
            this.rbBerlin.TabStop = true;
            this.rbBerlin.Text = "Berlin";
            this.rbBerlin.UseVisualStyleBackColor = true;
            // 
            // MethodeOhneEreignis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lblDisplay);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MethodeOhneEreignis";
            this.Text = "MethodeOhneEreignis";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDisplay;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbHotel;
        private System.Windows.Forms.RadioButton rbPension;
        private System.Windows.Forms.RadioButton rbAppartement;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbParis;
        private System.Windows.Forms.RadioButton rbRom;
        private System.Windows.Forms.RadioButton rbBerlin;
    }
}

