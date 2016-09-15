namespace ÜSteuerbetrag {
    partial class SalaryCalculator {
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
            this.lblSalary = new System.Windows.Forms.Label();
            this.lblTaxes = new System.Windows.Forms.Label();
            this.lblNetto = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.lblYearsSalary = new System.Windows.Forms.Label();
            this.lblNettoMonth = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSalary
            // 
            this.lblSalary.AutoSize = true;
            this.lblSalary.Location = new System.Drawing.Point(12, 16);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(41, 13);
            this.lblSalary.TabIndex = 1;
            this.lblSalary.Text = "Gehalt:";
            // 
            // lblTaxes
            // 
            this.lblTaxes.AutoSize = true;
            this.lblTaxes.Location = new System.Drawing.Point(35, 78);
            this.lblTaxes.Name = "lblTaxes";
            this.lblTaxes.Size = new System.Drawing.Size(47, 13);
            this.lblTaxes.TabIndex = 2;
            this.lblTaxes.Text = "Steuern:";
            // 
            // lblNetto
            // 
            this.lblNetto.AutoSize = true;
            this.lblNetto.Location = new System.Drawing.Point(46, 91);
            this.lblNetto.Name = "lblNetto";
            this.lblNetto.Size = new System.Drawing.Size(36, 13);
            this.lblNetto.TabIndex = 3;
            this.lblNetto.Text = "Netto:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(12, 35);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // lblYearsSalary
            // 
            this.lblYearsSalary.AutoSize = true;
            this.lblYearsSalary.Location = new System.Drawing.Point(12, 65);
            this.lblYearsSalary.Name = "lblYearsSalary";
            this.lblYearsSalary.Size = new System.Drawing.Size(70, 13);
            this.lblYearsSalary.TabIndex = 5;
            this.lblYearsSalary.Text = "Jahresgehalt:";
            // 
            // lblNettoMonth
            // 
            this.lblNettoMonth.AutoSize = true;
            this.lblNettoMonth.Location = new System.Drawing.Point(12, 104);
            this.lblNettoMonth.Name = "lblNettoMonth";
            this.lblNettoMonth.Size = new System.Drawing.Size(70, 13);
            this.lblNettoMonth.TabIndex = 6;
            this.lblNettoMonth.Text = "Netto/month:";
            // 
            // SalaryCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 262);
            this.Controls.Add(this.lblNettoMonth);
            this.Controls.Add(this.lblYearsSalary);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.lblNetto);
            this.Controls.Add(this.lblTaxes);
            this.Controls.Add(this.lblSalary);
            this.Name = "SalaryCalculator";
            this.Text = "Gehaltsrechner";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.Label lblTaxes;
        private System.Windows.Forms.Label lblNetto;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label lblYearsSalary;
        private System.Windows.Forms.Label lblNettoMonth;
    }
}

