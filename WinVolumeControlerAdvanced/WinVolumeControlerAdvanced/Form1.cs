using AudioSwitcher.AudioApi.CoreAudio;
using System.Windows.Forms;
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Diagnostics;

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

        
        // ---Dll Imports---
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string strClassName, string strWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);


        public Form1()
        {
            hook.OnKeyPressed += hook_KeyPressed;
            hook.OnKeyUnpressed += hook_KeyUnpressed;
            hook.HookKeyboard();

            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

          
            ////setVolume();
            //Application.Exit();
        }

        // *########################  2do ########################
        // * create handleList

        // *###################### 2do End ########################

        private List<Process> getProcessByName (string processName)
        {
            var allProcesses = Process.GetProcesses();
            List<Process> chromeProcessList = new List<Process>();
            foreach (Process singleProcess in allProcesses)
            {
                if (singleProcess.ProcessName .Equals(processName,StringComparison.OrdinalIgnoreCase)) //.Equal is another option for stings with aditional options like CaseInsensitive(OrdinalIgnoreCase)
                {
                    chromeProcessList.Add(singleProcess);
                }
            }
            return chromeProcessList;
        }

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
                case Keys.F9: //App1 lower Vol
                    if (controlPressed && altPressed)
                    {
                        //currentVolume = controller.DefaultPlaybackDevice.Volume - 10;
                        //if (currentVolume < 0)
                        //{
                        //    currentVolume = 0;
                        //}

                        //setVolume("StarCraft II", "StarCraft II", "decrease");
                        //foreach(Process Processname in getProcessByName("Chrome"))
                        //{
                        //    setVolume("", "", "decrease", (IntPtr)Processname.Id);
                        //}
                        setVolume("", "", "decrease", (IntPtr)14472);
                    }
                    break;
                case Keys.F10: //App1 increase Vol
                    if (controlPressed && altPressed)
                    {
                        currentVolume = controller.DefaultPlaybackDevice.Volume + 10;
                        if (currentVolume > 100)
                        {
                            currentVolume = 100;
                        }
                        //Stopwatch myClock = new Stopwatch();
                        //myClock.Start();
                        //setVolume("StarCraft II", "StarCraft II", "increase");
                        foreach (Process Processname in getProcessByName("Chrome"))
                        {
                            setVolume("", "", "increase", (IntPtr)Processname.Id);
                        }
                        //myClock.Stop();
                        //MessageBox.Show(myClock.Elapsed.ToString());
                    }
                    break;
                case Keys.F11: //App2 lower Vol
                    if (controlPressed && altPressed)
                    {
                        setVolume("StarCraft II", "StarCraft II", "decrease");
                    }
                    break;
                case Keys.F12: //App2 increase Vol
                    if (controlPressed && altPressed)
                    {
                        setVolume("StarCraft II", "StarCraft II", "increase");
                    }
                    break;
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            hook.UnHookKeyboard();
        }

        // ################################ (End) ofTheHook ################################



        static void setVolume(string programmClass , string windowName, string changeAppVolume , IntPtr? processHandle = null)    //as soon as a parameter have a default value they become OPTIONAL, multiple Optional parameters require an argument 
        {
            uint pID;
            if (processHandle == null)
            {
                var hWnd = FindWindow(programmClass, windowName);
                if (hWnd == IntPtr.Zero)
                    return;

                GetWindowThreadProcessId(hWnd, out pID);
                if (pID == 0)
                    return;
            }
            else
            {
                pID = (uint)processHandle;
            }
            float newApplicationVolume = -1;            //float? is a float accepting also NULL as value exists for every Datatype (except string which can be NULL allready)
                var Test = VolumeMixer.GetApplicationVolume((int)pID);
         if (VolumeMixer.GetApplicationVolume((int)pID) == null)
            {
                return;
            }
            if ( changeAppVolume == "increase" )
            {
                if (VolumeMixer.GetApplicationVolume((int)pID) <= 90f)
                {
                    newApplicationVolume = (float)VolumeMixer.GetApplicationVolume((int)pID) + 10f;
                }
                else
                {
                    newApplicationVolume = 100f;
                }
            }
            else if ( changeAppVolume == "decrease" )
            {
                if (VolumeMixer.GetApplicationVolume((int)pID) >= 10f)
                {
                    newApplicationVolume = (float)VolumeMixer.GetApplicationVolume((int)pID) - 10f;
                }
                else
                {
                    newApplicationVolume = 0f;
                }
            }
            if (newApplicationVolume != -1)
            {
                VolumeMixer.SetApplicationVolume((int)pID, newApplicationVolume);
            }
        }
    }
}



/*

static void setVolume()
{
    var hWnd = FindWindow("StarCraft II", "StarCraft II");
    if (hWnd == IntPtr.Zero)
        return;

    uint pID;
    GetWindowThreadProcessId(hWnd, out pID);
    if (pID == 0)
        return;

    VolumeMixer.SetApplicationVolume((int)pID, 50f);
}



*/
