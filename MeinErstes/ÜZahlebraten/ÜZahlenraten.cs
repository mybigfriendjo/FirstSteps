using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ÜZahlenraten {
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
        }

        //TODO - String einfügen (Ctrl+v) unterbinden
        private void numericsOnly(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)){ // && e.KeyChar != '.' && e.KeyChar != ',') { //lässt ctrl, 0-9, . und , zu
                e.Handled = true;
            }
        }
        
        private void btnPruefen_Click(object sender, EventArgs e) {
            tbEingabe.KeyPress += numericsOnly; //Only records digital keystrokes in the control!
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
                lblResult.Text = "Es wurde keine Zahl eingegeben!"; //TODO - klappt nicht - Text is exception -> exceptionhandling?
            }
            Cnt += 1;
            lblCounter.Text = "" + Cnt + " Versuche";
        }
    }
}
