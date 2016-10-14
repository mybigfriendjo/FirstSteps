using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhileDoWhileSchleifen {
    public partial class WhileDoWhileSchleifen : Form {
        public WhileDoWhileSchleifen() {
            InitializeComponent();
        }

        private Random r = new Random();

        private void button1_Click(object sender, EventArgs e) {
            int summe = 0, z;
            lbl1.Text = "";

            while(summe < 20) {
                z = r.Next(1, 7);
                summe = summe + z;
                lbl1.Text += summe + "\n";
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            int summe = 0, z;
            lbl1.Text = "";
            do {
                z = r.Next(1, 7);
                summe = summe + z;
                lbl1.Text += summe + "\n";
            }
            while (summe < 20);
        }
    }
}
