using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Übung_ÜHalbierung___While {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e) {
            lbl1.Text = "";
            double Textvalue = Convert.ToDouble(tb1.Text);
            while ( Textvalue > 0.001) {
                Textvalue = Textvalue / 2;
                lbl1.Text += "" + Textvalue + "\n";
            }
        }
    }
}
