using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kontrollkästchen {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            rbBlue.Checked = true; //default value
        }

        private void btnCheck_Click(object sender, EventArgs e) {
            if (checkBox1.Checked) {
                lbl2.Text = "An";
            }
            else {
                lbl2.Text = "Aus";
            }
        }

        private void btnSwitchSwitch_Click(object sender, EventArgs e) {
            checkBox1.Checked =! checkBox1.Checked; //Checkbox(true) =! Checkbox(true) -> sprich Checkbox wird false gesetzt. Funktioniert nur wenn es max 2 Ergebnisse gibt.
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            if (checkBox1.Checked) {
                lbl1.Text = "An";
            }
            else {
                lbl1.Text = "Aus";
            }
        }


        
        private void btnChkColor_Click(object sender, EventArgs e) {
            

            if (rbRed.Checked) {
                lblColorChk.Text = "Rot";
            }
            else if (rbBlue.Checked) {
                lblColorChk.Text = "Blau";
            }
            else {
                lblColorChk.Text = "Grün";
            }
        }

        private void btnSetRed_Click(object sender, EventArgs e) {
            rbRed.Checked = true;
        }

        private void rbRed_CheckedChanged(object sender, EventArgs e) {
            lblColorSwitch.Text = "Rot";
        }

        private void rbGreen_CheckedChanged(object sender, EventArgs e) {
            lblColorSwitch.Text = "Grün";
        }

        private void rbBlue_CheckedChanged(object sender, EventArgs e) {
            lblColorSwitch.Text = "Blau";
        }
    }
}
