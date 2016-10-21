using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Listenfeld {
    public partial class Listenfeld : Form {
        public Listenfeld() {
            InitializeComponent();
        }

        private void Listenfeld_Load(object sender, EventArgs e) {
            lbTest.Items.Add("Spaghetti");
            lbTest.Items.Add("Grüne Nudeln");
            lbTest.Items.Add("Tortellini");
            lbTest.Items.Add("Pizza");
            lbTest.Items.Add("Lasagne");
            string Placeholder = "";
            for (int i = 0; i < lbTest.Items.Count; i++) {
                Placeholder += "" + lbTest.Items[i] + "\n";
            }
            lblCnt.Text += "  " + lbTest.Items.Count + "\n\n" + Placeholder; 
        }

        private void lbTest_SelectedIndexChanged(object sender, EventArgs e) {
            lblSelectedIndex.Text = "Aktuelles Objekt(e): " + lbTest.SelectedItems + "(" + lbTest.SelectedIndex + ")";
        }
    }
}
