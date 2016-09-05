namespace MeinErstes
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnHallo = new System.Windows.Forms.Button();
            this.btnEnde = new System.Windows.Forms.Button();
            this.lblAnzeige = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnHallo
            // 
            this.btnHallo.Location = new System.Drawing.Point(12, 12);
            this.btnHallo.Name = "btnHallo";
            this.btnHallo.Size = new System.Drawing.Size(75, 23);
            this.btnHallo.TabIndex = 0;
            this.btnHallo.Text = "Hallo";
            this.btnHallo.UseVisualStyleBackColor = true;
            this.btnHallo.Click += new System.EventHandler(this.btnHallo_Click);
            // 
            // btnEnde
            // 
            this.btnEnde.Location = new System.Drawing.Point(12, 41);
            this.btnEnde.Name = "btnEnde";
            this.btnEnde.Size = new System.Drawing.Size(75, 23);
            this.btnEnde.TabIndex = 1;
            this.btnEnde.Text = "Ende";
            this.btnEnde.UseVisualStyleBackColor = true;
            this.btnEnde.Click += new System.EventHandler(this.btnEnde_Click);
            // 
            // lblAnzeige
            // 
            this.lblAnzeige.AutoSize = true;
            this.lblAnzeige.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAnzeige.Location = new System.Drawing.Point(12, 77);
            this.lblAnzeige.Name = "lblAnzeige";
            this.lblAnzeige.Size = new System.Drawing.Size(32, 15);
            this.lblAnzeige.TabIndex = 2;
            this.lblAnzeige.Text = "(leer)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lblAnzeige);
            this.Controls.Add(this.btnEnde);
            this.Controls.Add(this.btnHallo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHallo;
        private System.Windows.Forms.Button btnEnde;
        private System.Windows.Forms.Label lblAnzeige;
    }
}

