using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ÜZahlebraten {
    public partial class ÜZahlenraten : Form {
        public ÜZahlenraten() {
            InitializeComponent();
        }
        private Random r = new Random();
        int z = 0;
        int Cnt = 0;

        private void btnErzeugen_Click(object sender, EventArgs e) {
            z = r.Next(1, 100);
            lblResult.Text = "Neue Zahl wurde berechnet. \nBitte geben Sie im Eingabefeld die geratene Zahl ein \nund klicken Sie auf \"Prüfen\"!";
            Cnt = 0;
            lblCounter.Text = "" + Cnt + " Versuche";
            
            //else if (Convert.ToInt32(tbEingabe.Text) == z) {
            //    lblResult.Text = "Gratulation! Die Zahl ist richtig!";
            //}
            //else if (Convert.ToInt32(tbEingabe.Text) > z) {
            //    lblResult.Text = "Die eingegebene Zahl zu groß.";
            //}
            //else if (Convert.ToInt32(tbEingabe.Text) < z) {
            //    lblResult.Text = "Die eingegebene Zahl zu klein.";
            //}
            //else {
            //    lblResult.Text = "Es wurde keine Zahl eingegeben!";
            //}
        }

        //TODO - fix z
        private void btnPruefen_Click(object sender, EventArgs e) {
            if (tbEingabe.Text == "" || tbEingabe.Text == null) {
                lblResult.Text = "<<Bitte geben Sie im Eingabefeld die geratene Zahl ein>>";
            }
            else if (Convert.ToInt32(tbEingabe.Text) == z) {
                lblResult.Text = "Gratulation! Die Zahl ist richtig!";
            }
            else if (Convert.ToInt32(tbEingabe.Text) > z) {
                lblResult.Text = "Die eingegebene Zahl zu groß.";
            }
            else if (Convert.ToInt32(tbEingabe.Text) < z) {
                lblResult.Text = "Die eingegebene Zahl zu klein.";
            }
            else {
                lblResult.Text = "Es wurde keine Zahl eingegeben!";
            }
            Cnt += 1;
            lblCounter.Text = "" + Cnt + " Versuche";
        }
    }
}
