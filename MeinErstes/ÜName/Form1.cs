using System;
using System.Drawing;
using System.Windows.Forms;

namespace ÜName {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            LabelReferesh();
        }

        private void btnPosRel_Click(object sender, EventArgs e) {
            btnTest.Location = new Point(btnTest.Location.X + 20, btnTest.Location.Y);
            LabelReferesh();
            btnTest.BackColor = Color.Maroon;
        }

        private void btnPosAbs_Click(object sender, EventArgs e) {
            btnTest.Location = new Point(100, 200);
            LabelReferesh();
            btnTest.BackColor = Color.FromArgb(192, 10, 23);
        }

        private void btnSizeRel_Click(object sender, EventArgs e) {
            btnTest.Size = new Size(btnTest.Size.Width + 20, btnTest.Size.Height + 20);
            LabelReferesh();
            //Changes Control Background Color
            btnTest.BackColor = Color.FromArgb(192, 50, 200);
        }

        private void btnSizeAbs_Click(object sender, EventArgs e) {
            btnTest.Size = new Size(50, 100);
            LabelReferesh();
            //Changes Text Color
            btnTest.ForeColor = Color.Fuchsia;
        }

        private void btnAnzeige_Click(object sender, EventArgs e) {
            LabelReferesh();
            //Sets Form Background Color.
            BackColor = Color.Goldenrod;
        }

        private void LabelReferesh() { 
            lblSize.Text = "Position: X: " + btnTest.Location.X + ", Y: " + btnTest.Location.Y + "\n" + "Größe: Breite: " + btnTest.Size.Width + ", Höhe; " + btnTest.Size.Height;
        }
    }
}
