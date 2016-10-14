using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForSchleife {
    public partial class ForSchleife : Form {
        public ForSchleife() {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e) {
            lbl1.Text = "";
            for (int i = 1; i <= 7; i++) {
                lbl1.Text += i + "\n";
            }
        }

        private void btn2_Click(object sender, EventArgs e) {
            lbl2.Text = "";
            for (int i = 3; i <= 11; i = i + 2) {
                lbl2.Text += i + "\n";
            }
        }

        private void btn3_Click(object sender, EventArgs e) {
            lbl3.Text = "";
            for (int i = 7; i >= 3; i-- ) {
                lbl3.Text += i + "\n";
            }
        }

        private void btn4_Click(object sender, EventArgs e) {
            lbl4.Text = "";
            for (double d = 3.5; d <= 7.5; d = d + 1.5) {
                lbl4.Text += d + "\n";
            }
        }

        private void btn5_Click(object sender, EventArgs e) {
            lbl5.Text = "";
            for (int i = 3; i <= 20; i++ ) {
                if (i >= 5 && i <= 7) {
                    continue;
                }
                if (i >= 11) {
                    break;
                }
                lbl5.Text += i + "\n";
            }
        }
    }
}
