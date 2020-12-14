using System.Windows.Forms;
using System.Drawing;
using System;

namespace AutoSF.Helper {
    //static -> damit methoden ohne "new object" (also nicht instanziert) aufgerufen werden können
    public static class PixelFinder {

        public static bool SearchStaticPixel(int x, int y, string PixColorHex) {
            Bitmap bitmap = new Bitmap(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height); // Create an empty bitmap with the size of all connected screen
            Graphics graphics = Graphics.FromImage(bitmap as Image); // Create a new graphics objects that can capture the scree
            graphics.CopyFromScreen(SystemInformation.VirtualScreen.Left, SystemInformation.VirtualScreen.Top, 0, 0, bitmap.Size); // Screenshot moment → screen content to graphics object
            Color desiredPixelColor = ColorTranslator.FromHtml(PixColorHex);
            bitmap.Save("c:\\temp\\bitmap.jpeg");
            Color currentPixelColor = bitmap.GetPixel(x, y);
            if(currentPixelColor == desiredPixelColor) {
                Console.WriteLine("PixelFound");
                return true;
            }

            return false;
        }

        public static bool SearchPixelInArea(Rectangle sender, string Pix1, string Pix2 = "", string Pix3 = "") {
            //example: PixelFinder.SearchPixelInArea(RectPvPRoom2Entrance1, "73330B", "7E3908", "934208");

            Bitmap bitmap = new Bitmap(sender.Width, sender.Height); // Create an empty bitmap with the size of all connected screen 

            Graphics graphics = Graphics.FromImage(bitmap as Image); // Create a new graphics objects that can capture the screen
            //todo CopyFromScreen Values 0,0,... ?
            graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size); // Screenshot moment → screen content to graphics object

            Color desiredPixelColor1 = ColorTranslator.FromHtml(Pix1);
            if(Pix2 != "") {
                Color desiredPixelColor2 = ColorTranslator.FromHtml(Pix2);
            }
            if(Pix3 != "") {
                Color desiredPixelColor3 = ColorTranslator.FromHtml(Pix3);
            }

            for(int x = sender.X; x < sender.Right; x++) {
                for(int y = sender.Y; y < sender.Bottom; y++) {
                    // Get the current pixels color
                    Color currentPixelColor = bitmap.GetPixel(x, y);

                    // Finally compare the pixels hex color and the desired hex color (if they match we found a pixel)
                    //if(desiredPixelColor == (currentPixelColor1|currentPixelColor2|currentPixelColor3)) {
                    //MessageBox.Show("Found Pixel - Now set mouse cursor");
                    //MouseActions.DoubleClickAtPosition(x,y);
                    //return true;
                    //}
                }
            }
            return false;
        }
    }
}
