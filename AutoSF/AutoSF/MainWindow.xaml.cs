using System.Drawing;
using System.Windows;
using System;
using AutoSF.Helper;
using System.Windows.Input;
using System.Threading.Tasks;

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

        private void btnAutoPvP_Click(object sender, RoutedEventArgs e) {
            while() {
            CheckPixel();
            }
        }

        public async void ClickHandler() {
            await Task.Delay(5000);

        }


        private void CheckPixel() {
            int Score = 0;

            if(PixelFinder.SearchStaticPixel(117, 587, "#853C08")) { Score++; }
            if(PixelFinder.SearchStaticPixel(435, 568, "#47433A")) { Score++; }
            if(PixelFinder.SearchStaticPixel(1819, 648, "#292B33")) { Score++; }
            if(Score >= 2) {
                Console.WriteLine("Score Ok (" + Score + ")");
                Console.WriteLine("Entering Room2");
                //MouseActions.DoubleClickAtPosition(-966, 590);
                if(Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.M)) {
                    Console.WriteLine("AutoPvP interrupted");
                    break();
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
