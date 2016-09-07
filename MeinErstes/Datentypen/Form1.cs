using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datentypen {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btnAnzeige_Click(object sender, EventArgs e) {
            /* Ganze Zahlen */
            byte By;
            short Sh;
            int It, Hex;
            long Lg;

            /* Zahlen mit Nachkommastellen */
            float Fl;
            double Db1, Db2, Exp1, Exp2;
            decimal De;

            /* Boolesche Variable, Zeichen,
            Zeichenkette */
            bool Bo;
            char Ch;
            string St;

            /* Ganze Zahlen */
            By = 200;
            Sh = 30000;
            It = 2000000000;
            Lg = 3000000000;
            Hex = 0x3a;

            /* Zahlen mit Nachkommastellen */
            Fl = 1.0f / 7;
            Db1 = 1 / 7;
            Db2 = 1.0 / 7;
            De = 1.0m / 7;
            Exp1 = 1.5e3;
            Exp2 = 1.5e-3;

            /* Boolesche Variable, Zeichen,
            Zeichenkette */
            Bo = true;
            Ch = 'a';
            St = "Zeichenkette";

            lblSize.Text = "byte: " + By + "\n" + "short: " +
            Sh + "\n" +
            "int: " + It + "\n" + "long: " + Lg
            + "\n" +
            "(hexadezimale Zahl): " + Hex +
            "\n\n" +
            "float: " + Fl + "\n" + "double 1:" + Db1 + "\n" +
            "double 2: " + Db2 + "\n" +
            "decimal: " + De + "\n" +
            "(Exponent positiv): " + Exp1 +
            "\n" +
            "(Exponent negativ): " + Exp2 +
            "\n\n" +
            "bool: " + Bo + "\n" +
            "char: " + Ch + "\n" + "string: " +St;


            // Multiple Variable + Value declaration Test

            string i="Letter",o=i,u=o;
            i = "Bomb";
            //lblSize.Text = i + " " + o + " " + u;  //Result = Bomb Letter Letter


            // Numbers can be stored as Hex as well > result is a Number
            int a = 9654;
            int b = 0x742;

            //lblSize.Text = a + " " + b;

            // 2.2 Übung Datentypen

            string Adresse = "Claus Clever \n ";
            int Alter = 32;

            lblSize.Text = "Adresse: " + Adresse + "\n" + "Alter: " + Alter;
        }
    }
}
