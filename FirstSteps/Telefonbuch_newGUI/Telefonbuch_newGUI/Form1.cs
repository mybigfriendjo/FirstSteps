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

        #region "String"
        string sNumberType1 = "";
        string sNumberType2 = "";
        string sNumberType3 = "";
        string sNumberType4 = "";
        string sMailType1 = "";
        string sMailType2 = "";
        string sShowAsType = "NV";
        string sName = "";
        string sFirstName = "";
        string sNickName = "";
        string sTitle = "";
        string sStreet = "";
        string sStreetF = "";
        string sHouseNumber = "";
        string sHouseNumberF = "";
        string sPLZ = "";
        string sPLZF = "";
        string sCity = "";
        string sCityF = "";
        string sCountry = "";
        string sCountryF = "";
        string sFirma = "";
        string sMail1 = "";
        string sMail2 = "";
        string sOther = "";
        #endregion
       
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

        #region "Sonstige"
        Image iContactImg;
        DateTime dtBirthday;
        bool isFemale;
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
        {//Kontakte Button. Schaltet Karteikarten ein und Meldung aus.
            tabContact.Visible = true;
            this.labAttention.Visible = false;
        }

        private void cobShowAs_SelectedIndexChanged(object sender, EventArgs e)
        {//Vorschau. Combobox ShowAs - Auswahl geändert
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
                    this.tbCC1.Text = "43";
                    this.tbAC1.Text = "";
                    this.tbNumber1Part2.Text = "";
                    break;
                case "btnDelNr2":
                    this.cbNumber2.SelectedIndex = -1;
                    this.tbCC2.Text = "43";
                    this.tbAC2.Text = "";
                    this.tbNumber2Part2.Text = "";
                    break;
                case "btnDelNr3":
                    this.cbNumber3.SelectedIndex = -1;
                    this.tbCC3.Text = "43";
                    this.tbAC3.Text = "";
                    this.tbNumber3Part2.Text = "";
                    break;
                case "btnDelNr4":
                    this.cbNumber4.SelectedIndex = -1;
                    this.tbCC4.Text = "43";
                    this.tbAC4.Text = "";
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
                if (this.tbAC1.Text != "")
                {
                    iAC1 = int.Parse(this.tbAC1.Text);
                }
                if (this.tbAC2.Text != "")
                {
                    iAC2 = int.Parse(this.tbAC2.Text);
                }
                if (this.tbAC3.Text != "")
                {
                    iAC3 = int.Parse(this.tbAC3.Text);
                }
                if (this.tbAC4.Text != "")
                {
                    iAC4 = int.Parse(this.tbAC4.Text);
                }

                //Gleiche Funktion wie oben jedoch für die Nummernfelder rechts, und auf eine Zeile reduziert.
                if (this.tbNumber1Part2.Text != "") iNr1 = int.Parse(this.tbNumber1Part2.Text);
                if (this.tbNumber2Part2.Text != "") iNr2 = int.Parse(this.tbNumber2Part2.Text);
                if (this.tbNumber3Part2.Text != "") iNr3 = int.Parse(this.tbNumber3Part2.Text);
                if (this.tbNumber4Part2.Text != "") iNr4 = int.Parse(this.tbNumber4Part2.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Achtung! Bitte geben Sie nur Ziffern für die Telefonnummer ein!", "Fehler!",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            try
            {
                dtBirthday = DateTime.Parse(tbBirthday.Text);
            }
            catch
            {
                MessageBox.Show("Achtung! Bitte geben Sie ein gültiges Geburtsdatum ein!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            sName = tbName.Text;
            sFirstName = tbFirstname.Text;
            sNickName = tbNickname.Text;
            sTitle = tbTitle.Text;
            sStreet = tbStreet.Text;
            sStreetF = tbStreet.Text;
            sHouseNumber = tbNr.Text;
            sHouseNumberF = tbNrF.Text;
            sPLZ = tbCode.Text;
            sPLZF = tbCodeF.Text;
            sCity = tbCity.Text;
            sCityF = tbCityF.Text;
            sCountry = tbCountry.Text;
            sCountryF = tbCountryF.Text;
            sFirma = tbCompany.Text;
            sMail1 = tbMail1.Text;
            sMail2 = tbMail2.Text;
            sOther = tbOthers.Text;

            if (rbFemale.Checked == true)
            {
                isFemale = true;
            }
            else { isFemale = false; }

            //Text to int
            iCC1 = int.Parse(tbCC1.Text); 
            iCC2 = int.Parse(tbCC2.Text);
            iCC3 = int.Parse(tbCC3.Text);
            iCC4 = int.Parse(tbCC4.Text);
 
         }
    }
}