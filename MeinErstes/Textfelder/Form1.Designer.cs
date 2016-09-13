namespace Textfelder {
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
            this.btnAnzeige1 = new System.Windows.Forms.Button();
            this.btnAnzeige2 = new System.Windows.Forms.Button();
            this.btnAnzeige3 = new System.Windows.Forms.Button();
            this.lblAnzeige = new System.Windows.Forms.Label();
            this.lblAnzeige2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAnzeige1
            // 
            this.btnAnzeige1.Location = new System.Drawing.Point(12, 12);
            this.btnAnzeige1.Name = "btnAnzeige1";
            this.btnAnzeige1.Size = new System.Drawing.Size(75, 23);
            this.btnAnzeige1.TabIndex = 0;
            this.btnAnzeige1.Text = "Ausgabe";
            this.btnAnzeige1.UseVisualStyleBackColor = true;
            this.btnAnzeige1.Click += new System.EventHandler(this.btnAnzeige1_Click);
            // 
            // btnAnzeige2
            // 
            this.btnAnzeige2.Location = new System.Drawing.Point(105, 12);
            this.btnAnzeige2.Name = "btnAnzeige2";
            this.btnAnzeige2.Size = new System.Drawing.Size(75, 23);
            this.btnAnzeige2.TabIndex = 1;
            this.btnAnzeige2.Text = "Rechnen";
            this.btnAnzeige2.UseVisualStyleBackColor = true;
            this.btnAnzeige2.Click += new System.EventHandler(this.btnAnzeige2_Click);
            // 
            // btnAnzeige3
            // 
            this.btnAnzeige3.Location = new System.Drawing.Point(197, 12);
            this.btnAnzeige3.Name = "btnAnzeige3";
            this.btnAnzeige3.Size = new System.Drawing.Size(75, 23);
            this.btnAnzeige3.TabIndex = 2;
            this.btnAnzeige3.Text = "button3";
            this.btnAnzeige3.UseVisualStyleBackColor = true;
            this.btnAnzeige3.Click += new System.EventHandler(this.btnAnzeige3_Click);
            // 
            // lblAnzeige
            // 
            this.lblAnzeige.AutoSize = true;
            this.lblAnzeige.Location = new System.Drawing.Point(9, 130);
            this.lblAnzeige.Name = "lblAnzeige";
            this.lblAnzeige.Size = new System.Drawing.Size(35, 13);
            this.lblAnzeige.TabIndex = 3;
            this.lblAnzeige.Text = "label1";
            // 
            // lblAnzeige2
            // 
            this.lblAnzeige2.AutoSize = true;
            this.lblAnzeige2.Location = new System.Drawing.Point(12, 209);
            this.lblAnzeige2.Name = "lblAnzeige2";
            this.lblAnzeige2.Size = new System.Drawing.Size(35, 13);
            this.lblAnzeige2.TabIndex = 4;
            this.lblAnzeige2.Text = "label2";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 162);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(105, 162);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // tb1
            // 
            this.tb1.Location = new System.Drawing.Point(12, 50);
            this.tb1.Multiline = true;
            this.tb1.Name = "tb1";
            this.tb1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb1.Size = new System.Drawing.Size(174, 57);
            this.tb1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.lblAnzeige2);
            this.Controls.Add(this.lblAnzeige);
            this.Controls.Add(this.btnAnzeige3);
            this.Controls.Add(this.btnAnzeige2);
            this.Controls.Add(this.btnAnzeige1);
            this.Name = "Form1";
            this.Text = "Textfelder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAnzeige1;
        private System.Windows.Forms.Button btnAnzeige2;
        private System.Windows.Forms.Button btnAnzeige3;
        private System.Windows.Forms.Label lblAnzeige;
        private System.Windows.Forms.Label lblAnzeige2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox tb1;
    }
}

