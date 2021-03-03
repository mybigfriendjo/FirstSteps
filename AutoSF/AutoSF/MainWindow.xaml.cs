﻿using System.Windows;
using System;
using AutoSF.Helper;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
//using MessageBox = System.Windows.Forms.MessageBox;
using MessageBox = System.Windows.MessageBox;
using System.Runtime.InteropServices;
using NLog;
using System.Diagnostics;



namespace AutoSF {
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        /* todo >>>>>>>>>>>>>>>
        -Add check
            >if Room1 Intro should have been passed but "i" count exceeds a certain value, check if intro is still active and send key (for ex. Space)
            >intro does get canceled now but doesnt start shooting, AutoSF quits soon after.
        -Add sqlite DB
            add mission data
            add fuction (screens + log for missions not found in DB)
        -Make App active/foreground on start
            

        -Form
            add icon next to buttons to see if active or not


        ################################### */
        public MainWindow() {
            LoggingConfig.Initialize();
            BackgroundworkerConfig.InitializeBackgroundworker();
            InitializeComponent();
            [DllImport("user32.dll")]
            static extern bool SetForegroundWindow(IntPtr hWnd);
            foreach(var process in Process.GetProcessesByName("AutoSF")) {
                SetForegroundWindow(process.MainWindowHandle);
            }
        }

        private Logger logger = LogManager.GetCurrentClassLogger();


        public double PositionCount = 10;
        public static bool LeftMouseDown = false;
        int AmountOfClicks = 450;
        int DurationBetwClicks = 6;
        public static bool StopAutoPvP = false;
        //public IntPtr SFWindowHandle = WinSystem.WindowActivate();
        int WinCount = 0;
        int LoseCount = 0;
        public static string CurrentHostName = System.Net.Dns.GetHostName();
        public static int DontUseMouse = 0;
        public static int DontMoveMouse = 1;
        public static int Spam2Active = 0;
        public static int Spam3Active = 0;
        public static int StuckIntro = 0;




        private void btnCodeTest_Click(object sender, RoutedEventArgs e) {
            OCR.OCRcheck(15,105,475,65);
            OCR.OCRcheck(12, 105, 475, 55);
            var x = "dummy";
            x = x + " for empty method";
        }

        private void btnAutoPvP_Click(object sender, RoutedEventArgs e) {
            logger.Debug("AutoPvp Start");
            CloseBackgroundWorkers();
            StopAutoPvP = false;

            Thread TaskPvPCheckPixel = new Thread(TaskHandler);
            TaskPvPCheckPixel.SetApartmentState(ApartmentState.STA);
            TaskPvPCheckPixel.Start();
            //TaskPvPCheckPixel.Join();
        }


        public void TaskHandler() { //public async void TaskHandler() {
            //await Task.Delay(1);
            int round = 1;
            while(round < 200 && StopAutoPvP == false) {
                if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                    logger.Debug("AutoPvP interrupted by user at Pos:" + Convert.ToString(PositionCount));
                    PositionCount = 10;
                    StopAutoPvP = true;
                }
                Console.WriteLine(round);
                round++;
                logger.Debug("Positioncount: " + PositionCount + " round = " +  "Starting Checkpixel"); 
                CheckPixel();
            }
            //Will Kill SF after 200 Games, Stop Backgroundworkers
            if(StopAutoPvP == false) {
                WinSystem.WindowKill();
            }
            CloseBackgroundWorkers();
            PositionCount = 10;
            if(StuckIntro == 1) {
                PositionCount = 11;
            }
        }

        private void cbNoMouse_Click(object sender, RoutedEventArgs e) {
            if(cbNoMouse.IsChecked == true) {
                DontUseMouse = 1;
            }
            else {
                DontUseMouse = 0;
            }
        }
        private void cbNoMouseMove_Click(object sender, RoutedEventArgs e) {
            if(cbNoMouseMove.IsChecked == true) {
                DontMoveMouse = 1;
            }
            else {
                DontMoveMouse = 0;
            }
        }
        private void cbSpam2Active_Click (object sender, RoutedEventArgs e) {
            if(cbSpam2Active.IsChecked == true) {
                Spam2Active = 1;
            }
            else {
                Spam2Active = 0;
            }
        }
        private void cbSpam3Active_Click(object sender, RoutedEventArgs e) {
            if(cbSpam3Active.IsChecked == true) {
                Spam3Active = 1;
            }
            else {
                Spam3Active = 0;
            }
        }

        public async void TaskWait(int DelayInMS) {
            await Task.Delay(DelayInMS);
        }
        public static void Sleep(int DurationInMS) {
            Stopwatch st = new Stopwatch();
            st.Start();
            while(st.Elapsed < TimeSpan.FromMilliseconds(DurationInMS)) {
                //
            }
            st.Stop();
        }

        private void CloseBackgroundWorkers() {
            BackgroundworkerConfig.BgwCancelAsyn(BackgroundworkerConfig.backgroundWorker1);
            BackgroundworkerConfig.BgwCancelAsyn(BackgroundworkerConfig.backgroundWorker2);
            BackgroundworkerConfig.BgwCancelAsyn(BackgroundworkerConfig.backgroundWorker3);
            BackgroundworkerConfig.BgwCancelAsyn(BackgroundworkerConfig.backgroundWorker4);
            PositionCount = 10;
        }

        private void StuckOnIntro() {
            CloseBackgroundWorkers();
            PositionCount = 11;
            StuckIntro = 1;
            KeyboardInput.Send(KeyboardInput.ScanCodeShort.KEY_W);
            Sleep(10);
            SendKeys.Send("W");
            //if(WinSystem.WindowActivate() == IntPtr.Zero) {

            //}
            logger.Debug("Restart PvP-Bot after beeing Stuck");
            btnAutoPvP_Click(null,null);
        }

        //getWindowPosition (Size,Position)
        /*
        private void buttonGetWindowTitles_Click(object sender, EventArgs e) {
            logger.Debug("getting all window titles");
            foreach(KeyValuePair<IntPtr, string> pair in WinSystem.GetAllWindowTitles()) {
                ///lvWindowTitles.AddObject(pair);
                lvWindowTitles.Items.Add(new ListViewItem(""));
            }
        }
        
        private void buttonWindowPosition_Click(object sender, EventArgs e) {
            logger.Debug("checking selection");
            if(lvWindowTitles.SelectedItem == null) {
                logger.Warn("no item selected");
                return;
            }

            KeyValuePair<IntPtr, string> selectedObject = (KeyValuePair<IntPtr, string>)lvWindowTitles.SelectedObject;

            logger.Debug("selected value: " + selectedObject.Value);

            logger.Debug("getting window position");

            Rectangle windowPos = WinSystem.GetWindowRect(selectedObject.Key);

            logger.Debug(windowPos.ToString());

        }
       */

        public void CheckPixel(int position = 0) {
            //await Task.Delay(2);
            int Score = 0;

            //#######  Positions  ############
            //-- Check for event and switch to PvP-Start Screen
            //10 Check if enemy is attackable - if not reroll - if it is attackable start attack
            //11 skip intro, trigger "F" + start shooting
            //12 room1 finished -> progress to room2
            //13 room2 finished -> reset position to 10 - repeat from start

                    
            if(PositionCount == 10) { //scans for: Challange-Screen  and PvP-Screen / Enemy Selection - Lupe/KapfprotocollIcon/Aktualisieren
                TaskHandlerPos10();
                void TaskHandlerPos10() {
                    //await Task.Delay(1);
                    int i = 1;
                    BackgroundworkerConfig.BgwCancelAsyn(BackgroundworkerConfig.backgroundWorker4); //Stops F Key detection
                    Console.WriteLine("F detection stoped");
                    while(PositionCount == 10 && StopAutoPvP == false) {
                        //Scans button/color in "Rang belohnung(green)/
                        if(i > 400) {
                            Console.WriteLine("Stuck - i at" + i + ", current Programm Position is: " + PositionCount);
                            logger.Debug("Stuck - i at" + i + ", current Programm Position is: " + PositionCount);
                            StuckOnIntro();
                        }
                        if(PixelFinder.SearchStaticPixel(486, 463, "#91EAF7")) { Score++; } // "i" info icon near points
                        if(PixelFinder.SearchStaticPixel(1546, 531, "#FFFFF")) { Score++; }
                        if(PixelFinder.SearchStaticPixel(186, 651, "#007887")) { Score++; }
                        if(PixelFinder.SearchStaticPixel(960, 465, "#91EAF7")) { Score++; } // "i" info icon near points (with score)

                        LoopGarbageCollector.ClearGarbageCollector();
                        if(Score >= 2) {
                            Console.WriteLine("Challange found. Entering PVP Screen");
                            MouseActions.DoubleClickAtPosition(-273, 539); //Spielen/Start Button
                            Sleep(800);
                        }

                        //if Reward pops up
                        Score = 0;
                        if(PixelFinder.SearchStaticPixel(845, 217, "#0D2D4C")) { Score++; } //Upper BlueBar
                        if(PixelFinder.SearchStaticPixel(472, 139, "#E5C1A3")) { Score++; } //WomanToTheLeft
                        if(PixelFinder.SearchStaticPixel(1348, 850, "#FFFFFF")) { Score++; } //White Text in the blue "Einfordern" Button
                        LoopGarbageCollector.ClearGarbageCollector();
                        if(Score >= 2) {
                            Console.WriteLine("Reward found. Collecting and entering PVP Screen");
                            MouseActions.DoubleClickAtPosition(-500, 850); //"Einfordern" Button
                            Sleep(800);
                            MouseActions.DoubleClickAtPosition(-273, 539); //Spielen/Start Button
                        }

                        if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                            logger.Debug("AutoPvP interrupted by user at Pos:" + Convert.ToString(PositionCount));
                            PositionCount = 10;
                            StopAutoPvP = true;
                        }
                        Console.WriteLine("Pos10: " + i);
                        i++;
                        Score = 0;
                        if(PixelFinder.SearchStaticPixel(407, 549, "#082045")) { Score++; }
                        if(PixelFinder.SearchStaticPixel(102, 1032, "#FFFFFF")) { Score++; }
                        if(PixelFinder.SearchStaticPixel(907, 1052, "#0BAE28")) { Score++; }
                        LoopGarbageCollector.ClearGarbageCollector();
                        if(Score >= 2) {
                            if(PixelFinder.SearchStaticPixel(1461, 1020, "#646464") == true && PixelFinder.SearchStaticPixel(1710, 1007, "#B1B1B1") == true) { //AttackButton is Gray
                                MouseActions.DoubleClickAtPosition(-1049, 1050);
                            }
                            else if(PixelFinder.SearchStaticPixel(1452, 1020, "#1E86C5") == true && PixelFinder.SearchStaticPixel(1709, 1007, "#FFFFFF") == true) { //Button is Blue
                                Console.WriteLine("Score Ok (" + Score + ")");
                                Console.WriteLine("Entering Room1");
                                PositionCount = 11;

                                MouseActions.DoubleClickAtPosition(-180, 1014); //only BlueButton
                                Stopwatch s = new Stopwatch();
                                Sleep(1000);
                                if(PixelFinder.SearchStaticPixel(1430, 997, "#C4B827") == true || PixelFinder.SearchStaticPixel(1430, 997, "#BAAB01")) { //Yellow "Weiter" button (Storage Full)
                                    Console.WriteLine("YellowButton Recogniced");
                                    if(PixelFinder.SearchStaticPixel(1027, 724, "#FFFFFF")) {  //Kisten können verschmolzen werden 4/4
                                        MouseActions.DoubleClickAtPosition(-776, 755); //clicks melt button
                                        logger.Debug("4 Chests rdy - clicking melt button");
                                        Sleep(4000);
                                        MouseActions.DoubleClickAtPosition(-180, 1014);
                                        Sleep(4000);

                                        /*
                                        //checks if the current screen is the ranking list
                                        s.Start();
                                        while(s.Elapsed < TimeSpan.FromMilliseconds(4000)) {
                                            if(PixelFinder.SearchStaticPixel(46, 71, "#E1BF05")) { Score++; }
                                            if(PixelFinder.SearchStaticPixel(408, 77, "#FFD801")) { Score++; }
                                            if(PixelFinder.SearchStaticPixel(448, 72, "#FFD801")) { Score++; }
                                            LoopGarbageCollector.ClearGarbageCollector();
                                            if(Score >= 2) {
                                                Console.WriteLine("Score Ok (" + Score + ")");
                                                Console.WriteLine("Skipping Room1 Intro");
                                                PositionCount = 12;

                                                MouseActions.DoubleClickAtPosition(-956, 134);
                                            }
                                        }
                                        s.Stop();
                                        */
                                    }
                                    else {
                                        //MouseActions.DoubleClickAtPosition(-466, 1014); //clicks Yellow "Weiter" button  --hits Blue OR Yellow Button--
                                        MouseActions.DoubleClickAtPosition(-630, 1014); //clicks Yellow "Weiter" button //only YellowButton
                                        logger.Debug("4 Chests CD - clicks Yellow button");
                                    }
                                    //PositionCount = 10.5;
                                }
                                LoopGarbageCollector.ClearGarbageCollector();
                                //var breakpoint = 1;
                                //}
                                //else {
                                //    Close();
                                //}
                            }
                        }
                    }
                }
            }

            if(PositionCount == 10.5 && StopAutoPvP == false) { //If YellowButton was up
                MouseActions.DoubleClickAtPosition(-260, 1009);
                MouseActions.DoubleClickAtPosition(-960, 326);
                PositionCount = 11;
            }

            if(PositionCount == 11 && StopAutoPvP == false) { //scans for: Room1-Intro
                TaskHandlerPos11();
                void TaskHandlerPos11() {
                    //await Task.Delay(1);
                    int i = 1;
                    StuckIntro = 0;
                    while(PositionCount == 11 && StopAutoPvP == false) {
                        if(i > 400) {
                            Console.WriteLine("Stuck - i at" + i + ", current Programm Position is: " + PositionCount);
                            logger.Debug("Stuck - i at" + i + ", current Programm Position is: " + PositionCount);
                            StuckOnIntro();
                        }
                        if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                            logger.Debug("AutoPvP interrupted by user at Pos:" + Convert.ToString(PositionCount));
                            PositionCount = 10;
                            StopAutoPvP = true;
                        }
                        Console.WriteLine("Pos11: " + i);
                        i++;
                        Score = 0;
                        if(PixelFinder.SearchStaticPixel(46, 71, "#E1BF05")) { Score++; }
                        if(PixelFinder.SearchStaticPixel(408, 77, "#FFD801")) { Score++; }
                        if(PixelFinder.SearchStaticPixel(448, 72, "#FFD801")) { Score++; }
                        LoopGarbageCollector.ClearGarbageCollector();
                        if(Score >= 2) {
                            Console.WriteLine("Score Ok (" + Score + ")");
                            Console.WriteLine("Skipping Room1 Intro");
                            PositionCount = 12;

                            //MouseActions.SetCursorPos(-966, 590);
                            //var MsgBoxResult = MessageBox.Show("Is Curser Position Ok to Click?", "MouseClickPositionCheck - SwitchToRoom2", MessageBoxButton.YesNo);
                            //if(Convert.ToString(MsgBoxResult) == "Yes") {
                            MouseActions.DoubleClickAtPosition(-956, 134);
                            //}
                        }
                        else { //If PvP Intro doesnt appear - stillcontinue
                            PositionCount = 12;
                            MouseActions.DoubleClickAtPosition(-956, 134);
                        }
                    }
                }
            }

            if(PositionCount == 12 && StopAutoPvP == false) { //scans for: Entrance Room2
                TaskHandlerPos12();
                void TaskHandlerPos12() {
                    //await Task.Delay(1);
                    int i = 1;
                    Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt"));
                    // ---Special Sleep---
                    if(DontUseMouse == 0) {
                        Stopwatch s = new Stopwatch();
                        s.Start();
                        while(s.Elapsed < TimeSpan.FromMilliseconds(2700) && StopAutoPvP == false) {
                            //
                        }
                        s.Stop();
                        MouseActions.DoubleClickAtPosition(-956, 134);

                        s.Start();
                        while(s.Elapsed < TimeSpan.FromMilliseconds(1500) && StopAutoPvP == false) {
                            KeyboardInput.Send(KeyboardInput.ScanCodeShort.KEY_F);
                            if(Spam2Active == 1) {
                                KeyboardInput.Send(KeyboardInput.ScanCodeShort.KEY_2);
                                SendKeys.Send("2");
                            }
                            if(Spam3Active == 1 && i == 1) {   //only activate "3" once - pressing it again would disable it
                                KeyboardInput.Send(KeyboardInput.ScanCodeShort.KEY_3);
                            }
                        }
                        s.Stop();
                    }

                    Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt"));

                    while(PositionCount == 12 && StopAutoPvP == false) { //while clock pixel is found
                        Score = 0;
                        i++;
                        if(i > 400) {
                            Console.WriteLine("Stuck - i at" + i + ", current Programm Position is: " + PositionCount);
                            logger.Debug("Stuck - i at" + i + ", current Programm Position is: " + PositionCount);
                            StuckOnIntro();
                        }
                        Console.WriteLine("Pos12: " + i);
                        if(PixelFinder.SearchStaticPixel(911, 43, "#A3F5F6")) { Score++; } //VerticalBarRighttoClock
                        if(PixelFinder.SearchStaticPixel(777, 37, "#A3F5F6")) { Score++; } //VerticalBarLefttoClock
                        if(PixelFinder.SearchStaticPixel(803, 24, "#FFFFFF")) { Score++; } //Clock
                        LoopGarbageCollector.ClearGarbageCollector();

                        if(DontUseMouse == 0) {
                            BackgroundworkerConfig.BgwStartAsync(BackgroundworkerConfig.backgroundWorker1); //MouseClick
                            if(DontMoveMouse == 0) {
                                BackgroundworkerConfig.BgwStartAsync(BackgroundworkerConfig.backgroundWorker3); //MouseMovement
                            }
                        }
                        Console.WriteLine("Mousclick started");
                        //MouseActions.ClickSpam(10, 4);
                        KeyboardInput.Send(KeyboardInput.ScanCodeShort.KEY_F);
                        BackgroundworkerConfig.BgwStartAsync(BackgroundworkerConfig.backgroundWorker2); //Press F-Key

                        //Todo Remove AHK
                        if(MainWindow.CurrentHostName == "VMgr4ndpa") {
                            Process.Start("C:\\Spiele\\AutoSF\\Scripts\\AutoSFAssistent.ahk"); //Presses F Key
                        }
                        //Process.Start("H:\\BackupData\\Selftraning\\Programmieren\\ahk\\Sniperfury\\AutoSFAssistent.ahk"); //Presses F Key
                        //MouseActions.ClickSpam(AmountOfClicks, DurationBetwClicks);

                        if(Score <= 1) { //If Clock wasnt found
                            //Process.Start("H:\\BackupData\\Selftraning\\Programmieren\\ahk\\Sniperfury\\KillAutoSFscript.ahk");
                            Console.WriteLine("NoClockFound-Moving on");
                            PositionCount = 13;
                        }
                        KeyboardInput.Send(KeyboardInput.ScanCodeShort.KEY_F);
                    }
                }
            }

            if(PositionCount == 13 && StopAutoPvP == false) { //scans for: Entrance Room2
                TaskHandlerPos13();
                void TaskHandlerPos13() {
                    //await Task.Delay(1);
                    int i = 1;

                    Stopwatch s = new Stopwatch();
                    s.Start();
                    while(s.Elapsed < TimeSpan.FromMilliseconds(1500) && StopAutoPvP == false) {
                        MouseActions.DoubleClickAtPosition(-960, 326);
                    }
                    s.Stop();

                    while(PositionCount == 13 && StopAutoPvP == false) {
                        if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                            logger.Debug("AutoPvP interrupted by user at Pos:" + Convert.ToString(PositionCount));
                            PositionCount = 10;
                            StopAutoPvP = true;
                        }
                        KeyboardInput.Send(KeyboardInput.ScanCodeShort.KEY_F);

                        Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt") + " Pos13: " + i);
                        logger.Debug("Pos13: " + i);
                        i++;
                        Score = 0;
                        if(i > 400) {
                            Console.WriteLine("Stuck - i at" + i + ", current Programm Position is: " + PositionCount);
                            logger.Debug("Stuck - i at" + i + ", current Programm Position is: " + PositionCount);
                            StuckOnIntro();
                        }

                        if(PixelFinder.SearchStaticPixel(104, 266, "#FFFFFF")) { Score--; }
                        if(PixelFinder.SearchStaticPixel(933, 156, "#FF4C4C")) { Score--; }
                        if(PixelFinder.SearchStaticPixel(970, 921, "#FF4C4C")) { Score--; }
                        LoopGarbageCollector.ClearGarbageCollector();
                        if(Score <= -2) {
                            BackgroundworkerConfig.BgwCancelAsyn(BackgroundworkerConfig.backgroundWorker1); //MouseClick
                            BackgroundworkerConfig.BgwCancelAsyn(BackgroundworkerConfig.backgroundWorker3); //MouseMovement
                            MouseActions.DoubleClickAtPosition(-960, 326);
                            LoseCount++;
                            Stopwatch sw = new Stopwatch();
                            sw.Start();
                            while(sw.Elapsed < TimeSpan.FromMilliseconds(150) && StopAutoPvP == false) {
                                //
                            }
                            sw.Stop();
                            logger.Debug("Match lost at Pos:" + Convert.ToString(PositionCount) + " This is Lose Nr.: " + Convert.ToString(LoseCount));
                            PositionCount = 10;
                            MouseActions.DoubleClickAtPosition(-1681, 1024); //"Zurück" Button
                        }
                        else {
                            Console.WriteLine("Score Ok (" + Score + ")");
                            logger.Debug("Entering Room2");
                            PositionCount = 14;
                            MouseActions.DoubleClickAtPosition(-960, 326);
                        }
                    }
                }
            }

            if(PositionCount == 14 && StopAutoPvP == false) { //scans for: Match Won
                TaskHandlerPos14();
                void TaskHandlerPos14() {
                    //await Task.Delay(1);
                    int i = 1;
                    int count = 1;
                    Console.WriteLine("MousClickSTop/start");
                    while(PositionCount == 14 && StopAutoPvP == false) {
                        if(i > 400) {
                            Console.WriteLine("Stuck - i at" + i + ", current Programm Position is: " + PositionCount);
                            logger.Debug("Stuck - i at" + i + ", current Programm Position is: " + PositionCount);
                            StuckOnIntro();
                        }
                        if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                            logger.Debug("AutoPvP interrupted by user at Pos:" + Convert.ToString(PositionCount));
                            BackgroundworkerConfig.BgwCancelAsyn(BackgroundworkerConfig.backgroundWorker1); //MouseClick
                            BackgroundworkerConfig.BgwCancelAsyn(BackgroundworkerConfig.backgroundWorker3); //MouseMovement
                            PositionCount = 10;
                            StopAutoPvP = true;
                        }
                        //Stops Mouseclickspam after 60 rounds for every 10 rounds
                        if(i > 60 && count > 10) {
                            BackgroundworkerConfig.BgwCancelAsyn(BackgroundworkerConfig.backgroundWorker1);
                            count = 1;
                        }
                        if(DontUseMouse == 0) {
                            BackgroundworkerConfig.BgwStartAsync(BackgroundworkerConfig.backgroundWorker1);
                        }

                        Console.WriteLine("Pos14: " + i);
                        i++;
                        Score = 0;
                        //Win - Victory/Epic
                        if(PixelFinder.SearchStaticPixel(1770, 1016, "#479FD5")) { Score++; } //"Weiter" button enlighted (mouseover)
                        if(PixelFinder.SearchStaticPixel(1770, 1016, "#268ECD")) { Score++; } //"Weiter" button
                        if(PixelFinder.SearchStaticPixel(914, 130, "#88CCCF")) { Score++; } //UpperBlueBar
                        if(PixelFinder.SearchStaticPixel(983, 946, "#A3F5F6")) { Score++; } //LowerBlueBar

                        //Lose
                        if(PixelFinder.SearchStaticPixel(104, 266, "#FFFFFF")) { Score--; }
                        if(PixelFinder.SearchStaticPixel(933, 156, "#FF4C4C")) { Score--; }
                        if(PixelFinder.SearchStaticPixel(970, 921, "#FF4C4C")) { Score--; }
                        LoopGarbageCollector.ClearGarbageCollector();

                        if(Score >= 2) {
                            BackgroundworkerConfig.BgwCancelAsyn(BackgroundworkerConfig.backgroundWorker1); //MouseClick
                            BackgroundworkerConfig.BgwCancelAsyn(BackgroundworkerConfig.backgroundWorker3); //MouseMovement
                            MouseActions.DoubleClickAtPosition(-960, 326);
                            Stopwatch s = new Stopwatch();
                            s.Start();
                            while(s.Elapsed < TimeSpan.FromMilliseconds(150) && StopAutoPvP == false) {
                                //
                            }
                            s.Stop();
                            Console.WriteLine("Score Ok (" + Score + ")");
                            Console.WriteLine("Match won");
                            WinCount ++;
                            logger.Debug("Match Won. This is Win Nr.: " + Convert.ToString(WinCount));
                            PositionCount = 10;
                            MouseActions.DoubleClickAtPosition(-260, 1009);
                        }
                        else if(Score <= -2) { //Lose
                            BackgroundworkerConfig.BgwCancelAsyn(BackgroundworkerConfig.backgroundWorker1); //MouseClick
                            BackgroundworkerConfig.BgwCancelAsyn(BackgroundworkerConfig.backgroundWorker3); //MouseMovement
                            MouseActions.DoubleClickAtPosition(-960, 326);
                            LoseCount++;
                            Stopwatch s = new Stopwatch();
                            s.Start();
                            while(s.Elapsed < TimeSpan.FromMilliseconds(150) && StopAutoPvP == false) {
                                //
                            }
                            s.Stop();
                            logger.Debug("Match lost at Pos:" + Convert.ToString(PositionCount) + " This is Lose Nr.: " + Convert.ToString(LoseCount));
                            PositionCount = 10;
                            MouseActions.DoubleClickAtPosition(-1681, 1024); //"Zurück" Button
                        }
                        //MouseActions.ClickSpam(100, 4);
                    }
                }
                CloseBackgroundWorkers();
                Console.WriteLine("Mouseclick Stopped");
            }
        }
    }
}