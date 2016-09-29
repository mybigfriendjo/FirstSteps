using System;
using System.Drawing;
using System.Windows.Forms;

namespace ÜKranVerzweigung_Timer {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        
        private void btnStart_Click(object sender, EventArgs e) {
            timAnzeige.Enabled = true;
            timAnzeige.Interval = 50; //Number is ms 500 -> 0,5 sec
        }

        private void btnStop_Click(object sender, EventArgs e) {
            timAnzeige.Enabled = false;
        }
       
        private void timAnzeige_Tick(object sender, EventArgs e) {
            MessageBox.Show("" + sender,"");
        }

        private void btnHookUp_Click(object sender, EventArgs e) {
            if (panel4.Size.Height <= 15) {
            }
            else {
                panel4.Size = new Size(panel4.Size.Width, panel4.Size.Height - 10);
            }
        }

        private void btnHookDown_Click(object sender, EventArgs e) {
            panel4.Size = new Size(panel4.Size.Width, panel4.Size.Height + 10);
        }

        private void btnAuslegerL_Click(object sender, EventArgs e) {
            panel3.Size = new Size(panel3.Size.Width + 10, panel3.Size.Height);
            panel3.Location = new Point(panel3.Location.X - 10, panel3.Location.Y);
            panel4.Location = new Point(panel4.Location.X - 10, panel4.Location.Y);

        }

        private void btnAuslegerR_Click(object sender, EventArgs e) {
            if ((panel3.Location.X + panel3.Size.Height) >= (panel1.Location.X + panel1.Size.Width - 40)) {
            }
            else {
                panel3.Size = new Size(panel3.Size.Width - 10, panel3.Size.Height);
                panel3.Location = new Point(panel3.Location.X + 10, panel3.Location.Y);
                panel4.Location = new Point(panel4.Location.X + 10, panel4.Location.Y);
            }
        }

        private void btnKranR_Click(object sender, EventArgs e) {
            if (panel1.Location.X >= 229) {
            } //Dont move
            else {
                panel1.Location = new Point(panel1.Location.X + 10, panel1.Location.Y);
                panel3.Location = new Point(panel3.Location.X + 10, panel3.Location.Y);
                panel4.Location = new Point(panel4.Location.X + 10, panel4.Location.Y);
            }
        }

        private void btnKranL_Click(object sender, EventArgs e) {
            if (panel1.Location.X <= 179) {
            } //Dont move
            else {
                panel1.Location = new Point(panel1.Location.X - 10, panel1.Location.Y);
                panel3.Location = new Point(panel3.Location.X - 10, panel3.Location.Y);
                panel4.Location = new Point(panel4.Location.X - 10, panel4.Location.Y);
            }
        }

        private void btnKranUp_Click(object sender, EventArgs e) {
            panel1.Size = new Size(panel1.Size.Width, panel1.Size.Height + 10);
            panel1.Location = new Point(panel1.Location.X, panel1.Location.Y - 10);
            panel3.Location = new Point(panel3.Location.X, panel3.Location.Y - 10);
            panel4.Location = new Point(panel4.Location.X, panel4.Location.Y - 10);
        }

        private void btnKranDown_Click(object sender, EventArgs e) {
            if (panel1.Size.Height <= 12) {
            }
            else {
                panel1.Size = new Size(panel1.Size.Width, panel1.Size.Height - 10);
                panel1.Location = new Point(panel1.Location.X, panel1.Location.Y + 10);
                panel3.Location = new Point(panel3.Location.X, panel3.Location.Y + 10);
                panel4.Location = new Point(panel4.Location.X, panel4.Location.Y + 10);
            }
        }
    }
}
