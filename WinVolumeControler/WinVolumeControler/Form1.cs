using AudioSwitcher.AudioApi.CoreAudio;
using System.Windows.Forms;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinVolumeControler
{
    public partial class Form1 : Form
    {
        // ---Variables---
        string DeviceName = "";
        CoreAudioDevice InputVaio;
        CoreAudioDevice InputVaioAux;

        public Form1()
        {
            InitializeComponent();
            iwas();
        }

        /*CoreAudioDevice defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
            Debug.WriteLine("Current Volume:" + defaultPlaybackDevice.Volume);
            defaultPlaybackDevice.Volume = (double)numUpDownVol1.Value;*/

        /*########################  2do ########################
         * Start Voice meeter BANANA
         * Last Volume / Default Vol if no last Volume (RegistryCurrentUser)
         * Hotkeys 2per Device -> +Vol,-Vol, 
         * onchanged (numUDInputVaio){InputVaio.Volume = numUDInputVaio.Value}
         * 
         * 
         *###################### 2do End ########################*/

        public void iwas()
        {
            CoreAudioController controller = new CoreAudioController();
            foreach (CoreAudioDevice device in controller.GetPlaybackDevices())
            {
                // Console.WriteLine(device.FullName + " " + device.InterfaceName);
                DeviceName = DeviceName + device.InterfaceName + "\n\n";

                if (device.InterfaceName == "VB-Audio VoiceMeeter VAIO")
                {
                    InputVaio = device;
                }
                else if (device.InterfaceName == "VB-Audio VoiceMeeter AUX VAIO")
                {
                    InputVaioAux = device;
                }
            }
            Debug.WriteLine(DeviceName);

            //initial Value
            numUpDownVol1.Value = 30;
            numUpDownVol2.Value = 30;

            InputVaio.Volume = 30;
            InputVaioAux.Volume = 30;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            iwas();
        }

        private void numUpDownVol1_ValueChanged(object sender, EventArgs e)
        {
            InputVaio.Volume = (double)numUpDownVol1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            InputVaioAux.Volume = (double)numUpDownVol2.Value;
        }
    }
}
