using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Alarm
{
    public partial class Alarm : Form
    {
        public Alarm()
        {
            InitializeComponent();
        }

        private void tbNote_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.tbNote, "Please insert your Note that should be attatched to the Alarm.");
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string Space = new string (' ', 20);
            
            lbHistory.Items.Add(string.Format("{0:00}", numAlarmHour.Value) + ":" +  numAlarmMin.Value.ToString("00") + Space + tbNote.Text + "");
            File.WriteAllText("C:\\Temp\\AlarmHistory.db",lbHistory.Items.ToString()); //Foreach Item in lbHistory Append String to VarExport
        }

        //TODO
        /*
         ~~(dann kann Alarm und Countdown nicht gleichzeigig genutzt werden) Chkbox Alarm steuert Schreibschutz auf - numAlarmHour + numAlarmMin + lbHistory
         SoundPath
         YoutubePath
         Store-List
         Load-List (ToRight 5, Var1) + (All - ToRight 25 = Var2)

        
                  
         
         */
    }
}
