using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telefonbuch;

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
        string sNr1;
        string sNr2;
        string sNr3;
        string sNr4;
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

        #endregion

        #region "Sonstige"
        Image iContactImg;
        DateTime dtBirthday;
        bool isFemale;
        #endregion


        #endregion

        #region Buttons
        //Neu button wurde geklick - dadurch werden andere Tabs eingeblendet
        private void btnNew_Click(object sender, EventArgs e)
        {
            this.tabContact.Visible = true;
            this.btnPreview.Visible = true;
            this.btnSave.Visible = true;
            this.labAttention.Visible = false;
        }

        //Kontakte Button. Schaltet Karteikarten ein und Meldung aus.
        private void button1_Click(object sender, EventArgs e)
        {
            tabContact.Visible = true;
            this.labAttention.Visible = false;
        }

        //Läd die Bildauswahl
        private void btnPicture_Click(object sender, EventArgs e)
        {
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

        //Läd die Vorschau
        private void btnPreview_Click(object sender, EventArgs e)
        {
            VarsSpeicher();

            Form2_preview FPre = new Form2_preview();
            FPre.Text += PrepareShowAsPreview(sName, sFirstName, sNickName, sTitle, sShowAsType);

            FPre.label48.Text = PrepareMailPreview(sMail1, sMailType1);
            FPre.label47.Text = PrepareMailPreview(sMail2, sMailType2);

            FPre.label31.Text = PrepareNumbersPreview(cbNumber1.Text, iCC1, iAC1, sNr1);
            FPre.label32.Text = PrepareNumbersPreview(cbNumber2.Text, iCC2, iAC2, sNr2);
            FPre.label33.Text = PrepareNumbersPreview(cbNumber3.Text, iCC3, iAC3, sNr3);
            FPre.label34.Text = PrepareNumbersPreview(cbNumber4.Text, iCC4, iAC4, sNr4);

            FPre.label26.Text = sName;
            FPre.label25.Text = sFirstName;
            FPre.label27.Text = sNickName;
            FPre.label28.Text = sTitle;
            FPre.label45.Text = sStreet;
            FPre.label37.Text = sStreetF;
            FPre.label42.Text = sHouseNumber;
            FPre.label40.Text = sHouseNumberF;
            FPre.label44.Text = sPLZ;
            FPre.label36.Text = sPLZF;
            FPre.label41.Text = sCity;
            FPre.label39.Text = sCityF;
            FPre.label43.Text = sCountry;
            FPre.label35.Text = sCountryF;
            FPre.label38.Text = sFirma;
            FPre.label46.Text = sOther;

            FPre.label30.Text = dtBirthday.ToLongDateString();
            FPre.previewpictureBox1.Image = pictureBox1.Image;

            if (isFemale == true) FPre.label29.Text = "weiblich";
            else FPre.label29.Text = "männlich";

            FPre.Show();
        }
        #endregion

        #region Hilfsfunktionen
        //Löschfunktion für Löschbuttons die mit "sender" den button ausgibt und die jeweilige switch anweisung ausführt.
        private void btnDel(object sender, EventArgs e)
        {
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

        //Allgemeines -> Anzeigen als: Hier wird die Namenszusammenstellung gemacht.
        private void cobShowAs_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cobShowAs.SelectedIndex)
            {
                case 0:
                    this.labExample.Text = "Beispiel: " + this.tbName.Text + ", " + this.tbFirstName.Text;
                    sShowAsType = "NV";
                    break;
                case 1:
                    this.labExample.Text = "Beispiel: " + this.tbFirstName.Text + tbName.Text;
                    sShowAsType = "VN";
                    break;
                case 2:
                    if (this.tbNickname.Text != null && this.tbNickname.Text != "")
                    {
                        this.labExample.Text = "Beispiel: " + this.tbName.Text + ", " + this.tbFirstName.Text + " (" + this.tbNickname.Text + ")";
                        sShowAsType = "NVS";
                    }
                    else
                    {
                        this.labExample.Text = "Beispiel: " + this.tbName.Text + ", " + this.tbFirstName.Text;
                        sShowAsType = "NV";
                    }
                    break;
                case 3:
                    this.labExample.Text = "Beispiel: " + this.tbTitle.Text + " " + this.tbName.Text + ", " + this.tbFirstName.Text;
                    sShowAsType = "TNV";
                    break;
                default:
                    this.labExample.Text = "Beispiel: " + this.tbName.Text + ", " + this.tbFirstName.Text;
                    sShowAsType = "NV";
                    break;

            }
        }

        //überprüft ob ein "@" in der Mail enthalten ist oder das Feld leer ist.
        string MailStringChecken(string sMail, string source)
        {
            if (sMail != "")
            {
                if (sMail.IndexOf("@") == -1)
                {
                    MessageBox.Show("Achtung! Die Emailadresse ist ungültig da sie kein \"@\" enthält!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return sMail;
                }
                else
                {
                    return sMail;
                }
            }
            else
            {
                //TODO Alternative zu source? (Um 2 Meldungen zu vermeiden) 
                if (sMail1 == "" & sMail2 == "")
                { if (source == "sMail1" )
                  {
                        MessageBox.Show("Achtung! Bitte geben Sie eine Emailadresse ein!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  }
                }
                else
                {
                   
                }
                return sMail;
            }
        }

        //Speichert alle Inhalte für das preview
        void VarsSpeicher()
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
                if (tbAC3.Text != "") iAC3 = int.Parse(tbAC3.Text);
                if (tbAC4.Text != "") iAC4 = int.Parse(tbAC4.Text);


                //Gleiche Funktion wie oben jedoch für die Nummernfelder rechts, und auf eine Zeile reduziert.
            }
            catch (Exception)
            {
                MessageBox.Show("Achtung! Bitte geben Sie nur Ziffern für die Telefonnummer ein!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            try
            {
                dtBirthday = DateTime.Parse(tbBirthday.Text);
            }
            catch
            {
                MessageBox.Show("Achtung! Bitte geben Sie ein gültiges Geburtsdatum ein!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            sName = tbName.Text;
            sFirstName = tbFirstName.Text;
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
            sMail1 = MailStringChecken(tbMail1.Text, "sMail1");
            sMail2 = MailStringChecken(tbMail2.Text, "sMail2");
            sMailType1 = cbMail1.Text;
            sMailType2 = cbMail2.Text;
            sOther = tbOthers.Text;
                   
            sNr1 = tbNumber1Part2.Text;
            sNr2 = tbNumber2Part2.Text;
            sNr3 = tbNumber3Part2.Text;
            sNr4 = tbNumber4Part2.Text;

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

        //Nimmt die Werte der Namenszusammenstellung und gibt sie als string retour für den Titel von Form2 retour
        string PrepareShowAsPreview(string sName, string sFirstName, string sNickName, string sTitle, string sShowAs)
        {//TODO - kein if im case möglich?
            if (sName != "" & sFirstName != "")
            {
                switch (sShowAs)
                {
                    case "NV":
                        return sName + ", " + sFirstName;
                    case "VN":
                        return sFirstName + ", " + sName;
                    case "NVS":
                        return sFirstName + ", " + sName + ", (" + sNickName + ")";
                    case "TVN":
                        return sTitle + ", " + ", " + sFirstName + ", " + sName;
                    default:
                        //if (sName != "" || sFirstName != "")
                        //{ return sName + ", " + sFirstName; }
                        //else { return sName + sFirstName; }
                        return sName + ", " + sFirstName;
                }
            }
            else
            {
                return sName + sFirstName;
            }
        }

        //Prüft ob Mail befüllt ist und übergibt string.
        string PrepareMailPreview(string sMail, string sMailType)
        {
            if (sMail != "")
            {
                return sMail + " ( " + sMailType + " ) ";
            }
            else
            {
                return "----";
            }
        }

        //Prüft ob Nummer und Ländervorwahl befüllt sind und übergibt string.
        string PrepareNumbersPreview(string NumberType, int CC, int AC, string Number)
        {
            if ((AC.ToString() == "" || AC == 0) & (Number == "" || Number == "0" ))
            {
                return "----";
            }
            else
            {
                return "+" + CC + " " + AC + " / " + Number + " (" + NumberType + ")";
            }
        }
        #endregion
    }
}