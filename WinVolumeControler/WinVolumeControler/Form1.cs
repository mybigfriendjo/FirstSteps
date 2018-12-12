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

        KeyboardHook hook = new KeyboardHook();

        public Form1()
        {
            InitializeComponent();
            

            hook.KeyPressed += hook_KeyPressed;
            /*hook.RegisterHotKey((WinVolumeControler.ModifierKeys.Alt | WinVolumeControler.ModifierKeys.Control), Keys.F9);
            hook.RegisterHotKey((WinVolumeControler.ModifierKeys.Alt | WinVolumeControler.ModifierKeys.Control), Keys.F10);
            hook.RegisterHotKey((WinVolumeControler.ModifierKeys.Alt | WinVolumeControler.ModifierKeys.Control), Keys.F11);
            hook.RegisterHotKey((WinVolumeControler.ModifierKeys.Alt | WinVolumeControler.ModifierKeys.Control), Keys.F12);*/

            //hook.RegisterHotKey(WinVolumeControler.ModifierKeys.None, Keys.F10);
            hook.RegisterHotKey(WinVolumeControler.ModifierKeys.None, Keys.F11);
            //hook.RegisterHotKey(WinVolumeControler.ModifierKeys.None, Keys.F12);
            //hook.RegisterHotKey(WinVolumeControler.ModifierKeys.None, Keys.F9);

            iwas();
        }
        
        /*########################  2do ########################
         * Start Voice meeter BANANA
         * Last Volume / Default Vol if no last Volume (RegistryCurrentUser)
         * Hotkeys 2per Device -> +Vol,-Vol, 
         * onchanged (numUDInputVaio){InputVaio.Volume = numUDInputVaio.Value}
         * 
         * 
         *###################### 2do End ########################*/

            public void iwas()
        {   //Get Audio Devices
            CoreAudioController controller = new CoreAudioController();
            foreach (CoreAudioDevice device in controller.GetPlaybackDevices())
            {   
                if (device.InterfaceName == "VB-Audio VoiceMeeter VAIO")
                {
                    InputVaio = device;
                }
                else if (device.InterfaceName == "VB-Audio VoiceMeeter AUX VAIO")
                {
                    InputVaioAux = device;
                }
            }

            //initial Value
            numUpDownVol1.Value = 30;
            numUpDownVol2.Value = 30;
        }

        private void numUpDownVol1_ValueChanged(object sender, EventArgs e)
        {
            InputVaio.Volume = (double)numUpDownVol1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            InputVaioAux.Volume = (double)numUpDownVol2.Value;
        }

        private void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            if (e.Key == Keys.F9)// && e.Modifier.Equals( Keys.Control | Keys.Alt ))
            {
                if (numUpDownVol1.Value >= 5)
                {
                    numUpDownVol1.Value += -5;  
                }
                else
                {
                    numUpDownVol1.Value = 0;
                }
            }
            else if (e.Key == Keys.F10)// && e.Modifier.Equals(Keys.Control | Keys.Alt))
            {
                if (numUpDownVol1.Value <= 95)
                {
                    numUpDownVol1.Value += 5;
                }
                else
                {
                    numUpDownVol1.Value = 100;
                }
            }
            else if (e.Key == Keys.F11 && e.Modifier.Equals(Keys.Control | Keys.Alt))
            {
                if (numUpDownVol2.Value >= 5)
                {
                    numUpDownVol2.Value += -5;
                }
                else
                {
                    numUpDownVol2.Value = 0;
                }
            }
            else if (e.Key == Keys.F12 && e.Modifier.Equals(Keys.Control | Keys.Alt))
            {
                if (numUpDownVol2.Value <= 95)
                {
                    numUpDownVol2.Value += 5;
                }
                else
                {
                    numUpDownVol2.Value = 100;
                }
            }
        }

        public void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            // Do something here
            hook.Dispose();
        }

        static void OnProcessExit(object sender, EventArgs e)
        {
            // Console.WriteLine("I'm out of here");
        }
    }
}
