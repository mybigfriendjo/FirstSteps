using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using AutoSF.Helper;
using NLog;

namespace AutoSF {
    class DismissSoldier {

        private static Logger log = LogManager.GetCurrentClassLogger();
        private static bool StopSoldierDismiss =  false;

        public static void StartDismissingSoldiers() {
            Thread TaskSoldierScan = new Thread(DissmissMissingSoldiers);
            TaskSoldierScan.SetApartmentState(ApartmentState.STA);
            TaskSoldierScan.Start();
        }

        private static void DissmissMissingSoldiers() {
            if(CheckforTruppkameradenliste() == 1) {
                MouseActions.SingleClickAtPosition(-122, 925);
                if(CheckforFilterScreen() == 1) {
                    MouseActions.SingleClickAtPosition(-742, 218); //nicht verfügbar
                    MainWindow.Sleep(150);
                    MouseActions.SingleClickAtPosition(-551, 611); // activate 1*
                    MainWindow.Sleep(150);
                    MouseActions.SingleClickAtPosition(-742, 218); // activate 2*
                    MainWindow.Sleep(150);
                    MouseActions.SingleClickAtPosition(-1738, 209); // Close FilterScreen
                    MainWindow.Sleep(250);
                    if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                        log.Debug("Dismissing Soldiers interrupted by user at: CheckforTruppkameradenliste");
                        StopSoldierDismiss = true;
                        return;
                    }
                    string[] ImageLocation = ImgSearch.UseImageSearch(MainWindow.ResourcesPath + "booster.png", "120", -1920,748,0,120);
                    if (StopSoldierDismiss == false && ImageLocation != null && ImageLocation.Length > 0) {
                        int.TryParse(ImageLocation[1], out int x);
                        int.TryParse(ImageLocation[1], out int y);
                        MouseActions.SingleClickAtPosition(x - 100, y - 200); //upperleft corner of picture (which is in the "Bergung" Button) -> to middle of soldier screen
                        if(CheckforSoldierDissmissScreen() == 1) {
                            MouseActions.SingleClickAtPosition(-1834, 997); // Dissmiss Soldier
                            if(CheckforAcceptDissmissScreen() == 1) {
                                MouseActions.SingleClickAtPosition(-421, 811); //"Accept" Dismiss Button
                            }
                            else {
                                StopSoldierDismiss = true;
                                return;
                            }
                        }
                        else {
                            StopSoldierDismiss = true;
                            return;
                        }
                    }
                    else if(StopSoldierDismiss == false && ImageLocation == null) {
                        //scroll 3boosters
                        int i = 0;
                        while(StopSoldierDismiss == false && i < 3) {
                            if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                                log.Debug("Dismissing Soldiers interrupted by user at: CheckforTruppkameradenliste");
                                StopSoldierDismiss = true;
                                return;
                            }
                            int moveToX = 0;
                            if(MainWindow.CurrentHostName == "VMgr4ndpa") {
                                MouseActions.SetCursorPos(1868, 484);
                                moveToX = 1715;
                                MouseActions.LeftMouseDown();
                                while(moveToX > 48 && StopSoldierDismiss == false) {
                                    if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                                        log.Debug("AutoMission interrupted by user at: selecting Booster");
                                        StopSoldierDismiss = true;
                                        return;
                                    }
                                    moveToX -= 90;
                                    MouseActions.SetCursorPos(moveToX, 484);
                                    MainWindow.Sleep(34);
                                }
                            }
                            else {
                                MouseActions.SetCursorPos(-52, 557);
                                moveToX = -215;
                                MouseActions.LeftMouseDown();
                                while(moveToX > -1872 && StopSoldierDismiss == false) {
                                    if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                                        log.Debug("AutoMission interrupted by user at: selecting Booster");
                                        StopSoldierDismiss = true;
                                        return;
                                    }
                                    moveToX -= 90;
                                    MouseActions.SetCursorPos(moveToX, 484);
                                    MainWindow.Sleep(34);
                                }
                            }
                            MainWindow.Sleep(150);
                            MouseActions.LeftMouseUp();
                            i++;
                            if(StopSoldierDismiss == false && ImgSearch.UseImageSearch(MainWindow.ResourcesPath + "booster.png", "120", -1920, 748, 0, 120) != null) {
                                break;
                            }
                            else if(StopSoldierDismiss == true) {
                                return;
                            }
                        }

                    }
                    else if(StopSoldierDismiss == true) {
                        return;
                    }
                }
                else {
                    StopSoldierDismiss = true;
                    return;
                }
            }
            else {
                StopSoldierDismiss = true;
                return;
            }
        }

        private static int CheckforTruppkameradenliste() { //Check for Truppkameradenliste (soldier selection inside the base)
            int Score = 0;
            int i = 0;
            while(Score < 2 && StopSoldierDismiss == false) {
                Score = 0;
                if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                    log.Debug("Dismissing Soldiers interrupted by user at: CheckforTruppkameradenliste");
                    StopSoldierDismiss = true;
                    return -1;
                }
                if(PixelFinder.SearchStaticPixel(417, 948, "#60A0B9")) { Score++; } // Button Verteidigung
                if(PixelFinder.SearchStaticPixel(906, 122, "#0F2D51")) { Score++; } // Background of Truppkameraden-liste
                if(PixelFinder.SearchStaticPixel(1826, 12, "#FEFEFE")) { Score++; } // x in the upper right to close window
                LoopGarbageCollector.ClearGarbageCollector();
                if(++i > 25) {
                    log.Debug("Truppkameradenliste couldnt be found in time:");
                    return -1;
                }
            }
            return 1;
        }

        private static int CheckforFilterScreen() { //Check for Filterscreen in Truppkameradenliste (soldier selection inside the base)
            int Score = 0;
            int i = 0;
            while(Score < 2 && StopSoldierDismiss == false) {
                Score = 0;
                if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                    log.Debug("Dismissing Soldiers interrupted by user at: CheckforFilterScreen");
                    StopSoldierDismiss = true;
                    return -1;
                }
                if(PixelFinder.SearchStaticPixel(865, 134, "#1B4C71")) { Score++; } //u of Tr>U<ppkamm in the background
                if(PixelFinder.SearchStaticPixel(832, 869, "#153C5F")) { Score++; } //blue border of filter screen
                if(PixelFinder.SearchStaticPixel(1778, 924, "#3A9F64")) { Score++; } //active filter button
                LoopGarbageCollector.ClearGarbageCollector();
                if(++i > 25) {
                    log.Debug("FilterScreen couldnt be found in time:");
                    return -1;
                }
            }
            return 1;
        }

        private static int CheckforSoldierDissmissScreen() { //Check for Screen where you can dismiss solider
            int Score = 0;
            int i = 0;
            while(Score < 2 && StopSoldierDismiss == false) {
                Score = 0;
                if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                    log.Debug("Dismissing Soldiers interrupted by user at: CheckforFilterScreen");
                    StopSoldierDismiss = true;
                    return -1;
                }
                if(PixelFinder.SearchStaticPixel(50, 1001, "#DE4844")) { Score++; } //redDissmissButton
                if(PixelFinder.SearchStaticPixel(80, 984, "#FFFFFF")) { Score++; } //white garbagecollector on the red button
                if(PixelFinder.SearchStaticPixel(1854, 966, "#18BEEF")) { Score++; } //blue Berger Sign
                LoopGarbageCollector.ClearGarbageCollector();
                if(++i > 25) {
                    log.Debug("FilterScreen couldnt be found in time:");
                    return -1;
                }
            }
            return 1;
        }

        private static int CheckforAcceptDissmissScreen() { //Check for Screen to accept the dismiss
            int Score = 0;
            int i = 0;
            while(Score < 2 && StopSoldierDismiss == false) {
                Score = 0;
                if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                    log.Debug("Dismissing Soldiers interrupted by user at: CheckforFilterScreen");
                    StopSoldierDismiss = true;
                    return -1;
                }
                if(PixelFinder.SearchStaticPixel(297, 270, "#113662")) { Score++; } //dark blue Soldierpicture background
                if(PixelFinder.SearchStaticPixel(232, 812, "#63798C")) { Score++; } //grey "ablehnen" button
                if(PixelFinder.SearchStaticPixel(1692, 813, "#177FBE")) { Score++; } //blue accept button
                LoopGarbageCollector.ClearGarbageCollector();
                if(++i > 25) {
                    log.Debug("FilterScreen couldnt be found in time:");
                    return -1;
                }
            }
            return 1;
        }
    }
}
