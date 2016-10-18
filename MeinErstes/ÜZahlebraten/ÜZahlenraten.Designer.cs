namespace ÜZahlebraten {
    partial class ÜZahlenraten {
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
            this.btnErzeugen = new System.Windows.Forms.Button();
            this.btnPruefen = new System.Windows.Forms.Button();
            this.lblEingabe = new System.Windows.Forms.Label();
            this.tbEingabe = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblCounter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnErzeugen
            // 
            this.btnErzeugen.Location = new System.Drawing.Point(227, 12);
            this.btnErzeugen.Name = "btnErzeugen";
            this.btnErzeugen.Size = new System.Drawing.Size(75, 23);
            this.btnErzeugen.TabIndex = 0;
            this.btnErzeugen.Text = "Erzeugen";
            this.btnErzeugen.UseVisualStyleBackColor = true;
            this.btnErzeugen.Click += new System.EventHandler(this.btnErzeugen_Click);
            // 
            // btnPruefen
            // 
            this.btnPruefen.Location = new System.Drawing.Point(227, 41);
            this.btnPruefen.Name = "btnPruefen";
            this.btnPruefen.Size = new System.Drawing.Size(75, 23);
            this.btnPruefen.TabIndex = 1;
            this.btnPruefen.Text = "Prüfen";
            this.btnPruefen.UseVisualStyleBackColor = true;
            this.btnPruefen.Click += new System.EventHandler(this.btnPruefen_Click);
            // 
            // lblEingabe
            // 
            this.lblEingabe.AutoSize = true;
            this.lblEingabe.Location = new System.Drawing.Point(2, 17);
            this.lblEingabe.Name = "lblEingabe";
            this.lblEingabe.Size = new System.Drawing.Size(49, 13);
            this.lblEingabe.TabIndex = 2;
            this.lblEingabe.Text = "Eingabe:";
            // 
            // tbEingabe
            // 
            this.tbEingabe.Location = new System.Drawing.Point(68, 14);
            this.tbEingabe.Name = "tbEingabe";
            this.tbEingabe.Size = new System.Drawing.Size(100, 20);
            this.tbEingabe.TabIndex = 3;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(12, 85);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(278, 13);
            this.lblResult.TabIndex = 4;
            this.lblResult.Text = "<<Bitte geben Sie im Eingabefeld die geratene Zahl ein>>";
            // 
            // lblCounter
            // 
            this.lblCounter.AutoSize = true;
            this.lblCounter.Location = new System.Drawing.Point(12, 46);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(0, 13);
            this.lblCounter.TabIndex = 5;
            // 
            // ÜZahlenraten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 145);
            this.Controls.Add(this.lblCounter);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.tbEingabe);
            this.Controls.Add(this.lblEingabe);
            this.Controls.Add(this.btnPruefen);
            this.Controls.Add(this.btnErzeugen);
            this.Name = "ÜZahlenraten";
            this.Text = "Zahlenraten 1-100";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnErzeugen;
        private System.Windows.Forms.Button btnPruefen;
        private System.Windows.Forms.Label lblEingabe;
        private System.Windows.Forms.TextBox tbEingabe;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblCounter;
    }
}

