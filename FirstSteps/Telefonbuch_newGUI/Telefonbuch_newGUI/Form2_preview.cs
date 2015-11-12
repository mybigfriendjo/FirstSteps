using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telefonbuch_newGUI;

namespace Telefonbuch
{
    public partial class Form2_preview : Form
    {
        public Form2_preview()
        {
            InitializeComponent();
        }

        //Beendet den Frame2 per Doppelklick
        private void Form2_preview_DoubleClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
