using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gültigkeitsbereich {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private int Mx = 0;

        private void btnAnzeigen_Click(object sender, EventArgs e) {
            int x = 0;
            Mx = Mx + 1;
            x = x + 1;
            lblAnzeige.Text = "x: " + x + " Mx: " + Mx;
        }

        private void btnAnzeigen2_Click(object sender, EventArgs e) {
            int Mx = 0;
            Mx = Mx + 1;
            lblAnzeige.Text = "Mx: " + Mx;
        }

        //Übung Gültikeit Abbildung 2.5 + 2.6
        private double x = 0;

        private void bntAnzeige3_Click(object sender, EventArgs e) {
            double y = 0;
            x = x + 0.1;
            y = y + 0.1;
            lblAnzeige2.Text = "x: " + x + " y: " + y;
        }

        private void bntAnzeige4_Click(object sender, EventArgs e) {
            double z = 0;
            x = x + 0.1;
            z = z + 0.1;
            lblAnzeige2.Text = "x: " + x + " z: " + z;
        }
    }
}
