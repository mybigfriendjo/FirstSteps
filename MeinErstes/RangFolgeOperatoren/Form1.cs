using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RangFolgeOperatoren {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btnAnzeige1_Click(object sender, EventArgs e) {

            double a = 5;
            double b = 10;

            lblAnzeige.Text = "" + (a > 0 && b != 10); //False


            //2
            //double a = 5;
            //double b = 10;
            lblAnzeige.Text = "" + (a > 0 || b != 10); //True

            
            //3
            double z = 10;
            double w = 100;
            lblAnzeige.Text = "" + (z != 0 || z > w || w-z == 90); //True

            
            //4
            //double z = 10;
            //double w = 100;
            lblAnzeige.Text = "" + (z == 11 && z > w || w - z == 90); //True


            //5
            double x = 1.0;
            double y = 5.7;
            lblAnzeige.Text = "" + (x >= .9 && y <= 5.8); //True >= vor &&

              
            //6
            //double x = 1.0;
            //double y = 5.7;
            lblAnzeige.Text = "" + (x >= .9 && !(y <= 5.8)); //False
            

            //7
            double n1 = 1;
            double n2 = 17;
            lblAnzeige.Text = "" + (n1 > 0 && n2 > 0 || n1 > n2 && n2 != 17); //True
            

            //8
            //double n1 = 1;
            //n2 = 17;
            lblAnzeige.Text = "" + (n1 > 0 && (n2 > 0 || n1 > n2) && n2 != 17); //False
        }

        private void btnAnzeige2_Click(object sender, EventArgs e) {

        }

        private void btnAnzeige3_Click(object sender, EventArgs e) {

        }

        private void button4_Click(object sender, EventArgs e) {

        }

        private void button5_Click(object sender, EventArgs e) {

        }
    }
}
