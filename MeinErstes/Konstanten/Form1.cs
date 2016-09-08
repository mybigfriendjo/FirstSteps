using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Konstanten {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private const int MaxWert = 75;
        private const string Eintrag = "Picture";

        private void btnKonstanten_Click(object sender, EventArgs e) {
            const int MaxWert = 55;
            const int MinWert = 5;

            lblAnzeige.Text = (MaxWert - MinWert) / 2 + "\n" + Eintrag;
        }

        //Enumerationen Ab. 2.8 + 2.9
        private enum Farbe : int {
            Rot = 1, Gelb = 2, Blau = 3
        }
        private void btnEnumeration1_Click(object sender, EventArgs e) {
            lblAnzeige.Text = "Farbe: " +
            Farbe.Gelb +
            " " + (int)Farbe.Gelb;
        }
        private void btnEnumeration2_Click_1(object sender, EventArgs e) {
            lblAnzeige.Text = "Sonntag: " +
            DayOfWeek.Sunday + " " +
            (int)DayOfWeek.Sunday + "\n" +
            "Samstag: " +
            DayOfWeek.Saturday + " " +
            (int)DayOfWeek.Saturday;
        }
    }
}
