using System.Drawing;
using System.Windows;
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
using System.Collections.Generic;
using IronOcr;


namespace AutoSF {
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        /* todo >>>>>>>>>>>>>>>
        -class mouse
            .moveright - could work with Click and increasing/decreasing y coordinates
            .moveleft
        -main
            .send F key
        -Form
            add icon next to buttons to see if active or not


        ################################### */
        public MainWindow() {
            LoggingConfig.Initialize();
            BackgroundworkerConfig.InitializeBackgroundworker();
            InitializeComponent();

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




        private void btnCodeTest_Click(object sender, RoutedEventArgs e) {
            
            var x = 0;
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


        public async void TaskHandler() {
            //await Task.Delay(1);
            int i = 1;
            while(i < 100 && StopAutoPvP == false) {
                if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                    logger.Debug("AutoPvP interrupted by user at Pos:" + Convert.ToString(PositionCount));
                    PositionCount = 10;
                    StopAutoPvP = true;
                }
                Console.WriteLine(i);
                i++;
                logger.Debug("Positioncount: " + PositionCount + "i = " +  "Starting Checkpixel"); 
                CheckPixel();
            }
            //Will Kill SF after 100 Games, Stop Backgroundworkers
            if(StopAutoPvP == false) {
                WinSystem.WindowKill();
            }
            CloseBackgroundWorkers();
            PositionCount = 10;
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

        public async void CheckPixel(int position = 0) {
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
                async void TaskHandlerPos10() {
                    //await Task.Delay(1);
                    int i = 1;
                    BackgroundworkerConfig.BgwCancelAsyn(BackgroundworkerConfig.backgroundWorker4); //Stops F Key detection
                    Console.WriteLine("F detection stoped");
                    while(PositionCount == 10 && StopAutoPvP == false) {
                        //scans for: PvPStartScreen - grabs pixels in "Bestenliste/Ranking"- Icon and mouseover (Big Icon) - has to be allways executed
                        //if(PixelFinder.SearchStaticPixel(1773, 418, "#73BBC6")) { Score++; }
                        //if(PixelFinder.SearchStaticPixel(1798, 402, "#91EAF7")) { Score++; }
                        //if(PixelFinder.SearchStaticPixel(1826, 422, "#3F8C97")) { Score++; }
                        //if(PixelFinder.SearchStaticPixel(1772, 419, "#9ACED6")) { Score++; }
                        //if(PixelFinder.SearchStaticPixel(1802, 409, "#AFF0F9")) { Score++; }
                        //if(PixelFinder.SearchStaticPixel(1831, 425, "#74ACB4")) { Score++; }

                        //Scans button/color in "Rang belohnung(green)/
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

                                //Get Room1 Armor

                                //var Ocr = new IronTesseract();
                                //using(var OcrInputImage = new OcrInput()) {
                                //    var ContentArea = new System.Drawing.Rectangle() { X = 1550, Y = 750, Height = 200, Width = 250 };
                                //    // Dimensions are in in px
                                //    OcrInputImage.AddImage(PixelFinder.OCRImage, ContentArea);
                                //    var Result = Ocr.Read(OcrInputImage);
                                //    Result.SaveAsSearchablePdf("c:\\temp\\rectangle.pdf");
                                //    PixelFinder.OCRImage.Save("c:\\temp\\bitmap.jpeg");
                                //    string Text = new IronTesseract().Read(PixelFinder.OCRImage).Text;
                                //    logger.Debug("OCRResult: " + Result.Text);
                                //    logger.Debug("OCRResult: " + Text);
                                //    Console.WriteLine(Result.Text);
                                //}

                                //MouseActions.SetCursorPos(-260, 1009);

                                //todo setcursorposition relative to target window(multiple monitors)
                                //MouseActions.SetCursorPos(1452, 1020);
                                //var MsgBoxResult = MessageBox.Show("Is Curser Position Ok to Click?", "MouseClickPositionCheck - Start PvP", MessageBoxButton.YesNo);
                                //if(Convert.ToString(MsgBoxResult) == "Yes") {
                                //MouseActions.DoubleClickAtPosition(-466, 1014); --hits Blue OR Yellow Button--
                                MouseActions.DoubleClickAtPosition(-180, 1014); //only BlueButton
                                Stopwatch s = new Stopwatch();
                                Sleep(1000);
                                if(PixelFinder.SearchStaticPixel(1430, 997, "#C4B827") == true || PixelFinder.SearchStaticPixel(1430, 997, "#BAAB01")) { //Yellow "Weiter" button (Storage Full)
                                    Console.WriteLine("YellowButton Recogniced");
                                    if(PixelFinder.SearchStaticPixel(1027, 724, "#FFFFFF")) {  //Kisten können verschmolzen werden 4/4
                                        MouseActions.DoubleClickAtPosition(-893, 724); //clicks melt button
                                        logger.Debug("4 Chests rdy - clicking melt button");
                                        Sleep(2000);
                                        MouseActions.DoubleClickAtPosition(-180, 1014);
                                        Sleep(2000);
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
                async void TaskHandlerPos11() {
                    //await Task.Delay(1);
                    int i = 1;
                    while(PositionCount == 11 && StopAutoPvP == false) {
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
                async void TaskHandlerPos12() {
                    //await Task.Delay(1);
                    int i = 1;
                    Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt"));
                    // ---Special Sleep---
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
                    }
                    s.Stop();

                    Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt"));

                    while(PositionCount == 12 && StopAutoPvP == false) { //while clock pixel is found
                        Score = 0;
                        i++;
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
                async void TaskHandlerPos13() {
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

                        Console.WriteLine("Starting MouseClick - " + DateTime.Now.ToString("h:mm:ss tt"));

                        KeyboardInput.Send(KeyboardInput.ScanCodeShort.KEY_F);
                        //MoveMouseToSecurePosition - AvoidClickingPopups
                        //MouseActions.SetCursorPos(-960, 326);
                        //MouseActions.ClickSpam(AmountOfClicks, DurationBetwClicks);

                        Console.WriteLine("End MouseClick - " + DateTime.Now.ToString("h:mm:ss tt"));

                        Console.WriteLine("Pos13: " + i);
                        i++;
                        Score = 0;

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
                async void TaskHandlerPos14() {
                    //await Task.Delay(1);
                    int i = 1;
                    Console.WriteLine("MousClickSTop/start");
                    while(PositionCount == 14 && StopAutoPvP == false) {
                        if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                            logger.Debug("AutoPvP interrupted by user at Pos:" + Convert.ToString(PositionCount));
                            BackgroundworkerConfig.BgwCancelAsyn(BackgroundworkerConfig.backgroundWorker1); //MouseClick
                            BackgroundworkerConfig.BgwCancelAsyn(BackgroundworkerConfig.backgroundWorker3); //MouseMovement
                            PositionCount = 10;
                            StopAutoPvP = true;
                        }
                        if(i > 60) {
                           BackgroundworkerConfig.BgwCancelAsyn(BackgroundworkerConfig.backgroundWorker1);
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
