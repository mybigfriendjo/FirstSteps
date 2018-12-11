namespace WinVolumeControler
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.numUpDownVol1 = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.numUpDownVol2 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownVol1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownVol2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Input - Vaio";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numUpDownVol1
            // 
            this.numUpDownVol1.Location = new System.Drawing.Point(116, 12);
            this.numUpDownVol1.Name = "numUpDownVol1";
            this.numUpDownVol1.Size = new System.Drawing.Size(59, 20);
            this.numUpDownVol1.TabIndex = 2;
            this.numUpDownVol1.ValueChanged += new System.EventHandler(this.numUpDownVol1_ValueChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(11, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Input - VaioAux";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // numUpDownVol2
            // 
            this.numUpDownVol2.Location = new System.Drawing.Point(116, 41);
            this.numUpDownVol2.Name = "numUpDownVol2";
            this.numUpDownVol2.Size = new System.Drawing.Size(59, 20);
            this.numUpDownVol2.TabIndex = 4;
            this.numUpDownVol2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(189, 73);
            this.Controls.Add(this.numUpDownVol2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.numUpDownVol1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownVol1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownVol2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numUpDownVol1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown numUpDownVol2;
    }
}

