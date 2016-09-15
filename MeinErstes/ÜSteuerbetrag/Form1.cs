using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ÜSteuerbetrag {
    public partial class SalaryCalculator : Form {
        public SalaryCalculator() {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs z) {
            double Salary = Convert.ToDouble(numericUpDown1.Text);
            lblTaxes.Text = "Steuern: ";
            lblNetto.Text = "Netto: ";
            lblYearsSalary.Text = "Jahresgehalt: ";
            lblNettoMonth.Text = "Netto/Monat";
            Salary *= 14; //14 Gehälter
            lblYearsSalary .Text += " " + Salary;

            if (Salary > 90000) {
                double e = (Salary - 90000) * 0.50;
                double d = 30000 * 0.48;
                double c = 29000 * 0.42;
                double b = 13000 * 0.35;
                double a = 7000 * 0.25;
                lblTaxes.Text += " " + (a + b + c + d + e);
                lblNetto.Text += " " + (Salary - (a + b + c + d + e));
                lblNettoMonth.Text += " " + (((Salary - (a + b + c + d + e))/14) - -(((Salary - (a + b + c + d + e)) / 14) * 0.058));
            }
            else if (Salary > 60000) {
                double d = (Salary - 60000) * 0.48;
                double c = 29000 * 0.42;
                double b = 13000 * 0.35;
                double a = 7000 * 0.25;
                lblTaxes.Text += " " + (a + b + c + d);
                lblNetto.Text += " " + (Salary - (a + b + c + d));
                lblNettoMonth.Text += " " + (((Salary - (a + b + c + d)) / 14) - (((Salary - (a + b + c + d)) / 14) * 0.058));
            }
            else if (Salary > 31000) {
                double c = (Salary - 29000) * 0.42;
                double b = 13000 * 0.35;
                double a = 7000 * 0.25;
                lblTaxes.Text += " " + (a + b + c);
                lblNetto.Text += " " + (Salary - (a + b + c));
                lblNettoMonth.Text += " " + (((Salary - (a + b + c)) / 14) - (((Salary - (a + b + c)) / 14)*0.058));
            }
            else if (Salary > 18000) {
                double b = (Salary - 18000) * 0.35;
                double a = 7000 * 0.25;
                lblTaxes.Text += " " + (a + b);
                lblNetto.Text += " " + (Salary - (a + b));
                lblNettoMonth.Text += " " + (((Salary - (a + b)) / 14) - ((Salary - (a + b)) / 14)*0.058);
            }
            else if (Salary > 11000) {
                double a = (Salary - 11000) * 0.25;
                lblTaxes.Text += " " + a;
                lblNetto.Text += " " + (Salary - a);
                lblNettoMonth.Text += " " + ((Salary - a) / 14);
            }
        }
    }
}
