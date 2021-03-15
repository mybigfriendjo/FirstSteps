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

namespace AutoSF {
    public static class AutoMission {

        
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
             * -automatisch zur mission navigieren
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
            DataRow[] result = null;


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
            dicClickPos.Add("RSKommunkikation", new int[] { -620, 600 });
            dicClickPos.Add("RSRadar", new int[] { -520, 600 });
            dicClickPos.Add("RSBoot", new int[] { -420, 600 });
            dicClickPos.Add("RSJetpack", new int[] { -320, 600 });
            dicClickPos.Add("RSTarnung", new int[] { -220, 600 });
            dicClickPos.Add("RSVerkleidung", new int[] { -120, 600 });
            dicClickPos.Add("RSHelikopter", new int[] { -620, 700 });
            dicClickPos.Add("RSGeiseln", new int[] { -520, 700 });
            dicClickPos.Add("RSTaktiken", new int[] { -420, 700 });
            dicClickPos.Add("RSVIP", new int[] { -320, 700 });
            dicClickPos.Add("RSSprengstoffe", new int[] { -220, 700 });
            dicClickPos.Add("RSAufklaerung", new int[] { -120, 700 });
            dicClickPos.Add("RSBiologischeGefahr", new int[] { -620, 800 });
            dicClickPos.Add("RSFahrzeug", new int[] { -520, 800 });
            dicClickPos.Add("RSToedlich", new int[] { -420, 800 });
            dicClickPos.Add("RSBegrenzteMunition", new int[] { -320, 800 });
            dicClickPos.Add("OnlySniper", new int[] { }); //Unknown................

            dicClickPos.Add("verfügbar", new int[] { -1132, 207 });
            dicClickPos.Add("nichtverfügbar", new int[] { -898, 205 });
            dicClickPos.Add("Stern1", new int[] { -1185, 400 });
            dicClickPos.Add("Stern2", new int[] { -1085, 400 });
            dicClickPos.Add("Stern3", new int[] { -985, 400 });
            dicClickPos.Add("Stern4", new int[] { -885, 400 });
            dicClickPos.Add("Stern5", new int[] { -785, 400 });
            dicClickPos.Add("Stern6", new int[] { -1185, 500 });
            dicClickPos.Add("Stern7", new int[] { -1085, 500 });
            dicClickPos.Add("Stern8", new int[] { -985, 500 });
            dicClickPos.Add("Stern9", new int[] { -885, 500 });
            dicClickPos.Add("Stern10", new int[] { -785, 500 });
            dicClickPos.Add("Stern11", new int[] { -1185, 600 });
            dicClickPos.Add("Stern12", new int[] { -1085, 600 });
            dicClickPos.Add("RandomSoldier1", new int[] { -1807, 922 });
            dicClickPos.Add("RandomSoldier2", new int[] { -1707, 922 });
            dicClickPos.Add("RandomSoldier3", new int[] { -1607, 922 });
            dicClickPos.Add("RandomSoldier4", new int[] { -1507, 922 });
            dicClickPos.Add("bluedrohne", new int[] { -690, 748 });
            dicClickPos.Add("golddrohne", new int[] { -952, 740 });

            dicClickPos.Add("BSMechaniker", new int[] { -645, 219 }); //20 %speed(bei aktiver drohne) -645, 219
            dicClickPos.Add("BSGepanzert", new int[] { -545, 219 });
            dicClickPos.Add("BSSchwere Rüstung", new int[] { -445, 219 });
            dicClickPos.Add("BSKoordination", new int[] { -345, 219 }); //+20%winrate
            dicClickPos.Add("BSAbsicherung", new int[] { -245, 219 }); //immun gegen klauen
            dicClickPos.Add("BSAufsteiger", new int[] { -145, 219 }); //+5% größergleich 4st
            dicClickPos.Add("BSGeschäftemacher", new int[] { -645, 319 });
            dicClickPos.Add("BSÜberlebenskünstler", new int[] { -545, 319 });
            dicClickPos.Add("BSÜberlebensspezialist", new int[] { -445, 319 });
            dicClickPos.Add("BSGlück", new int[] { -345, 319 });
            dicClickPos.Add("BSImprovisation", new int[] { -245, 319 }); //+5% kleinergleich 2st
            dicClickPos.Add("BSRabatt", new int[] { -145, 319 });
            dicClickPos.Add("BSLehrer", new int[] { -645, 419 });
            dicClickPos.Add("BSUnabhängig", new int[] { -545, 419 }); //+5% solo
            dicClickPos.Add("BSZeitgewinn", new int[] { -445, 419 }); //10 %speed
            dicClickPos.Add("BSDrohne", new int[] { -345, 419 }); // +10%winrate (bei aktiver drohne)
            dicClickPos.Add("BSTechnik", new int[] { -245, 419 });
            dicClickPos.Add("BSSchnell", new int[] { -145, 419 }); //20 % speed
            #endregion



            Stopwatch missionTime = Stopwatch.StartNew();



            //if(MissionsAvailible() != 0 && StopAutoMission == false) { //checks for availible Missions
            //    MouseActions.SingleClickAtPosition(-1423, 939); //Click "Verfügbar"
            //    MainWindow.Sleep(600);
            //    MouseActions.DoubleClickAtPosition(-1544, 518); //click Mission to the left (not avilible Mission is at the right side)
            //    MainWindow.Sleep(800);


                OcrMissionname1 = OCR.OCRcheck(15, 100, 475, 70); //bsp.: Hinweis
                OcrMissionname2 = OCR.OCRcheck(12, 105, 475, 55);
                result = DB.dt.Select("Missionname = '" + OcrMissionname1 + "'");
                loadMission();

            //}




            void loadMission() {    
                if((result == null || result.Length == 0) && StopAutoMission == false) {
                    result = DB.dt.Select("Missionname = '" + OcrMissionname2 + "'");
                    if((result == null || result.Length == 0) && StopAutoMission == false) { //Mission not found in DB - storing MissionScreenshot named OcrMissionname1_OcrMissionname2
                        result = DB.dt.Select("MissionnameAlias = '" + OcrMissionname1 + "'");
                        if((result == null || result.Length == 0) && StopAutoMission == false) { //Mission not found in DB - storing MissionScreenshot named OcrMissionname1_OcrMissionname2
                            Console.WriteLine("MissionNotInDB_" + OcrMissionname1 + "_" + OcrMissionname2 + "_" + DateTime.Now.ToString("dd/MM/yyyy HH-mm-ss") + ".png");


                            log.Debug("MissionNotInDB_" + OcrMissionname1 + "_" + OcrMissionname2 + DateTime.Now.ToString("dd/MM/yyyy HH-mm-ss") + ".png");
                            using(StreamWriter sw = new StreamWriter(@"MissionLog.txt", true)) { //Streamwriter is of tpye IDisposable (objects that dont get deleted automatically) using(sw){ } disposes every sw object at "}"
                                sw.WriteLine("MissionNotInDB_" + OcrMissionname1 + "_" + OcrMissionname2 + DateTime.Now.ToString("dd/MM/yyyy HH-mm-ss") + ".png");
                            }

                            string saveOcrMissionname1 = checkString(OcrMissionname1); //removes special characters
                            string saveOcrMissionname2 = checkString(OcrMissionname2);
                            if(OcrMissionname1 != saveOcrMissionname1 && OcrMissionname2 != saveOcrMissionname2) {
                                OCR.FullsizeImage.Save("MissionNotInDB_" + "BothEDITED" + saveOcrMissionname1 + "_" + saveOcrMissionname2 + DateTime.Now.ToString("dd/MM/yyyy HH-mm-ss") + ".png");
                            }
                            else if(OcrMissionname1 != saveOcrMissionname1) {
                                OCR.FullsizeImage.Save("MissionNotInDB_" + saveOcrMissionname1 + "1stEDITED" + "_" + saveOcrMissionname2 + DateTime.Now.ToString("dd/MM/yyyy HH-mm-ss") + ".png");
                            }
                            else if(OcrMissionname2 != saveOcrMissionname2) {
                                OCR.FullsizeImage.Save("MissionNotInDB_" + saveOcrMissionname1 + "_" + saveOcrMissionname2 + "2ndEDITED" + DateTime.Now.ToString("dd/MM/yyyy HH-mm-ss") + ".png");
                            }
                            else {
                                OCR.FullsizeImage.Save("MissionNotInDB_" + saveOcrMissionname1 + "_" + saveOcrMissionname2 + DateTime.Now.ToString("dd/MM/yyyy HH-mm-ss") + ".png");
                            }
                        }
                        else if(StopAutoMission == false) { Missionfound = true; }
                    }
                    else if(StopAutoMission == false) { Missionfound = true; }
                }
                else if(StopAutoMission == false){ Missionfound = true; }


                if(Missionfound == true && StopAutoMission == false) {

                    if((result[0].Field<Int64>("Speed")) == 1 && StopAutoMission == false) {
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
                            targetSuccessRate = 140;
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
                    //Adds all COUNTER Columns with a value of one into the array Checkcounter
                    foreach(DataRow row in result) {
                        foreach(DataColumn col in row.Table.Columns) {
                            if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                                log.Debug("AutoMission interrupted by user at Pos ??");
                                StopAutoMission = true;
                            }
                            if(col.Ordinal >= 14 && col.Ordinal <= 29) { //14-29 is the Column range for all Counters
                                if(Convert.ToInt32(row[col.Ordinal]) == 1) {
                                    CheckCounter = CheckCounter.Append(col.ColumnName).ToArray();
                                }
                            }
                        }
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
                    if(StopAutoMission == false && 100 <= checkSuccessRate(targetSuccessRate)) {
                        //checkGold();
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
                        else if(StopAutoMission == false) { return; }

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
                            if(CheckSoldierType.Length == 1) {
                                MouseActions.SingleClickAtPosition(-94, 125); //Close SoldierSelectionScreen - if no viable Soldier has been found
                                MainWindow.Sleep(800);
                                ORCGetSuccessrate = OCR.OCRcheck(1056, 963, 100, 35);
                                MouseActions.DoubleClickAtPosition(-255, 350);
                                MainWindow.Sleep(1200);
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
                        else if(StopAutoMission == false) { return; }
                        if(StopAutoMission == false && CheckforFilterMenu() == 1) {
                            if(Missiontype != "Speed") {
                                MouseActions.SingleClickAtPosition(dicClickPos["verfügbar"][0], dicClickPos["verfügbar"][1]);
                            }
                        }
                        else if(StopAutoMission == false){ return; }
                        MainWindow.Sleep(500);
                        if(StopAutoMission == false && (Missiontype == "Speed" || Missiontype == "SpeedMitBonus")) {
                            bool counterFound = false;
                            if(currentSoldier == "Sniper") { //selects 9* schnell(kommunikation) or 9* Zeitgewinn(RSTarnung)
                                foreach(string counter in CheckCounter) {
                                    if(counter == "RSTarnung") {
                                        MouseActions.SingleClickAtPosition(dicClickPos[counter][0], dicClickPos[counter][1]);
                                        MainWindow.Sleep(150);
                                        MouseActions.SingleClickAtPosition(dicClickPos["BSZeitgewinn"][0], dicClickPos["BSZeitgewinn"][1]);
                                        counterFound = true;
                                    }
                                }
                            }
                            else if(currentSoldier == "Sturm") { //selects 9* mechaniker(RSRadar) or 9* Zeitgewinn(RSBoot)
                                foreach(string counter in CheckCounter) {
                                    if(counter == "RSBoot") {
                                        MouseActions.SingleClickAtPosition(dicClickPos[counter][0], dicClickPos[counter][1]);
                                        MainWindow.Sleep(150);
                                        MouseActions.SingleClickAtPosition(dicClickPos["BSZeitgewinn"][0], dicClickPos["BSZeitgewinn"][1]);
                                        counterFound = true;
                                    }
                                }
                            }
                            else if(currentSoldier == "RPG") {

                            }
                            else if(currentSoldier == "Molotow") {
                                MainWindow.Sleep(150);MainWindow.Sleep(150);
                                MouseActions.SingleClickAtPosition(dicClickPos["verfügbar"][0], dicClickPos["verfügbar"][1]);
                                //MainWindow.Sleep(150);
                            }
                            else if(currentSoldier == "Elite") {
                                
                            }
                            if(counterFound == false) {
                                MouseActions.SingleClickAtPosition(dicClickPos["BSMechaniker"][0], dicClickPos["BSMechaniker"][1]);
                                MainWindow.Sleep(150);
                                MouseActions.SingleClickAtPosition(dicClickPos["BSSchnell"][0], dicClickPos["BSSchnell"][1]);
                            }
                            MouseActions.SingleClickAtPosition(-1818, 209); //Close Filter
                            MainWindow.Sleep(600);
                            int SoldierReady = CheckforFilteredSoldierReady();
                            if(SoldierReady == 0) { //Bluebutton "Erledigt"
                                MouseActions.SingleClickAtPosition(-1664, 810); //click Bluebutton "Erledigt"
                                MainWindow.Sleep(300); //Wiat for Mission Completed-Animation to be interruptable
                                MouseActions.DoubleClickAtPosition(-979, 611); //click Screen mid to interruprt Mission Completed-Animation
                                MainWindow.Sleep(300);
                                MouseActions.SingleClickAtPosition(-263, 995); //Annehmen Button
                                //Soldier is now Availible but SF will switch to MissionScreen therefore return to trigger the selection again.
                                return;
                            }
                            else if(SoldierReady == 1) { //Greenbutton "Wählen"
                                CheckSoldierType = CheckSoldierType.Where(e => e != currentSoldier).ToArray();
                                MouseActions.SingleClickAtPosition(-1650, 813); //Select FilteredSoldier
                                MainWindow.Sleep(1000);
                            }
                            else if(SoldierReady == -1) { //Timeout neighter "Erledigt" or "Wählen" Button found
                                StopAutoMission = true;
                                log.Debug("No Speed " + currentSoldier + " ready.");
                                return;
                            }
                        }
                        else if(StopAutoMission == false && Missiontype == "DoppeltMitBonusOnlySniper") {
                        }
                        else if(StopAutoMission == false && Missiontype == "DoppeltMitBonus") {
                            if(CheckSoldierType.Length == 1 && currentSoldier == "Elite" && ORCGetSuccessrate == "135%") {
                                //MouseActions.DoubleClickAtPosition(dicClickPos["Elite"][0], dicClickPos["Elite"][1]);
                                //MainWindow.Sleep(1500);
                                //MouseActions.SingleClickAtPosition(-117, 923);
                                //MainWindow.Sleep(2000);
                                //MouseActions.SingleClickAtPosition(dicClickPos["verfügbar"][0], dicClickPos["verfügbar"][1]);
                                //MainWindow.Sleep(400);
                                MouseActions.SingleClickAtPosition(dicClickPos["Stern6"][0], dicClickPos["Stern6"][1]);
                                MainWindow.Sleep(400);
                                MouseActions.SingleClickAtPosition(dicClickPos["RSVIP"][0], dicClickPos["RSVIP"][1]);
                                MainWindow.Sleep(400);
                                //MouseActions.SingleClickAtPosition(-1818, 209); //Close Filter
                                //MainWindow.Sleep(400);
                                //MouseActions.SingleClickAtPosition(-1650, 813); //Select FilteredSoldier
                                //MainWindow.Sleep(1000);
                            }
                            else {
                                MouseActions.SingleClickAtPosition(dicClickPos["Stern10"][0], dicClickPos["Stern10"][1]);
                                MainWindow.Sleep(500);
                                MouseActions.SingleClickAtPosition(dicClickPos["Stern11"][0], dicClickPos["Stern11"][1]);
                                MainWindow.Sleep(500);
                                MouseActions.SingleClickAtPosition(-335, 211); //Bonus Kordination +10
                                MainWindow.Sleep(500);
                            }

                            string OcrActiveSoldiers = (OCR.OCRcheck(1160, 922, 140, 34, "0123456789/")); //bsp.: 19/25
                            if(OcrActiveSoldiers.Length <= 4 && StopAutoMission == false) {
                                OcrActiveSoldiers = (OCR.OCRcheck(1170, 926, 60, 34, "0123456789/")); //bsp.: 19/25
                            }
                            if(StopAutoMission == false && OcrActiveSoldiers != "0/0" && OcrActiveSoldiers != "17240") {
                                SoldierPickProcessDopMitBon();
                            }
                            else if(StopAutoMission == false){
                                log.Debug("No Soldier found that meets the requirements for " + result[0].Field<Int64>("Missionname") + ", " + Missiontype);
                            }

                            void SoldierPickProcessDopMitBon() {
                                //CheckCounter = CheckCounter.Where(e => e != Counter).ToArray(); //creates a new Array without value Counter
                                CheckSoldierType = CheckSoldierType.Where(e => e != currentSoldier).ToArray();
                                MouseActions.SingleClickAtPosition(-1818, 209); //Close Filter
                                MainWindow.Sleep(600);
                                MouseActions.SingleClickAtPosition(-1650, 813); //Select FilteredSoldier
                                MainWindow.Sleep(1000);
                            }
                        }
                        else if(StopAutoMission == false && Missiontype == "MitBonusOnlySniper") {

                        }
                        else if(StopAutoMission == false && Missiontype == "MitBonus") {

                        }
                        else if(StopAutoMission == false && (Missiontype == "Standard" || Missiontype == "Doppelt")) {

                            if(StopAutoMission == false && (result[0].Field<Int64>("Difficulty")) == 5) {
                                MouseActions.SingleClickAtPosition(dicClickPos["Stern6"][0], dicClickPos["Stern6"][1]);
                                MainWindow.Sleep(200);
                            }
                            else if(StopAutoMission == false && (result[0].Field<Int64>("Difficulty")) == 4) {
                                MouseActions.SingleClickAtPosition(dicClickPos["Stern5"][0], dicClickPos["Stern5"][1]);
                                MainWindow.Sleep(200);
                            }

                            foreach(string Counter in CheckCounter) {
                                if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                                    log.Debug("AutoMission interrupted by user at: Setting Counter");
                                    StopAutoMission = true;
                                    break;
                                }
                                MouseActions.SingleClickAtPosition(dicClickPos[Counter][0], dicClickPos[Counter][1]);
                                log.Debug("Click Filter " + Counter + " at " + dicClickPos[Counter][0].ToString() + "," + dicClickPos[Counter][1].ToString());
                                MainWindow.Sleep(400);
                                string OcrActiveSoldiers = (OCR.OCRcheck(1160, 922, 140, 34, "0123456789/")); //bsp.: 19/25
                                if(OcrActiveSoldiers.Length <= 4) {
                                    OcrActiveSoldiers = (OCR.OCRcheck(1170, 926, 60, 34, "0123456789/")); //bsp.: 19/25
                                }
                                if(StopAutoMission == false && OcrActiveSoldiers != "0/0" && OcrActiveSoldiers != "17240") {
                                    SoldierPickProcess(); //removes soldier from Array (Soldier/Counter)closes Filter, selects Filterresult-Soldier
                                }
                                else if(StopAutoMission == false) {
                                    if(++ZeroCount == CheckSoldierType.Length && StopAutoMission == false) {
                                        if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                                            log.Debug("AutoMission interrupted by user at: no Soldier found ZeroCount == AmountOfSoldiers");
                                            StopAutoMission = true;
                                            break;
                                        }
                                        log.Debug("No Soldier found for this Counter: " + Counter);
                                        MouseActions.SingleClickAtPosition(dicClickPos[Counter][0], dicClickPos[Counter][1]); //unselect counter
                                        if(!StopAutoMission) { NoSoldierfound(); }
                                    }
                                    MouseActions.SingleClickAtPosition(-1818, 209); //Close Filter
                                    MainWindow.Sleep(300);
                                    MouseActions.DoubleClickAtPosition(-94, 125); //Close SoldierSelectionScreen - if no viable Soldier has been found
                                    MainWindow.Sleep(800);
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
                                    MainWindow.Sleep(1000);
                                    MouseActions.SingleClickAtPosition(-1650, 813); //Select FilteredSoldier
                                    MainWindow.Sleep(2000);
                                    ZeroCount = 0;
                                }

                                void NoSoldierfound() {
                                    if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                                        log.Debug("AutoMission interrupted by user at: NoSoldierfound");
                                        StopAutoMission = true;
                                        return;
                                    }
                                    MouseActions.SingleClickAtPosition(-133, 214); //Aufsteiger +5
                                    MainWindow.Sleep(800);                                               //if Still 0/0
                                    OcrActiveSoldiers = (OCR.OCRcheck(1160, 922, 140, 34, "0123456789/")); //bsp.: 19/25
                                    if(OcrActiveSoldiers.Length <= 4) {
                                        OcrActiveSoldiers = (OCR.OCRcheck(1170, 926, 60, 34, "0123456789/")); //bsp.: 19/25
                                    }
                                    if(StopAutoMission == false && OcrActiveSoldiers != "0/0" && OcrActiveSoldiers != "17240") {
                                        SoldierPickProcess();
                                    }
                                    else if(StopAutoMission == false && ZeroCount == CheckSoldierType.Length) {
                                        MouseActions.SingleClickAtPosition(-348, 217); //Koordination +10
                                        MainWindow.Sleep(300);
                                        MouseActions.SingleClickAtPosition(-332, 417); //Drohne +10
                                        MainWindow.Sleep(300);
                                        MouseActions.SingleClickAtPosition(-774, 398); //5*
                                        MainWindow.Sleep(600);
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
                string OcrMissionsAvailible = OCR.OCRcheck(289, 895, 26, 34); //checks for MissionsAvailible (Missions availible selected)
                string OcrMissionsAvailible2 = OCR.OCRcheck(282, 890, 33, 42); //checks for MissionsAvailible (Missions availible Not selected)
                int ReturnMissionsAvailible = 0;
                if(OcrMissionsAvailible == "3" || OcrMissionsAvailible == "2" || OcrMissionsAvailible == "1") {
                    ReturnMissionsAvailible = Convert.ToInt32(OcrMissionsAvailible);
                }
                else if(OcrMissionsAvailible2 == "3" || OcrMissionsAvailible2 == "2" || OcrMissionsAvailible2 == "1") {
                    ReturnMissionsAvailible = Convert.ToInt32(OcrMissionsAvailible);
                }
                return ReturnMissionsAvailible;
            }

            string checkString(string text) {
                return System.Text.RegularExpressions.Regex.Replace(text, @"[^0-9a-zA-Z _-]", string.Empty);
            }

            string checkDuration() {
                string OcrDuration = OCR.OCRcheck(586, 993, 140, 42); //bsp.:  00:01:00 ,  02:00:00
                return OcrDuration;
            }
            int checkSuccessRate(int targetSuccessRate) {
                string OcrSuccessRate = OCR.OCRcheck(1056, 963, 100, 35); //bsp.:  100% , 130%
                int OcrSuccessRateInt = Convert.ToInt32(OcrSuccessRate.Substring(0, OcrSuccessRate.Length - 1));
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


                if(OcrSuccessRateInt > 49 ) {
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
                    MouseActions.SingleClickAtPosition(dicClickPos["bluedrohne"][0], dicClickPos["bluedrohne"][1]);
                    MainWindow.Sleep(2000);
                }
                if(golddrohne == 1) {
                    MouseActions.SingleClickAtPosition(dicClickPos["golddrohne"][0], dicClickPos["golddrohne"][1]);
                    MainWindow.Sleep(2000);
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
                    selectBooster("successbooster", successbooster);
                }

                string OcrSuccessRate2 = OCR.OCRcheck(1056, 963, 100, 35); //bsp.:  100% , 130%
                int OcrSuccessRateInt2 = Convert.ToInt32(OcrSuccessRate.Substring(0, OcrSuccessRate.Length - 1));
                return OcrSuccessRateInt2;
            }

            void selectBooster(string boosterType, int boosterValue) {
                MainWindow.Sleep(100);
                MouseActions.SingleClickAtPosition(-450, 734); //open GambitMenu
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
                while(XCoordinate == 0 && StopAutoMission == false && i<5) { //Limited to 5 Times
                    if(boosterType != "double") {
                        if(boosterType != "speed") {
                            if(boosterType == "successbooster") {
                                if(boosterValue == 30) {
                                    XCoordinate = FindImageCoordinates(@"C:\temp\success30.jpg");
                                    if(XCoordinate != 0) {
                                        break;
                                    }
                                }
                            }
                        }
                        else { //speedbooster
                            XCoordinate = FindImageCoordinates(@"C:\temp\speed30.jpg");
                            if(XCoordinate != 0) {
                                break;
                            }
                        }
                    }
                    else { //double
                        XCoordinate = FindImageCoordinates(@"C:\temp\double.jpg");
                        if(XCoordinate != 0) {
                            break;
                        }
                    }
                    log.Debug("Round: " + i.ToString() + ", Booster not found");
                    //MainWindow.Sleep(8000);
                    //scroll 3boosters
                    MouseActions.SetCursorPos(-202, 484);
                    MouseActions.LeftMouseDown();
                    int moveToX = -215;
                    while(moveToX > -1805 && StopAutoMission == false) {
                        if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                            log.Debug("AutoMission interrupted by user at: selecting Booster");
                            StopAutoMission = true;
                            return;
                        }
                        moveToX -= 5;
                        MouseActions.SetCursorPos(moveToX, 484);
                        MainWindow.Sleep(22);
                    }
                    MouseActions.LeftMouseUp();
                    i++;
                    //MainWindow.Sleep(4000);
                }
                MouseActions.SingleClickAtPosition(XCoordinate, 690);
            }

            int FindImageCoordinates(string ImageInput) {
                string[] ImgSearchResult = ImgSearch.UseImageSearch(ImageInput, "140");
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
                            while(Score > 2 && StopAutoMission == false && i < 10) {
                                Score = 0;
                                if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                                    log.Debug("AutoMission interrupted by user at: CheckforSoldierScreenSelection");
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
                                    log.Debug("SoldierScreenSelection couldnt be found in time:");
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
                                while(Score > 2 && StopAutoMission == false && i < 10) {
                                    Score = 0;
                                    if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                                        log.Debug("AutoMission interrupted by user at: CheckforSoldierScreenSelection");
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
                                        log.Debug("SoldierScreenSelection couldnt be found in time:");
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
                    if(++i > 25) {
                        log.Debug("SoldierScreenSelection couldnt be found in time:");
                        return -1;
                    }
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

            int CheckforFilteredSoldierReady() { //of the leftmost Soldier
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
                        log.Debug("FilterMenu couldnt be found in time:");
                        return -1; //Timeout
                    }
                }
                return 1; //GreenButton
            }
        }
    }
}
