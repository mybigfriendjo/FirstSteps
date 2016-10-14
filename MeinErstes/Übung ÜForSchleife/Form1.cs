using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Übung_ÜForSchleife {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        //Teil1
        private void btn1_Click(object sender, EventArgs e) {
            double sum = 0;
            double counter = 0;
            for (double i = 35; i >= 20; i = i - 2.5) {
                sum = i + sum;
                lbl1.Text += i + "\n";
                counter++;
            }
            //Teil2
            counter = sum / counter;
            lbl1.Text += "Summe: " + sum + "\n" + "Mittelwert: " + counter + "\n";
        }
    }
}
