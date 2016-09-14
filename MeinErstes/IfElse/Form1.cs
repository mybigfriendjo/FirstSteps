using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IfElse {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e) {
            int x = (int)numericUpDown1.Value;
            lbl3.Text = "";
        
            if (x > 0) {
                lbl3.Text = "x ist größer als 0";

                numericUpDown1.BackColor = Color.LightGreen;
            }
        }

        private void btn2_Click(object sender, EventArgs e) {
            int x = (int)numericUpDown1.Value;

            if (x > 0) {
                lbl3.Text = "x ist größer als 0";
                numericUpDown1.BackColor = Color.LightGreen;
            }
            else {
                lbl3.Text = "x ist kleiner als 0 oder gleich 0";
                numericUpDown1.BackColor = Color.LightBlue;
            }
        }

        private void btn3_Click(object sender, EventArgs e) {
            int x = (int)numericUpDown1.Value;

            lbl4.Text = x > 0 ? "x > 0" : "x <= 0";
            numericUpDown1.BackColor = x > 0 ? Color.LightGreen : Color.LightBlue;
        }

        private void btn4_Click(object sender, EventArgs e) {
            int x = (int)numericUpDown1.Value;
            int y = (int)numericUpDown2.Value;
            numericUpDown1.BackColor = Color.White;
            if (x > 0 && y > 0) {
                lbl3.Text = "x und y sind größer als 0";
            }
            else {
                lbl3.Text = "Mind. eine der beiden" + " Zahlen ist nicht größer als 0";
            }
        }
    }
}
