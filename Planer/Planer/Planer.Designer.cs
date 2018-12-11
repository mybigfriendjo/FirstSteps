namespace Planer
{
    partial class Planer
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
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Node1");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Node2");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Node6");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Node5", new System.Windows.Forms.TreeNode[] {
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Node7");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Node4", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Node3", new System.Windows.Forms.TreeNode[] {
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10,
            treeNode15});
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chkboxDone = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tbDiscribtion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbllbTask = new System.Windows.Forms.Label();
            this.lblDatagridTasksteps = new System.Windows.Forms.Label();
            this.treeViewTasks = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSaveToPacket = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkboxDone,
            this.tbDiscribtion});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 3);
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(261, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(598, 274);
            this.dataGridView1.TabIndex = 1;
            // 
            // chkboxDone
            // 
            this.chkboxDone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.chkboxDone.FalseValue = "0";
            this.chkboxDone.HeaderText = "Done";
            this.chkboxDone.IndeterminateValue = "0";
            this.chkboxDone.Name = "chkboxDone";
            this.chkboxDone.TrueValue = "1";
            this.chkboxDone.Width = 39;
            // 
            // tbDiscribtion
            // 
            this.tbDiscribtion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tbDiscribtion.HeaderText = "Describtion";
            this.tbDiscribtion.Name = "tbDiscribtion";
            // 
            // lbllbTask
            // 
            this.lbllbTask.AutoSize = true;
            this.lbllbTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbllbTask.Location = new System.Drawing.Point(3, 0);
            this.lbllbTask.Name = "lbllbTask";
            this.lbllbTask.Size = new System.Drawing.Size(252, 25);
            this.lbllbTask.TabIndex = 2;
            this.lbllbTask.Text = "Tasks";
            // 
            // lblDatagridTasksteps
            // 
            this.lblDatagridTasksteps.AutoSize = true;
            this.lblDatagridTasksteps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDatagridTasksteps.Location = new System.Drawing.Point(261, 0);
            this.lblDatagridTasksteps.Name = "lblDatagridTasksteps";
            this.lblDatagridTasksteps.Size = new System.Drawing.Size(195, 25);
            this.lblDatagridTasksteps.TabIndex = 3;
            this.lblDatagridTasksteps.Text = "Tasksteps";
            // 
            // treeViewTasks
            // 
            this.treeViewTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewTasks.Location = new System.Drawing.Point(3, 28);
            this.treeViewTasks.Name = "treeViewTasks";
            treeNode9.Name = "Node1";
            treeNode9.Text = "Node1";
            treeNode10.Name = "Node2";
            treeNode10.Text = "Node2";
            treeNode11.Name = "Node6";
            treeNode11.Text = "Node6";
            treeNode12.Name = "Node5";
            treeNode12.Text = "Node5";
            treeNode13.Name = "Node7";
            treeNode13.Text = "Node7";
            treeNode14.Name = "Node4";
            treeNode14.Text = "Node4";
            treeNode15.Name = "Node3";
            treeNode15.Text = "Node3";
            treeNode16.Name = "Node0";
            treeNode16.Text = "Node0";
            this.treeViewTasks.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode16});
            this.tableLayoutPanel1.SetRowSpan(this.treeViewTasks, 4);
            this.treeViewTasks.Size = new System.Drawing.Size(252, 604);
            this.treeViewTasks.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.003F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.33233F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.33233F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.33233F));
            this.tableLayoutPanel1.Controls.Add(this.btnSaveToPacket, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.treeViewTasks, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDatagridTasksteps, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbllbTask, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(862, 655);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // btnSaveToPacket
            // 
            this.btnSaveToPacket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveToPacket.Location = new System.Drawing.Point(261, 308);
            this.btnSaveToPacket.Name = "btnSaveToPacket";
            this.btnSaveToPacket.Size = new System.Drawing.Size(195, 19);
            this.btnSaveToPacket.TabIndex = 6;
            this.btnSaveToPacket.Text = "Save as Packet";
            this.btnSaveToPacket.UseVisualStyleBackColor = true;
            // 
            // Planer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 655);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Planer";
            this.Text = "Planer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkboxDone;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbDiscribtion;
        private System.Windows.Forms.Label lbllbTask;
        private System.Windows.Forms.Label lblDatagridTasksteps;
        private System.Windows.Forms.TreeView treeViewTasks;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnSaveToPacket;
    }
}

