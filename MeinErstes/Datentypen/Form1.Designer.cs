namespace Datentypen {
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
            this.btnAnzeige = new System.Windows.Forms.Button();
            this.lblSize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAnzeige
            // 
            this.btnAnzeige.Location = new System.Drawing.Point(12, 12);
            this.btnAnzeige.Name = "btnAnzeige";
            this.btnAnzeige.Size = new System.Drawing.Size(73, 22);
            this.btnAnzeige.TabIndex = 7;
            this.btnAnzeige.Text = "Anzeige";
            this.btnAnzeige.UseVisualStyleBackColor = true;
            this.btnAnzeige.Click += new System.EventHandler(this.btnAnzeige_Click);
            // 
            // lblSize
            // 
            this.lblSize.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSize.Location = new System.Drawing.Point(12, 48);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(260, 317);
            this.lblSize.TabIndex = 8;
            this.lblSize.Text = "label1";
            this.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 374);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.btnAnzeige);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAnzeige;
        private System.Windows.Forms.Label lblSize;
    }
}

