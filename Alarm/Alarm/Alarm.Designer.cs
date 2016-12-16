﻿namespace Alarm {
    partial class Alarm {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Alarm));
            this.cbCountdown = new System.Windows.Forms.CheckBox();
            this.rb5min = new System.Windows.Forms.RadioButton();
            this.rb10min = new System.Windows.Forms.RadioButton();
            this.rb15min = new System.Windows.Forms.RadioButton();
            this.rb30min = new System.Windows.Forms.RadioButton();
            this.rb1hour = new System.Windows.Forms.RadioButton();
            this.rbCustom = new System.Windows.Forms.RadioButton();
            this.timerCountdown = new System.Windows.Forms.Timer(this.components);
            this.numCountdownHour = new System.Windows.Forms.NumericUpDown();
            this.numCountdownMin = new System.Windows.Forms.NumericUpDown();
            this.lbHistory = new System.Windows.Forms.ListBox();
            this.lblHistory = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelCountdown = new System.Windows.Forms.Panel();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblCountdownTime = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.contextMenuStripSystray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAcivateAlarm = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column2525 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.cbNoDoubleEntry = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbShutdown = new System.Windows.Forms.CheckBox();
            this.cbFlashscreen = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numCountdownHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCountdownMin)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panelCountdown.SuspendLayout();
            this.contextMenuStripSystray.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCountdown
            // 
            this.cbCountdown.AutoSize = true;
            this.cbCountdown.Location = new System.Drawing.Point(633, 37);
            this.cbCountdown.Name = "cbCountdown";
            this.cbCountdown.Size = new System.Drawing.Size(80, 17);
            this.cbCountdown.TabIndex = 0;
            this.cbCountdown.Text = "Countdown";
            this.cbCountdown.UseVisualStyleBackColor = true;
            this.cbCountdown.CheckedChanged += new System.EventHandler(this.cbCountdown_CheckedChanged);
            // 
            // rb5min
            // 
            this.rb5min.AutoSize = true;
            this.rb5min.Location = new System.Drawing.Point(18, 4);
            this.rb5min.Name = "rb5min";
            this.rb5min.Size = new System.Drawing.Size(51, 17);
            this.rb5min.TabIndex = 1;
            this.rb5min.TabStop = true;
            this.rb5min.Text = "5 Min";
            this.rb5min.UseVisualStyleBackColor = true;
            this.rb5min.CheckedChanged += new System.EventHandler(this.CountdownRadio);
            // 
            // rb10min
            // 
            this.rb10min.AutoSize = true;
            this.rb10min.Location = new System.Drawing.Point(18, 27);
            this.rb10min.Name = "rb10min";
            this.rb10min.Size = new System.Drawing.Size(57, 17);
            this.rb10min.TabIndex = 2;
            this.rb10min.TabStop = true;
            this.rb10min.Text = "10 Min";
            this.rb10min.UseVisualStyleBackColor = true;
            this.rb10min.CheckedChanged += new System.EventHandler(this.CountdownRadio);
            // 
            // rb15min
            // 
            this.rb15min.AutoSize = true;
            this.rb15min.Location = new System.Drawing.Point(18, 50);
            this.rb15min.Name = "rb15min";
            this.rb15min.Size = new System.Drawing.Size(57, 17);
            this.rb15min.TabIndex = 3;
            this.rb15min.TabStop = true;
            this.rb15min.Text = "15 Min";
            this.rb15min.UseVisualStyleBackColor = true;
            this.rb15min.CheckedChanged += new System.EventHandler(this.CountdownRadio);
            // 
            // rb30min
            // 
            this.rb30min.AutoSize = true;
            this.rb30min.Location = new System.Drawing.Point(18, 73);
            this.rb30min.Name = "rb30min";
            this.rb30min.Size = new System.Drawing.Size(57, 17);
            this.rb30min.TabIndex = 4;
            this.rb30min.TabStop = true;
            this.rb30min.Text = "30 Min";
            this.rb30min.UseVisualStyleBackColor = true;
            this.rb30min.CheckedChanged += new System.EventHandler(this.CountdownRadio);
            // 
            // rb1hour
            // 
            this.rb1hour.AutoSize = true;
            this.rb1hour.Location = new System.Drawing.Point(18, 96);
            this.rb1hour.Name = "rb1hour";
            this.rb1hour.Size = new System.Drawing.Size(57, 17);
            this.rb1hour.TabIndex = 5;
            this.rb1hour.TabStop = true;
            this.rb1hour.Text = "1 Hour";
            this.rb1hour.UseVisualStyleBackColor = true;
            this.rb1hour.CheckedChanged += new System.EventHandler(this.CountdownRadio);
            // 
            // rbCustom
            // 
            this.rbCustom.AutoSize = true;
            this.rbCustom.Location = new System.Drawing.Point(18, 119);
            this.rbCustom.Name = "rbCustom";
            this.rbCustom.Size = new System.Drawing.Size(14, 13);
            this.rbCustom.TabIndex = 6;
            this.rbCustom.TabStop = true;
            this.rbCustom.UseVisualStyleBackColor = true;
            this.rbCustom.CheckedChanged += new System.EventHandler(this.CountdownRadio);
            // 
            // numCountdownHour
            // 
            this.numCountdownHour.Location = new System.Drawing.Point(36, 119);
            this.numCountdownHour.Name = "numCountdownHour";
            this.numCountdownHour.Size = new System.Drawing.Size(35, 20);
            this.numCountdownHour.TabIndex = 8;
            this.numCountdownHour.ValueChanged += new System.EventHandler(this.CountdownRadio);
            // 
            // numCountdownMin
            // 
            this.numCountdownMin.Location = new System.Drawing.Point(76, 119);
            this.numCountdownMin.Name = "numCountdownMin";
            this.numCountdownMin.Size = new System.Drawing.Size(37, 20);
            this.numCountdownMin.TabIndex = 9;
            this.numCountdownMin.ValueChanged += new System.EventHandler(this.CountdownRadio);
            // 
            // lbHistory
            // 
            this.lbHistory.Enabled = false;
            this.lbHistory.FormattingEnabled = true;
            this.lbHistory.Location = new System.Drawing.Point(470, 427);
            this.lbHistory.Name = "lbHistory";
            this.lbHistory.Size = new System.Drawing.Size(180, 69);
            this.lbHistory.Sorted = true;
            this.lbHistory.TabIndex = 12;
            // 
            // lblHistory
            // 
            this.lblHistory.AutoSize = true;
            this.lblHistory.Location = new System.Drawing.Point(467, 411);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Size = new System.Drawing.Size(68, 13);
            this.lblHistory.TabIndex = 13;
            this.lblHistory.Text = "Alarm History";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(737, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.languageToolStripMenuItem.Text = "&Language";
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.englishToolStripMenuItem.Text = "&English";
            // 
            // panelCountdown
            // 
            this.panelCountdown.Controls.Add(this.rb5min);
            this.panelCountdown.Controls.Add(this.rb10min);
            this.panelCountdown.Controls.Add(this.rb15min);
            this.panelCountdown.Controls.Add(this.rb30min);
            this.panelCountdown.Controls.Add(this.rb1hour);
            this.panelCountdown.Controls.Add(this.rbCustom);
            this.panelCountdown.Controls.Add(this.numCountdownHour);
            this.panelCountdown.Controls.Add(this.numCountdownMin);
            this.panelCountdown.Enabled = false;
            this.panelCountdown.Location = new System.Drawing.Point(615, 65);
            this.panelCountdown.Name = "panelCountdown";
            this.panelCountdown.Size = new System.Drawing.Size(116, 148);
            this.panelCountdown.TabIndex = 20;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(341, 521);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 21;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // lblCountdownTime
            // 
            this.lblCountdownTime.AutoSize = true;
            this.lblCountdownTime.Location = new System.Drawing.Point(630, 216);
            this.lblCountdownTime.Name = "lblCountdownTime";
            this.lblCountdownTime.Size = new System.Drawing.Size(0, 13);
            this.lblCountdownTime.TabIndex = 22;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(489, 301);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(48, 23);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(543, 301);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(66, 23);
            this.btnDeleteAll.TabIndex = 24;
            this.btnDeleteAll.Text = "Delete List";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // contextMenuStripSystray
            // 
            this.contextMenuStripSystray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.contextMenuStripSystray.Name = "contextMenuStrip1";
            this.contextMenuStripSystray.Size = new System.Drawing.Size(138, 26);
            this.contextMenuStripSystray.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripSystray_Opening);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            // 
            // btnAcivateAlarm
            // 
            this.btnAcivateAlarm.Location = new System.Drawing.Point(615, 219);
            this.btnAcivateAlarm.Name = "btnAcivateAlarm";
            this.btnAcivateAlarm.Size = new System.Drawing.Size(100, 23);
            this.btnAcivateAlarm.TabIndex = 10;
            this.btnAcivateAlarm.Text = "Activate Alarm";
            this.btnAcivateAlarm.UseVisualStyleBackColor = true;
            this.btnAcivateAlarm.Click += new System.EventHandler(this.btnAcivateAlarm_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(597, 258);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2525});
            this.dataGridView2.DataSource = this.dataSet1;
            this.dataGridView2.Location = new System.Drawing.Point(41, 427);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(206, 139);
            this.dataGridView2.TabIndex = 1;
            // 
            // Column2525
            // 
            this.Column2525.HeaderText = "Column1";
            this.Column2525.Name = "Column2525";
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2});
            this.dataTable1.TableName = "Table1";
            // 
            // dataColumn1
            // 
            this.dataColumn1.Caption = "AlarmActive2";
            this.dataColumn1.ColumnName = "AlarmActive";
            this.dataColumn1.DataType = typeof(bool);
            this.dataColumn1.DefaultValue = true;
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "Column1";
            // 
            // cbNoDoubleEntry
            // 
            this.cbNoDoubleEntry.AutoSize = true;
            this.cbNoDoubleEntry.Checked = true;
            this.cbNoDoubleEntry.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNoDoubleEntry.Location = new System.Drawing.Point(470, 391);
            this.cbNoDoubleEntry.Name = "cbNoDoubleEntry";
            this.cbNoDoubleEntry.Size = new System.Drawing.Size(109, 17);
            this.cbNoDoubleEntry.TabIndex = 43;
            this.cbNoDoubleEntry.Text = "No double entries";
            this.cbNoDoubleEntry.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(470, 502);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(48, 23);
            this.btnSave.TabIndex = 40;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // cbShutdown
            // 
            this.cbShutdown.AutoSize = true;
            this.cbShutdown.Location = new System.Drawing.Point(156, 378);
            this.cbShutdown.Name = "cbShutdown";
            this.cbShutdown.Size = new System.Drawing.Size(91, 17);
            this.cbShutdown.TabIndex = 37;
            this.cbShutdown.Text = "PC-Shutdown";
            this.cbShutdown.UseVisualStyleBackColor = true;
            // 
            // cbFlashscreen
            // 
            this.cbFlashscreen.AutoSize = true;
            this.cbFlashscreen.Checked = true;
            this.cbFlashscreen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFlashscreen.Location = new System.Drawing.Point(40, 378);
            this.cbFlashscreen.Name = "cbFlashscreen";
            this.cbFlashscreen.Size = new System.Drawing.Size(88, 17);
            this.cbFlashscreen.TabIndex = 36;
            this.cbFlashscreen.Text = "Flash Screen";
            this.cbFlashscreen.UseVisualStyleBackColor = true;
            // 
            // Alarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 572);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbNoDoubleEntry);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbShutdown);
            this.Controls.Add(this.cbFlashscreen);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.btnAcivateAlarm);
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblCountdownTime);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.cbCountdown);
            this.Controls.Add(this.panelCountdown);
            this.Controls.Add(this.lblHistory);
            this.Controls.Add(this.lbHistory);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Alarm";
            this.Text = "Alarm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Alarm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numCountdownHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCountdownMin)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelCountdown.ResumeLayout(false);
            this.panelCountdown.PerformLayout();
            this.contextMenuStripSystray.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbCountdown;
        private System.Windows.Forms.RadioButton rb5min;
        private System.Windows.Forms.RadioButton rb10min;
        private System.Windows.Forms.RadioButton rb15min;
        private System.Windows.Forms.RadioButton rb30min;
        private System.Windows.Forms.RadioButton rb1hour;
        private System.Windows.Forms.RadioButton rbCustom;
        private System.Windows.Forms.Timer timerCountdown;
        private System.Windows.Forms.NumericUpDown numCountdownHour;
        private System.Windows.Forms.NumericUpDown numCountdownMin;
        private System.Windows.Forms.ListBox lbHistory;
        private System.Windows.Forms.Label lblHistory;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.Panel panelCountdown;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblCountdownTime;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSystray;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btnAcivateAlarm;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column2525;
        private System.Windows.Forms.CheckBox cbNoDoubleEntry;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox cbShutdown;
        private System.Windows.Forms.CheckBox cbFlashscreen;
    }
}

