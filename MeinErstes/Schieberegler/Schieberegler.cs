using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schieberegler {
    public partial class Schieberegler : Form {
        public Schieberegler() {
            InitializeComponent();
        }
        private void Schieberegler_Load(object sender, EventArgs e) {
            FarbeAnzeigen();
        }
        private void FarbeAnzeigen() {
            panel1.BackColor = Color.FromArgb(trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value);
            lbl2.Text = "" + trackBarRed.Value;
            lbl4.Text = "" + trackBarGreen.Value;
            lbl6.Text = "" + trackBarBlue.Value;
        }
        private void WertGeändert(object sender, EventArgs e) {
            FarbeAnzeigen();
        }
    }
}
