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

        private static List<float?> pIDsWithVolume = new List<float?>();

        private DateTime dateF9F10Old = DateTime.Now;
        private DateTime dateF11F12Old = DateTime.Now;
        private static float currentVolumeF9F10 = 50;
        private static float currentVolumeF11F12 = 50;
        private static uint pID;
        private static List<Process> listpID = new List<Process>();
        //private static HashSet<Process> hashpIDF9F10 = new HashSet<Process>();   //unlike lists HashSet entries are unique
        private static HashSet<Process> hashpIDF11F12 = new HashSet<Process>();
        private static Dictionary<int, Process> dictpIDF9F10 = new Dictionary<int, Process>();
        private static int validProcessF11F12 = 0;

        private NotifyIcon MyNotifyIcon = new NotifyIcon();
        //ProcessNames
        private static string processNameF9F10 = "Chrome";
        private static string programmClassF11F12 = "StarCraft II";
        private static string windowNameF11F12 = "StarCraft II";


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

            //3Second Intervall
            DateTime dateTimeTest = DateTime.FromOADate(0);  //Sets dateTimeTest to 0 (untested)

            //hide Form  (Form is required for HotKeys and can't be closed)
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;

            //Systray
            ContextMenu trayMenu = new ContextMenu();   //Creates the Contextmenu (will automaticly show up on richtclick as soon as it gets assigned to a notifyIcon
            trayMenu.MenuItems.Add("Quit", trayMenuQuit); //Adds a Menuitem "Quit" which triggers the method "contextMenuStripSystray"

            MyNotifyIcon.Icon = AdvancedWinVolumeControler.Properties.Resources.download_wKO_icon;
            MyNotifyIcon.ContextMenu = trayMenu; //assignes the trayMenu to the NotifyIcon (==SystrayIcon)
            MyNotifyIcon.Visible = true;

            //Get Current Applications Volume
            renewF9F10vol();
            renewF11F12vol();
        }
        

        private void trayMenuQuit(object sender, EventArgs e)
        {
            applicationQuit();
        }

        private void applicationQuit()
        {
            MyNotifyIcon.Visible = false;
            hook.UnHookKeyboard();
            Application.Exit();
            Environment.Exit(0);
        }

        protected override void OnLoad(EventArgs e)
        {//this will be executed right on start
            base.OnLoad(e);
        }

        private static void renewF9F10vol()
        {
            dictpIDF9F10.Clear();
            foreach (Process Processname in getProcessByName(processNameF9F10))
            {
                if (VolumeMixer.GetApplicationVolume((int)Processname.Id) == null)
                {
                    //return;
                }
                else
                {
                    if (!dictpIDF9F10.ContainsKey(Processname.Id)) //if process Id isnt part of table yet do....
                    {
                        currentVolumeF9F10 = (float)VolumeMixer.GetApplicationVolume((int)Processname.Id);
                        dictpIDF9F10.Add(Processname.Id, Processname);
                    }
                }
            }
        }
        private static void renewF11F12vol()
        {
            var hWnd = FindWindow(programmClassF11F12, windowNameF11F12);
            if (hWnd == IntPtr.Zero)
            {
                //return;
            }
            else
            {
                GetWindowThreadProcessId(hWnd, out pID);
                if (pID == 0)
                {
                    //return;
                }
                else
                {
                    currentVolumeF11F12 = (float)VolumeMixer.GetApplicationVolume((int)pID);
                    validProcessF11F12 = 1;
                    //hashpIDF11F12.Add(pID);
                }
            }
        }

        private void keyPressTime(string Key)
        {
            if (Key == "F9" || Key == "F10")
            {
                if ((dateF9F10Old <= DateTime.Now.AddSeconds(-3)) || (dictpIDF9F10.Count == 0)) // If old Time was set at least 3 Sec ago  OR valid entry was stored in ProcessList.
                {//Try to get a curret Volume and set Time for last try to Now
                    renewF9F10vol();
                    dateF9F10Old = DateTime.Now;
                }
            }
            if (Key == "F11" || Key == "F12")
            {
                if ((dateF11F12Old <= DateTime.Now.AddSeconds(-3)) || (validProcessF11F12 == 0)) // If old Time was set at least 3 Sec ago   OR no validProcess was found so far
                {
                    renewF11F12vol();
                    dateF11F12Old = DateTime.Now;
                }
            }
        }

        private static List<Process> getProcessByName(string processName)
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
                        keyPressTime("F9");
                        if (currentVolumeF9F10 != 0f)
                        {
                            if (currentVolumeF9F10 >= 10f)
                            {
                                currentVolumeF9F10 = currentVolumeF9F10 - 10f;
                            }
                            else
                            {
                                currentVolumeF9F10 = 0f;
                            }
                            if (dictpIDF9F10.Count != 0)
                            {
                                foreach (int Processname in dictpIDF9F10.Keys)
                                {
                                    setVolume("F9", "", currentVolumeF9F10, (IntPtr)dictpIDF9F10[Processname].Id);
                                }
                            }
                            else
                            {
                                foreach (Process Processname in getProcessByName(processNameF9F10))
                                {
                                    setVolume("F9", "", currentVolumeF9F10, (IntPtr)Processname.Id);
                                }
                            }
                        }
                    }
                    break;
                case Keys.F10: //App1 increase Vol
                    if (controlPressed && altPressed)
                    {
                        keyPressTime("F10");
                        if (currentVolumeF9F10 != 100f)
                        {
                            if (currentVolumeF9F10 <= 90f)
                            {
                                currentVolumeF9F10 = currentVolumeF9F10 + 10f;
                            }
                            else
                            {

                                currentVolumeF9F10 = 100f;
                            }
                            if (dictpIDF9F10.Count != 0)
                            {
                                foreach (int Processname in dictpIDF9F10.Keys)
                                {
                                    setVolume("F10", "", currentVolumeF9F10, (IntPtr)dictpIDF9F10[Processname].Id);
                                }
                            }
                            else
                            {
                                foreach (Process Processname in getProcessByName(processNameF9F10))
                                {
                                    setVolume("F10", "", currentVolumeF9F10, (IntPtr)Processname.Id);
                                }
                            }
                        }
                    }
                    break;
                case Keys.F11: //App2 lower Vol
                    if (controlPressed && altPressed)
                    {
                        keyPressTime("F11");
                        if (currentVolumeF11F12 != 0f)
                        {
                            if (currentVolumeF11F12 >= 10f)
                            {
                                currentVolumeF11F12 = currentVolumeF11F12 - 10f;
                            }
                            else
                            {

                                currentVolumeF11F12 = 0f;
                            }
                            setVolume(programmClassF11F12, windowNameF11F12, currentVolumeF11F12);
                        }
                    }
                    break;
                case Keys.F12: //App2 increase Vol
                    if (controlPressed && altPressed)
                    {
                        keyPressTime("F12");
                        if (currentVolumeF11F12 != 100f)
                        {
                            if (currentVolumeF11F12 <= 90f)
                            {
                                currentVolumeF11F12 = currentVolumeF11F12 + 10f;
                            }
                            else
                            {
                                currentVolumeF11F12 = 100f;
                            }
                            setVolume(programmClassF11F12, windowNameF11F12, currentVolumeF11F12);
                        }
                    }
                    break;
            }
        }
        // ################################ (End) ofTheHook ################################


        static void setVolume(string programmClass, string windowName, float changeAppVolume, IntPtr? processHandle = null)    //as soon as a parameter have a default value they become OPTIONAL, multiple Optional parameters require an argument 
        {
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
            //Get valid pID's/pID-List
            if (VolumeMixer.GetApplicationVolume((int)pID) == null)
            {
                return;
            }
            else
            {
                if (programmClass == "F9" || programmClass == "F10")
                {
                    newApplicationVolume = currentVolumeF9F10;
                }
                else if (programmClass == programmClassF11F12)
                {
                    newApplicationVolume = currentVolumeF11F12;
                }
                pIDsWithVolume.Add(pID);
            }
            if (newApplicationVolume != -1)
            {
                VolumeMixer.SetApplicationVolume((int)pID, newApplicationVolume);
            }
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            applicationQuit();
        }
    }
}
