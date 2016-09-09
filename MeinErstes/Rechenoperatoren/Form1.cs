using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rechenoperatoren {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private void btnAnzeige1_Click(object sender, EventArgs e) {
            int x = 5;
            x++;
            ++x;
            x = x + 1;
            lblA.Text = "Ergebnis: " + x; //8
        }
        private void btnAnzeige2_Click(object sender, EventArgs e) {
            int x = 5;
            lblA.Text = "Ergebnis: " + x++; //5  - (old value - gets stored after new line)
        }
        private void btnAnzeige3_Click(object sender, EventArgs e) {
            int x = 5;
            lblA.Text = "Ergebnis: " + ++x; //6
        }

        //Übung modulo %
        private void btnAnzeige4_Click(object sender, EventArgs e) {
            double result1 = 3 * -2.5 + 4 * 2;
            lblA2.Text = result1.ToString();
        }

        private void btnAnzeige5_Click(object sender, EventArgs e) {
            double result2 = 3 * (-2.5 + 4) * 2;
            lblA3.Text = result2.ToString();
        }
    }
}
