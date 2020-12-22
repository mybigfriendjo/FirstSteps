using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel; //Backgroundworker
using System.Windows.Forms;

namespace AutoSF.Helper {
    public class BackgroundworkerConfig {
        //Backgroundworker   https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.backgroundworker?view=net-5.0
        public static BackgroundWorker backgroundWorker1 = new BackgroundWorker();  //Backgroundworker
        public static BackgroundWorker backgroundWorker2 = new BackgroundWorker();
        public static BackgroundWorker backgroundWorker3 = new BackgroundWorker();

        //resultlabes are Lables Created on a Form to show Status
        //Bgw1resultLabel
        //Bgw2resultLabel

        public static void InitializeBackgroundworker() {
            backgroundWorker1.DoWork += bgw1DoWork;
            backgroundWorker2.DoWork += bgw2DoWork;
            backgroundWorker3.DoWork += bgw3DoWork;
        }


        // This event handler is where the time-consuming work is done.
        //  ------  backgroundWorker1 - MouseSpam -----------
        public static void bgw1DoWork(object sender, DoWorkEventArgs e) {

            //while(MainWindow.LeftMouseDown == true) {
            //mousestrave
            int x = 100; //x-coordinate
            int y = 500;
            int i = 0;
            while(1<2) {
                if(backgroundWorker1.CancellationPending == true) {
                    e.Cancel = true;
                    MouseActions.LeftMouseUp();
                    break;
                }
                else {
                    // Perform a time consuming operation and report progress.
                    //MouseActions.Click();
                    MouseActions.LeftMouseDown();
                    System.Threading.Thread.Sleep(2);
                    //backgroundWorker1.ReportProgress(i * 10);
                }
                i++;
                if(x > 1880) { //if mouse is almost completly right -> reset to left side
                    MouseActions.SetCursorPos(50, 500);
                    System.Threading.Thread.Sleep(4);
                    MouseActions.SetCursorPos(50, 500);
                    x = 100;
                }
                if((i % 10) == 0) { //Every 10th times           Modulo 10 (everytime i/10 has no remainder/ is no dezimal  30%10  remains 0  34%10 -> 4 remains
                    x += 2;
                }
                MouseActions.SetCursorPos(x, y);
            }
            BgwCancelAsyn(backgroundWorker1);
        }


        // This event handler is where the time-consuming work is done.
        //  ------  backgroundWorker2 -----------
        public static void bgw2DoWork(object sender, DoWorkEventArgs e) {
            //BackgroundWorker worker = sender as BackgroundWorker;

            for(int i = 1; i <= 100; i++) {
                if(backgroundWorker2.CancellationPending == true) {
                    e.Cancel = true;
                    break;
                }
                else {
                    // Perform a time consuming operation and report progress.
                    if(i > 40) { //Delay to kill Drohnes
                        KeyboardInput.Send(KeyboardInput.ScanCodeShort.KEY_F);
                    }
                    System.Threading.Thread.Sleep(4);
                    //backgroundWorker2.ReportProgress(i * 10);
                }
            }
        }
        private static void bgw3DoWork(object sender, DoWorkEventArgs e) {
            for(int i = 1; i <= 10; i++) {
                if(backgroundWorker2.CancellationPending == true) {
                    e.Cancel = true;
                    break;
                }
                else {
                    // Perform a time consuming operation and report progress.
                    int Score = 0;
                    if(PixelFinder.SearchStaticPixel(1773, 418, "#73BBC6")) { Score++; }
                    if(Score > 0) { 
                        Console.WriteLine("Scored"); 
                    }
                    //System.Threading.Thread.Sleep(4);
                    //backgroundWorker2.ReportProgress(i * 10);
                }
            }
        }

        public static void enableReportAndCancel(BackgroundWorker Bgw) {
            Bgw.WorkerReportsProgress = true;  //Backgroundworker
            Bgw.WorkerSupportsCancellation = true;  //Backgroundworker
        }

        
        public static void BgwStartAsync(BackgroundWorker Bgw) {
            if(Bgw.IsBusy != true) {
                // Start the asynchronous operation.
                Bgw.RunWorkerAsync();
                enableReportAndCancel(Bgw);
            }
        }

        public static  void BgwCancelAsyn(BackgroundWorker Bgw) {
            if(Bgw.WorkerSupportsCancellation == true) {
                // Cancel the asynchronous operation.
                Bgw.CancelAsync();
            }
        }

      
        
        // This event handler updates the progress.
        private static void bgwProgressChanged(Label BgwLabel, ProgressChangedEventArgs e) {
            BgwLabel.Text = (e.ProgressPercentage.ToString() + "%");
        }

        // This event handler deals with the results of the background operation.
        private static void BgwRunWorkerCompleted(Label BgwLabel, RunWorkerCompletedEventArgs e) {
            if(e.Cancelled == true) {
                BgwLabel.Text = "Canceled!";
            }
            else if(e.Error != null) {
                BgwLabel.Text = "Error: " + e.Error.Message;
            }
            else {
                BgwLabel.Text = "Done!";
            }
        }

    }
}
