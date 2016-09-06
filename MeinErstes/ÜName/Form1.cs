using System;
using System.Drawing;
using System.Windows.Forms;

namespace ÜName {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btnPosRel_Click(object sender, EventArgs e) {
            btnTest.Location = new Point(btnTest.Location.X + 20, btnTest.Location.Y);
        }

        private void btnPosAbs_Click(object sender, EventArgs e) {
            btnTest.Location = new Point(100, 200);
        }

        private void btnSizeRel_Click(object sender, EventArgs e) {
            btnTest.Size = new Size(btnTest.Size.Width + 20, btnTest.Size.Height + 20);
        }

        private void btnSizeAbs_Click(object sender, EventArgs e) {
            btnTest.Size = new Size(50, 100);
        }

        private void btnAnzeige_Click(object sender, EventArgs e) {
            lblSize.Text = "Position: X: " + btnTest.Location.X + ", Y: " + btnTest.Location.Y + "\n" + "Größe: Breite: " + btnTest.Size.Width + ", Höhe; " + btnTest.Size.Height;
        }
    }
}
