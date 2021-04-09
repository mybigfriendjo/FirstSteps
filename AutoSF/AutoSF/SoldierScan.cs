using System;
using System.Collections.Generic;
using AutoSF.Helper;
using NLog;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Threading;
using System.Diagnostics;
using Microsoft.VisualBasic;

namespace AutoSF {
    class SoldierScan {


        private static readonly Logger log = LogManager.GetCurrentClassLogger();
        static bool StopSoldierScan = false;

        public static void StartSoldierScan() {

            //------SQL Query to find Solderiers with wrong Amount---------
            //SELECT* FROM soldaten WHERE anzahl NOT like "%/%" UNION
            //SELECT* FROM soldaten WHERE anzahl like "/%" UNION
            //SELECT* FROM soldaten WHERE anzahl like "%/" UNION
            //SELECT* FROM soldaten WHERE length(anzahl) < 3 UNION
            //SELECT* From soldaten WHERE length(anzahl) = 3 AND substr(anzahl,1,1) > substr(anzahl, -1, 1) UNION
            //SELECT* From soldaten WHERE length(anzahl) = 5 AND substr(anzahl,1,2) > substr(anzahl, -2, 2);

            //-----regex (to filter tables in DB Browser)
            //   / ^/\d +|\d +/$/ findet / x und x/
            //   / ^\d +$/ findet alle die kein / enthalten
            //   / ^[2 - 9] / 1$/

            Dictionary<string, int[]> dicClickPosTyp = new Dictionary<string, int[]>();
            dicClickPosTyp.Add("Sniper", new int[] { -1555, 230 });
            dicClickPosTyp.Add("Sturm", new int[] { -1239, 230 });
            dicClickPosTyp.Add("RPG", new int[] { -1092, 230 });
            dicClickPosTyp.Add("Molotow", new int[] { -951, 230 });
            dicClickPosTyp.Add("Elite", new int[] { -795, 230 });
            dicClickPosTyp.Add("Beschuetzer", new int[] { -649, 230 });
            dicClickPosTyp.Add("Attentaeter", new int[] { -492, 230 });
            dicClickPosTyp.Add("Suppressor", new int[] { -358, 230 });

            Dictionary<string, int[]> dicClickPosStufe = new Dictionary<string, int[]>();
            //dicClickPosStufe.Add("Stern1", new int[] { -1285, 400 });
            //dicClickPosStufe.Add("Stern2", new int[] { -1185, 400 });
            dicClickPosStufe.Add("Stern3", new int[] { -1085, 400 });
            dicClickPosStufe.Add("Stern4", new int[] { -985, 400 });
            dicClickPosStufe.Add("Stern5", new int[] { -885, 400 });
            dicClickPosStufe.Add("Stern6", new int[] { -1285, 500 });
            dicClickPosStufe.Add("Stern7", new int[] { -1185, 500 });
            dicClickPosStufe.Add("Stern8", new int[] { -1085, 500 });
            dicClickPosStufe.Add("Stern9", new int[] { -985, 500 });
            dicClickPosStufe.Add("Stern10", new int[] { -885, 500 });
            dicClickPosStufe.Add("Stern11", new int[] { -1285, 600 });
            //dicClickPosStufe.Add("Stern12", new int[] { -1185, 600 });
            /////////////-pre "Spezial Update"-------
            ////dicClickPosStufe.Add("Stern1", new int[] { -1185, 400 });
            ////dicClickPosStufe.Add("Stern2", new int[] { -1085, 400 });
            //dicClickPosStufe.Add("Stern3", new int[] { -985, 400 });
            //dicClickPosStufe.Add("Stern4", new int[] { -885, 400 });
            //dicClickPosStufe.Add("Stern5", new int[] { -785, 400 });
            //dicClickPosStufe.Add("Stern6", new int[] { -1185, 500 });
            //dicClickPosStufe.Add("Stern7", new int[] { -1085, 500 });
            //dicClickPosStufe.Add("Stern8", new int[] { -985, 500 });
            //dicClickPosStufe.Add("Stern9", new int[] { -885, 500 });
            //dicClickPosStufe.Add("Stern10", new int[] { -785, 500 });
            ////dicClickPosStufe.Add("Stern11", new int[] { -1185, 600 });
            ////dicClickPosStufe.Add("Stern12", new int[] { -1085, 600 });

            Dictionary<string, int[]> dicClickPosKonter = new Dictionary<string, int[]>();
            dicClickPosKonter.Add("RSKommunikation", new int[] { -720, 600 });
            dicClickPosKonter.Add("RSToedlichSpezial", new int[] { -620, 600 });
            dicClickPosKonter.Add("RSRadar", new int[] { -520, 600 });
            dicClickPosKonter.Add("RSBiologischeGefahrSpezial", new int[] { -420, 600 });
            dicClickPosKonter.Add("RSBoot", new int[] { -320, 600 });
            dicClickPosKonter.Add("RSJetpack", new int[] { -220, 600 });
            dicClickPosKonter.Add("RSTarnung", new int[] { -120, 600 });
            dicClickPosKonter.Add("RSVerkleidung", new int[] { -720, 700 });
            dicClickPosKonter.Add("RSHelikopter", new int[] { -620, 700 });
            dicClickPosKonter.Add("RSBootSpezial", new int[] { -520, 700 });
            dicClickPosKonter.Add("RSToedlich", new int[] { -420, 700 });
            dicClickPosKonter.Add("RSGeiseln", new int[] { -320, 700 });
            dicClickPosKonter.Add("RSVIP", new int[] { -220, 700 });
            dicClickPosKonter.Add("RSSprengstoffe", new int[] { -120, 700 });
            dicClickPosKonter.Add("RSTaktiken", new int[] { -720, 800 });
            dicClickPosKonter.Add("RSBegrenzteMunitionSpezial", new int[] { -620, 800 });
            dicClickPosKonter.Add("RSAufklaerung", new int[] { -520, 800 });
            dicClickPosKonter.Add("RSBiologischeGefahr", new int[] { -420, 800 });
            dicClickPosKonter.Add("RSFahrzeug", new int[] { -320, 800 });
            dicClickPosKonter.Add("RSKommunikationSpezial", new int[] { -220, 800 });
            dicClickPosKonter.Add("RSBegrenzteMunition", new int[] { -120, 800 });
            //dicClickPosKonter.Add("OnlySniper", new int[] { }); //Unknown................
            /////////////-pre "Spezial Update"-------
            //dicClickPosKonter.Add("RSKommunikation", new int[] { -620, 600 });
            //dicClickPosKonter.Add("RSRadar", new int[] { -520, 600 });
            //dicClickPosKonter.Add("RSBoot", new int[] { -420, 600 });
            //dicClickPosKonter.Add("RSJetpack", new int[] { -320, 600 });
            //dicClickPosKonter.Add("RSTarnung", new int[] { -220, 600 });
            //dicClickPosKonter.Add("RSVerkleidung", new int[] { -120, 600 });
            //dicClickPosKonter.Add("RSHelikopter", new int[] { -620, 700 });
            //dicClickPosKonter.Add("RSGeiseln", new int[] { -520, 700 });
            //dicClickPosKonter.Add("RSTaktiken", new int[] { -420, 700 });
            //dicClickPosKonter.Add("RSVIP", new int[] { -320, 700 });
            //dicClickPosKonter.Add("RSSprengstoffe", new int[] { -220, 700 });
            //dicClickPosKonter.Add("RSAufklaerung", new int[] { -120, 700 });
            //dicClickPosKonter.Add("RSBiologischeGefahr", new int[] { -620, 800 });
            //dicClickPosKonter.Add("RSFahrzeug", new int[] { -520, 800 });
            //dicClickPosKonter.Add("RSToedlich", new int[] { -420, 800 });
            //dicClickPosKonter.Add("RSBegrenzteMunition", new int[] { -320, 800 });

            Dictionary<string, int[]> dicClickPosBonus = new Dictionary<string, int[]>();
            dicClickPosBonus.Add("BSSchnell", new int[] { -545, 419 }); //20 % speed
            dicClickPosBonus.Add("BSMechaniker", new int[] { -745, 219 }); //20 %speed(bei aktiver drohne) -645, 219
            dicClickPosBonus.Add("BSZeitgewinn", new int[] { -445, 419 }); //10 %speed
            dicClickPosBonus.Add("BSKoordination", new int[] { -445, 219 }); //+10%winrate
            dicClickPosBonus.Add("BSDrohne", new int[] { -745, 419 }); // +10%winrate (bei aktiver drohne)
            dicClickPosBonus.Add("BSImprovisation", new int[] { -345, 319 }); //+5% kleinergleich 2st
            dicClickPosBonus.Add("BSAufsteiger", new int[] { -245, 219 }); //+5% größergleich 4st

            /////////////-pre "Spezial Update"-------
            //dicClickPosBonus.Add("BSSchnell", new int[] { -145, 419 }); //20 % speed
            //dicClickPosBonus.Add("BSMechaniker", new int[] { -645, 219 }); //20 %speed(bei aktiver drohne) -645, 219
            //dicClickPosBonus.Add("BSZeitgewinn", new int[] { -445, 419 }); //10 %speed
            //dicClickPosBonus.Add("BSKoordination", new int[] { -345, 219 }); //+10%winrate
            //dicClickPosBonus.Add("BSDrohne", new int[] { -345, 419 }); // +10%winrate (bei aktiver drohne)
            //dicClickPosBonus.Add("BSImprovisation", new int[] { -245, 319 }); //+5% kleinergleich 2st
            //dicClickPosBonus.Add("BSAufsteiger", new int[] { -145, 219 }); //+5% größergleich 4st

            Dictionary<string, int[]> dicClickPosBonusUnimportant = new Dictionary<string, int[]>();
            dicClickPosBonusUnimportant.Add("BSGepanzert", new int[] { -645, 219 });
            dicClickPosBonusUnimportant.Add("BSSchwere Rüstung", new int[] { -545, 219 });
            dicClickPosBonusUnimportant.Add("BSAbsicherung", new int[] { -345, 219 }); //immun gegen klauen
            dicClickPosBonusUnimportant.Add("BSGeschäftemacher", new int[] { -745, 319 });
            dicClickPosBonusUnimportant.Add("BSÜberlebenskünstler", new int[] { -645, 319 });
            dicClickPosBonusUnimportant.Add("BSÜberlebensspezialist", new int[] { -545, 319 });
            dicClickPosBonusUnimportant.Add("BSGlück", new int[] { -445, 319 });
            dicClickPosBonusUnimportant.Add("BSRabatt", new int[] { -145, 219 });
            dicClickPosBonusUnimportant.Add("BSLehrer", new int[] { -145, 319 });
            dicClickPosBonusUnimportant.Add("BSUnabhängig", new int[] { -245, 319 }); //+5% solo
            dicClickPosBonusUnimportant.Add("BSTechnik", new int[] { -645, 419 });
            /////////////-pre "Spezial Update"-------
            //dicClickPosBonusUnimportant.Add("BSGepanzert", new int[] { -545, 219 });
            //dicClickPosBonusUnimportant.Add("BSSchwere Rüstung", new int[] { -445, 219 });
            //dicClickPosBonusUnimportant.Add("BSAbsicherung", new int[] { -245, 219 }); //immun gegen klauen
            //dicClickPosBonusUnimportant.Add("BSGeschäftemacher", new int[] { -645, 319 });
            //dicClickPosBonusUnimportant.Add("BSÜberlebenskünstler", new int[] { -545, 319 });
            //dicClickPosBonusUnimportant.Add("BSÜberlebensspezialist", new int[] { -445, 319 });
            //dicClickPosBonusUnimportant.Add("BSGlück", new int[] { -345, 319 });
            //dicClickPosBonusUnimportant.Add("BSRabatt", new int[] { -145, 319 });
            //dicClickPosBonusUnimportant.Add("BSLehrer", new int[] { -645, 419 });
            //dicClickPosBonusUnimportant.Add("BSUnabhängig", new int[] { -545, 419 }); //+5% solo
            //dicClickPosBonusUnimportant.Add("BSTechnik", new int[] { -245, 419 });

            WinSystem.WindowActivate(false); //Game won't be started if not allready running
            MainWindow.Sleep(3000); //Time to get mouse out of VM ;) -> alternativ send Strg+Alt if host = VM

            if(StopSoldierScan == true) { return; }

            int Score = 0;
            if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                log.Debug("AutoMission interrupted by user at: FirstCheckforFilterMenu");
                StopSoldierScan = true;
                return;
            }
            if(PixelFinder.SearchStaticPixel(1773, 925, "#3A9F64")) { Score++; } //FilterButtonGreen
            if(PixelFinder.SearchStaticPixel(1826, 124, "#27597E")) { Score++; } //Grey X behind FilterWindow
            if(PixelFinder.SearchStaticPixel(727, 114, "#FFFFFF")) { Score++; } //FilterWindowText Filtern >F<ilternach Verfü.
            LoopGarbageCollector.ClearGarbageCollector();
            if(Score >= 2) {
                log.Debug("FirstFilterMenu found - start Filtering");
            }
            else {
                log.Debug("FirstFilterMenu couldnt be found. Please Navigate into a mission -> filter");
                return;
            }
            int delayInMS = 200;
            delayInMS = Convert.ToInt32(Interaction.InputBox("Enter Scan Delay in milliseconds.", "Scan Delay", "200"));
            void delay() {
                MainWindow.Sleep(delayInMS);
            }

            Stopwatch s = Stopwatch.StartNew();
            log.Debug("Stopwatch started. Beginning with foreach");

            int i = 0;
            foreach(KeyValuePair<string, int[]> typ in dicClickPosTyp) {
                //log.Debug("foreach typ: " + typ.Key);
                MouseActions.SingleClickAtPosition(-1774, 220); //closes Filter
                delay();
                MouseActions.SingleClickAtPosition(dicClickPosTyp[typ.Key][0], dicClickPosTyp[typ.Key][1]); //selects typ
                delay();
                MouseActions.SingleClickAtPosition(-117, 923); //click FilterMenu

                Score = 0;
                while(Score < 2 && StopSoldierScan == false) {
                    Score = 0;
                    if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                        log.Debug("SoldierScan interrupted by user at: SecondCheckforFilterMenu");
                        StopSoldierScan = true;
                        return;
                    }
                    if(PixelFinder.SearchStaticPixel(1773, 925, "#3A9F64")) { Score++; } //FilterButtonGreen
                    if(PixelFinder.SearchStaticPixel(1826, 124, "#27597E")) { Score++; } //Grey X behind FilterWindow
                    if(PixelFinder.SearchStaticPixel(727, 114, "#FFFFFF")) { Score++; } //FilterWindowText Filtern >F<ilternach Verfü.
                    LoopGarbageCollector.ClearGarbageCollector();
                    if(Score >= 2) {
                        log.Debug("SecondFilterMenu found - continue Filtering");
                    }
                    if(++i > 25) {
                        log.Debug("SecondFilterMenu couldnt be found in time. Current SolderType: " + typ.Key);
                        return;
                    }
                }
                foreach(var stufe in dicClickPosStufe) {
                    //log.Debug("foreach stufe: " + stufe.Key);
                    MouseActions.SingleClickAtPosition(dicClickPosStufe[stufe.Key][0], dicClickPosStufe[stufe.Key][1]);
                    delay();
                    foreach(var konter in dicClickPosKonter) {
                        //log.Debug("foreach konter: " + konter.Key);
                        MouseActions.SingleClickAtPosition(dicClickPosKonter[konter.Key][0], dicClickPosKonter[konter.Key][1]);
                        delay();

                        if(stufe.Key != "Stern3") {
                            foreach(var bonus in dicClickPosBonus) {
                                //log.Debug("foreach bonus: " + bonus.Key);
                                if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                                    log.Debug("SoldierScan interrupted by user at Click Bonus: " + "stufe: " + stufe.Key + " typ: " + typ.Key + " konter: " + konter.Key + " bonus: " + bonus.Key);
                                    StopSoldierScan = true;
                                    return;
                                }

                                MouseActions.SingleClickAtPosition(dicClickPosBonus[bonus.Key][0], dicClickPosBonus[bonus.Key][1]);
                                delay();
                                //log.Debug("start OCR:");
                                string OcrActiveSoldiers = (OCR.OCRcheck(1160, 922, 140, 34, "0123456789/")); //bsp.: 19/25
                                //log.Debug("OcrActiveSoldiers:" + OcrActiveSoldiers);
                                if(OcrActiveSoldiers != "17240") {
                                    if(OcrActiveSoldiers.Length <= 4 && StopSoldierScan == false) {
                                        log.Debug("Conditions for second Ocr triggered");
                                        OcrActiveSoldiers = (OCR.OCRcheck(1170, 926, 60, 34, "0123456789/")); //bsp.: 19/25
                                        log.Debug("Second OcrActiveSoldiers:" + OcrActiveSoldiers);
                                    }
                                    log.Debug("stufe: " + stufe.Key + " typ: " + typ.Key + " konter: " + konter.Key + " bonus: " + bonus.Key); //+ " Anzahl: " + OcrActiveSoldiers);
                                    if(OcrActiveSoldiers != "0/0" && OcrActiveSoldiers != null && OcrActiveSoldiers != "") {
                                        CacheDb.InsertScanSoldier(stufe.Key, typ.Key, konter.Key, bonus.Key, OcrActiveSoldiers);
                                    }
                                }
                                MouseActions.SingleClickAtPosition(dicClickPosBonus[bonus.Key][0], dicClickPosBonus[bonus.Key][1]);
                                delay();
                            }

                            foreach(var bonusUnimportant in dicClickPosBonusUnimportant) { //activates every BonusUnimportant
                                //log.Debug("foreach bonus: " + bonus.Key);
                                if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                                    log.Debug("SoldierScan interrupted by user at Click Bonus: " + "stufe: " + stufe.Key + " typ: " + typ.Key + " konter: " + konter.Key + " bonus: " + bonusUnimportant.Key);
                                    StopSoldierScan = true;
                                    return;
                                }
                                MouseActions.SingleClickAtPosition(dicClickPosBonusUnimportant[bonusUnimportant.Key][0], dicClickPosBonusUnimportant[bonusUnimportant.Key][1]);
                                delay();
                            }

                            //log.Debug("start OCR:");
                            string OcrActiveSoldiers2 = (OCR.OCRcheck(1160, 922, 140, 34, "0123456789/")); //bsp.: 19/25
                            //log.Debug("OcrActiveSoldiers2:" + OcrActiveSoldiers2);
                            if(OcrActiveSoldiers2 != "17240") {
                                if(OcrActiveSoldiers2.Length <= 4 && StopSoldierScan == false) {
                                    log.Debug("Conditions for second Ocr triggered");
                                    OcrActiveSoldiers2 = (OCR.OCRcheck(1170, 926, 60, 34, "0123456789/")); //bsp.: 19/25
                                    log.Debug("Second OcrActiveSoldiers2:" + OcrActiveSoldiers2);
                                }
                                log.Debug("stufe: " + stufe.Key + " typ: " + typ.Key + " konter: " + konter.Key + " bonus: " + "bonusUnimportant"); //+ " Anzahl: " + OcrActiveSoldiers2);
                                if(OcrActiveSoldiers2 != "0/0" && OcrActiveSoldiers2 != null && OcrActiveSoldiers2 != "") {
                                    CacheDb.InsertScanSoldier(stufe.Key, typ.Key, konter.Key, "bonusUnimportant", OcrActiveSoldiers2);
                                }
                            }

                            foreach(var bonusUnimportant in dicClickPosBonusUnimportant) { //deactivates every BonusUnimportant
                                //log.Debug("foreach bonus: " + bonus.Key);
                                if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.NumPad0)) {
                                    log.Debug("SoldierScan interrupted by user at Click Bonus: " + "stufe: " + stufe.Key + " typ: " + typ.Key + " konter: " + konter.Key + " bonusUnimportant: " + bonusUnimportant.Key);
                                    StopSoldierScan = true;
                                    return;
                                }
                                MouseActions.SingleClickAtPosition(dicClickPosBonusUnimportant[bonusUnimportant.Key][0], dicClickPosBonusUnimportant[bonusUnimportant.Key][1]);
                                delay();
                            }
                        }
                        else if(stufe.Key == "Stern3") {
                            string OcrActiveSoldiers2 = (OCR.OCRcheck(1160, 922, 140, 34, "0123456789/")); //bsp.: 19/25
                            //log.Debug("OcrActiveSoldiers2:" + OcrActiveSoldiers2);
                            if(OcrActiveSoldiers2 != "17240") {
                                if(OcrActiveSoldiers2.Length <= 4 && StopSoldierScan == false) {
                                    log.Debug("Conditions for second Ocr triggered");
                                    OcrActiveSoldiers2 = (OCR.OCRcheck(1170, 926, 60, 34, "0123456789/")); //bsp.: 19/25
                                    log.Debug("Second OcrActiveSoldiers2:" + OcrActiveSoldiers2);
                                }
                                log.Debug("stufe: " + stufe.Key + " typ: " + typ.Key + " konter: " + konter.Key); //+ " Anzahl: " + OcrActiveSoldiers2);
                                if(OcrActiveSoldiers2 != "0/0" && OcrActiveSoldiers2 != null && OcrActiveSoldiers2 != "") {
                                    CacheDb.InsertScanSoldier(stufe.Key, typ.Key, konter.Key, "bonusInactive", OcrActiveSoldiers2);
                                }
                            }
                        }

                        MouseActions.SingleClickAtPosition(dicClickPosKonter[konter.Key][0], dicClickPosKonter[konter.Key][1]);
                        delay();

                    }

                    MouseActions.SingleClickAtPosition(dicClickPosStufe[stufe.Key][0], dicClickPosStufe[stufe.Key][1]);
                    delay();
                }
                log.Debug("ScanTime: " + typ.Key + " finished in: " + s.Elapsed);
            }
            log.Debug("ScanTime: " + s.Elapsed);
            s.Stop();
        }

        bool SoldierScanCheckForAvailibleSoldiers() {
            string OcrActiveSoldiers = "";

            if(StopSoldierScan == false) {  //same position for difficulty 5-10
                OcrActiveSoldiers = OCR.OCRcheck(1173, 922, 106, 34, "0123456789/ "); //6char
                if(!SoldierScanCheckOCRResultValid(OcrActiveSoldiers)) {
                    OcrActiveSoldiers = OCR.OCRcheck(1173, 922, 84, 34, "0123456789/ "); //5char
                    if(!SoldierScanCheckOCRResultValid(OcrActiveSoldiers)) {
                        OcrActiveSoldiers = OCR.OCRcheck(1173, 922, 74, 34, "0123456789/ "); //4char
                        if(!SoldierScanCheckOCRResultValid(OcrActiveSoldiers)) {
                            OcrActiveSoldiers = OCR.OCRcheck(1173, 922, 51, 34, "0123456789/ "); //3char
                            if(!SoldierScanCheckOCRResultValid(OcrActiveSoldiers)) {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        bool SoldierScanCheckOCRResultValid(string OcrActiveSoldiers) {
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
                            else if(CurrentlyAvailible == 0) {
                                return false;
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}
