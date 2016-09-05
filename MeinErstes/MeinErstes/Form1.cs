using System;
using System.Windows.Forms;

namespace MeinErstes {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btnHallo_Click(object sender, EventArgs e) {
            lblAnzeige.Text = "Hallo";
        }

        private void btnEnde_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
