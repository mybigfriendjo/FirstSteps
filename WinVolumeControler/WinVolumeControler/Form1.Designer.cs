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
            this.numUpDownVol1 = new System.Windows.Forms.NumericUpDown();
            this.numUpDownVol2 = new System.Windows.Forms.NumericUpDown();
            this.lblInputVaio = new System.Windows.Forms.Label();
            this.lblInputVaioAux = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownVol1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownVol2)).BeginInit();
            this.SuspendLayout();
            // 
            // numUpDownVol1
            // 
            this.numUpDownVol1.Location = new System.Drawing.Point(116, 12);
            this.numUpDownVol1.Name = "numUpDownVol1";
            this.numUpDownVol1.Size = new System.Drawing.Size(59, 20);
            this.numUpDownVol1.TabIndex = 2;
            this.numUpDownVol1.ValueChanged += new System.EventHandler(this.numUpDownVol1_ValueChanged);
            // 
            // numUpDownVol2
            // 
            this.numUpDownVol2.Location = new System.Drawing.Point(116, 41);
            this.numUpDownVol2.Name = "numUpDownVol2";
            this.numUpDownVol2.Size = new System.Drawing.Size(59, 20);
            this.numUpDownVol2.TabIndex = 4;
            this.numUpDownVol2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // lblInputVaio
            // 
            this.lblInputVaio.AutoSize = true;
            this.lblInputVaio.Location = new System.Drawing.Point(12, 14);
            this.lblInputVaio.Name = "lblInputVaio";
            this.lblInputVaio.Size = new System.Drawing.Size(61, 13);
            this.lblInputVaio.TabIndex = 5;
            this.lblInputVaio.Text = "Input - Vaio";
            // 
            // lblInputVaioAux
            // 
            this.lblInputVaioAux.AutoSize = true;
            this.lblInputVaioAux.Location = new System.Drawing.Point(12, 43);
            this.lblInputVaioAux.Name = "lblInputVaioAux";
            this.lblInputVaioAux.Size = new System.Drawing.Size(79, 13);
            this.lblInputVaioAux.TabIndex = 6;
            this.lblInputVaioAux.Text = "Input - VaioAux";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 76);
            this.Controls.Add(this.lblInputVaioAux);
            this.Controls.Add(this.lblInputVaio);
            this.Controls.Add(this.numUpDownVol2);
            this.Controls.Add(this.numUpDownVol1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownVol1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownVol2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numUpDownVol1;
        private System.Windows.Forms.NumericUpDown numUpDownVol2;
        private System.Windows.Forms.Label lblInputVaio;
        private System.Windows.Forms.Label lblInputVaioAux;
    }
}

