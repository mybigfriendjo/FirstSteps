using AudioSwitcher.AudioApi.CoreAudio;
using System.Windows.Forms;
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace WinVolumeControler
{
    public partial class Form1 : Form
    {
        // ---Variables---
        private CoreAudioController controller = new CoreAudioController();
        private KeyboardHook hook = new KeyboardHook();
        private KeysConverter kc = new KeysConverter();

        private bool controlPressed;
        private bool altPressed;

        public Form1()
        {
            hook.OnKeyPressed += hook_KeyPressed;
            hook.OnKeyUnpressed += hook_KeyUnpressed;
            hook.HookKeyboard();
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;

            setVolume();
            
        }

        //*########################  2do ########################
        // * 
        // *###################### 2do End ########################


        private void hook_KeyUnpressed(object sender, Keys e)
        {
            switch (e)
            {
                case Keys.Control:
                case Keys.LControlKey:
                case Keys.RControlKey:
                    controlPressed = false;
                    break;
                case Keys.Alt:
                case Keys.LMenu:
                    altPressed = false;
                    break;
            }
        }

        private void hook_KeyPressed(object sender, Keys e)
        {

            double currentVolume;

            switch (e)
            {
                case Keys.Control:
                case Keys.LControlKey:
                case Keys.RControlKey:
                    controlPressed = true;
                    break;
                case Keys.Alt:
                case Keys.LMenu:
                    altPressed = true;
                    break;
                case Keys.F9:
                    if (controlPressed && altPressed)
                    {
                        currentVolume = controller.DefaultPlaybackDevice.Volume - 10;
                        if (currentVolume < 0)
                        {
                            currentVolume = 0;
                        }

                        controller.DefaultPlaybackDevice.Volume = currentVolume;
                    }
                    break;
                case Keys.F10:
                    if (controlPressed && altPressed)
                    {
                        currentVolume = controller.DefaultPlaybackDevice.Volume + 10;
                        if (currentVolume > 100)
                        {
                            currentVolume = 100;
                        }

                        controller.DefaultPlaybackDevice.Volume = currentVolume;
                    }
                    break;
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            hook.UnHookKeyboard();
        }

        // ################################ (End) ofTheHook ################################

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string strClassName, string strWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

        static void setVolume()
        {
            //var hWnd = FindWindow("SpotifyMainWindow", "Spotify");
            var hWnd = FindWindow("StarCraft II", "StarCraft II");
            if (hWnd == IntPtr.Zero)
                return;

            uint pID;
            GetWindowThreadProcessId(hWnd, out pID);
            if (pID == 0)
                return;

            VolumeMixer.SetApplicationVolume((int)pID, 50f);
        }
    }      
}
    
