using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeitgeber {
    public partial class Zeitgeber : Form {
        public Zeitgeber() {
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
            lblText.Text += "x";
            panel1.Location = new Point(panel1.Location.X - 1, panel1.Location.Y - 1);
            panel2.Location = new Point(panel2.Location.X + 1, panel2.Location.Y - 1);
            panel3.Location = new Point(panel3.Location.X - 1, panel3.Location.Y + 1);
            panel4.Location = new Point(panel4.Location.X + 1, panel4.Location.Y + 1);
        }

        private void panel1_Paint(object sender, PaintEventArgs e) {
        }

        private void panel2_Paint(object sender, PaintEventArgs e) {
        }

        private void panel3_Paint(object sender, PaintEventArgs e) {
        }

        private void panel4_Paint(object sender, PaintEventArgs e) {
            
        }
    }
}
