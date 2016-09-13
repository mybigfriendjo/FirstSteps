using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EinfacheSteuerelemente {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        

        private void btnUpperLeft_Click(object sender, EventArgs e) {
            panel1.Location = new Point(panel1.Location.X - 10, panel1.Location.Y - 10);
        }

        private void btnUpperRight_Click(object sender, EventArgs e) {
            panel1.Location = new Point(panel1.Location.X + 10, panel1.Location.Y - 10);
        }

        private void btnLowerLeft_Click(object sender, EventArgs e) {
            panel1.Location = new Point(panel1.Location.X - 10, panel1.Location.Y + 10);
        }

        private void btnLowerRight_Click(object sender, EventArgs e) {
            panel1.Location = new Point(panel1.Location.X + 10, panel1.Location.Y + 10);
        }
    }
}
