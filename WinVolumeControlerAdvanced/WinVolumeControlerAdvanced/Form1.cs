using AudioSwitcher.AudioApi.CoreAudio;
using System.Windows.Forms;
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Timers;

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


        private static List<float?> pIDsWithVolume = new List<float?>();

        // ---Dll Imports---
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string strClassName, string strWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);


        public Form1()
        {
            //Keydetection
            hook.OnKeyPressed += hook_KeyPressed;
            hook.OnKeyUnpressed += hook_KeyUnpressed;
            hook.HookKeyboard();

            //Timer


            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;

        }

        protected override void OnLoad(EventArgs e)
        {//this will be executed right on start
            base.OnLoad(e);

            System.Timers.Timer listTimer = new System.Timers.Timer();
            listTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            listTimer.Interval = 3000;
        }

        /* *########################  2do ########################
        //  get current time on press key time.now()
            on next keypress get time again -> if newTime - oldTime > 3sec { to this }
            
        // * get Vol for F9/F10 and F11/F12 right away -> store it in defaultVol
        // * now setVolume and adjust defaultVol -> no more need for getVol

        //  * gather Vol increases and set them only once

            Timer maybe not neccesary?


        // *###################### 2do End ########################*/

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Hello World!");
        }

        private void keyPressTime(string Key)
        {
            
            //DateTime currentDateTime = DateTime.Now;
            DateTime datek9K10Old = DateTime.Now -   ;
            if (Key == "F9" || Key == "F10"){
                DateTime datek9K10Now = DateTime.Now;
                if( datek9K10Old )
                {
                    DateTime datek9K10Old = datek9K10Now;
                }

            }
            if (Key == "F10" || Key == "F11")
            {
                DateTime datek11K12Now = DateTime.Now;
            }
        }


        private List<Process> getProcessByName(string processName)
        {
            var allProcesses = Process.GetProcesses();
            List<Process> chromeProcessList = new List<Process>();
            foreach (Process singleProcess in allProcesses)
            {
                if (singleProcess.ProcessName.Equals(processName, StringComparison.OrdinalIgnoreCase)) //.Equal is another option for stings with aditional options like CaseInsensitive(OrdinalIgnoreCase)
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
                        //Stopwatch myClockdecrease = new Stopwatch();
                        //myClockdecrease.Start();
                        var tempClockProcceses = getProcessByName("Chrome");
                        //myClockdecrease.Stop();
                        //File.AppendAllText("C:\\temp\\WinVolPerf.log", "\nF9-deacease " + myClockdecrease.Elapsed.ToString());
                        //Stopwatch myClockdecreaseVol = new Stopwatch();
                        //myClockdecreaseVol.Start();
                        foreach (Process Processname in tempClockProcceses)
                        {
                            setVolume("", "", "decrease", (IntPtr)Processname.Id);
                        }
                        //myClockdecreaseVol.Stop();
                        //File.AppendAllText("C:\\temp\\WinVolPerf.log", "\nF9-deaceaseVol " + myClockdecreaseVol.Elapsed.ToString());
                    }
                    break;
                case Keys.F10: //App1 increase Vol
                    if (controlPressed && altPressed)
                    {
                        //Stopwatch myClockincrease = new Stopwatch();
                        //myClockincrease.Start();
                        var tempClockProcceses = getProcessByName("Chrome");
                        //myClockincrease.Stop();
                        //File.AppendAllText("C:\\temp\\WinVolPerf.log", "\nF9-increase " + myClockincrease.Elapsed.ToString());
                        //Stopwatch myClockincreaseVol = new Stopwatch();
                        //myClockincreaseVol.Start();
                        foreach (Process Processname in tempClockProcceses)
                        {
                            setVolume("", "", "increase", (IntPtr)Processname.Id);
                        }
                        //myClockincreaseVol.Stop();
                        //File.AppendAllText("C:\\temp\\WinVolPerf.log", "\nF9-increaseVol " + myClockincreaseVol.Elapsed.ToString());
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
            Application.Exit();
        }

        // ################################ (End) ofTheHook ################################

        static void setVolume(string programmClass, string windowName, string changeAppVolume, IntPtr? processHandle = null)    //as soon as a parameter have a default value they become OPTIONAL, multiple Optional parameters require an argument 
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
            if (VolumeMixer.GetApplicationVolume((int)pID) == null)
            {
                return;
            }
            else
            {
                pIDsWithVolume.Add(pID);
            }
            if (changeAppVolume == "increase")
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
            else if (changeAppVolume == "decrease")
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
