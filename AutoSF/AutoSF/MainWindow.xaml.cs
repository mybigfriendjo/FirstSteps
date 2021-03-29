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
using System.Linq;
using System.Data;
using System.Text;
using System.IO;

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
            DB.InitializeDB();
            CacheDb.InitializeCacheDb();

            [DllImport("user32.dll")]
            static extern bool SetForegroundWindow(IntPtr hWnd);
            foreach(var process in Process.GetProcessesByName("AutoSF")) {
                SetForegroundWindow(process.MainWindowHandle);
            }

            Thread AUtoMissionHotkeyThread = new Thread(ActivateAutoMissionHotkey); //Enabels AutomissionStartHotkey
            AUtoMissionHotkeyThread.SetApartmentState(ApartmentState.STA);
            AUtoMissionHotkeyThread.Start();
            //ActivateAutoMissionHotkey(); //Enabels AutomissionStartHotkey

        }

        private static Logger log = LogManager.GetCurrentClassLogger();


        public double PositionCount = 10;
        public static bool LeftMouseDown = false;
        //int AmountOfClicks = 450;
        //int DurationBetwClicks = 6;
        public static bool StopAutoPvP = false;
        public static bool StopAutoMission = false;
        //public IntPtr SFWindowHandle = WinSystem.WindowActivate();
        int WinCount = 0;
        int LoseCount = 0;
        public static string CurrentHostName = System.Net.Dns.GetHostName();
        public static int DontUseMouse = 0;
        public static int DontMoveMouse = 1;
        public static int Spam2Active = 0;
        public static int Spam3Active = 0;
        public static int StuckIntro = 0;
        public static int MoveOn = 0; //if activated it will move from mission to missionä
        public static string ResourcesPath = @"C:\Temp\Resources\";
        


        public void ActivateAutoMissionHotkey() { //enables HotKeyforAutoStartMission
            StopAutoPvP = false;

            while(30 < 40 && StopAutoMission == false) { //endless loop
                if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad2)) {
                    log.Debug("AutoMission start triggered by hotkey");
                    AutoMission.StartAutoMissionThread();
                    Sleep(400); //ensure it gets only triggered once
                }
            }
        }
            
        

        public void btnAutoMission_Click(object sender, RoutedEventArgs e) {
            /* 
             * FilterSelection -> use pixelfinder to fasten up  
             * Add alternative if no soldier is found 
             * 
             */
            //Start Game if not running -> setActive
                WinSystem.WindowActivate(true);
            //getCurrentPosition
            bool PositionFound = false;
            bool ReachedTarget = false;
            if(CheckIfStartScreen() == false && StopAutoMission == false) {
                if(CheckIfNavigationScreen() == false && StopAutoMission == false) {
                    if(CheckIfMissionScreen() == false && StopAutoMission == false) {
                        if(CheckIfAtSpezialMission() == false && StopAutoMission == false) {
                            Console.WriteLine("Position Unknown");
                        }
                        else if(StopAutoMission == false) {
                            Console.WriteLine("Position Found at Specialmiss.Navigated to R19-Availible SpecialMissions. Starting AutoMission now.");
                            AutoMission.StartAutoMissionThread();
                        }
                    }
                    else if(StopAutoMission == false) {
                        Console.WriteLine("Position Found at MissionScreen.Navigated to R19-Availible SpecialMissions. Starting AutoMission now.");
                        AutoMission.StartAutoMissionThread();
                    }
                }
                else if(StopAutoMission == false) {
                    Console.WriteLine("Position Found at NavigationScreen.Navigated to R19-Availible SpecialMissions. Starting AutoMission now.");
                    AutoMission.StartAutoMissionThread();
                }
            }
            else if(StopAutoMission == false) {
                Console.WriteLine("Position Found at StartScreen.Navigated to R19-Availible SpecialMissions. Starting AutoMission now.");
                AutoMission.StartAutoMissionThread();
            }



            bool CheckIfStartScreen() {
                int HiddenScore = 0;
                int Score = 0;
                if(OCR.OCRcheck(1508, 972, 179, 50) == "START") {
                    //Ensure its StartScreen 
                    if(PixelFinder.SearchStaticPixel(85, 983, "#6EF2F9")) { Score++; } //PowerOff button
                    if(PixelFinder.SearchStaticPixel(1851, 1007, "#FFFFFF")) { Score++; }
                    //Check for points that should be hidden if overlay
                    if(PixelFinder.SearchStaticPixel(1144, 545, "#7B6E76")) { HiddenScore++; }
                    if(PixelFinder.SearchStaticPixel(1422, 957, "#64ABD6")) { HiddenScore++; }
                    if(Score >= 1) {
                        if(HiddenScore >= 1) {
                            Console.WriteLine("StartScreen Confirmed. Navigate to NavigationScreen");
                            MouseActions.SingleClickAtPosition(-220, 1005); //Click Start button 
                            Sleep(1000);
                            CheckIfNavigationScreen();
                            PositionFound = true;
                            return true;
                        }
                        else {
                            PixelFinder.BackupImage.Save("C:\\temp\\" + DateTime.Now.ToString("dd/MM/yyyy_HH-mm-ss") + "_StartscreenPopup.jepg");
                            if(OCR.OCRcheck(1555, 113, 48, 48) == "%") { //the fat "X" gets recognized as %
                                Console.WriteLine("Popup found - close with click on X");
                                MouseActions.DoubleClickAtPosition(-339, 135);
                            }
                            //Repeat Check for points that should be hidden if overlay
                            if(PixelFinder.SearchStaticPixel(1144, 545, "#7B6E76")) { HiddenScore++; }
                            if(PixelFinder.SearchStaticPixel(1422, 957, "#64ABD6")) { HiddenScore++; }
                            if(HiddenScore >= 1) {
                                Console.WriteLine("StartScreen Confirmed. Navigate to NavigationScreen");
                                MouseActions.DoubleClickAtPosition(-220, 1005); //Click Start button
                                Sleep(1000);
                                CheckIfNavigationScreen();
                                PositionFound = true;
                                return true;
                            }
                        }
                    }    
                }
                return PositionFound;
            }

            bool CheckIfNavigationScreen() {
                int Score = 0;
                if(PixelFinder.SearchStaticPixel(62, 1025, "#1C3E40")) { Score++; } //(darkend)PowerOff button
                if(PixelFinder.SearchStaticPixel(1245, 353, "#CA0203")) { Score++; } //Klan
                if(PixelFinder.SearchStaticPixel(1297, 778, "#454A76")) { Score++; } //Basis
                if(PixelFinder.SearchStaticPixel(803, 734, "#804F73")) { Score++; } //Arena
                LoopGarbageCollector.ClearGarbageCollector();
                if(Score >= 3) {
                    Console.WriteLine("NavigationScreen Confirmed. Navigate to Missions");
                    MouseActions.DoubleClickAtPosition(-309, 361); //Click Missionen button 
                    Sleep(1000);
                    CheckIfMissionScreen();
                    PositionFound = true;
                }
                return PositionFound;
            }

            bool CheckIfMissionScreen() {
                int Score = 0;
                int RightArrow = 2;
                int LeftArrow = 2;

                if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                    log.Debug("AutoMission interrupted by user at CheckIfMissionScreen");
                    StopAutoMission = true;
                    return PositionFound;
                }

                if(PixelFinder.SearchStaticPixel(1308, 188, "#C6F7BD")) { Score++; } //Money upperRightCorner 
                if(PixelFinder.SearchStaticPixel(1345, 149, "#6EC1F4")) { Score++; } //Questionmark in Money upperRightCorner
                if(PixelFinder.SearchStaticPixel(82, 538, "#91EBF7")) { Score++; } //Leftarrow - RegionSelection
                else { LeftArrow = 0; }
                if(PixelFinder.SearchStaticPixel(1326, 539, "#91EBF7")) { Score++; } //Rightarrow - RegionSelection
                else { RightArrow = 0; }

                LoopGarbageCollector.ClearGarbageCollector();
                if(Score >= 2) {
                    PositionFound = true;
                    if(LeftArrow == 0) {
                        Console.WriteLine("MissionScreen R1 found. Navigating to R19!");
                        if(ReachedTarget == false) {
                            NavigateToR19();
                        }
                    }
                    else if(RightArrow == 0) {
                        Console.WriteLine("MissionScreen R32 found. Navigating to R19!");
                        if(ReachedTarget == false) {
                            NavigateToR19();
                        }
                    }
                    else {
                        Console.WriteLine("MissionScreen found. Checking if R19! else navigating to R19!");
                        if("R19" == OCR.OCRcheck(544, 909, 88, 40)) { //checks for Region19 "R19" (Bottom)
                            MouseActions.DoubleClickAtPosition(-1228, 543); //R19 Spezialmissionen
                            Sleep(2000);
                        }
                        else {
                            if(ReachedTarget == false) {
                                NavigateToR19();
                            }
                        }
                    }

                    
                }
                else {
                    PositionFound = false;
                }
                return PositionFound;
            }

            void NavigateToR19() {
                if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                    log.Debug("AutoMission interrupted by user at CheckIfMissionScreen");
                    StopAutoMission = true;
                    return;
                }
                if(PixelFinder.SearchStaticPixel(667, 1046, "#FFFFFF")) { //FirstArea of missions (BottomMid LeftWhiteDot)
                    MouseActions.DoubleClickAtPosition(-607, 1005); //LastRegion at RegionArea1
                    Sleep(1000);
                    MouseActions.DoubleClickAtPosition(-587, 540); //RightArrow into RegionArea2
                    Sleep(1000);
                    MouseActions.DoubleClickAtPosition(-1672, 1004); //R19 regionbar

                }
                else if(PixelFinder.SearchStaticPixel(744, 1046, "#FFFFFF")) { //SecondArea of missions (BottomMid RightWhiteDot)
                    //Sleep(2000);
                    MouseActions.DoubleClickAtPosition(-1672, 1004); //R19 regionbar
                }
                Sleep(1500);
                MouseActions.DoubleClickAtPosition(-1228, 543); //R19 Spezialmissionen
                Sleep(2500);
                string OCRR19 = OCR.OCRcheck(796, 145, 92, 47,"R19");
                if("R19" == OCRR19) { //checks for Region19 "R19" (TopBar)
                    Console.WriteLine("Moved to R19 SpezialMissions successfully");
                    ReachedTarget = true;
                }
                else {
                    Console.WriteLine("Something went wrong. Where the fuck are we?");
                    StopAutoMission = true;
                }
            }

            bool CheckIfAtSpezialMission(){
                int Score = 0;
                if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                    log.Debug("AutoMission interrupted by user at: Checking for Position 'SpezialMission'");
                    StopAutoMission = true;
                    return false;
                }
                if(PixelFinder.SearchStaticPixel(695, 173, "#63DCFF")) { Score++; } //left changeRegion Arrow
                if(PixelFinder.SearchStaticPixel(1226, 168, "#63DCFF")) { Score++; } //right changeRegion Arrow
                if(PixelFinder.SearchStaticPixel(33, 186, "#9A9DA9")) { Score++; } //thin gray border

                LoopGarbageCollector.ClearGarbageCollector();
                if(Score >= 2) {
                    log.Debug("Position 'SpezialMission' found - checking for correct start Region R19");
                    string OCRR19 = OCR.OCRcheck(796, 145, 92, 47, "R19");
                    if("R19" == OCRR19) { //checks for Region19 "R19" (TopBar)
                        Console.WriteLine("Moved to R19 SpezialMissions successfully");
                        ReachedTarget = true;
                    }
                    else {
                        Console.WriteLine("Not R19, navigating to correct Region.");
                        MouseActions.SingleClickAtPosition(-1869, 51); //clicks "back" Button to return to missionscreen
                        Sleep(500);
                        NavigateToR19();
                    }

                    return true;
                }
                else {
                    log.Debug("FirstFilterMenu couldnt be found. Please Navigate into a mission -> filter");
                    return false;
                }
            }


        }
        

        private void btnCodeTest_Click(object sender, RoutedEventArgs e) {
            ///////////////////////// vvv CodeTestArea vvv \\\\\\\\\\\\\\\\\\\\\
            ///
            CacheDb.GetSoldiers(6,5, "rstarnung", "rsverkleidung", "rsvip", "rsgeiseln", "rsfahrzeug");
            CacheDb.GetSoldiersSelect();

            DataGridTableCacheDB.ItemsSource = CacheDb.DataTableFilteredSoldiers.DefaultView;

            ///////////////////////// ^^^ CodeTestArea ^^^ \\\\\\\\\\\\\\\\\\\\\
            string ImJustAPossibleBreakPoint = "";
        }

        private void btnAutoDelSoldiers_Click(object sender, RoutedEventArgs e) {
            DismissSoldier.StartDismissingSoldiers();
        }

        private void btnAutoPvP_Click(object sender, RoutedEventArgs e) {
            log.Debug("AutoPvp Start");
            CloseBackgroundWorkers();
            StopAutoPvP = false;

            Thread TaskPvPCheckPixel = new Thread(TaskHandler);
            TaskPvPCheckPixel.SetApartmentState(ApartmentState.STA);
            TaskPvPCheckPixel.Start();
            //TaskPvPCheckPixel.Join();

            //create FVK (freeVirtualKeyboard).ini
            StringBuilder IniSettings = new StringBuilder("[Main]\n");
            IniSettings.Append("Site=1\n");
            IniSettings.Append("Keyboard=3\n");
            IniSettings.Append("AutoClick=1\n");
            IniSettings.Append("FitWidth=0\n");
            IniSettings.Append("AlphaBlend=0\n");
            IniSettings.Append("TMainFormTop=0\n");
            IniSettings.Append("TMainFormLeft=1652\n");
            IniSettings.Append("TMainFormHeight=108\n");
            IniSettings.Append("TMainFormWidth=268\n");
            IniSettings.Append("TMainFormState=0\n");
            using(StreamWriter sw = new StreamWriter(@"C:\Temp\resources\FreeVK.ini", false)) { //Streamwriter is of tpye IDisposable (objects that dont get deleted automatically) using(sw){ } disposes every sw object at "}"
                sw.WriteLine(IniSettings);
            }
            WinSystem.WindowActivateFreeVK(true);


            Sleep(4000);
            if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                log.Debug("AutoPvP interrupted by user at Pos:" + Convert.ToString(PositionCount));
                PositionCount = 10;
                StopAutoPvP = true;
            }
        }


        public void TaskHandler() { //public async void TaskHandler() {
            //await Task.Delay(1);
            int round = 1;
            while(round < 250 && StopAutoPvP == false) {
                if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                    log.Debug("AutoPvP interrupted by user at Pos:" + Convert.ToString(PositionCount));
                    PositionCount = 10;
                    StopAutoPvP = true;
                }
                Console.WriteLine(round);
                round++;
                log.Debug("Positioncount: " + PositionCount + " round = " + round +  "Starting Checkpixel"); 
                CheckPixel();
            }
            //Will Kill SF after 250 Games, Stop Backgroundworkers
            //if(StopAutoPvP == false) {
            //    WinSystem.WindowKill("mcfw");
            //}
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

        private void cbMoveOn_Click(object sender, RoutedEventArgs e) {
            if(cbMoveOn.IsChecked == true) {
                MoveOn = 1;
            }
            else {
                MoveOn = 0;
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
            WinSystem.WindowKill("FreeVK");
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
            log.Debug("Restart PvP-Bot after beeing Stuck");
            btnAutoPvP_Click(null,null);
        }

        //getWindowPosition (Size,Position)
        /*
        private void buttonGetWindowTitles_Click(object sender, EventArgs e) {
            log.Debug("getting all window titles");
            foreach(KeyValuePair<IntPtr, string> pair in WinSystem.GetAllWindowTitles()) {
                ///lvWindowTitles.AddObject(pair);
                lvWindowTitles.Items.Add(new ListViewItem(""));
            }
        }
        
        private void buttonWindowPosition_Click(object sender, EventArgs e) {
            log.Debug("checking selection");
            if(lvWindowTitles.SelectedItem == null) {
                logger.Warn("no item selected");
                return;
            }

            KeyValuePair<IntPtr, string> selectedObject = (KeyValuePair<IntPtr, string>)lvWindowTitles.SelectedObject;

            log.Debug("selected value: " + selectedObject.Value);

            log.Debug("getting window position");

            Rectangle windowPos = WinSystem.GetWindowRect(selectedObject.Key);

            log.Debug(windowPos.ToString());

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

                    
            if(PositionCount == 10 && StopAutoPvP == false) { //scans for: Challange-Screen  and PvP-Screen / Enemy Selection - Lupe/KapfprotocollIcon/Aktualisieren
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
                            log.Debug("Stuck - i at" + i + ", current Programm Position is: " + PositionCount);
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
                            log.Debug("AutoPvP interrupted by user at Pos:" + Convert.ToString(PositionCount));
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
                        if(Score >= 2 && StopAutoPvP == false) {
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
                                    if(PixelFinder.SearchStaticPixel(1027, 724, "#FFFFFF") && StopAutoPvP == false) {  //Kisten können verschmolzen werden 4/4
                                        MouseActions.DoubleClickAtPosition(-776, 755); //clicks melt button
                                        log.Debug("4 Chests rdy - clicking melt button");
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
                                        log.Debug("4 Chests CD - clicks Yellow button");
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
                            log.Debug("Stuck - i at" + i + ", current Programm Position is: " + PositionCount);
                            StuckOnIntro();
                        }
                        if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                            log.Debug("AutoPvP interrupted by user at Pos:" + Convert.ToString(PositionCount));
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
                            if(Spam2Active == 1 || Spam3Active == 1) {
                                Sleep(100);
                                WinSystem.WindowActivateFreeVK(true); //Starts virtual Keyboard
                                if(Spam2Active == 1) {
                                    KeyboardInput.Send(KeyboardInput.ScanCodeShort.KEY_2);
                                    SendKeys.Send("2");
                                    MouseActions.SingleClickAtPosition(-192, 49); //2
                                }
                                if(Spam3Active == 1 && i == 1) {   //only activate "3" once - pressing it again would disable it
                                    //KeyboardInput.Send(KeyboardInput.ScanCodeShort.KEY_3);
                                    MouseActions.SingleClickAtPosition(-178, 49); //3
                                }
                                Sleep(25);
                                WinSystem.WindowActivate(false);
                            }

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
                    Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH-mm-ss"));
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
                            log.Debug("Stuck - i at" + i + ", current Programm Position is: " + PositionCount);
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
                            log.Debug("AutoPvP interrupted by user at Pos:" + Convert.ToString(PositionCount));
                            PositionCount = 10;
                            StopAutoPvP = true;
                        }
                        KeyboardInput.Send(KeyboardInput.ScanCodeShort.KEY_F);

                        Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt") + " Pos13: " + i);
                        log.Debug("Pos13: " + i);
                        i++;
                        Score = 0;
                        if(i > 400) {
                            Console.WriteLine("Stuck - i at" + i + ", current Programm Position is: " + PositionCount);
                            log.Debug("Stuck - i at" + i + ", current Programm Position is: " + PositionCount);
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
                            log.Debug("Match lost at Pos:" + Convert.ToString(PositionCount) + " This is Lose Nr.: " + Convert.ToString(LoseCount));
                            PositionCount = 10;
                            MouseActions.DoubleClickAtPosition(-1681, 1024); //"Zurück" Button
                        }
                        else {
                            Console.WriteLine("Score Ok (" + Score + ")");
                            log.Debug("Entering Room2");
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
                            log.Debug("Stuck - i at" + i + ", current Programm Position is: " + PositionCount);
                            StuckOnIntro();
                        }
                        if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                            log.Debug("AutoPvP interrupted by user at Pos:" + Convert.ToString(PositionCount));
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
                            log.Debug("Match Won. This is Win Nr.: " + Convert.ToString(WinCount));
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
                            log.Debug("Match lost at Pos:" + Convert.ToString(PositionCount) + " This is Lose Nr.: " + Convert.ToString(LoseCount));
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
