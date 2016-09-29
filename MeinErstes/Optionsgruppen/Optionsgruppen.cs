using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optionsgruppen {
    public partial class Optionsgruppen : Form {
        public Optionsgruppen() {
            InitializeComponent();
        }

        private string AusgabeUrlaubsort = "Berlin";
        private string AusgabeUnterkunft = "Pension";
        private void optUrlaubsort_CheckedChanged(object sender, EventArgs e) {
            // Urlaubsort
            if (rbBerlin.Checked)
                AusgabeUrlaubsort = "Berlin";
            else if (rbParis.Checked)
                AusgabeUrlaubsort = "Paris";
            else
                AusgabeUrlaubsort = "Rom";
            lblDisplay.Text = AusgabeUrlaubsort + ", " + AusgabeUnterkunft;
        }
        private void optUnterkunft_CheckedChanged(object sender, EventArgs e) {
            // Unterkunft
            if (rbAppartement.Checked)
                AusgabeUnterkunft = "Appartement";
            else if (rbPension.Checked)
                AusgabeUnterkunft = "Pension";
            else
                AusgabeUnterkunft = "Hotel";
            lblDisplay.Text = AusgabeUrlaubsort + ", " + AusgabeUnterkunft;
        }
    }
}
