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

namespace AutoSF {
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        /* todo >>>>>>>>>>>>>>>
        -class mouse
            .click
            .stopclick
            .moveright
            .moveleft
        -main
            .send F key


        ################################### */
        public MainWindow() {
            InitializeComponent();
            
        }

        public Logger logger = LogManager.GetCurrentClassLogger();
        public int PositionCount = 10;
        int AmountOfClicks = 200;
        int DurationBetwClicks = 6;

        private void btnAutoPvP_Click(object sender, RoutedEventArgs e) {
            Thread TaskPvPCheckPixel = new Thread(TaskHandler);
            TaskPvPCheckPixel.SetApartmentState(ApartmentState.STA);
            TaskPvPCheckPixel.Start();
            TaskPvPCheckPixel.Join();
        }

      public async void TaskHandler() {
            //await Task.Delay(1);
            int i = 1;
            while(i < 10) {
                if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.M)) {
                    Console.WriteLine("AutoPvP interrupted");
                    PositionCount = 10;
                    //break;
                    Close();
                }
                Console.WriteLine(i);
                i++;
                CheckPixel();
            }
        }

        public async void TaskWait(int DelayInMS) {
            await Task.Delay(DelayInMS);
        }

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
                    while(PositionCount == 10) {

                        //scans for: PvPStartScreen - grabs pixels in "Bestenliste/Ranking"- Icon and mouseover (Big Icon) - has to be allways executed
                        if(PixelFinder.SearchStaticPixel(1773, 418, "#73BBC6")) { Score++; }
                        if(PixelFinder.SearchStaticPixel(1798, 402, "#91EAF7")) { Score++; }
                        if(PixelFinder.SearchStaticPixel(1826, 422, "#3F8C97")) { Score++; }
                        if(PixelFinder.SearchStaticPixel(1772, 419, "#9ACED6")) { Score++; }
                        if(PixelFinder.SearchStaticPixel(1802, 409, "#AFF0F9")) { Score++; }
                        if(PixelFinder.SearchStaticPixel(1831, 425, "#74ACB4")) { Score++; }
                        if(Score >= 2) {
                            Console.WriteLine("Score Ok (" + Score + ")");
                            Console.WriteLine("Challange found. Entering PVP Screen");
                            MouseActions.DoubleClickAtPosition(-273, 539); //Spielen/Start Button
                        }

                        if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.M)) {
                            Console.WriteLine("AutoPvP interrupted");
                            PositionCount = 10;
                            //break;
                            Close();
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

                                //MouseActions.SetCursorPos(-260, 1009);

                                //todo setcursorposition relative to target window(multiple monitors)
                                //MouseActions.SetCursorPos(1452, 1020);
                                //var MsgBoxResult = MessageBox.Show("Is Curser Position Ok to Click?", "MouseClickPositionCheck - Start PvP", MessageBoxButton.YesNo);
                                //if(Convert.ToString(MsgBoxResult) == "Yes") {
                                MouseActions.DoubleClickAtPosition(-260, 1009);
                                TaskWait(300);
                                if(PixelFinder.SearchStaticPixel(1312, 958, "#D2CA61")) { //Yellow "Weiter" button (Storage Full)
                                    MouseActions.DoubleClickAtPosition(-1049, 1050);
                                }

                                //}
                                //else {
                                //    Close();
                                //}
                            }
                        }
                    }
                }
            }


            if(PositionCount == 11) { //scans for: Room1-Intro
                TaskHandlerPos11();
                async void TaskHandlerPos11() {
                    //await Task.Delay(1);
                    int i = 1;
                    while(PositionCount == 11) {
                        if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.M)) {
                            Console.WriteLine("AutoPvP interrupted");
                            PositionCount = 10;
                            //break;
                            Close();
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
                            MouseActions.DoubleClickAtPosition(-966, 590);
                            //}
                        }
                        else { //If PvP Intro doesnt appear - stillcontinue
                            PositionCount = 12;
                            MouseActions.DoubleClickAtPosition(-966, 590);
                        }
                    }
                }
            }

            if(PositionCount == 12) { //scans for: Entrance Room2
                TaskHandlerPos12();
                async void TaskHandlerPos12() {
                    //await Task.Delay(1);
                    int i = 1;

                    
                    Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt"));
                    // ---Special Sleep---
                    Stopwatch s = new Stopwatch();
                    s.Start();
                    while(s.Elapsed < TimeSpan.FromMilliseconds(2700)) {
                        //
                    }
                    s.Stop();
                    MouseActions.DoubleClickAtPosition(-966, 590);

                    s.Start();
                    while(s.Elapsed < TimeSpan.FromMilliseconds(1500)) {
                        KeyboardInput.Send(KeyboardInput.ScanCodeShort.KEY_F);
                    }
                    s.Stop();

                    Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt"));

                    //Process.Start("H:\\BackupData\\Selftraning\\Programmieren\\ahk\\Sniperfury\\AutoSFAssistent.ahk");
                    MouseActions.LeftMouseDown();
                    while(PositionCount == 12) { //while clock pixel is found
                        Score = 0;
                        i++;
                        Console.WriteLine("Pos12: " + i);
                        if(PixelFinder.SearchStaticPixel(911, 43, "#A3F5F6")) { Score++; } //VerticalBarRighttoClock
                        if(PixelFinder.SearchStaticPixel(777, 37, "#A3F5F6")) { Score++; } //VerticalBarLefttoClock
                        if(PixelFinder.SearchStaticPixel(803, 24, "#FFFFFF")) { Score++; } //Clock
                        LoopGarbageCollector.ClearGarbageCollector();

                        MouseActions.ClickSpam(10, 4);
                        KeyboardInput.Send(KeyboardInput.ScanCodeShort.KEY_F);
                        MouseActions.ClickSpam(AmountOfClicks, DurationBetwClicks);

                        if(Score <= 1) { //If Clock wasnt found
                            //Process.Start("H:\\BackupData\\Selftraning\\Programmieren\\ahk\\Sniperfury\\KillAutoSFscript.ahk");
                            Console.WriteLine("NoClockFound-Moving on");
                            PositionCount = 13;
                        }
                        KeyboardInput.Send(KeyboardInput.ScanCodeShort.KEY_F);
                    }
                }
            }

            if(PositionCount == 13) { //scans for: Entrance Room2
                TaskHandlerPos13();
                async void TaskHandlerPos13() {
                    //await Task.Delay(1);
                    int i = 1;

                    Stopwatch s = new Stopwatch();
                    s.Start();
                    while(s.Elapsed < TimeSpan.FromMilliseconds(1500)) {
                        //
                    }
                    s.Stop();
                    
                    while(PositionCount == 13) { 
                        if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.M)) {
                            Console.WriteLine("AutoPvP interrupted");
                            PositionCount = 10;
                            Close();
                        }

                        Console.WriteLine("Starting MouseClick - " + DateTime.Now.ToString("h:mm:ss tt"));

                        MouseActions.ClickSpam(AmountOfClicks, DurationBetwClicks);
                        KeyboardInput.Send(KeyboardInput.ScanCodeShort.KEY_F);

                        Console.WriteLine("End MouseClick - " + DateTime.Now.ToString("h:mm:ss tt"));

                        Console.WriteLine("Pos13: " + i);
                        i++;
                        Score = 0;

                        if(PixelFinder.SearchStaticPixel(104, 266, "#FFFFFF")) { Score--; }
                        if(PixelFinder.SearchStaticPixel(933, 156, "#FF4C4C")) { Score--; }
                        if(PixelFinder.SearchStaticPixel(970, 921, "#FF4C4C")) { Score--; }
                        LoopGarbageCollector.ClearGarbageCollector();
                        if(Score <= -2) {
                            PositionCount = 10;
                            Console.WriteLine("Match lost");
                            MouseActions.DoubleClickAtPosition(-1681, 1024); //"Zurück" Button
                        }
                        else {
                            Console.WriteLine("Score Ok (" + Score + ")");
                            Console.WriteLine("Entering Room2");
                            PositionCount = 14;
                            MouseActions.DoubleClickAtPosition(-966, 590);
                        }
                    }
                }
            }

            if(PositionCount == 14) { //scans for: Match Won
                TaskHandlerPos14();
                async void TaskHandlerPos14() {
                    //await Task.Delay(1);
                    int i = 1;
                    while(PositionCount == 14) {
                        if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.M)) {
                            Console.WriteLine("AutoPvP interrupted");
                            MouseActions.LeftMouseUp();
                            PositionCount = 10;
                            Process.Start("H:\\BackupData\\Selftraning\\Programmieren\\ahk\\Sniperfury\\KillAutoSFscript.ahk");
                            //break;
                            Close();
                        }

                        MouseActions.ClickSpam(AmountOfClicks, DurationBetwClicks);

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
                            Console.WriteLine("Score Ok (" + Score + ")");
                            Console.WriteLine("Match won");
                            PositionCount = 10;
                            MouseActions.DoubleClickAtPosition(-260, 1009);
                        }
                        else if(Score <= -2) { //Lose
                            PositionCount = 10;
                            Console.WriteLine("Match lost");
                            MouseActions.DoubleClickAtPosition(-1681, 1024); //"Zurück" Button
                        }
                    }
                }
            }
        }
    }
}
