using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using AutoSF.Helper;
using System.IO;
using System.Data.Common;
using NLog;
using System.Windows.Input;
using System.Threading;
using System.Diagnostics;
using Microsoft.VisualBasic;
using ImageFinderNS;
using System.Drawing;
using System.Windows.Forms;

namespace AutoSF {
    public static class AutoMission {

        #region UpdateMainWindowGui //multiple tasks 
        public interface IAutomissionListener {
            void Update(DataTable DtInput);
        }   

        private static List<IAutomissionListener> Listeners = new List<IAutomissionListener>();
        
        public static void RegisterListener(IAutomissionListener newListener) {
            Listeners.Add(newListener);
        }
        private static void UpdateListeners(DataTable DtInput) {
            foreach(IAutomissionListener listener in Listeners) {
                listener.Update(DtInput);
            }
        }
        #endregion

        public static void StartAutoMissionThread() {
            Thread TaskSoldierScan = new Thread(StartAutoMission);
            TaskSoldierScan.SetApartmentState(ApartmentState.STA);
            TaskSoldierScan.Start();
        }


        public static void StartAutoMission() {

            /*
             * 
             * -drohnencheck  => test ausständig ->wird nicht aufgerufen!
             * 
             * -goldcheck
             * -sleeps durch pixelfinder ersetzen
             * -dynamische db erstellen
             *    >soldaten scannen und in db befüllen
             * -mausklicks/Inputs durch directX ersetzen
             * 
             * 
             * 
             */



            string OcrMissionname1 = "";
            string OcrMissionname2 = "";
            int MissionDifficulty = 0;

            Logger log = LogManager.GetCurrentClassLogger();
            bool Missionfound = false;
            string Missiontype = "";
            string CounterUsed = "";
            string[] CheckCounter = { };
            string[] CheckSoldierType = { };
            string ORCGetSuccessrate = "";
            bool StopAutoMission = false;
            int bluedrohne = 0;
            int golddrohne = 0;
            int successbooster = 0;
            int targetSuccessRate = 100;
            int ZeroCount = 0;
            DataRow[] result = null; //MissionData From DB
            DateTime LastSpeedMission = DateTime.Now.AddMinutes(-2);
            



            try {
                if(!Directory.Exists(MainWindow.ResourcesPath + "counter\\")) {
                    log.Error("couldn't find dynamicDB´s path '" + MainWindow.ResourcesPath + "counter\\" + "'");
                    //return false;
                }
            }
            catch(UnauthorizedAccessException) {
                log.Error("was denied access to dynamicDB´s path '" + MainWindow.ResourcesPath + "counter\\" + "'");
                //return false;
            }
            string[] Counters = { "RSKommunikation", "RSRadar", "RSBoot", "RSJetpack", "RSTarnung", "RSVerkleidung", "RSHelikopter", "RSGeiseln", "RSTaktiken", "RSVIP", "RSSprengstoffe", "RSAufklaerung", "RSBiologischeGefahr", "RSFahrzeug", "RSToedlich", "RSBegrenzteMunition" };
            string filename = "";
            string[] ImageResult = { "" };
            string FoundCounters = "";


            Dictionary<string, int[]> dicClickPos = new Dictionary<string, int[]>();
            #region DirectoryContentRegion //includes all Content for the Directory dicClickPos
            dicClickPos.Add("Sniper", new int[] { -1555, 230 });
            dicClickPos.Add("Sturm", new int[] { -1239, 230 });
            dicClickPos.Add("RPG", new int[] { -1092, 230 });
            dicClickPos.Add("Molotow", new int[] { -951, 230 });
            dicClickPos.Add("Elite", new int[] { -795, 230 });
            dicClickPos.Add("Beschuetzer", new int[] { -649, 230 });
            dicClickPos.Add("Attentaeter", new int[] { -492, 230 });
            dicClickPos.Add("Suppressor", new int[] { -358, 230 });

            dicClickPos.Add("RSKommunikation", new int[] { -720, 600 });
            dicClickPos.Add("RSToedlichSpezial", new int[] { -620, 600 });
            dicClickPos.Add("RSRadar", new int[] { -520, 600 });
            dicClickPos.Add("RSBiologischeGefahrSpezial", new int[] { -420, 600 });
            dicClickPos.Add("RSBoot", new int[] { -320, 600 });
            dicClickPos.Add("RSJetpack", new int[] { -220, 600 });
            dicClickPos.Add("RSTarnung", new int[] { -120, 600 });
            dicClickPos.Add("RSVerkleidung", new int[] { -720, 700 });
            dicClickPos.Add("RSHelikopter", new int[] { -620, 700 });
            dicClickPos.Add("RSBootSpezial", new int[] { -520, 700 });
            dicClickPos.Add("RSToedlich", new int[] { -420, 700 });
            dicClickPos.Add("RSGeiseln", new int[] { -320, 700 });
            dicClickPos.Add("RSVIP", new int[] { -220, 700 });
            dicClickPos.Add("RSSprengstoffe", new int[] { -120, 700 });
            dicClickPos.Add("RSTaktiken", new int[] { -720, 800 });
            dicClickPos.Add("RSBegrenzteMunitionSpezial", new int[] { -620, 800 });
            dicClickPos.Add("RSAufklaerung", new int[] { -520, 800 });
            dicClickPos.Add("RSBiologischeGefahr", new int[] { -420, 800 });
            dicClickPos.Add("RSFahrzeug", new int[] { -320, 800 });
            dicClickPos.Add("RSKommunikationSpezial", new int[] { -220, 800 });
            dicClickPos.Add("RSBegrenzteMunition", new int[] { -120, 800 });
            dicClickPos.Add("OnlySniper", new int[] { }); //Unknown................

            dicClickPos.Add("verfügbar", new int[] { -1132, 207 });
            dicClickPos.Add("nichtverfügbar", new int[] { -898, 205 });
            dicClickPos.Add("Stern1", new int[] { -1285, 400 });
            dicClickPos.Add("Stern2", new int[] { -1185, 400 });
            dicClickPos.Add("Stern3", new int[] { -1085, 400 });
            dicClickPos.Add("Stern4", new int[] { -985, 400 });
            dicClickPos.Add("Stern5", new int[] { -885, 400 });
            dicClickPos.Add("Stern6", new int[] { -1285, 500 });
            dicClickPos.Add("Stern7", new int[] { -1185, 500 });
            dicClickPos.Add("Stern8", new int[] { -1085, 500 });
            dicClickPos.Add("Stern9", new int[] { -985, 500  });
            dicClickPos.Add("Stern10", new int[] { -885, 500  });
            dicClickPos.Add("Stern11", new int[] { -1285, 600 });
            dicClickPos.Add("Stern12", new int[] { -1185, 600 });
            dicClickPos.Add("RandomSoldier1", new int[] { -1807, 922 });
            dicClickPos.Add("RandomSoldier2", new int[] { -1707, 922 });
            dicClickPos.Add("RandomSoldier3", new int[] { -1607, 922 });
            dicClickPos.Add("RandomSoldier4", new int[] { -1507, 922 });
            dicClickPos.Add("bluedrohne", new int[] { -615, 750 });
            dicClickPos.Add("golddrohne", new int[] { -891, 751 });

            dicClickPos.Add("BSSchnell", new int[] { -545, 419 }); //20 % speed
            dicClickPos.Add("BSMechaniker", new int[] { -745, 219 }); //20 %speed(bei aktiver drohne) -645, 219
            dicClickPos.Add("BSZeitgewinn", new int[] { -445, 419 }); //10 %speed
            dicClickPos.Add("BSKoordination", new int[] { -445, 219 }); //+10%winrate
            dicClickPos.Add("BSDrohne", new int[] { -745, 419 }); // +10%winrate (bei aktiver drohne)
            dicClickPos.Add("BSImprovisation", new int[] { -345, 319 }); //+5% kleinergleich 2st
            dicClickPos.Add("BSAufsteiger", new int[] { -245, 219 }); //+5% größergleich 4st
            dicClickPos.Add("BSGepanzert", new int[] { -645, 219 });
            dicClickPos.Add("BSSchwere Rüstung", new int[] { -545, 219 });
            dicClickPos.Add("BSAbsicherung", new int[] { -345, 219 }); //immun gegen klauen
            dicClickPos.Add("BSGeschäftemacher", new int[] { -745, 319 });
            dicClickPos.Add("BSÜberlebenskünstler", new int[] { -645, 319 });
            dicClickPos.Add("BSÜberlebensspezialist", new int[] { -545, 319 });
            dicClickPos.Add("BSGlück", new int[] { -445, 319 });
            dicClickPos.Add("BSRabatt", new int[] { -145, 219 });
            dicClickPos.Add("BSLehrer", new int[] { -145, 319 });
            dicClickPos.Add("BSUnabhängig", new int[] { -245, 319 }); //+5% solo
            dicClickPos.Add("BSTechnik", new int[] { -645, 419 });
            #endregion

            Stopwatch missionTime = Stopwatch.StartNew();

            

            if(MainWindow.MoveOn == 1) {
                while(MainWindow.MoveOn == 1 && StopAutoMission == false) {
                    if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                        log.Debug("AutoMission interrupted by user at: CheckforMoveOn");
                        StopAutoMission = true;
                        return;
                    }
                    MouseActions.SingleClickAtPosition(-1423, 939); //Click "Verfügbar"
                    MainWindow.Sleep(400);
                    if(MissionsAvailible() != 0 && StopAutoMission == false) { //checks for availible Missions
                        MouseActions.SingleClickAtPosition(-1372, 519); //click Mission to the left (not avilible Mission is at the right side)
                        if(CheckforInMissionScreen() != 1) { return; }

                        OcrMissionname1 = OCR.OCRcheck(15, 100, 475, 70); //bsp.: Hinweis
                        OcrMissionname2 = OCR.OCRcheck(12, 105, 475, 55);
                        result = DB.dt.Select("Missionname = '" + OcrMissionname1 + "'");
                        loadMission();

                        int Score = 0;
                        int i = 0;
                        while(Score < 2 && StopAutoMission == false) {
                            Score = 0;
                            if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                                log.Debug("AutoMission interrupted by user at: CheckforMissionsAvailible");
                                StopAutoMission = true;
                                return;
                            }
                            if(PixelFinder.SearchStaticPixel(57, 803, "#A3F5F6")) { Score++; } // Missionscreen >A<nforderungen
                            if(PixelFinder.SearchStaticPixel(290, 798, "#A3F5F6")) { Score++; } // Missionscreen Anforderu>N<gen
                            if(PixelFinder.SearchStaticPixel(251, 954, "#A3F5F6")) { Score++; } // Missionscreen Rücksch>L<äge
                            LoopGarbageCollector.ClearGarbageCollector();
                            if(Score >= 2) {
                                Score = 0;
                                if(PixelFinder.SearchStaticPixel(1873, 974, "#0A9E26")) { Score++; } // Green StartButton - green area
                                if(PixelFinder.SearchStaticPixel(1844, 1004, "#FFB631")) { Score++; } // Green StartButton - Gold bars
                                if(Score == 2) {
                                    log.Debug("InMissionScreen and green Startbutton found,starting Mission: \"" + result[0].Field<string>("Missionname") + "\"");
                                    //Interaction.InputBox("Everything Ok? Press Ok to contiunue", "All good?");
                                    MainWindow.Sleep(5000);
                                    if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                                        log.Debug("AutoMission interrupted by user at: Start Mission");
                                        StopAutoMission = true;
                                        return;
                                    }
                                    MouseActions.SingleClickAtPosition(-224, 996); //click Startbutton
                                    MainWindow.Sleep(400);
                                }
                                else if (StopAutoMission == false){
                                    log.Debug("InMissionScreen found but Button not green - No Soldiers set, or time to get some gold!");
                                    if(MessageBox.Show("Grab some Gold, im waiting to continue the mission (wait at chest screen)!\nIf you wanna stop press CANCEL", "Gimme Gold!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.Cancel) { //MessageBoxOptions.DefaultDesktopOnly makes the window in stay front
                                        return;
                                    }
                                }
                                else { return; }
                            }
                            else if(++i > 25) {
                                log.Debug("InMissionScreen couldn't be found in time:");
                                return;
                            }
                        }

                        MouseActions.SingleClickAtPosition(-1867, 55); //get out of InMissionScreen into MissionsScreen
                        if(CheckIfSpezialMissionsScreen() == -1) { return; }
                    }
                    else if(StopAutoMission == false) {
                        MouseActions.SingleClickAtPosition(-1229, 169); //move to left next region (for ex.  R19 -> r18 -> r17)
                        MainWindow.Sleep(100);
                        if(CheckIfSpezialMissionsScreen() == -1) { return; }
                    }
                }
            }
            else {
                OcrMissionname1 = OCR.OCRcheck(15, 100, 475, 70); //bsp.: Hinweis
                OcrMissionname2 = OCR.OCRcheck(12, 105, 475, 55);
                result = DB.dt.Select("Missionname = '" + OcrMissionname1 + "'");
                loadMission();
            }




            void loadMission() {    
                if((result == null || result.Length == 0) && StopAutoMission == false) {
                    result = DB.dt.Select("Missionname = '" + OcrMissionname2 + "'");
                    if((result == null || result.Length == 0) && StopAutoMission == false) { //Mission not found in DB - storing MissionScreenshot named OcrMissionname1_OcrMissionname2
                        result = DB.dt.Select("MissionnameAlias = '" + OcrMissionname1 + "' OR MissionnameAlias = '" + OcrMissionname2 + "'");
                        if((result == null || result.Length == 0) && StopAutoMission == false) { //Mission not found in DB - storing MissionScreenshot named OcrMissionname1_OcrMissionname2
                            Console.WriteLine("MissionNotInDB_" + OcrMissionname1 + "_" + OcrMissionname2 + "_" + DateTime.Now.ToString("dd/MM/yyyy HH-mm-ss") + ".png");


                            log.Debug("MissionNotInDB_" + OcrMissionname1 + "_" + OcrMissionname2 + DateTime.Now.ToString("dd/MM/yyyy HH-mm-ss") + ".png");
                            using(StreamWriter sw = new StreamWriter(@"MissionLog.txt", true)) { //Streamwriter is of tpye IDisposable (objects that dont get deleted automatically) using(sw){ } disposes every sw object at "}"
                                sw.WriteLine("MissionNotInDB_" + OcrMissionname1 + "_" + OcrMissionname2 + "_" + DateTime.Now.ToString("dd/MM/yyyy HH-mm-ss") + ".png");
                            }

                            string saveOcrMissionname1 = checkString(OcrMissionname1); //removes special characters
                            string saveOcrMissionname2 = checkString(OcrMissionname2);
                            if(OcrMissionname1 != saveOcrMissionname1 && OcrMissionname2 != saveOcrMissionname2) {
                                OCR.FullsizeImage.Save("MissionNotInDB_" + "BothEDITED" + saveOcrMissionname1 + "_" + saveOcrMissionname2 + "_" + DateTime.Now.ToString("dd/MM/yyyy HH-mm-ss") + ".png");
                            }
                            else if(OcrMissionname1 != saveOcrMissionname1) {
                                OCR.FullsizeImage.Save("MissionNotInDB_" + saveOcrMissionname1 + "1stEDITED" + "_" + saveOcrMissionname2 + "_" + DateTime.Now.ToString("dd/MM/yyyy HH-mm-ss") + ".png");
                            }
                            else if(OcrMissionname2 != saveOcrMissionname2) {
                                OCR.FullsizeImage.Save("MissionNotInDB_" + saveOcrMissionname1 + "_" + saveOcrMissionname2 + "_" + "2ndEDITED" + DateTime.Now.ToString("dd/MM/yyyy HH-mm-ss") + ".png");
                            }
                            else {
                                OCR.FullsizeImage.Save("MissionNotInDB_" + saveOcrMissionname1 + "_" + saveOcrMissionname2 + "_" + DateTime.Now.ToString("dd/MM/yyyy HH-mm-ss") + ".png");
                            }
                            return;
                        }
                        else if(StopAutoMission == false) { Missionfound = true; }
                    }
                    else if(StopAutoMission == false) { Missionfound = true; }
                }
                else if(StopAutoMission == false){ Missionfound = true; }


                if(Missionfound == true && StopAutoMission == false) {

                    if((result[0].Field<Int64>("Speed")) == 1 && StopAutoMission == false) {
                        //DateTime CurrentTime = DateTime.Now;
                        if(LastSpeedMission > DateTime.Now.AddSeconds(-90)) {
                            //int TimeTillSpeedRdy = Convert.ToInt32((LastSpeedMission - CurrentTime.AddMinutes(-1)).TotalMilliseconds);
                            MainWindow.Sleep(Convert.ToInt32((LastSpeedMission - DateTime.Now.AddSeconds(-90)).TotalMilliseconds));
                            //MainWindow.Sleep(TimeTillSpeedRdy);
                        }
                        else {
                            LastSpeedMission = DateTime.Now;
                        }
                        if((result[0].Field<Int64>("MitBonus")) == 1) { //wie speed jedoch mit 2 drohnen
                            log.Debug("Speed=1, MitBonus=1");
                            Missiontype = "SpeedMitBonus";
                            targetSuccessRate = 3; //both drohnes + speedbooster
                            clickFilter();
                        }
                        else {//1xx% mit Speedbooster (1min) min 1 drohne
                            log.Debug("Speed=1");
                            Missiontype = "Speed";
                            targetSuccessRate = 1; //blue drohne + speedbooster
                            //successbooster = 1;
                            //selectBooster("speed", successbooster);

                            clickFilter();
                        }
                    }
                    else if((result[0].Field<Int64>("Doppelt")) == 1 && StopAutoMission == false) {
                        if((result[0].Field<Int64>("MitBonus")) == 1) {
                            if((result[0].Field<Int64>("OnlySniper")) == 1) { //130-180% mit verdoppler (keine 10/11* Sturm/Rpg/molo/elite)
                                log.Debug("Doppelt=1, MitBonus=1, OnlySniper");
                                Missiontype = "DoppeltMitBonusOnlySniper";
                                targetSuccessRate = 150;

                                clickFilter();
                            }
                            else { //195% mit verdoppler
                                log.Debug("Doppelt=1, MitBonus=1");
                                Missiontype = "DoppeltMitBonus";
                                targetSuccessRate = 195;
                                //selectBooster("double", 100);

                                clickFilter();
                            }
                        }
                        else { //100% mit verdoppler
                            log.Debug("Doppelt=1");
                            Missiontype = "Doppelt";
                            targetSuccessRate = 100;
                            //selectBooster("double",100);
                            clickFilter();
                        }
                    }
                    else if((result[0].Field<Int64>("MitBonus")) == 1 && StopAutoMission == false) { //195% mit chanceBooster
                        if((result[0].Field<Int64>("OnlySniper")) == 1) { //130-180% mit chanceBooster (keine 10/11* Sturm/Rpg/molo/elite)
                            log.Debug("MitBonus=1, OnlySniper");
                            Missiontype = "MitBonusOnlySniper";
                            targetSuccessRate = 150;
                            clickFilter();
                        }
                        else { //195% mit chanceBooster
                            log.Debug("MitBonus=1");
                            Missiontype = "MitBonus";
                            targetSuccessRate = 195;
                            clickFilter();
                        }
                    }
                    else if(StopAutoMission == false){ //standardMission - 100%
                        log.Debug("Standard 100%");
                        Missiontype = "Standard";
                        targetSuccessRate = 100;
                        //selectBooster("double",100);
                        clickFilter();
                    }
                }
            }

            void clickFilter() {
                if(StopAutoMission == false) {
                    ////Adds all COUNTER Columns with a value of one into the array Checkcounter
                    //foreach(DataRow row in result) {
                    //    foreach(DataColumn col in row.Table.Columns) {
                    //        if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                    //            log.Debug("AutoMission interrupted by user at Pos ??");
                    //            StopAutoMission = true;
                    //        }
                    //        if(col.Ordinal >= 14 && col.Ordinal <= 29) { //14-29 is the Column range for all Counters
                    //            if(Convert.ToInt32(row[col.Ordinal]) == 1) {
                    //                CheckCounter = CheckCounter.Append(col.ColumnName).ToArray();
                    //            }
                    //        }
                    //    }
                    //}

                    

                    //foreach(string counter in Counters) {
                    //    filename = Path.Combine(MainWindow.ResourcesPath + "counter\\" + counter + ".png");

                    //    if(!File.Exists(filename)) {
                    //        log.Error("couldn't find " + counter);
                    //    }

                    //    ImageResult = ImgSearch.UseImageSearch(filename, "108", -1920, 940, -1375, 1080);
                    //    if(ImageResult != null) {
                    //        FoundCounters += counter + ",";
                    //    }
                    //}


                    Bitmap bitmap = null;
                    Bitmap cropped = null;

                    using(bitmap = new Bitmap(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height)) { // Create an empty bitmap with the size of all connected screen
                        Graphics graphics = Graphics.FromImage(bitmap as Image); // Create a new graphics objects that can capture the scree
                        graphics.CopyFromScreen(SystemInformation.VirtualScreen.Left, SystemInformation.VirtualScreen.Top, 0, 0, bitmap.Size);
                        LoopGarbageCollector.ClearGarbageCollector();
                        //Rectangle BoosterScanZone = new Rectangle(1920, 250, 1920, 350);
                        //Bitmap cropped = (Bitmap)bitmap.Clone(BoosterScanZone, bitmap.PixelFormat);
                        Rectangle CounterScanZone = new Rectangle(0, 955, 500, 120);
                        cropped = (Bitmap)bitmap.Clone(CounterScanZone, bitmap.PixelFormat);
                        cropped.Save(@"c:\temp\ImageFinderCropped.png");
                    }

                    ImageFinder.SetSource(cropped);
                    FoundCounters = "";
                    foreach(string counter in Counters) {
                        string ImageSourcePath = Path.Combine(MainWindow.ResourcesPath + "counter\\" + counter + ".png");
                        Image TempBit = Image.FromFile(ImageSourcePath);
                        TempBit.Save(@"c:\temp\TembBit.png");
                        ImageFinder.Find(TempBit, 0.83f);
                        if(ImageFinder.LastMatches.Count >= 1) {
                            FoundCounters += counter + ",";
                        }
                    }

                    log.Debug("counters checked. \nThe following counters have been found: " + FoundCounters.Substring(0, FoundCounters.Length - 1));
                    char[] CharSeperator = { ',' };
                    CheckCounter = FoundCounters.Split(CharSeperator, StringSplitOptions.RemoveEmptyEntries);
                    if(CheckCounter.Length != 5 && CheckCounter.Length != 4) {
                        //if(CheckCounter.Length == 0 || CheckCounter.Length > 5) {
                        log.Debug("Invalid Value at CheckCounter.Length (" + CheckCounter.Length + ")");
                        StopAutoMission = true;
                        return;
                        //}
                    }


                    //Adds all SOLDIERTYPE Columns with a value of one into the array CheckSoldierType
                    foreach(DataRow row in result) {
                        foreach(DataColumn col in row.Table.Columns) {
                            if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                                log.Debug("AutoMission interrupted by user at Pos ??");
                                StopAutoMission = true;
                                return;
                            }
                            if(col.Ordinal >= 3 && col.Ordinal <= 10) { //3-10 is the Column range for all Soldiertypes
                                if(Convert.ToInt32(row[col.Ordinal]) == 1) {
                                    CheckSoldierType = CheckSoldierType.Append(col.ColumnName).ToArray();
                                }
                            }
                        }
                    }




                    ////ToDo Check what happens if Counters[4] is null or the array has < 5 items
                    //CacheDb.GetSoldiers(6, 5, Counters[0], Counters[1], Counters[2], Counters[3], Counters[4]);
                    //foreach(string SoldierType in CheckSoldierType) {
                    //    //--- select fist row -> get the Data, Drop alls rows where type = SelectedSoldier.type
                    //    DataRow[] SelectedSoldier = CacheDb.DataTableFilteredSoldiers.Select("");
                    //}




                    int AmountOfSoldiers = CheckSoldierType.Length;
                    while(CheckSoldierType.Length > 0 && StopAutoMission == false) {
                        foreach(string Soldier in CheckSoldierType) {
                            if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                                log.Debug("AutoMission interrupted by user at Pos ??");
                                StopAutoMission = true;
                                break;
                            }
                            if(StopAutoMission == false) {
                                FilterSelection(Soldier);
                            }
                        }
                    }
                    int CheckSuccessRateResult = checkSuccessRate(targetSuccessRate);
                    if(StopAutoMission == false && 100 <= CheckSuccessRateResult) {
                        //checkGold();
                    }
                    else if (StopAutoMission == false && -1 == CheckSuccessRateResult) {
                        log.Debug("MissionTime =" + missionTime.Elapsed);
                        missionTime.Stop();
                        return;
                    }
                    log.Debug("MissionTime =" + missionTime.Elapsed);
                    missionTime.Stop();

                    void FilterSelection(string currentSoldier) {
                        if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                            log.Debug("AutoMission interrupted by user at: Setting Counter");
                            StopAutoMission = true;
                            return;
                        }
                        //MainWindow.Sleep(3000);
                        if(StopAutoMission == false && AmountOfSoldiers == 1) {
                            MouseActions.DoubleClickAtPosition(-836, 350); //Opens SolidierSelection
                        }
                        else if(StopAutoMission == false && AmountOfSoldiers == 2) {
                            if(CheckSoldierType.Length == 2) {
                                MouseActions.DoubleClickAtPosition(-923, 350);
                            }
                            else {
                                MouseActions.DoubleClickAtPosition(-580, 350);
                            }
                        }
                        else if(StopAutoMission == false && AmountOfSoldiers == 3) {
                            if(CheckSoldierType.Length == 3) {
                                MouseActions.DoubleClickAtPosition(-1096, 350);
                            }
                            else if(CheckSoldierType.Length == 2) {
                                MouseActions.DoubleClickAtPosition(-749, 350);
                            }
                            else {
                                MouseActions.DoubleClickAtPosition(-419, 350);
                            }
                        }
                        else if(StopAutoMission == false && AmountOfSoldiers == 4) {
                            if(CheckSoldierType.Length == 4) {
                                MouseActions.DoubleClickAtPosition(-1251, 350);
                            }
                            else if(CheckSoldierType.Length == 3) {
                                MouseActions.DoubleClickAtPosition(-913, 350);
                            }
                            else if(CheckSoldierType.Length == 2) {
                                MouseActions.DoubleClickAtPosition(-632, 350);
                            }
                            else {
                                MouseActions.DoubleClickAtPosition(-255, 350);
                            }
                        }
                        if(StopAutoMission == false && CheckforSoldierScreenSelection() == 1) {
                            //wait for Soldierscreen to open
                        }
                        else if(StopAutoMission == false) { log.Error("Pos507153616"); return; }

                        if(StopAutoMission == false && "Sniper" == currentSoldier) {
                            MouseActions.DoubleClickAtPosition(dicClickPos["Sniper"][0], dicClickPos["Sniper"][1]);
                        }
                        else if(StopAutoMission == false && "Sturm" == currentSoldier) {
                            MouseActions.DoubleClickAtPosition(dicClickPos["Sturm"][0], dicClickPos["Sturm"][1]);
                        }
                        else if(StopAutoMission == false && "RPG" == currentSoldier) {
                            MouseActions.DoubleClickAtPosition(dicClickPos["RPG"][0], dicClickPos["RPG"][1]);
                        }
                        else if(StopAutoMission == false && "Molotow" == currentSoldier) {
                            MouseActions.DoubleClickAtPosition(dicClickPos["Molotow"][0], dicClickPos["Molotow"][1]);
                        }
                        else if(StopAutoMission == false && "Elite" == currentSoldier) {
                            if(Missiontype == "DoppeltMitBonus"  && CheckSoldierType.Length == 1) { 
                                MouseActions.SingleClickAtPosition(-94, 125); //Close SoldierSelectionScreen - to get current Successrate
                                int InMissionscreen = CheckforInMissionScreen();
                                if(InMissionscreen == -1) { return; } //else (1) InMissionscreen -> continue
                                ORCGetSuccessrate = OCR.OCRcheck(1056, 963, 100, 35);
                                //MouseActions.DoubleClickAtPosition(-255, 350);
                                //MainWindow.Sleep(1200);
                            }
                            MouseActions.DoubleClickAtPosition(dicClickPos["Elite"][0], dicClickPos["Elite"][1]);
                        }
                        else if(StopAutoMission == false && "Beschuetzer" == currentSoldier) {
                            MouseActions.DoubleClickAtPosition(dicClickPos["Beschuetzer"][0], dicClickPos["Beschuetzer"][1]);
                        }
                        else if(StopAutoMission == false && "Attentaeter" == currentSoldier) {
                            MouseActions.DoubleClickAtPosition(dicClickPos["Attentaeter"][0], dicClickPos["Attentaeter"][1]);
                        }
                        else if(StopAutoMission == false && "Suppressor" == currentSoldier) {
                            MouseActions.DoubleClickAtPosition(dicClickPos["Suppressor"][0], dicClickPos["Suppressor"][1]);
                        }

                        if(StopAutoMission == false && CheckforSoldierScreenSelection() == 1) { 
                            MouseActions.SingleClickAtPosition(-117, 923); //click FilterMenu
                        }
                        else if(StopAutoMission == false) { log.Error("Pos1510375"); return; }
                        if(StopAutoMission == false && CheckforFilterMenu() == 1) {
                            if(Missiontype != "Speed" && Missiontype != "SpeedMitBonus") {
                                MouseActions.SingleClickAtPosition(dicClickPos["verfügbar"][0], dicClickPos["verfügbar"][1]);
                            }
                        }
                        else if(StopAutoMission == false){ return; }
                        MainWindow.Sleep(500);
                        if(StopAutoMission == false && (Missiontype == "Speed" || Missiontype == "SpeedMitBonus")) {
                            bool counterFound = false;
                            //if(currentSoldier == "Sniper") { //selects 9* schnell(kommunikation) or 9* Zeitgewinn(RSTarnung)
                            //    foreach(string counter in CheckCounter) {
                            //        if(counter == "RSTarnung") {
                            //            MouseActions.SingleClickAtPosition(dicClickPos[counter][0], dicClickPos[counter][1]);
                            //            MainWindow.Sleep(150);
                            //            MouseActions.SingleClickAtPosition(dicClickPos["BSZeitgewinn"][0], dicClickPos["BSZeitgewinn"][1]);
                            //            MainWindow.Sleep(150);
                            //            MouseActions.SingleClickAtPosition(dicClickPos["BSSchnell"][0], dicClickPos["BSSchnell"][1]);
                            //            counterFound = true;
                            //        }
                            //    }
                            //}
                            //else if(currentSoldier == "Sturm") { //selects 9* mechaniker(RSRadar) or 9* Zeitgewinn(RSBoot)
                            //    foreach(string counter in CheckCounter) {
                            //        if(counter == "RSBoot") {
                            //            MouseActions.SingleClickAtPosition(dicClickPos[counter][0], dicClickPos[counter][1]);
                            //            MainWindow.Sleep(150);
                            //            MouseActions.SingleClickAtPosition(dicClickPos["BSZeitgewinn"][0], dicClickPos["BSZeitgewinn"][1]);
                            //            counterFound = true;
                            //        }
                            //    }
                            //}
                            //else if(currentSoldier == "RPG") {

                            //}
                            //else if(currentSoldier == "Molotow") {
                            //    MainWindow.Sleep(150);MainWindow.Sleep(150);
                            //    MouseActions.SingleClickAtPosition(dicClickPos["verfügbar"][0], dicClickPos["verfügbar"][1]);
                            //    MainWindow.Sleep(150);
                            //}
                            //else if(currentSoldier == "Elite") {
                                
                            //}
                            if(counterFound == false) {
                                MouseActions.SingleClickAtPosition(dicClickPos["BSMechaniker"][0], dicClickPos["BSMechaniker"][1]);
                                MainWindow.Sleep(150);
                                MouseActions.SingleClickAtPosition(dicClickPos["BSSchnell"][0], dicClickPos["BSSchnell"][1]);
                            }
                            MouseActions.SingleClickAtPosition(-1818, 209); //Close Filter
                            MainWindow.Sleep(300);
                            int SoldierReady = CheckforFilteredSoldierReady();
                            if(SoldierReady == 0) { //Bluebutton "Erledigt"
                                MouseActions.SingleClickAtPosition(-1664, 810); //click Bluebutton "Erledigt"
                                MainWindow.Sleep(500); //Wiat for Mission Completed-Animation to be interruptable
                                MouseActions.DoubleClickAtPosition(-979, 611); //click Screen mid to interruprt Mission Completed-Animation
                                MainWindow.Sleep(400);
                                MouseActions.SingleClickAtPosition(-263, 995); //Annehmen Button
                                //Soldier is now Availible but SF will switch to MissionScreen therefore return to trigger the selection again.
                                return;
                            }
                            else if(SoldierReady == 1) { //Greenbutton "Wählen"
                                CheckSoldierType = CheckSoldierType.Where(e => e != currentSoldier).ToArray();
                                MouseActions.SingleClickAtPosition(-1650, 813); //Select FilteredSoldier
                                int InMissionscreen = CheckforInMissionScreen();
                                if(InMissionscreen == -1) { return; } //else (1) InMissionscreen -> continue
                            }
                            else if(SoldierReady == -1) { //Timeout neighter "Erledigt" or "Wählen" Button found
                                StopAutoMission = true;
                                log.Debug("No Speed " + currentSoldier + " ready.");
                                return;
                            }
                        }
                        else if(StopAutoMission == false && Missiontype == "DoppeltMitBonusOnlySniper") {
                            if(currentSoldier == "Sniper") {
                                MouseActions.SingleClickAtPosition(dicClickPos["Stern6"][0], dicClickPos["Stern6"][1]);
                                MainWindow.Sleep(150);
                                MouseActions.SingleClickAtPosition(dicClickPos["Stern7"][0], dicClickPos["Stern7"][1]);
                                MainWindow.Sleep(150);
                                MouseActions.SingleClickAtPosition(dicClickPos["Stern8"][0], dicClickPos["Stern8"][1]);
                                MainWindow.Sleep(150);
                                MouseActions.SingleClickAtPosition(dicClickPos["Stern9"][0], dicClickPos["Stern9"][1]);
                                MainWindow.Sleep(150);
                            }
                            else {
                                MouseActions.SingleClickAtPosition(dicClickPos["Stern6"][0], dicClickPos["Stern6"][1]);
                                MainWindow.Sleep(150);

                            }
                            MouseActions.SingleClickAtPosition(dicClickPos["BSKoordination"][0], dicClickPos["BSKoordination"][1]); //Bonus Kordination +10
                            MainWindow.Sleep(150);
                            MouseActions.SingleClickAtPosition(dicClickPos["BSDrohne"][0], dicClickPos["BSDrohne"][1]); //Bonus BSDrohne +10
                            MainWindow.Sleep(300);



                            if(StopAutoMission == false && CheckForAvailibleSoldiers() == true) {
                                SoldierPickProcessDopMitBon();
                            }
                            else if(StopAutoMission == false) { //no soldiers found
                                if(result[0].Field<Int64>("Duration") > 4 && StopAutoMission == false) {
                                    MouseActions.SingleClickAtPosition(dicClickPos["BSAufsteiger"][0], dicClickPos["BSAufsteiger"][1]); //Bonus Aufsteiger +5% > 4hours
                                    MainWindow.Sleep(400);
                                }
                                else if(StopAutoMission == false) {
                                    MouseActions.SingleClickAtPosition(dicClickPos["BSImprovisation"][0], dicClickPos["BSImprovisation"][1]); //Bonus BSImprovisation +5% < 4hours
                                    MainWindow.Sleep(400);
                                }
                                if(StopAutoMission == false && CheckForAvailibleSoldiers() == true) {
                                    SoldierPickProcessDopMitBon();
                                }
                                else {
                                    log.Debug("No Soldier found that meets the requirements for " + result[0].Field<string>("Missionname") + ", " + Missiontype);
                                    StopAutoMission = true;
                                    return;
                                }
                            }

                            void SoldierPickProcessDopMitBon() {
                                //CheckCounter = CheckCounter.Where(e => e != Counter).ToArray(); //creates a new Array without value Counter
                                CheckSoldierType = CheckSoldierType.Where(e => e != currentSoldier).ToArray();
                                MouseActions.SingleClickAtPosition(-1818, 209); //Close Filter
                                MainWindow.Sleep(600);
                                MouseActions.SingleClickAtPosition(-1650, 813); //Select FilteredSoldier
                                int InMissionscreen = CheckforInMissionScreen();
                                if(InMissionscreen == -1) { return; } //else (1) InMissionscreen -> continue
                            }
                        }
                        else if(StopAutoMission == false && Missiontype == "DoppeltMitBonus") {
                            if(CheckSoldierType.Length == 1 && currentSoldier == "Elite" && ORCGetSuccessrate == "135%") {
                                MouseActions.SingleClickAtPosition(dicClickPos["Stern6"][0], dicClickPos["Stern6"][1]);
                                MainWindow.Sleep(150);
                                MouseActions.SingleClickAtPosition(dicClickPos["RSVIP"][0], dicClickPos["RSVIP"][1]);
                                MainWindow.Sleep(150);
                            }
                            else {
                                MouseActions.SingleClickAtPosition(dicClickPos["Stern8"][0], dicClickPos["Stern8"][1]);
                                MainWindow.Sleep(150);
                                MouseActions.SingleClickAtPosition(dicClickPos["Stern9"][0], dicClickPos["Stern9"][1]);
                                MainWindow.Sleep(150);
                                MouseActions.SingleClickAtPosition(dicClickPos["Stern10"][0], dicClickPos["Stern10"][1]);
                                MainWindow.Sleep(150);
                                MouseActions.SingleClickAtPosition(dicClickPos["Stern11"][0], dicClickPos["Stern11"][1]);
                                MainWindow.Sleep(150);
                                MouseActions.SingleClickAtPosition(-335, 211); //Bonus Kordination +10
                                MainWindow.Sleep(300);
                            }

                            if(StopAutoMission == false && CheckForAvailibleSoldiers() == true) {
                                SoldierPickProcessDopMitBon();
                            }
                            else if(StopAutoMission == false){
                                log.Debug("No Soldier found that meets the requirements for " + result[0].Field<string>("Missionname") + ", " + Missiontype);
                                StopAutoMission = true;
                                return;
                            }

                            void SoldierPickProcessDopMitBon() {
                                //CheckCounter = CheckCounter.Where(e => e != Counter).ToArray(); //creates a new Array without value Counter
                                CheckSoldierType = CheckSoldierType.Where(e => e != currentSoldier).ToArray();
                                MouseActions.SingleClickAtPosition(-1818, 209); //Close Filter
                                MainWindow.Sleep(600);
                                MouseActions.SingleClickAtPosition(-1650, 813); //Select FilteredSoldier
                                int InMissionscreen = CheckforInMissionScreen();
                                if(InMissionscreen == -1) { return; } //else (1) InMissionscreen -> continue
                            }
                        }
                        else if(StopAutoMission == false && Missiontype == "MitBonusOnlySniper") {
                            if(currentSoldier == "Sniper") {
                                MouseActions.SingleClickAtPosition(dicClickPos["Stern7"][0], dicClickPos["Stern7"][1]);
                                MainWindow.Sleep(150);
                                MouseActions.SingleClickAtPosition(dicClickPos["Stern8"][0], dicClickPos["Stern8"][1]);
                                MainWindow.Sleep(150);
                            }
                            else {
                                MouseActions.SingleClickAtPosition(dicClickPos["Stern6"][0], dicClickPos["Stern6"][1]);
                                MainWindow.Sleep(150);

                            }
                            //foreach(string counter in Counters) {
                            //    if(counter == "RSAufklaerung" || counter == "RSHelikopter") {
                            //        MouseActions.SingleClickAtPosition(dicClickPos[counter][0], dicClickPos[counter][1]);
                            //        MainWindow.Sleep(300);
                            //    }
                            //}
                            MouseActions.SingleClickAtPosition(dicClickPos["BSKoordination"][0], dicClickPos["BSKoordination"][1]); //Bonus Kordination +10
                            MainWindow.Sleep(150);
                            MouseActions.SingleClickAtPosition(dicClickPos["BSDrohne"][0], dicClickPos["BSDrohne"][1]); //Bonus BSDrohne +10
                            MainWindow.Sleep(300);

                            if(StopAutoMission == false && CheckForAvailibleSoldiers() == true) {
                                SoldierPickProcessDopMitBon();
                            }
                            else if(StopAutoMission == false) { //no soldiers found
                                if(result[0].Field<Int64>("Duration") > 4 && StopAutoMission == false) {
                                    MouseActions.SingleClickAtPosition(dicClickPos["BSAufsteiger"][0], dicClickPos["BSAufsteiger"][1]); //Bonus Aufsteiger +5% > 4hours
                                    MainWindow.Sleep(300);
                                }
                                else if(StopAutoMission == false) {
                                    MouseActions.SingleClickAtPosition(dicClickPos["BSImprovisation"][0], dicClickPos["BSImprovisation"][1]); //Bonus BSImprovisation +5% < 4hours
                                    MainWindow.Sleep(300);
                                }
                                if(StopAutoMission == false && CheckForAvailibleSoldiers() == true) {
                                    SoldierPickProcessDopMitBon();
                                }
                                else {
                                    log.Debug("No Soldier found that meets the requirements for " + result[0].Field<string>("Missionname") + ", " + Missiontype);
                                    StopAutoMission = true;
                                    return;
                                }
                            }

                            void SoldierPickProcessDopMitBon() {
                                //CheckCounter = CheckCounter.Where(e => e != Counter).ToArray(); //creates a new Array without value Counter
                                CheckSoldierType = CheckSoldierType.Where(e => e != currentSoldier).ToArray();
                                MouseActions.SingleClickAtPosition(-1818, 209); //Close Filter
                                MainWindow.Sleep(600);
                                MouseActions.SingleClickAtPosition(-1650, 813); //Select FilteredSoldier
                                int InMissionscreen = CheckforInMissionScreen();
                                if(InMissionscreen == -1) { return; } //else (1) InMissionscreen -> continue
                            }

                        }
                        else if(StopAutoMission == false && Missiontype == "MitBonus") {
                            if(CheckSoldierType.Length == 1 && currentSoldier == "Elite" && ORCGetSuccessrate == "135%") {
                                MouseActions.SingleClickAtPosition(dicClickPos["Stern6"][0], dicClickPos["Stern6"][1]);
                                MainWindow.Sleep(150);
                                MouseActions.SingleClickAtPosition(dicClickPos["RSVIP"][0], dicClickPos["RSVIP"][1]);
                                MainWindow.Sleep(300);
                            }
                            else {
                                MouseActions.SingleClickAtPosition(dicClickPos["Stern8"][0], dicClickPos["Stern8"][1]);
                                MainWindow.Sleep(150);
                                MouseActions.SingleClickAtPosition(dicClickPos["Stern9"][0], dicClickPos["Stern9"][1]);
                                MainWindow.Sleep(150);
                                MouseActions.SingleClickAtPosition(dicClickPos["Stern10"][0], dicClickPos["Stern10"][1]);
                                MainWindow.Sleep(150);
                                MouseActions.SingleClickAtPosition(dicClickPos["Stern11"][0], dicClickPos["Stern11"][1]);
                                MainWindow.Sleep(150);
                                MouseActions.SingleClickAtPosition(-335, 211); //Bonus Kordination +10
                                MainWindow.Sleep(300);
                            }

                            if(StopAutoMission == false && CheckForAvailibleSoldiers() == true) {
                                SoldierPickProcessDopMitBon();
                            }
                            else if(StopAutoMission == false) {
                                log.Debug("No Soldier found that meets the requirements for " + result[0].Field<string>("Missionname") + ", " + Missiontype);
                            }

                            void SoldierPickProcessDopMitBon() {
                                //CheckCounter = CheckCounter.Where(e => e != Counter).ToArray(); //creates a new Array without value Counter
                                CheckSoldierType = CheckSoldierType.Where(e => e != currentSoldier).ToArray();
                                MouseActions.SingleClickAtPosition(-1818, 209); //Close Filter
                                MainWindow.Sleep(600);
                                MouseActions.SingleClickAtPosition(-1650, 813); //Select FilteredSoldier
                                int InMissionscreen = CheckforInMissionScreen();
                                if(InMissionscreen == -1) { return; } //else (1) InMissionscreen -> continue
                            }
                        }
                        else if(StopAutoMission == false && (Missiontype == "Standard" || Missiontype == "Doppelt")) {

                            if(StopAutoMission == false && (result[0].Field<Int64>("Difficulty")) == 6) {
                                MouseActions.SingleClickAtPosition(dicClickPos["Stern7"][0], dicClickPos["Stern7"][1]);
                                MainWindow.Sleep(150);
                                MouseActions.SingleClickAtPosition(dicClickPos["Stern6"][0], dicClickPos["Stern6"][1]);
                                MainWindow.Sleep(150);
                            }
                            else if(StopAutoMission == false && (result[0].Field<Int64>("Difficulty")) == 5) {
                                MouseActions.SingleClickAtPosition(dicClickPos["Stern6"][0], dicClickPos["Stern6"][1]);
                                MainWindow.Sleep(150);
                                MouseActions.SingleClickAtPosition(dicClickPos["Stern5"][0], dicClickPos["Stern5"][1]);
                                MainWindow.Sleep(150);
                            }
                            else if(StopAutoMission == false && (result[0].Field<Int64>("Difficulty")) == 4) {
                                MouseActions.SingleClickAtPosition(dicClickPos["Stern5"][0], dicClickPos["Stern5"][1]);
                                MainWindow.Sleep(150);
                                MouseActions.SingleClickAtPosition(dicClickPos["Stern4"][0], dicClickPos["Stern4"][1]);
                                MainWindow.Sleep(150);
                            }

                            foreach(string Counter in CheckCounter) {
                                if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                                    log.Debug("AutoMission interrupted by user at: Setting Counter");
                                    StopAutoMission = true;
                                    break;
                                }
                                MouseActions.SingleClickAtPosition(dicClickPos[Counter][0], dicClickPos[Counter][1]);
                                log.Debug("Click Filter " + Counter + " at " + dicClickPos[Counter][0].ToString() + "," + dicClickPos[Counter][1].ToString());
                                MainWindow.Sleep(300);
                                //string OcrActiveSoldiers = (OCR.OCRcheck(1160, 922, 140, 34, "0123456789/")); //bsp.: 19/25
                                //if(OcrActiveSoldiers.Length <= 4) {
                                //    OcrActiveSoldiers = (OCR.OCRcheck(1170, 926, 60, 34, "0123456789/")); //bsp.: 19/25
                                //}
                                if(StopAutoMission == false && CheckForAvailibleSoldiers() == true) {
                                    SoldierPickProcess(); //removes soldier from Array (Soldier/Counter)closes Filter, selects Filterresult-Soldier
                                }
                                else if(StopAutoMission == false) {
                                    if(++ZeroCount == CheckSoldierType.Length && StopAutoMission == false) {
                                        if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                                            log.Debug("AutoMission interrupted by user at: no Soldier found ZeroCount == AmountOfSoldiers");
                                            StopAutoMission = true;
                                            break;
                                        }
                                        log.Debug("No Soldier found for " + currentSoldier + " Counter: " + Counter);
                                        MouseActions.SingleClickAtPosition(dicClickPos[Counter][0], dicClickPos[Counter][1]); //unselect counter
                                        if(!StopAutoMission) { NoSoldierfound(); }
                                    }
                                    MouseActions.SingleClickAtPosition(-1818, 209); //Close Filter
                                    MainWindow.Sleep(300);
                                    MouseActions.DoubleClickAtPosition(-94, 125); //Close SoldierSelectionScreen - if no viable Soldier has been found
                                    int InMissionscreen = CheckforInMissionScreen();
                                    if(InMissionscreen == -1) { return; } //else (1) InMissionscreen -> continue
                                }
                                void SoldierPickProcess() {
                                    if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                                        log.Debug("AutoMission interrupted by user at: Setting SoldierPickProcess");
                                        StopAutoMission = true;
                                        return;
                                    }
                                    CheckCounter = CheckCounter.Where(e => e != Counter).ToArray(); //creates a new Array without value Counter
                                    CheckSoldierType = CheckSoldierType.Where(e => e != currentSoldier).ToArray();
                                    MouseActions.SingleClickAtPosition(-1818, 209); //Close Filter
                                    MainWindow.Sleep(300);
                                    MouseActions.SingleClickAtPosition(-1650, 813); //Select FilteredSoldier
                                    int InMissionscreen = CheckforInMissionScreen();
                                    if(InMissionscreen == -1) { return; } //else (1) InMissionscreen -> continue
                                    ZeroCount = 0;
                                }

                                void NoSoldierfound() {
                                    if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                                        log.Debug("AutoMission interrupted by user at: NoSoldierfound");
                                        StopAutoMission = true;
                                        return;
                                    }
                                    MouseActions.SingleClickAtPosition(dicClickPos["BSAufsteiger"][0], dicClickPos["BSAufsteiger"][1]); ; //Aufsteiger +5
                                    MainWindow.Sleep(600);                                               //if Still 0/0

                                    if(StopAutoMission == false && CheckForAvailibleSoldiers() == true) {
                                        SoldierPickProcess();
                                    }
                                    else if(StopAutoMission == false && ZeroCount == CheckSoldierType.Length) {
                                        
                                        MouseActions.SingleClickAtPosition(dicClickPos["BSDrohne"][0], dicClickPos["BSDrohne"][1]);
                                        MainWindow.Sleep(200);
                                        MouseActions.SingleClickAtPosition(dicClickPos["BSKoordination"][0], dicClickPos["BSKoordination"][1]);
                                        MainWindow.Sleep(400);
                                        SoldierPickProcess();
                                    }
                                }

                                break;

                            }
                        }
                    }
                }
            }

            int MissionsAvailible() {
                int Score = 0;
                int i = 0;
                while(Score < 2 && StopAutoMission == false) {
                    Score = 0;
                    if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                        log.Debug("AutoMission interrupted by user at: CheckforMissionsAvailible");
                        StopAutoMission = true;
                        return 0;
                    }
                    if(PixelFinder.SearchStaticPixel(223, 715, "#19649B")) { Score++; } // Blue "Neue Mission in" - Bar left side
                    if(PixelFinder.SearchStaticPixel(473, 720, "#FFFFFF")) { Score++; } // White lock sign
                    if(PixelFinder.SearchStaticPixel(484, 694, "#176299")) { Score++; } // Blue "Neue Mission in" - Bar right side

                    LoopGarbageCollector.ClearGarbageCollector();
                    if(Score >= 2) {
                        log.Debug("No availible Mission could be found in time!");
                        return 0;
                    }
                    else if(++i > 3) {
                        log.Debug("At least one Mission is availible!");
                        return 1;
                    }
                    return 1;
                }
                return 0;
            }

            string checkString(string text) {
                return System.Text.RegularExpressions.Regex.Replace(text, @"[^0-9a-zA-Z _-]", string.Empty);
            }

            string checkDuration() {
                string OcrDuration = OCR.OCRcheck(586, 993, 140, 42); //bsp.:  00:01:00 ,  02:00:00
                return OcrDuration;
            }
            int checkSuccessRate(int targetSuccessRate) {
                MainWindow.Sleep(300); //neccecary to update winrate
                string OcrSuccessRate = OCR.OCRcheck(1056, 963, 100, 35, "0123456789% "); //bsp.:  100% , 130%
                if(OcrSuccessRate == "") {
                    OcrSuccessRate = OCR.OCRcheck(1025, 963, 100, 35, "0123456789% ");
                    if(OcrSuccessRate == "") {
                        log.Error("OcrSuccessRate not found or recognized!");
                        return -1;
                    }
                }
                int OcrSuccessRateInt = 0;
                if(OcrSuccessRate.Length > 2) {
                    OcrSuccessRateInt = Convert.ToInt32(OcrSuccessRate.Substring(0, OcrSuccessRate.Length - 1));
                }
                else {
                    log.Error("Unexpected Value at OcrSuccessRate.Length " + OcrSuccessRate.Length.ToString() +  "," + OcrSuccessRate);
                }

                //Checks if rate wit blueDrone > targetrate - if so drohne will stay active, else drohne will be deaktivated and continued and soldiers with drohne bonus will not be treated special.
                if(targetSuccessRate > 49 && OcrSuccessRateInt < targetSuccessRate) {
                    MouseActions.SingleClickAtPosition((dicClickPos["bluedrohne"][0]), dicClickPos["bluedrohne"][1]);
                    MainWindow.Sleep(300);
                    string OcrSuccessRateWithDrone = OCR.OCRcheck(1056, 963, 100, 35, "0123456789% "); //bsp.:  110% , 150%
                    if(OcrSuccessRateWithDrone == "") {
                        OcrSuccessRateWithDrone = OCR.OCRcheck(1025, 963, 100, 35, "0123456789% ");
                        if(OcrSuccessRateWithDrone == "") {
                            log.Error("OcrSuccessRateWithDrone not found or recognized!");
                            return -1;
                        }
                    }
                    int OcrSuccessRateWithDroneInt = Convert.ToInt32(OcrSuccessRateWithDrone.Substring(0, OcrSuccessRateWithDrone.Length - 1));

                    if(OcrSuccessRateWithDroneInt >= targetSuccessRate) {
                        OcrSuccessRateInt = OcrSuccessRateWithDroneInt;
                    }
                    else {
                        MouseActions.SingleClickAtPosition((dicClickPos["bluedrohne"][0]), dicClickPos["bluedrohne"][1]);
                        MainWindow.Sleep(400);
                    }
                }

                switch(targetSuccessRate) {
                    case 0:
                        //do nothing
                        break;
                    case 1:
                        bluedrohne = 1;
                        break;
                    case 2:
                        golddrohne = 1;
                        break;
                    case 3:
                        bluedrohne = 1;
                        golddrohne = 1;
                        break;
                    case 4:
                        //booster10 %
                        successbooster = 10;
                        break;
                    case 5:
                        //booster5 %
                        successbooster = 5;
                        break;
                    case 6:
                        successbooster = 15;
                        break;
                    case 14:
                        bluedrohne = 1;
                        successbooster = 10;
                        break;
                    case 15:
                        bluedrohne = 1;
                        successbooster = 5;
                        break;
                    case 24:
                        golddrohne = 1;
                        successbooster = 10;
                        break;
                    case 25:
                        golddrohne = 1;
                        successbooster = 5;
                        break;
                    case 34:
                        bluedrohne = 1;
                        golddrohne = 1;
                        successbooster = 10;
                        break;
                    case 35:
                        bluedrohne = 1;
                        golddrohne = 1;
                        successbooster = 5;
                        break;
                    case 36:
                        bluedrohne = 1;
                        golddrohne = 1;
                        successbooster = 15;
                        break;
                    case 37:
                        bluedrohne = 1;
                        golddrohne = 1;
                        successbooster = 20;
                        break;
                    case 38:
                        bluedrohne = 1;
                        golddrohne = 1;
                        successbooster = 25;
                        break;
                    case 39:
                        bluedrohne = 1;
                        golddrohne = 1;
                        successbooster = 30;
                        break;
                }


                if(OcrSuccessRateInt > 49  && (targetSuccessRate - OcrSuccessRateInt) > 0) {
                    if(targetSuccessRate >= OcrSuccessRateInt && (targetSuccessRate - OcrSuccessRateInt) >= 50) {
                        bluedrohne = 1;
                        golddrohne = 1;
                        successbooster = 30;
                    }
                    else if((targetSuccessRate - OcrSuccessRateInt) >= 45) {
                        bluedrohne = 1;
                        golddrohne = 1;
                        successbooster = 25;
                    }
                    else if((targetSuccessRate - OcrSuccessRateInt) == 40) {
                        bluedrohne = 1;
                        golddrohne = 1;
                        successbooster = 15;
                    }
                    else if((targetSuccessRate - OcrSuccessRateInt) == 35) {
                        bluedrohne = 1;
                        golddrohne = 1;
                        successbooster = 10;
                    }
                    else if((targetSuccessRate - OcrSuccessRateInt) == 30) {
                        bluedrohne = 1;
                        golddrohne = 1;
                        successbooster = 5;
                    }
                    else if((targetSuccessRate - OcrSuccessRateInt) == 25) {
                        bluedrohne = 1;
                        golddrohne = 1;
                    }
                    else if((targetSuccessRate - OcrSuccessRateInt) == 20) {
                        bluedrohne = 1;
                        golddrohne = 1;
                    }
                    else if((targetSuccessRate - OcrSuccessRateInt) == 15) {
                        golddrohne = 1;
                    }
                    else if((targetSuccessRate - OcrSuccessRateInt) == 10) {
                        bluedrohne = 1;
                    }
                    else if((targetSuccessRate - OcrSuccessRateInt) == 5) {
                        bluedrohne = 1;
                    }
                }

                
                if(bluedrohne == 1) {
                    MouseActions.SingleClickAtPosition((dicClickPos["bluedrohne"][0]), dicClickPos["bluedrohne"][1]);
                    MainWindow.Sleep(500);
                }
                if(golddrohne == 1) {
                    MouseActions.SingleClickAtPosition((dicClickPos["golddrohne"][0]), dicClickPos["golddrohne"][1]);
                    MainWindow.Sleep(500);
                }
                if(Missiontype.Contains("Doppelt")) {
                    successbooster = 1;
                    selectBooster("double", successbooster);
                }
                else if(Missiontype.Contains("Speed")) {
                    successbooster = 1;
                    selectBooster("speed", successbooster);
                }
                else if(successbooster > 0) {
                    MainWindow.Sleep(100);
                    string OcrPreBoosterRate = OCR.OCRcheck(1056, 963, 100, 35,"0123456789% "); //bsp.:  100% , 130%
                    if(OcrPreBoosterRate == "") {
                        OcrPreBoosterRate = OCR.OCRcheck(1025, 963, 100, 35, "0123456789% ");
                        if(OcrPreBoosterRate == "") {
                            log.Error("OcrPreBoosterRate not found or recognized!");
                            return -1;
                        }
                    }
                    int OcrPreBoosterRateInt = Convert.ToInt32(OcrPreBoosterRate.Substring(0, OcrPreBoosterRate.Length - 1));
                    if(OcrPreBoosterRateInt < targetSuccessRate) {
                        selectBooster("successbooster", successbooster);
                    }
                    else {
                        return OcrPreBoosterRateInt;
                    }
                }

                string OcrSuccessRate2 = OCR.OCRcheck(1056, 963, 100, 35, "0123456789% "); //bsp.:  100% , 130%
                int OcrSuccessRateInt2 = Convert.ToInt32(OcrSuccessRate.Substring(0, OcrSuccessRate.Length - 1));
                return OcrSuccessRateInt2;
            }

            void selectBooster(string boosterType, int boosterValue) {
                MainWindow.Sleep(100);
                MouseActions.SingleClickAtPosition(-398, 736); //open GambitMenu
                int Score = 0;
                int i = 0;
                while(Score < 2 && StopAutoMission == false) {
                    Score = 0;
                    if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                        log.Debug("AutoMission interrupted by user at: selecting Booster");
                        StopAutoMission = true;
                        return;
                    }
                    if(PixelFinder.SearchStaticPixel(253, 943, "#6A8093")) { Score++; } //grey "Schliessen" button
                    if(PixelFinder.SearchStaticPixel(1794, 154, "#FFFFFF")) { Score++; } //white x top close window
                    if(PixelFinder.SearchStaticPixel(1011, 214, "#2179CE")) { Score++; } //Gambit Background
                    LoopGarbageCollector.ClearGarbageCollector();
                    if(++i > 25) {
                        log.Debug("GambitScreen couldnt be found in time:");
                        return;
                    }
                }
                i = 0;
                log.Debug("GambitScreenFound");
            
                int XCoordinate = 0;
                while(XCoordinate == 0 && StopAutoMission == false && i<7) { //Limited to 6 Times
                    if(boosterType != "double") {
                        if(boosterType != "speed") {
                            if(boosterType == "successbooster") {
                                if(boosterValue == 30) {
                                    //XCoordinate = FindImageCoordinates(@"C:\temp\success30.jpg");
                                    XCoordinate = FindImageCoordinates(MainWindow.ResourcesPath + @"booster\success30drohne.png"); 
                                    if(XCoordinate != 0) {
                                        break;
                                    }
                                }
                                else if(boosterValue == 25) {
                                    //XCoordinate = FindImageCoordinates(@"C:\temp\success30.jpg");
                                    XCoordinate = FindImageCoordinates(MainWindow.ResourcesPath + @"booster\success25.png");
                                    if(XCoordinate != 0) {
                                        break;
                                    }
                                }
                                else if(boosterValue == 20) {
                                    //XCoordinate = FindImageCoordinates(@"C:\temp\success30.jpg");
                                    XCoordinate = FindImageCoordinates(MainWindow.ResourcesPath + @"booster\success20drohne.png");
                                    if(XCoordinate != 0) {
                                        break;
                                    }
                                }
                                else if(boosterValue == 15) {
                                    //XCoordinate = FindImageCoordinates(@"C:\temp\success30.jpg");
                                    XCoordinate = FindImageCoordinates(MainWindow.ResourcesPath + @"booster\success15.png");
                                    if(XCoordinate != 0) {
                                        break;
                                    }
                                }
                                else if(boosterValue == 10) {
                                    //XCoordinate = FindImageCoordinates(@"C:\temp\success30.jpg");
                                    XCoordinate = FindImageCoordinates(MainWindow.ResourcesPath + @"booster\success10drohne.png");
                                    if(XCoordinate != 0) {
                                        break;
                                    }
                                }
                                else if(boosterValue == 10) {
                                    //XCoordinate = FindImageCoordinates(@"C:\temp\success30.jpg");
                                    XCoordinate = FindImageCoordinates(MainWindow.ResourcesPath + @"booster\success10drohne.png");
                                    if(XCoordinate != 0) {
                                        break;
                                    }
                                }
                                else if(boosterValue == 5) {
                                    //XCoordinate = FindImageCoordinates(@"C:\temp\success30.jpg");
                                    XCoordinate = FindImageCoordinates(MainWindow.ResourcesPath + @"booster\success5drohne.png");
                                    if(XCoordinate != 0) {
                                        break;
                                    }
                                }
                            }
                        }
                        else { //speedbooster
                            XCoordinate = FindImageCoordinates(MainWindow.ResourcesPath + @"booster\BMPspeed30.bmp");
                            if(XCoordinate != 0) {
                                break;
                            }
                        }
                    }
                    else { //double
                        XCoordinate = FindImageCoordinates(MainWindow.ResourcesPath + @"booster\double.png");
                        if(XCoordinate != 0) {
                            break;
                        }
                    }
                    log.Debug("Round: " + i.ToString() + ", Booster not found");

                    //scroll 3boosters
                    int moveToX = 0;
                    if(MainWindow.CurrentHostName == "VMgr4ndpa") {
                        MouseActions.SetCursorPos(1718, 484);
                        moveToX = 1715;
                        MouseActions.LeftMouseDown();
                        while(moveToX > 115 && StopAutoMission == false) {
                            if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                                log.Debug("AutoMission interrupted by user at: selecting Booster");
                                StopAutoMission = true;
                                return;
                            }
                            moveToX -= 90;
                            MouseActions.SetCursorPos(moveToX, 484);
                            MainWindow.Sleep(34);
                        }
                    }
                    else {
                        MouseActions.SetCursorPos(-202, 484);
                        moveToX = -215;
                        MouseActions.LeftMouseDown();
                        while(moveToX > -1805 && StopAutoMission == false) {
                            if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                                log.Debug("AutoMission interrupted by user at: selecting Booster");
                                StopAutoMission = true;
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
                }
                if(MainWindow.CurrentHostName == "VMgr4ndpa") {
                    MouseActions.SingleClickAtPosition(XCoordinate - 1920, 690);
                }
                else {
                    MouseActions.SingleClickAtPosition(XCoordinate, 690);
                }
            }

            int FindImageCoordinates(string ImageInput) {
                string[] ImgSearchResult = ImgSearch.UseImageSearch(ImageInput, "130");
                if(ImgSearchResult != null && ImgSearchResult.Length > 0) {
                    log.Debug("Found at: " + ImgSearchResult[1] + ", 690");
                    return Convert.ToInt32(ImgSearchResult[1]);
                }
                return 0;
            }

            void checkGold() {
                string OcrCurrentGold = OCR.OCRcheck(1230, 34, 113, 32); //bsp.: 10000k
                string OcrMissionCost = OCR.OCRcheck(1647, 977, 123, 46); //bsp.: 2500k

                OcrMissionCost = "40000k";

                if(OcrCurrentGold.Contains("k")) {
                    OcrCurrentGold = OcrCurrentGold.Substring(0, (OcrCurrentGold.Length - 1));
                    if(Convert.ToInt32(OcrCurrentGold) >= Convert.ToInt32(OcrMissionCost.Substring(0, (OcrMissionCost.Length - 1)))) {
                        //Continue
                    }
                    else {
                        //getMoreGold
                        MouseActions.DoubleClickAtPosition(-1225, 40); //shop
                        MainWindow.Sleep(800);
                        MouseActions.DoubleClickAtPosition(-336, 130); //close advertisement
                        MainWindow.Sleep(800);
                        MouseActions.SingleClickAtPosition(-287, 301); //schlachtpakete
                        MainWindow.Sleep(800);
                        //MouseActions.SingleClickAtPosition(-1225, 40); //shop
                        

                        MouseActions.SetCursorPos(-213, 916); //empty space between exclusiv und austrüsungskiste
                        MouseActions.LeftMouseDown();
                        int moveToX = -215;
                        //while(moveToX > -1805 && StopAutoMission == false) {
                            if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                                log.Debug("AutoMission interrupted by user at: selecting Booster");
                                StopAutoMission = true;
                                return;
                            }
                            moveToX -= 500;
                            MouseActions.SetCursorPos(moveToX, 484);
                            MainWindow.Sleep(22);
                        //}
                        MouseActions.LeftMouseUp();
                        MainWindow.Sleep(800);
                        MouseActions.SingleClickAtPosition(-294, 919); //mostright chest
                        MainWindow.Sleep(800);
                        string OcrFindPacket = OCR.OCRcheck(65, 189, 394, 65);
                        if(OcrFindPacket == "Kampf-Paket") {
                            MouseActions.SingleClickAtPosition(-383, 729); //Buy 4x"Kampf-paket" first time
                            MainWindow.Sleep(7600);
                            MouseActions.DoubleClickAtPosition(-966, 812);
                            MainWindow.Sleep(2000);
                            //BetterDoWhile PixelCheckTrue && i<5 to avoid running into some bullshit

                            int Score = 3;
                            int i = 0;
                            while(Score > 2 && StopAutoMission == false) {
                                Score = 0;
                                if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                                    log.Debug("AutoMission interrupted by user at: CheckforGreenChests can be baugt for money");
                                    StopAutoMission = true;
                                    return;
                                }
                                if(PixelFinder.SearchStaticPixel(520, 1028, "#4C713C")) { Score++; } //GreenButton MoneySign
                                if(PixelFinder.SearchStaticPixel(546, 1017, "#FDB4A6")) { Score++; } //GreenButton MoneySign
                                if(PixelFinder.SearchStaticPixel(584, 1039, "#375C27")) { Score++; } //GreenButton MoneySign
                                LoopGarbageCollector.ClearGarbageCollector();
                                if(Score > 2) {
                                    MouseActions.SingleClickAtPosition(-1338, 992); //Buy 4x"Kampf-paket"
                                    MainWindow.Sleep(800);
                                    MouseActions.DoubleClickAtPosition(-1338, 992); //Buy 4x"Kampf-paket"
                                    MainWindow.Sleep(800);
                                }
                                if(++i > 40) {
                                    log.Debug("Gathering Limit reached");
                                    return;
                                }
                            }
                        }
                        else {
                            MouseActions.SingleClickAtPosition(-847, 926); //chest left to the mostright chest
                            MainWindow.Sleep(800);
                            OcrFindPacket = OCR.OCRcheck(65, 189, 394, 65);
                            if(OcrFindPacket == "Kampf-Paket") {
                                MouseActions.SingleClickAtPosition(-383, 729); //Buy 4x"Kampf-paket" first time
                                MainWindow.Sleep(7600);
                                MouseActions.DoubleClickAtPosition(-966, 812);
                                MainWindow.Sleep(2000);
                                //BetterDoWhile PixelCheckTrue && i<5 to avoid running into some bullshit
                                int Score = 3;
                                int i = 0;
                                while(Score > 2 && StopAutoMission == false ) {
                                    Score = 0;
                                    if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                                        log.Debug("AutoMission interrupted by user at: CheckforGreenChests can be baugt for money");
                                        StopAutoMission = true;
                                        return;
                                    }
                                    if(PixelFinder.SearchStaticPixel(520, 1028, "#4C713C")) { Score++; } //GreenButton MoneySign
                                    if(PixelFinder.SearchStaticPixel(546, 1017, "#FDB4A6")) { Score++; } //GreenButton MoneySign
                                    if(PixelFinder.SearchStaticPixel(584, 1039, "#375C27")) { Score++; } //GreenButton MoneySign
                                    LoopGarbageCollector.ClearGarbageCollector();
                                    if(Score > 2) {
                                        MouseActions.SingleClickAtPosition(-1338, 992); //Buy 4x"Kampf-paket"
                                        MainWindow.Sleep(800);
                                        MouseActions.DoubleClickAtPosition(-1338, 992); //Buy 4x"Kampf-paket"
                                        MainWindow.Sleep(800);
                                    }
                                    if(++i > 40) {
                                        log.Debug("Gathering Limit reached");
                                        return;
                                    }
                                }

                            }
                            else {
                                Console.WriteLine("Package not found man!");
                            }
                        }

                        //while(OcrFindPacket != "Kampf-Paket") {
                        //    //i++;
                        //    KeyboardInput.Send(KeyboardInput.ScanCodeShort.r);
                        //}

                    }
                }
                else {
                    //getMoreGold
                }
            }

            void CheckForDifficulty(){
                if(ImgSearch.UseImageSearch(MainWindow.ResourcesPath + @"stern6.png", "120", -895, 865, -761, 984) != null) {
                    MissionDifficulty = 6;
                }
                else if(ImgSearch.UseImageSearch(MainWindow.ResourcesPath + @"stern5.png","120", -895, 865, -761, 984) != null) {
                    MissionDifficulty = 5;
                }
                else if(ImgSearch.UseImageSearch(MainWindow.ResourcesPath + @"stern7.png", "120", -895, 865, -761, 984) != null) {
                    MissionDifficulty = 7;
                }
                else if(ImgSearch.UseImageSearch(MainWindow.ResourcesPath + @"stern8.png", "120", -895, 865, -761, 984) != null) {
                    MissionDifficulty = 8;
                }
                else if(ImgSearch.UseImageSearch(MainWindow.ResourcesPath + @"stern9.png", "120", -895, 865, -761, 984) != null) {
                    MissionDifficulty = 9;
                }
                else if(ImgSearch.UseImageSearch(MainWindow.ResourcesPath + @"stern10.png", "120", -895, 865, -761, 984) != null) {
                    MissionDifficulty = 10;
                }
                else if(ImgSearch.UseImageSearch(MainWindow.ResourcesPath + @"stern4.png", "120", -998, 865, -871, 984) != null) {
                    MissionDifficulty = 4;
                }
                else if(ImgSearch.UseImageSearch(MainWindow.ResourcesPath + @"stern3.png", "120", -1330, 865, -1073, 984) != null) {
                    MissionDifficulty = 3;
                }
                else if(ImgSearch.UseImageSearch(MainWindow.ResourcesPath + @"stern2.png", "120", -1530, 865, -1205, 984) != null) {
                    MissionDifficulty = 2;
                }
                else if(ImgSearch.UseImageSearch(MainWindow.ResourcesPath + @"stern1.png", "120", -1747, 865, -1504, 984) != null) {
                    MissionDifficulty = 1;
                }

                else if (MissionDifficulty == 0) {
                    log.Debug("Difficulty couldn't been detected!");
                    StopAutoMission = true;
                    return;
                }
                log.Debug("Difficulty is " + MissionDifficulty.ToString());
            }

            bool CheckForAvailibleSoldiers(){
                string OcrActiveSoldiers = "";

                if(MissionDifficulty >= 5  && StopAutoMission == false) {  //same position for difficulty 5-10
                    OcrActiveSoldiers = OCR.OCRcheck(1173, 922, 106, 34, "0123456789/ "); //6char
                    if(!CheckOCRResultValid(OcrActiveSoldiers)) {
                        OcrActiveSoldiers = OCR.OCRcheck(1173, 922, 84, 34, "0123456789/ "); //5char
                        if(!CheckOCRResultValid(OcrActiveSoldiers)) {
                            OcrActiveSoldiers = OCR.OCRcheck(1173, 922, 74, 34, "0123456789/ "); //4char
                            if(!CheckOCRResultValid(OcrActiveSoldiers)) {
                                OcrActiveSoldiers = OCR.OCRcheck(1173, 922, 51, 34, "0123456789/ "); //3char
                                if(!CheckOCRResultValid(OcrActiveSoldiers)) {
                                    return false;
                                }
                            }
                        }
                    }
                }
                else if(MissionDifficulty == 4 && StopAutoMission == false) {
                    OcrActiveSoldiers = OCR.OCRcheck(1073, 922, 106, 34, "0123456789/ "); //6char
                    if(!CheckOCRResultValid(OcrActiveSoldiers)) {
                        OcrActiveSoldiers = OCR.OCRcheck(1073, 922, 84, 34, "0123456789/ "); //5char
                        if(!CheckOCRResultValid(OcrActiveSoldiers)) {
                            OcrActiveSoldiers = OCR.OCRcheck(1073, 922, 74, 34, "0123456789/ "); //4char
                            if(!CheckOCRResultValid(OcrActiveSoldiers)) {
                                OcrActiveSoldiers = OCR.OCRcheck(1073, 922, 51, 34, "0123456789/ "); //3char
                                if(!CheckOCRResultValid(OcrActiveSoldiers)) {
                                    return false;
                                }
                            }
                        }
                    }
                }
                else if(MissionDifficulty == 3 && StopAutoMission == false) {

                }
                else if(MissionDifficulty == 2 && StopAutoMission == false) {

                }
                else if(MissionDifficulty == 1 && StopAutoMission == false) {

                }
                return true;
            }

            bool CheckOCRResultValid(string OcrActiveSoldiers) {
                string[] OcrActiveSoldiersStringArray = { };
                int CurrentlyAvailible = -1;
                int PossessedOnes = -1;
                if(!String.IsNullOrWhiteSpace(OcrActiveSoldiers)) {
                    if(OcrActiveSoldiers.Contains("/")) {
                        OcrActiveSoldiersStringArray = OcrActiveSoldiers.Split('/');
                        if(int.TryParse(OcrActiveSoldiersStringArray[0], out CurrentlyAvailible)) {
                            if(int.TryParse(OcrActiveSoldiersStringArray[1], out PossessedOnes)) {
                                if(CurrentlyAvailible <= PossessedOnes && CurrentlyAvailible > 0) {
                                    return true;
                                }
                                else if (CurrentlyAvailible == 0) { 
                                    return false;
                                }
                            }
                        }
                    }
                }
                return false;
            }

            int CheckforSoldierScreenSelection(){
                int Score = 0;
                int i = 0;
                while(Score < 2 && StopAutoMission == false) {
                    Score = 0;
                    if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                        log.Debug("AutoMission interrupted by user at: CheckforSoldierScreenSelection");
                        StopAutoMission = true;
                        return -1;
                    }
                    if(PixelFinder.SearchStaticPixel(1187, 119, "#FFFFFF")) { Score++; } //Text Team zuwe>I<sen
                    if(PixelFinder.SearchStaticPixel(1828, 124, "#FEFEFE")) { Score++; } //white x top close window
                    if(PixelFinder.SearchStaticPixel(1471, 100, "#123B64")) { Score++; } //TeamZuweisen Background
                    LoopGarbageCollector.ClearGarbageCollector();
                    if(++i > 10) {
                        log.Debug("SoldierScreenSelection couldnt be found in time:");
                        return -1;
                    }
                }
                if(MissionDifficulty == 0) {
                    CheckForDifficulty();
                    if(CheckCounter.Length == 5) { //5 Counter
                        CacheDb.GetSoldiers(MissionDifficulty, CheckCounter[0], CheckCounter[1], CheckCounter[2], CheckCounter[3], CheckCounter[4]);
                    }
                    else if(CheckCounter.Length == 4) {
                        CacheDb.GetSoldiers(MissionDifficulty, CheckCounter[0], CheckCounter[1], CheckCounter[2], CheckCounter[3]);
                    }
                    else if(CheckCounter.Length == 3) {
                        CacheDb.GetSoldiers(MissionDifficulty, CheckCounter[0], CheckCounter[1], CheckCounter[2]);
                    }
                    else if(CheckCounter.Length == 2) {
                        CacheDb.GetSoldiers(MissionDifficulty, CheckCounter[0], CheckCounter[1]);
                    }
                    else if(CheckCounter.Length == 1) {
                        CacheDb.GetSoldiers(MissionDifficulty, CheckCounter[0]);
                    }

                    CacheDb.GetSoldiersSelect();
                    UpdateListeners(CacheDb.DataTableFilteredSoldiers);
                } 
                return 1;
            }

            int CheckforFilterMenu() {
                int Score = 0;
                int i = 0;
                while(Score < 2 && StopAutoMission == false) {
                    Score = 0;
                    if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                        log.Debug("AutoMission interrupted by user at: CheckforFilterMenu");
                        StopAutoMission = true;
                        return -1;
                    }
                    if(PixelFinder.SearchStaticPixel(1773, 925, "#3A9F64")) { Score++; } //FilterButtonGreen
                    if(PixelFinder.SearchStaticPixel(1826, 124, "#27597E")) { Score++; } //Grey X behind FilterWindow
                    if(PixelFinder.SearchStaticPixel(727, 114, "#FFFFFF")) { Score++; } //FilterWindowText Filtern >F<ilternach Verfü.
                    LoopGarbageCollector.ClearGarbageCollector();
                    if(++i > 25) {
                        log.Debug("FilterMenu couldnt be found in time:");
                        return -1;
                    }
                }
                return 1;
            }

            int CheckforFilteredSoldierReady() { //of the leftmost Soldier  -Checks For soldierButton
                int Score = 0;
                int i = 0;
                while(Score < 2 && Score > -2 && StopAutoMission == false) {
                    Score = 0;
                    if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                        log.Debug("AutoMission interrupted by user at: CheckforFilterMenu");
                        StopAutoMission = true;
                        return -1;
                    }
                    //SearchFor GreenButton
                    if(PixelFinder.SearchStaticPixel(86, 797, "#065C16")) { Score++; } //left of Green Button
                    if(PixelFinder.SearchStaticPixel(225, 788, "#FFFFFF")) { Score++; } //dot of Ä in w>Ä<hlen
                    if(PixelFinder.SearchStaticPixel(443, 774, "#52C067")) { Score++; } //shiny area right of Green Button

                    //SearchFor BlueButton
                    if(PixelFinder.SearchStaticPixel(171, 816, "#2182BD")) { Score--; } //BlueBackground at Text >E<rgebnis -> Wählen/Melden have white Text this pixel
                    if(PixelFinder.SearchStaticPixel(287, 826, "#2A92D1")) { Score--; } //BlueBackground at Text Erge><bnis -> Wählen/Melden have diffrent Color this pixel
                    if(PixelFinder.SearchStaticPixel(95, 823, "#0C4D75")) { Score--; } //Point on blue button

                    LoopGarbageCollector.ClearGarbageCollector();
                    if(Score <= -2) {
                        return 0; //BlueButton
                    }
                    if(++i > 25) {
                        log.Debug("No Soldier fullfilling the Filters couldnt be found in time:");
                        return -1; //Timeout
                    }
                }
                return 1; //GreenButton
            }

            int CheckforInMissionScreen() { //Inside a mission
                int Score = 0;
                int i = 0;
                while(Score < 2 && StopAutoMission == false) {
                    Score = 0;
                    if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                        log.Debug("AutoMission interrupted by user at: CheckforFilterMenu");
                        StopAutoMission = true;
                        return -1;
                    }
                    if(PixelFinder.SearchStaticPixel(57, 803, "#A3F5F6")) { Score++; } // Missionscreen >A<nforderungen
                    if(PixelFinder.SearchStaticPixel(290, 798, "#A3F5F6")) { Score++; } // Missionscreen Anforderu>N<gen
                    if(PixelFinder.SearchStaticPixel(251, 954, "#A3F5F6")) { Score++; } // Missionscreen Rücksch>L<äge
                    LoopGarbageCollector.ClearGarbageCollector();
                    if(++i > 25) {
                        log.Debug("InMissionScreen couldnt be found in time:");
                        return -1;
                    }
                }
                return 1;
            }

            int CheckIfSpezialMissionsScreen() {
                int Score = 0;
                int i = 0;
                while(Score < 2 && StopAutoMission == false) {
                    Score = 0;
                    if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                        log.Debug("AutoMission interrupted by user at: CheckforFilterMenu");
                        StopAutoMission = true;
                        return -1;
                    }
                    if(PixelFinder.SearchStaticPixel(184, 144, "#91EAF7")) { Score++; } // Blue Area Info Sign
                    if(PixelFinder.SearchStaticPixel(692, 165, "#63DCFF")) { Score++; } // Leftblue Arrow
                    if(PixelFinder.SearchStaticPixel(1226, 164, "#63DCFF")) { Score++; } // Right Blue Arrow

                    LoopGarbageCollector.ClearGarbageCollector();
                    if(++i > 10) {
                        log.Debug("InMissionScreen couldnt be found in time:");
                        return -1;
                    }
                }
                MainWindow.Sleep(100); //Isssues on VM to continue
                return 1;
            }
        }
    }
}
