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
    }

    private void optUnterkunft(object sender, EventArgs e) {
        // Unterkunft
        if (optAppartement.Checked)
            AusgabeUnterkunft = "Appartement";
        else if (optPension.Checked)
            AusgabeUnterkunft = "Pension";
        else
            AusgabeUnterkunft = "Hotel";
        Anzeigen();
    }
    private void Anzeigen() {
        lblAnzeige.Text = AusgabeUrlaubsort
        +
        ", " + AusgabeUnterkunft;
    }
}
