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
        
        public int PositionCount = 10;

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
                    break;
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
                
                MouseActions.SetCursorPos(-273, 539);
                var MsgBoxResult = MessageBox.Show("Is Curser Position Ok to Click?","MouseClickPositionCheck - SwitchToPvP",MessageBoxButton.YesNo);
                if(Convert.ToString(MsgBoxResult) == "Yes") {
                    MouseActions.DoubleClickAtPosition(-273, 539); //Spielen/Start Button
                }
                else {
                    Close();
                }
            }


            if(PositionCount == 10) { //scans for: PvP-Screen / Enemy Selection - Lupe/KapfprotocollIcon/Aktualisieren
                TaskHandlerPos10();
                async void TaskHandlerPos10() {
                    //await Task.Delay(1);
                    int i = 1;
                    while(PositionCount == 10) {
                        if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.M)) {
                            Console.WriteLine("AutoPvP interrupted");
                            PositionCount = 10;
                            break;
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
                            }//Button is Blue
                            else if(PixelFinder.SearchStaticPixel(1452, 1020, "#1E86C5") == true && PixelFinder.SearchStaticPixel(1709, 1007, "#FFFFFF") == true) {
                                Console.WriteLine("Score Ok (" + Score + ")");
                                Console.WriteLine("Entering Room1");
                                PositionCount = 11;

                                MouseActions.SetCursorPos(-260, 1009);

                                //todo setcursorposition relative to target window(multiple monitors)
                                //MouseActions.SetCursorPos(1452, 1020);
                                var MsgBoxResult = MessageBox.Show("Is Curser Position Ok to Click?", "MouseClickPositionCheck - Start PvP", MessageBoxButton.YesNo);
                                if(Convert.ToString(MsgBoxResult) == "Yes") {
                                    MouseActions.DoubleClickAtPosition(-260, 1009);
                                }
                                else {
                                    Close();
                                }
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
                            break;
                        }
                        Console.WriteLine("Pos11: " + i);
                        i++;
                        Score = 0;
                        if(PixelFinder.SearchStaticPixel(46, 71, "#E1BF05")) { Score++; }
                        if(PixelFinder.SearchStaticPixel(408, 77, "#FFD801")) { Score++; }
                        if(PixelFinder.SearchStaticPixel(824, 840, "#F5D001")) { Score++; }
                        LoopGarbageCollector.ClearGarbageCollector();
                        if(Score >= 2) {
                            Console.WriteLine("Score Ok (" + Score + ")");
                            Console.WriteLine("Skipping Room1 Intro");
                            PositionCount = 12;

                            MouseActions.SetCursorPos(-966, 590);
                            var MsgBoxResult = MessageBox.Show("Is Curser Position Ok to Click?", "MouseClickPositionCheck - SwitchToRoom2", MessageBoxButton.YesNo);
                            if(Convert.ToString(MsgBoxResult) == "Yes") {
                                MouseActions.DoubleClickAtPosition(-966, 590);
                                TaskWait(2000);
                                
                                SendKeys.Send("F");
                                while(PixelFinder.SearchStaticPixel(824, 840, "#F5D001")){
                                    MouseActions.Click();
                                }
                            }
                            else {
                                Close();
                            }
                        }
                    }
                }
            }

            if(PositionCount == 12) { //scans for: Entrance Room2
                TaskHandlerPos12();
                async void TaskHandlerPos12() {
                    //await Task.Delay(1);
                    int i = 1;
                    while(PositionCount == 12) {
                        if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.M)) {
                            Console.WriteLine("AutoPvP interrupted");
                            PositionCount = 10;
                            break;
                        }
                        Console.WriteLine("Pos11: " + i);
                        i++;
                        Score = 0;
                        if(PixelFinder.SearchStaticPixel(117, 587, "#853C08")) { Score++; }
                        if(PixelFinder.SearchStaticPixel(435, 568, "#47433A")) { Score++; }
                        if(PixelFinder.SearchStaticPixel(1819, 648, "#292B33")) { Score++; }
                        LoopGarbageCollector.ClearGarbageCollector();
                        if(Score >= 2) {
                            Console.WriteLine("Score Ok (" + Score + ")");
                            Console.WriteLine("Entering Room2");
                            PositionCount = 13;

                            MouseActions.SetCursorPos(-966, 590);
                            var MsgBoxResult = MessageBox.Show("Is Curser Position Ok to Click?", "MouseClickPositionCheck - SwitchToRoom2", MessageBoxButton.YesNo);
                            if(Convert.ToString(MsgBoxResult) == "Yes") {
                                MouseActions.DoubleClickAtPosition(-966, 590);
                                
                                
                            }
                            else {
                                Close();
                            }
                        }
                    }
                }
            }
        }

        private void CheckPixelInArea() {
            //PixelFinder.SearchPixelInArea(UpperLeft_x.,UpperLeft_y,LowerRight_x,LowerRight_y)
            /*
            Rectangle RectPvPRoom2Entrance1 = new Rectangle() {
                X = 14,
                Y = 497,
                Width = 130,
                Height = 70
            };
            */

            //PixelsInside: 73330B, 7E3908, 934208
            //PixelFinder.SearchPixelInArea(RectPvPRoom2Entrance1, "73330B", "7E3908", "934208");
        }
    }
}
