namespace Konstanten {
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
            this.btnKonstanten = new System.Windows.Forms.Button();
            this.lblAnzeige = new System.Windows.Forms.Label();
            this.btnEnumeration1 = new System.Windows.Forms.Button();
            this.btnEnumeration2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnKonstanten
            // 
            this.btnKonstanten.Location = new System.Drawing.Point(12, 12);
            this.btnKonstanten.Name = "btnKonstanten";
            this.btnKonstanten.Size = new System.Drawing.Size(75, 23);
            this.btnKonstanten.TabIndex = 0;
            this.btnKonstanten.Text = "Konstanten";
            this.btnKonstanten.UseVisualStyleBackColor = true;
            this.btnKonstanten.Click += new System.EventHandler(this.btnKonstanten_Click);
            // 
            // lblAnzeige
            // 
            this.lblAnzeige.Location = new System.Drawing.Point(12, 38);
            this.lblAnzeige.Name = "lblAnzeige";
            this.lblAnzeige.Size = new System.Drawing.Size(260, 107);
            this.lblAnzeige.TabIndex = 1;
            this.lblAnzeige.Text = "label1";
            // 
            // btnEnumeration1
            // 
            this.btnEnumeration1.Location = new System.Drawing.Point(93, 12);
            this.btnEnumeration1.Name = "btnEnumeration1";
            this.btnEnumeration1.Size = new System.Drawing.Size(86, 23);
            this.btnEnumeration1.TabIndex = 2;
            this.btnEnumeration1.Text = "Enumeration 1";
            this.btnEnumeration1.UseVisualStyleBackColor = true;
            this.btnEnumeration1.Click += new System.EventHandler(this.btnEnumeration1_Click);
            // 
            // btnEnumeration2
            // 
            this.btnEnumeration2.Location = new System.Drawing.Point(185, 12);
            this.btnEnumeration2.Name = "btnEnumeration2";
            this.btnEnumeration2.Size = new System.Drawing.Size(86, 23);
            this.btnEnumeration2.TabIndex = 3;
            this.btnEnumeration2.Text = "Enumeration 2";
            this.btnEnumeration2.UseVisualStyleBackColor = true;
            this.btnEnumeration2.Click += new System.EventHandler(this.btnEnumeration2_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnEnumeration2);
            this.Controls.Add(this.btnEnumeration1);
            this.Controls.Add(this.lblAnzeige);
            this.Controls.Add(this.btnKonstanten);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKonstanten;
        private System.Windows.Forms.Label lblAnzeige;
        private System.Windows.Forms.Button btnEnumeration1;
        private System.Windows.Forms.Button btnEnumeration2;
    }
}

