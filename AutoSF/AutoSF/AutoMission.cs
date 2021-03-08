using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using AutoSF.Helper;
using System.IO;
using System.Data.Common;
using NLog;
using System.Windows.Input;

namespace AutoSF {
    class AutoMission {
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

            Logger logger = LogManager.GetCurrentClassLogger();
            bool Missionfound = false;
            string Missiontype = "";
            string CounterUsed = "";
            string[] CheckCounter = { };
            string[] CheckSoldierType = { };
            bool StopAutoMission = false;
            int bluedrohne = 0;
            int golddrohne = 0;
            int successbooster = 0;
            int targetSuccessRate = 100;
            int ZeroCount = 0;
            Dictionary<string, int[]> dicClickPos = new Dictionary<string, int[]>();
            DataRow[] result = DB.dt.Select("Missionname = '" + OcrMissionname1 + "'");

            
            //if(MissionsAvailible() != 0) { //checks for availible Missions
            //    MouseActions.SingleClickAtPosition(-1423, 939); //Click "Verfügbar"
            //    MainWindow.Sleep(600);
            //    MouseActions.DoubleClickAtPosition(-1544, 518); //click Mission to the left (not avilible Mission is at the right side)
            //    MainWindow.Sleep(800);
                OcrMissionname1 = OCR.OCRcheck(15, 100, 475, 70); //bsp.: Hinweis
                OcrMissionname2 = OCR.OCRcheck(12, 105, 475, 55);
                loadMission();
            //}




            void loadMission() {    
                if(result == null || result.Length == 0) {
                    result = DB.dt.Select("Missionname = '" + OcrMissionname2 + "'");
                    if(result == null || result.Length == 0) { //Mission not found in DB - storing MissionScreenshot named OcrMissionname1_OcrMissionname2
                        Console.WriteLine("MissionNotInDB_" + OcrMissionname1 + "_" + OcrMissionname2 + DateTime.Now.ToString("dd/MM/yyyy HH-mm-ss") + ".jpeg");
                        //    logger.Debug("MissionNotInDB_" + OcrMissionname1 + "_" + OcrMissionname2 + DateTime.Now.ToString("dd/MM/yyyy HH-mm-ss") + ".jpeg");
                        //    using(StreamWriter sw = new StreamWriter(@"MissionLog.txt", true)) {
                        //        sw.WriteLine("MissionNotInDB_" + OcrMissionname1 + "_" + OcrMissionname2 + DateTime.Now.ToString("dd/MM/yyyy HH-mm-ss") + ".jpeg");
                        //    }

                        //    string saveOcrMissionname1 = checkString(OcrMissionname1); //removes special characters
                        //    string saveOcrMissionname2 = checkString(OcrMissionname2);
                        //    if(OcrMissionname1 != saveOcrMissionname1 && OcrMissionname2 != saveOcrMissionname2) {
                        //        OCR.FullsizeImage.Save("MissionNotInDB_" + "BothEDITED" + saveOcrMissionname1 + "_" + saveOcrMissionname2 + DateTime.Now.ToString("dd/MM/yyyy HH-mm-ss") + ".jpeg");
                        //    }
                        //    else if(OcrMissionname1 != saveOcrMissionname1) {
                        //        OCR.FullsizeImage.Save("MissionNotInDB_" + saveOcrMissionname1 + "1stEDITED" + "_" + saveOcrMissionname2 + DateTime.Now.ToString("dd/MM/yyyy HH-mm-ss") + ".jpeg");
                        //    }
                        //    else if(OcrMissionname2 != saveOcrMissionname2) {
                        //        OCR.FullsizeImage.Save("MissionNotInDB_" + saveOcrMissionname1 + "_" + saveOcrMissionname2 + "2ndEDITED" + DateTime.Now.ToString("dd/MM/yyyy HH-mm-ss") + ".jpeg");
                        //    }
                        //    else {
                        //        OCR.FullsizeImage.Save("MissionNotInDB_" + saveOcrMissionname1 + "_" + saveOcrMissionname2 + DateTime.Now.ToString("dd/MM/yyyy HH-mm-ss") + ".jpeg");
                        //    }
                    }
                    else { Missionfound = true; }
                }
                else { Missionfound = true; }


                if(Missionfound) {

                    if((result[0].Field<Int64>("Speed")) == 1) {
                        if((result[0].Field<Int64>("MitBonus")) == 1) { //wie speed jedoch mit 2 drohnen
                            Console.WriteLine("Speed=1, MitBonus=1");
                            Missiontype = "SpeedMitBonus";
                            clickFilter();
                        }
                        else {//1xx% mit Speedbooster (1min) min 1 drohne
                            Console.WriteLine("Speed=1");
                            Missiontype = "Speed";
                            clickFilter();
                        }
                    }
                    else if((result[0].Field<Int64>("Doppelt")) == 1) {
                        if((result[0].Field<Int64>("MitBonus")) == 1) {
                            if((result[0].Field<Int64>("OnlySniper")) == 1) { //130-180% mit verdoppler (keine 10/11* Sturm/Rpg/molo/elite)
                                Console.WriteLine("Doppelt=1, MitBonus=1, OnlySniper");
                                Missiontype = "DoppeltMitBonusOnlySniper";
                                targetSuccessRate = 150;
                                clickFilter();
                            }
                            else { //195% mit verdoppler
                                Console.WriteLine("Doppelt=1, MitBonus=1");
                                Missiontype = "DoppeltMitBonus";
                                targetSuccessRate = 195;
                                clickFilter();
                            }
                        }
                        else { //100% mit verdoppler
                            Console.WriteLine("Doppelt=1");
                            Missiontype = "Doppelt";
                            targetSuccessRate = 100;
                            selectBooster("double",100);
                            clickFilter();
                        }
                    }
                    else if((result[0].Field<Int64>("MitBonus")) == 1) { //195% mit chanceBooster
                        if((result[0].Field<Int64>("OnlySniper")) == 1) { //130-180% mit chanceBooster (keine 10/11* Sturm/Rpg/molo/elite)
                            Console.WriteLine("MitBonus=1, OnlySniper");
                            Missiontype = "MitBonusOnlySniper";
                        }
                        else { //195% mit chanceBooster
                            Console.WriteLine("MitBonus=1");
                            Missiontype = "MitBonus";
                            targetSuccessRate = 195;
                            clickFilter();
                        }
                    }
                    else { //standardMission - 100%
                        Console.WriteLine("Standard 100%");
                        Missiontype = "Standard";
                        targetSuccessRate = 100;
                        clickFilter();
                    }
                }
            }

            void clickFilter() {
                //Adds all COUNTER Columns with a value of one into the array Checkcounter
                foreach(DataRow row in result) {
                    foreach(DataColumn col in row.Table.Columns) {
                        if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                            logger.Debug("AutoMission interrupted by user at Pos ??");
                            StopAutoMission = true;
                        }
                        if(col.Ordinal >= 14 && col.Ordinal <= 29) { //14-29 is the Column range for all Counters
                            if(Convert.ToInt32(row[col.Ordinal]) == 1) {
                                CheckCounter = CheckCounter.Append(col.ColumnName).ToArray();
                            }
                        }
                    }
                }

                

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



                //Adds all SOLDIERTYPE Columns with a value of one into the array CheckSoldierType
                foreach(DataRow row in result) {
                    foreach(DataColumn col in row.Table.Columns) {
                        if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                            logger.Debug("AutoMission interrupted by user at Pos ??");
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
                            logger.Debug("AutoMission interrupted by user at Pos ??");
                            StopAutoMission = true;
                            break;
                        }
                        if(StopAutoMission == false) {
                            FilterSelection(Soldier);
                        }
                    }
                }
                if (100 <= checkSuccessRate(targetSuccessRate) && StopAutoMission == false ) {
                    //checkGold();
                }

                void FilterSelection(string currentSoldier) {
                    if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                        logger.Debug("AutoMission interrupted by user at: Setting Counter");
                        StopAutoMission = true;
                        return;
                    }
                    MainWindow.Sleep(3000);
                    if(StopAutoMission == false && AmountOfSoldiers == 1) {
                        MouseActions.DoubleClickAtPosition(-836, 350); //Opens SolidierSelection
                    }
                    else if(StopAutoMission == false && AmountOfSoldiers == 2) {
                        if(StopAutoMission == false && CheckSoldierType.Length == 2) {
                            MouseActions.DoubleClickAtPosition(-923, 350);
                        }
                        else {
                            MouseActions.DoubleClickAtPosition(-580, 350);
                        }
                    }
                    else if(StopAutoMission == false && AmountOfSoldiers == 3) {
                        if(StopAutoMission == false && CheckSoldierType.Length == 3) {
                            MouseActions.DoubleClickAtPosition(-1096, 350);
                        }
                        else if(StopAutoMission == false && CheckSoldierType.Length == 2) {
                            MouseActions.DoubleClickAtPosition(-749, 350);
                        }
                        else {
                            MouseActions.DoubleClickAtPosition(-419, 350);
                        }
                    }
                    else if(StopAutoMission == false && AmountOfSoldiers == 4) {
                        if(StopAutoMission == false && CheckSoldierType.Length == 4) {
                            MouseActions.DoubleClickAtPosition(-1251, 350);
                        }
                        else if(StopAutoMission == false && CheckSoldierType.Length == 3) {
                            MouseActions.DoubleClickAtPosition(-913, 350);
                        }
                        else if(StopAutoMission == false && CheckSoldierType.Length == 2) {
                            MouseActions.DoubleClickAtPosition(-632, 350);
                        }
                        else {
                            MouseActions.DoubleClickAtPosition(-255, 350);
                        }
                    }
                    MainWindow.Sleep(3000);

                    if(StopAutoMission == false && "Sniper" == currentSoldier) {
                        MouseActions.DoubleClickAtPosition(dicClickPos["Sniper"][0], dicClickPos["Sniper"][1]);
                    }
                    if(StopAutoMission == false && "Sturm" == currentSoldier) {
                        MouseActions.DoubleClickAtPosition(dicClickPos["Sturm"][0], dicClickPos["Sturm"][1]);
                    }
                    if(StopAutoMission == false && "RPG" == currentSoldier) {
                        MouseActions.DoubleClickAtPosition(dicClickPos["RPG"][0], dicClickPos["RPG"][1]);
                    }
                    if(StopAutoMission == false && "Molotow" == currentSoldier) {
                        MouseActions.DoubleClickAtPosition(dicClickPos["Molotow"][0], dicClickPos["Molotow"][1]);
                    }
                    if(StopAutoMission == false && "Elite" == currentSoldier) {
                        MouseActions.DoubleClickAtPosition(dicClickPos["Elite"][0], dicClickPos["Elite"][1]);
                    }
                    if(StopAutoMission == false && "Beschuetzer" == currentSoldier) {
                        MouseActions.DoubleClickAtPosition(dicClickPos["Beschuetzer"][0], dicClickPos["Beschuetzer"][1]);
                    }
                    if(StopAutoMission == false && "Attentaeter" == currentSoldier) {
                        MouseActions.DoubleClickAtPosition(dicClickPos["Attentaeter"][0], dicClickPos["Attentaeter"][1]);
                    }
                    if(StopAutoMission == false && "Suppressor" == currentSoldier) {
                        MouseActions.DoubleClickAtPosition(dicClickPos["Suppressor"][0], dicClickPos["Suppressor"][1]);
                    }
                    MainWindow.Sleep(3000);

                    //MouseActions.DoubleClickAtPosition(-117, 923); //Opens FilterView
                    MouseActions.SingleClickAtPosition(-117, 923);
                    MainWindow.Sleep(2000);
                    MouseActions.SingleClickAtPosition(dicClickPos["verfügbar"][0], dicClickPos["verfügbar"][1]);
                    MainWindow.Sleep(500);
                    if(StopAutoMission == false && Missiontype == "SpeedMitBonus") {
                        checkSuccessRate(2);
                    }
                    else if(StopAutoMission == false && Missiontype == "Speed") {

                    }
                    else if(StopAutoMission == false && Missiontype == "DoppeltMitBonusOnlySniper") {
                    }
                    else if(StopAutoMission == false && Missiontype == "DoppeltMitBonus") {
                        MouseActions.SingleClickAtPosition(dicClickPos["Stern10"][0], dicClickPos["Stern10"][1]);
                        MainWindow.Sleep(500);
                        MouseActions.SingleClickAtPosition(dicClickPos["Stern11"][0], dicClickPos["Stern11"][1]);
                        MainWindow.Sleep(500);
                        MouseActions.SingleClickAtPosition(-335, 211); //Bonus Kordination +10
                        MainWindow.Sleep(500);
                        if(CheckSoldierType.Length == 1 && currentSoldier == "Elite" ) {
                            MouseActions.SingleClickAtPosition(-1818, 209); //Close Filter
                            MainWindow.Sleep(1000);
                            MouseActions.DoubleClickAtPosition(-94, 125); //Close SoldierSelectionScreen - if no viable Soldier has been found
                            MainWindow.Sleep(1500);

                            if(checkSuccessRate(195) == 160) {
                                MouseActions.DoubleClickAtPosition(dicClickPos["Elite"][0], dicClickPos["Elite"][1]);
                                MainWindow.Sleep(1500);
                                MouseActions.SingleClickAtPosition(dicClickPos["Stern6"][0], dicClickPos["Stern6"][1]);
                                MainWindow.Sleep(500);
                                MouseActions.SingleClickAtPosition(dicClickPos["RSVIP"][0], dicClickPos["RSVIP"][1]);
                            }
                        }

                        string[] OcrActiveSoldiers = (OCR.OCRcheck(1160, 922, 140, 34, "0123456789/")).Split('/'); //bsp.: 19/25
                        if(OcrActiveSoldiers[0].Length > 4) {
                            OcrActiveSoldiers = (OCR.OCRcheck(1170, 926, 60, 34, "0123456789/")).Split('/'); //bsp.: 19/25
                        }
                        if(StopAutoMission == false && (OcrActiveSoldiers[0] + "/" + OcrActiveSoldiers[1]) != "0/0") {
                            SoldierPickProcessDopMitBon();
                        }
                        else { 
                            Console.WriteLine("No Soldier found that meets the requirements for " + result[0].Field<Int64>("Missionname") + ", " + Missiontype ); 
                        }

                        void SoldierPickProcessDopMitBon() {
                            //CheckCounter = CheckCounter.Where(e => e != Counter).ToArray(); //creates a new Array without value Counter
                            CheckSoldierType = CheckSoldierType.Where(e => e != currentSoldier).ToArray();
                            MouseActions.SingleClickAtPosition(-1818, 209); //Close Filter
                            MainWindow.Sleep(1000);
                            MouseActions.SingleClickAtPosition(-1650, 813); //Select FilteredSoldier
                            MainWindow.Sleep(2000);
                        }
                    }
                    else if(StopAutoMission == false && Missiontype == "MitBonusOnlySniper") {

                    }
                    else if(StopAutoMission == false && Missiontype == "MitBonus") {

                    }
                    else if(StopAutoMission == false && (Missiontype == "Standard" || Missiontype == "Doppelt")) {

                        if(StopAutoMission == false && (result[0].Field<Int64>("Difficulty")) == 5) {
                            MouseActions.SingleClickAtPosition(dicClickPos["Stern6"][0], dicClickPos["Stern6"][1]);
                            MainWindow.Sleep(600);
                        }
                        else if(StopAutoMission == false && (result[0].Field<Int64>("Difficulty")) == 4) {
                            MouseActions.DoubleClickAtPosition(dicClickPos["Stern5"][0], dicClickPos["Stern5"][1]);
                            MainWindow.Sleep(600);
                        }

                        foreach(string Counter in CheckCounter) {
                            if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                                logger.Debug("AutoMission interrupted by user at: Setting Counter");
                                StopAutoMission = true;
                                break;
                            }
                            MouseActions.SingleClickAtPosition(dicClickPos[Counter][0], dicClickPos[Counter][1]);
                            Console.WriteLine("Click Filter " + Counter + " at " + dicClickPos[Counter][0].ToString() + "," + dicClickPos[Counter][1].ToString());
                            MainWindow.Sleep(600);
                            string OcrActiveSoldiers = (OCR.OCRcheck(1160, 922, 140, 34, "0123456789/")); //.Split('/'); //bsp.: 19/25
                            if( OcrActiveSoldiers.Length <= 4) {
                                OcrActiveSoldiers = (OCR.OCRcheck(1170, 926, 60, 34, "0123456789/")); //.Split('/'); //bsp.: 19/25
                            }
                            if(StopAutoMission == false && OcrActiveSoldiers != "0/0") {
                                //If Successfully assigned, the CheckCounter and the currentSoldier get removed out of their Arrays
                                SoldierPickProcess(); //removes soldier from Array (Soldier/Counter)closes Filter, selects Filterresult-Soldier

                            }
                            else {
                                if(++ZeroCount == CheckSoldierType.Length && StopAutoMission == false) {
                                    if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                                        logger.Debug("AutoMission interrupted by user at: no Soldier found ZeroCount == AmountOfSoldiers");
                                        StopAutoMission = true;
                                        break;
                                    }
                                    Console.WriteLine("No Soldier found for this Counter: " + Counter);
                                    MouseActions.SingleClickAtPosition(dicClickPos[Counter][0], dicClickPos[Counter][1]); //unselect counter
                                    NoSoldierfound();
                                    //if(StopAutoMission == false && "Sniper" == currentSoldier) {
                                    //    NoSoldierfound();
                                    //}
                                    //if(StopAutoMission == false && "Sturm" == currentSoldier) {
                                    //    //MouseActions.DoubleClickAtPosition(-133, 214);
                                    //    NoSoldierfound();
                                    //}
                                    //if(StopAutoMission == false && "RPG" == currentSoldier) {
                                    //    //MouseActions.DoubleClickAtPosition(dicClickPos["RPG"][0], dicClickPos["RPG"][1]);
                                    //    NoSoldierfound();
                                    //}
                                    //if(StopAutoMission == false && "Molotow" == currentSoldier) {
                                    //    //MouseActions.DoubleClickAtPosition(dicClickPos["Molotow"][0], dicClickPos["Molotow"][1]);
                                    //    NoSoldierfound();
                                    //}
                                    //if(StopAutoMission == false && "Elite" == currentSoldier) {
                                    //    //MouseActions.DoubleClickAtPosition(dicClickPos["Elite"][0], dicClickPos["Elite"][1]);
                                    //    NoSoldierfound();
                                    //}
                                    //if(StopAutoMission == false && "Beschuetzer" == currentSoldier) {
                                    //    //MouseActions.DoubleClickAtPosition(dicClickPos["Beschuetzer"][0], dicClickPos["Beschuetzer"][1]);
                                    //    NoSoldierfound();
                                    //}
                                    //if(StopAutoMission == false && "Attentaeter" == currentSoldier) {
                                    //    //MouseActions.DoubleClickAtPosition(dicClickPos["Attentaeter"][0], dicClickPos["Attentaeter"][1]);
                                    //    NoSoldierfound();
                                    //}
                                    //if(StopAutoMission == false && "Suppressor" == currentSoldier) {
                                    //    //MouseActions.DoubleClickAtPosition(dicClickPos["Suppressor"][0], dicClickPos["Suppressor"][1]);
                                    //    NoSoldierfound();
                                    //}
                                }
                                MouseActions.SingleClickAtPosition(-1818, 209); //Close Filter
                                MainWindow.Sleep(1000);
                                MouseActions.DoubleClickAtPosition(-94, 125); //Close SoldierSelectionScreen - if no viable Soldier has been found
                                MainWindow.Sleep(2000);
                            }
                            void SoldierPickProcess() {
                                if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                                    logger.Debug("AutoMission interrupted by user at: Setting SoldierPickProcess");
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
                                    logger.Debug("AutoMission interrupted by user at: NoSoldierfound");
                                    StopAutoMission = true;
                                    return;
                                }
                                MouseActions.SingleClickAtPosition(-133, 214); //Aufsteiger +5
                                MainWindow.Sleep(800);                                               //if Still 0/0
                                OcrActiveSoldiers = (OCR.OCRcheck(1160, 922, 140, 34, "0123456789/")); //bsp.: 19/25
                                if(OcrActiveSoldiers.Length <= 4) {
                                    OcrActiveSoldiers = (OCR.OCRcheck(1170, 926, 60, 34, "0123456789/")); //bsp.: 19/25
                                }
                                if(StopAutoMission == false && OcrActiveSoldiers != "0/0") {
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
                switch(OcrSuccessRateInt) {
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


                if(OcrSuccessRateInt > 49 && OcrSuccessRateInt < 100) {
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
                if(successbooster > 0) {
                    selectBooster("successbooster", successbooster);
                }
                if(Missiontype.Contains("Doppelt") || Missiontype.Contains("Speed")) {
                    successbooster = 1;
                    selectBooster("double", successbooster);
                }
                if(Missiontype.Contains("Speed")) {
                    successbooster = 1;
                    selectBooster("speed", successbooster);
                }

                string OcrSuccessRate2 = OCR.OCRcheck(1056, 963, 100, 35); //bsp.:  100% , 130%
                int OcrSuccessRateInt2 = Convert.ToInt32(OcrSuccessRate.Substring(0, OcrSuccessRate.Length - 1));
                return OcrSuccessRateInt2;
            }

            void selectBooster(string boosterType, int boosterValue) {
                MainWindow.Sleep(100);
                MouseActions.SingleClickAtPosition(-450, 734); //open GambitMenu
                MainWindow.Sleep(700);

                int XCoordinate = 0;
                int i = 0;
                while(XCoordinate == 0) {
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
                    MainWindow.Sleep(3000);
                    Console.WriteLine("Round: " +  i.ToString() + ", Booster not found");
                    //scroll 3boosters
                    MouseActions.SetCursorPos(-202, 484);
                    MouseActions.LeftMouseDown();
                    int moveToX = -215;
                    while(moveToX > -1805) {
                        moveToX -= 5;
                        MouseActions.SetCursorPos(moveToX, 484);
                        MainWindow.Sleep(22);
                    }
                    MouseActions.LeftMouseUp();
                    i++;
                    MainWindow.Sleep(8000);
                }
                MouseActions.SingleClickAtPosition(XCoordinate, 690);
            }

            int FindImageCoordinates(string ImageInput) {
                if(ImgSearch.UseImageSearch(ImageInput, "100") != null) {
                    string[] ImgSearchResult = ImgSearch.UseImageSearch(ImageInput, "100");
                    Console.WriteLine("click: " + ImgSearchResult[1] + ", 690");
                    return Convert.ToInt32(ImgSearchResult[1]);
                }
                return 0;
            }

            void checkGold() {
                string OcrCurrentGold = OCR.OCRcheck(1230, 34, 113, 32); //bsp.: 10000k
                string OcrMissionCost = OCR.OCRcheck(1647, 977, 123, 46); //bsp.: 2500k

                if(OcrCurrentGold.Contains("k")) {
                    OcrCurrentGold = OcrCurrentGold.Substring(0, (OcrCurrentGold.Length - 1));
                    if(Convert.ToInt32(OcrCurrentGold) >= Convert.ToInt32(OcrMissionCost.Substring(0, (OcrMissionCost.Length - 1)))) {
                        //Continue
                    }
                    else {
                        //getMoreGold
                    }
                }
                else {
                    //getMoreGold
                }
            }
        }
    }
}
