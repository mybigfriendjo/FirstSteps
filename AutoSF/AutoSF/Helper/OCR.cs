using System;
using System.Drawing;
using System.Windows.Forms;
using NLog;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using IronOcr;

namespace AutoSF.Helper {
    public class OCR {

        private Logger logger = LogManager.GetCurrentClassLogger();
        
        public IronTesseract Ocr = new IronTesseract();
        public static Image FullsizeImage;
        public static Image OCRImage;
      

        public static string OCRcheck(int RectUpperLeftX,int RectUpperLeftY,int RectWith = 140, int RectHigh =45 ) { 
            Bitmap src = new Bitmap(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height); // Create an empty bitmap with the size of all connected screen
            Graphics graphics = Graphics.FromImage(src as Image); // Create a new graphics objects that can capture the scree
            graphics.CopyFromScreen(SystemInformation.VirtualScreen.Left, SystemInformation.VirtualScreen.Top, 0, 0, src.Size); // Screenshot moment → screen content to graphics object
            FullsizeImage = src; 

            Rectangle cropRect = new Rectangle(RectUpperLeftX, RectUpperLeftY, RectWith, RectHigh);
            Bitmap cropped = (Bitmap)src.Clone(cropRect, src.PixelFormat);

            cropped.Save("c:\\temp\\SrcTest.jpeg");
            var OCR = new IronTesseract();
            OCR.Language = OcrLanguage.GermanFast;
            //OCR.Configuration.BlackListCharacters = "013456789";
            string OCRText = OCR.Read(cropped).Text;
            Console.WriteLine(OCRText);
            return OCRText;
        }
    }
}

