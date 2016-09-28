namespace MehrereEreignisse {
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.optFarbeRot = new System.Windows.Forms.RadioButton();
            this.optFarbeGrün = new System.Windows.Forms.RadioButton();
            this.optFarbeBlau = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 71);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.optFarbeGewechselt);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(93, 71);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.optFarbeGewechselt);
            // 
            // optFarbeRot
            // 
            this.optFarbeRot.AutoSize = true;
            this.optFarbeRot.Location = new System.Drawing.Point(12, 116);
            this.optFarbeRot.Name = "optFarbeRot";
            this.optFarbeRot.Size = new System.Drawing.Size(84, 17);
            this.optFarbeRot.TabIndex = 4;
            this.optFarbeRot.TabStop = true;
            this.optFarbeRot.Text = "optFarbeRot";
            this.optFarbeRot.UseVisualStyleBackColor = true;
            this.optFarbeRot.CheckedChanged += new System.EventHandler(this.optFarbeGewechselt);
            // 
            // optFarbeGrün
            // 
            this.optFarbeGrün.AutoSize = true;
            this.optFarbeGrün.Location = new System.Drawing.Point(12, 139);
            this.optFarbeGrün.Name = "optFarbeGrün";
            this.optFarbeGrün.Size = new System.Drawing.Size(90, 17);
            this.optFarbeGrün.TabIndex = 5;
            this.optFarbeGrün.TabStop = true;
            this.optFarbeGrün.Text = "optFarbeGrün";
            this.optFarbeGrün.UseVisualStyleBackColor = true;
            this.optFarbeGrün.CheckedChanged += new System.EventHandler(this.optFarbeGewechselt);
            // 
            // optFarbeBlau
            // 
            this.optFarbeBlau.AutoSize = true;
            this.optFarbeBlau.Location = new System.Drawing.Point(12, 162);
            this.optFarbeBlau.Name = "optFarbeBlau";
            this.optFarbeBlau.Size = new System.Drawing.Size(88, 17);
            this.optFarbeBlau.TabIndex = 6;
            this.optFarbeBlau.TabStop = true;
            this.optFarbeBlau.Text = "optFarbeBlau";
            this.optFarbeBlau.UseVisualStyleBackColor = true;
            this.optFarbeBlau.CheckedChanged += new System.EventHandler(this.optFarbeGewechselt);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.optFarbeBlau);
            this.Controls.Add(this.optFarbeGrün);
            this.Controls.Add(this.optFarbeRot);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RadioButton optFarbeRot;
        private System.Windows.Forms.RadioButton optFarbeGrün;
        private System.Windows.Forms.RadioButton optFarbeBlau;
        private System.Windows.Forms.Label label1;
    }
}

