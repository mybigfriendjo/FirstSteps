using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MethodeOhneEreignis {
    public partial class MethodeOhneEreignis : Form {
        public MethodeOhneEreignis() {
            InitializeComponent();
        }

        string AusgabeUnterkunft = "";
        string AusgabeUrlaubsort = "";
        private void optUnterkunft(object sender, EventArgs e) {
            // Unterkunft
            if (rbAppartement.Checked) {
                AusgabeUnterkunft = "Appartement";
            } else if (rbPension.Checked) {
                AusgabeUnterkunft = "Pension";
            } else {
                AusgabeUnterkunft = "Hotel";
            }
            Anzeigen();
        }
        private void Anzeigen() {
            lblDisplay.Text = AusgabeUrlaubsort + ", " + AusgabeUnterkunft;
        }
    }
}
