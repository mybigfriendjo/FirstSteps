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
            this.btnSaveToPacket = new System.Windows.Forms.Button();
            this.treeViewTasks = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkboxDone,
            this.tbDiscribtion});
            this.dataGridView1.Location = new System.Drawing.Point(196, 39);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(654, 286);
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
            this.lbllbTask.Location = new System.Drawing.Point(23, 22);
            this.lbllbTask.Name = "lbllbTask";
            this.lbllbTask.Size = new System.Drawing.Size(36, 13);
            this.lbllbTask.TabIndex = 2;
            this.lbllbTask.Text = "Tasks";
            // 
            // lblDatagridTasksteps
            // 
            this.lblDatagridTasksteps.AutoSize = true;
            this.lblDatagridTasksteps.Location = new System.Drawing.Point(208, 22);
            this.lblDatagridTasksteps.Name = "lblDatagridTasksteps";
            this.lblDatagridTasksteps.Size = new System.Drawing.Size(56, 13);
            this.lblDatagridTasksteps.TabIndex = 3;
            this.lblDatagridTasksteps.Text = "Tasksteps";
            // 
            // btnSaveToPacket
            // 
            this.btnSaveToPacket.Location = new System.Drawing.Point(211, 331);
            this.btnSaveToPacket.Name = "btnSaveToPacket";
            this.btnSaveToPacket.Size = new System.Drawing.Size(106, 23);
            this.btnSaveToPacket.TabIndex = 4;
            this.btnSaveToPacket.Text = "Save as Packet";
            this.btnSaveToPacket.UseVisualStyleBackColor = true;
            // 
            // treeViewTasks
            // 
            this.treeViewTasks.Location = new System.Drawing.Point(12, 39);
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
            this.treeViewTasks.Size = new System.Drawing.Size(178, 604);
            this.treeViewTasks.TabIndex = 5;
            // 
            // Planer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 655);
            this.Controls.Add(this.treeViewTasks);
            this.Controls.Add(this.btnSaveToPacket);
            this.Controls.Add(this.lblDatagridTasksteps);
            this.Controls.Add(this.lbllbTask);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Planer";
            this.Text = "Planer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkboxDone;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbDiscribtion;
        private System.Windows.Forms.Label lbllbTask;
        private System.Windows.Forms.Label lblDatagridTasksteps;
        private System.Windows.Forms.Button btnSaveToPacket;
        private System.Windows.Forms.TreeView treeViewTasks;
    }
}

