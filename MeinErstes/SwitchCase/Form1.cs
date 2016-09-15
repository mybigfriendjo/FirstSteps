using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwitchCase {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            int x = (int)numericUpDown1.Value;
            switch (x) {
                case 1:
                case 3:
                case 5:
                case 7:
                case 9:
                    label1.Text = "einstellig, ungerade";
                    break;
                case 2:
                case 4:
                case 6:
                case 8:
                    label1.Text = "einstellig, gerade";
                    break;
                case 0:
                    label1.Text = "Zero";
                    break;
                default:
                    label1.Text = "zweistellig oder mehrstellig";
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            //string s = "Nizza";
            string s = textBox1.Text;
            label2.Text = "";
            switch (s) {
                case "France":
                    label2.Text += "Frankreich\n";
                    break;
                case "Bordeaux":
                    label2.Text += "Atlantik\n";
                    goto case "France";
                case "Nizza":
                    label2.Text += "Cote d'Azur\n";
                    goto case "France";
                default:
                    label2.Text += "restliche Fälle\n";
                    break;
            }
        }   
    }
}
