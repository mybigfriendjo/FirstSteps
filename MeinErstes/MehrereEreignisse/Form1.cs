using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MehrereEreignisse {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            Console.Write ("i belive im button 1\n");
            MessageBox.Show("i belive im button 1\n", "MsgBoxName", MessageBoxButtons.OK);
        }

        private void optFarbeGewechselt(object sender, EventArgs e) {
            if (optFarbeRot.Checked)
                label1.Text = "Rot";
            else if (optFarbeGrün.Checked)
                label1.Text = "Grün";
            else
                label1.Text = "Blau";
        }
    }
}
