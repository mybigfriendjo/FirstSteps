using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vergleichsoperatoren {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btnAnzeige1_Click(object sender, EventArgs e) {
            double Var1 = 12 - 3;
            double Var2 = 4 * 2.5;

            if (Var1 == Var2) {
                lblAnzeige.Text = "" + (Var1 == Var2);
            }
            else {
                //lblAnzeige.Text = "Var1 == Var2 -> False";
                lblAnzeige.Text = "" + (Var1 == Var2); // "" + variable  wandelt Variable automatisch in string um!
            }
        }

        private void btnAnzeige2_Click(object sender, EventArgs e) {
            double Var1 = 12 - 3;
            double Var2 = 4 * 2.5;

            lblAnzeige.Text = "" + (Var1 == Var2);
        }

        private void btnAnzeige3_Click(object sender, EventArgs e) {
            double Var1 = 12 - 3;
            double Var2 = 4 * 2.5;

            lblAnzeige.Text = "" + ((Var1 != Var2) ? true : false); //trifft zu, dass v1 != v2  -> daher true
        }

        private void button4_Click(object sender, EventArgs e) {
            double Var0 = 8;
            double Var1 = 12 - 3;
            double Var2 = 4 * 2.5;

            lblAnzeige.Text = "" + (Var0 == Var1 || Var0 == Var2 ? true : false);
        }

        private void button5_Click(object sender, EventArgs e) {
            string a, b;
            double d;
            int x;
            b = "Hallo";
            d = 4.6;
            x = -5;
            a = b + " Welt " + d + " " + x + "" + 12;
            lblAnzeige2.Text = a;
            // lblAnzeige.Text = x;
        }
    }
}
