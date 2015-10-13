using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telefonbuch_newGUI
{
    public partial class Phonebook : Form
    {
        public Phonebook()
        {
            InitializeComponent();
        }

        #region "Variabeln"

        DateTime dBirthday;
        bool isFemale;
        #region "integer"

        int iCC1;
        int iCC2;
        int iCC3;
        int iCC4;
        int iAC1;
        int iAC2;
        int iAC3;
        int iAC4;
        int iNr1;
        int iNr2;
        int iNr3;
        int iNr4;

        #endregion
        #endregion


        private void btnNew_Click(object sender, EventArgs e)
        {//Neu button wurde geklick
            this.tabContact.Visible = true;
            this.btnPreview.Visible = true;
            this.btnSave.Visible = true;
            this.labAttention.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {//Schaltet Karteikarten ein und Meldung aus.
            tabContact.Visible = true;
            this.labAttention.Visible = false;
        }

        private void cobShowAs_SelectedIndexChanged(object sender, EventArgs e)
        {//Combobox ShowAs - Auswahl geändert
            switch (this.cobShowAs.SelectedIndex)
            {
                case 0:
                    this.labExample.Text = "Beispiel: " + this.tbName.Text + ", " + this.tbFirstname.Text;
                    break;
                case 1:
                    this.labExample.Text = "Beispiel: " + this.tbFirstname.Text + tbName.Text;
                    break;
                case 2:
                    if(this.tbNickname.Text != null && this.tbNickname.Text != "")
                    {
                        this.labExample.Text = "Beispiel: " + this.tbName.Text + ", " + this.tbFirstname.Text + " (" + this.tbNickname.Text + ")";
                    }
                    else
                    {
                        this.labExample.Text = "Beispiel: " + this.tbName.Text + ", " + this.tbFirstname.Text;
                    }   
                    break;
                case 3:
                    this.labExample.Text = "Beispiel: " + this.tbTitle.Text + " " + this.tbName.Text + ", " + this.tbFirstname.Text;
                    break;
                default:
                    this.labExample.Text = "Beispiel: " + this.tbName.Text + ", " + this.tbFirstname.Text;
                    break;
                    
            }
        }

        private void btnPicture_Click(object sender, EventArgs e)
        {//Bildauswahl
            OpenFileDialog OF = new OpenFileDialog();
            OF.Title = "Bitte Bild auswählen...";
            OF.Multiselect = false;
            OF.Filter = "Bilder|*.jpg;*.png;*.bmp;*.ico|PNG-Bilder|*.png|All|*.*"; //Bilder = 0,  PNG-Bilder=1, All=2
            OF.FilterIndex = 0; //Stadardauswahl = Bilder

            if (OF.ShowDialog() == DialogResult.OK)
            {//Of.showdialog Ruft auswahlfenster ab und gibt Ok oder abbruch zurück
                this.pictureBox1.Image = Image.FromFile(OF.FileName);
            }
            else
            {// Bei abbrechen setze folgendes Bild:
                //this.pictureBox1.Image = Telefonbuch.Properties.Resources.turtle;
            }
        }

        private void btnDel(object sender, EventArgs e)
        {//Löschfunktion für Löschbuttons die mit "sender" den button ausgibt und die jeweilige switch anweisung ausführt.
            Button usedBtn = new Button();
            usedBtn = (Button)sender;

            switch (usedBtn.Name)
            {
                case "btnDelNr1":
                    this.cbNumber1.SelectedIndex = -1;
                    this.mtbCountryCode1.Text = "43";
                    this.tbNumber1.Text = "";
                    this.tbNumber1Part2.Text = "";
                    break;
                case "btnDelNr2":
                    this.cbNumber2.SelectedIndex = -1;
                    this.mtbCountryCode2.Text = "43";
                    this.tbNumber2.Text = "";
                    this.tbNumber2Part2.Text = "";
                    break;
                case "btnDelNr3":
                    this.cbNumber3.SelectedIndex = -1;
                    this.mtbCountryCode3.Text = "43";
                    this.tbNumber3.Text = "";
                    this.tbNumber3Part2.Text = "";
                    break;
                case "btnDelNr4":
                    this.cbNumber4.SelectedIndex = -1;
                    this.mtbCountryCode4.Text = "43";
                    this.tbNumber4.Text = "";
                    this.tbNumber4Part2.Text = "";
                    break;
                case "btnDelMail1":
                    this.cbMail1.SelectedIndex = -1;
                    this.tbMail1.Text = "";
                    break;
                case "btnDelMail2":
                    this.cbMail2.SelectedIndex = -1;
                    this.tbMail2.Text = "";
                    break;
                //default:
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            //try and catch - string in intfeld wirft einen Fehler, dieser wird abgefangen und als Messagebox wiedergegeben.
            try
            {
                if (this.tbNumber1.Text != "")
                {
                    iNr1 = int.Parse(this.tbNumber1.Text);
                }
                if (this.tbNumber2.Text != "")
                {
                    iNr2 = int.Parse(this.tbNumber2.Text);
                }
                if (this.tbNumber3.Text != "")
                {
                    iNr3 = int.Parse(this.tbNumber3.Text);
                }
                if (this.tbNumber4.Text != "")
                {
                    iNr4 = int.Parse(this.tbNumber4.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Achtung! Bitte geben Sie nur Ziffern für die Telefonnummer ein!", "Fehler!",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}