namespace Listenfeld {
    partial class Listenfeld {
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
            this.lbTest = new System.Windows.Forms.ListBox();
            this.lblCnt = new System.Windows.Forms.Label();
            this.lblSelectedIndex = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbTest
            // 
            this.lbTest.FormattingEnabled = true;
            this.lbTest.Items.AddRange(new object[] {
            "Schinken",
            "Steak",
            "Grüne Grüze"});
            this.lbTest.Location = new System.Drawing.Point(12, 12);
            this.lbTest.Name = "lbTest";
            this.lbTest.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbTest.Size = new System.Drawing.Size(260, 82);
            this.lbTest.TabIndex = 0;
            this.lbTest.SelectedIndexChanged += new System.EventHandler(this.lbTest_SelectedIndexChanged);
            // 
            // lblCnt
            // 
            this.lblCnt.AutoSize = true;
            this.lblCnt.Location = new System.Drawing.Point(9, 220);
            this.lblCnt.Name = "lblCnt";
            this.lblCnt.Size = new System.Drawing.Size(108, 13);
            this.lblCnt.TabIndex = 1;
            this.lblCnt.Text = "Elemente in der Liste:";
            // 
            // lblSelectedIndex
            // 
            this.lblSelectedIndex.AutoSize = true;
            this.lblSelectedIndex.Location = new System.Drawing.Point(9, 106);
            this.lblSelectedIndex.Name = "lblSelectedIndex";
            this.lblSelectedIndex.Size = new System.Drawing.Size(99, 13);
            this.lblSelectedIndex.TabIndex = 2;
            this.lblSelectedIndex.Text = "Aktuelles Objekt(e):";
            // 
            // Listenfeld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 375);
            this.Controls.Add(this.lblSelectedIndex);
            this.Controls.Add(this.lblCnt);
            this.Controls.Add(this.lbTest);
            this.Name = "Listenfeld";
            this.Text = "Listenfeld";
            this.Load += new System.EventHandler(this.Listenfeld_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbTest;
        private System.Windows.Forms.Label lblCnt;
        private System.Windows.Forms.Label lblSelectedIndex;
    }
}

