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
        




        //public static bool SearchStaticPixel(int x, int y, string PixColorHex) {
            
        //    Graphics graphics = Graphics.FromImage(bitmap as Image); // Create a new graphics objects that can capture the screen
        //    graphics.CopyFromScreen(SystemInformation.VirtualScreen.Left, SystemInformation.VirtualScreen.Top, 0, 0, bitmap.Size); // Screenshot moment → screen content to graphics object
        //    //OCRImage = bitmap;
        //    Color desiredPixelColor = ColorTranslator.FromHtml(PixColorHex);
        //    //save Bitmap to see Picture/Content    
        //    //Bitmap Bitmapcopy = new Bitmap(bitmap);
        //    //Bitmapcopy.Save("c:\\temp\\bitmapnew.jpeg");
        //    Color currentPixelColor = bitmap.GetPixel(x, y);
        //    if(currentPixelColor == desiredPixelColor) {
        //        return true;
        //    }

        //    return false;
        //}



        public static void OCRcheck(int RectUpperLeftX,int RectUpperLeftY,int RectWith = 140, int RectHigh =45 ) { 
            Bitmap src = new Bitmap(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height); // Create an empty bitmap with the size of all connected screen
            Graphics graphics = Graphics.FromImage(src as Image); // Create a new graphics objects that can capture the scree
            graphics.CopyFromScreen(SystemInformation.VirtualScreen.Left, SystemInformation.VirtualScreen.Top, 0, 0, src.Size); // Screenshot moment → screen content to graphics object
                                                                                                                                   //FullsizeImage = src;



            Rectangle cropRect = new Rectangle(RectUpperLeftX, RectUpperLeftY, RectWith, RectHigh);
            Bitmap cropped = (Bitmap)src.Clone(cropRect, src.PixelFormat);

            cropped.Save("c:\\temp\\SrcTest.jpeg");
            var OCR = new IronTesseract();
            OCR.Language = OcrLanguage.GermanFast;
            //OCR.Configuration.BlackListCharacters = "013456789";
            string OCRText = OCR.Read(cropped).Text;
            Console.WriteLine(OCRText);

            ////Bitmap target = new Bitmap(cropRect.Width, cropRect.Height);
            //Bitmap target = new Bitmap(cropRect.Width, cropRect.Height);
            //using(OCRImage) {
            //    using(Graphics g = Graphics.FromImage(target)) {
            //        g.DrawImage(src, new Rectangle(RectUpperLeftX, RectUpperLeftY, target.Width, target.Height),
            //                        cropRect,
            //                        GraphicsUnit.Pixel);

            //        src.Save("c:\\temp\\SrcTest.jpeg");
            //        OCRImage = src;
            //    }
            //}
            //OCRImage.Save("c:\\temp\\OCRCropTest.jpeg");
            //string OCRText = new IronTesseract().Read(PixelFinder.OCRImage).Text;
            //Console.WriteLine(OCRText);




            //using(var OcrInputImage = new OcrInput()) {
            //    var ContentArea = new System.Drawing.Rectangle() { X = 1550, Y = 750, Height = 200, Width = 250 };
            //    // Dimensions are in in px
            //    OcrInputImage.AddImage(PixelFinder.OCRImage, ContentArea);
            //    Ocr.Configuration.WhiteListCharacters = "01234566789.";
            //    var Result = Ocr.Read(OcrInputImage);
            //    Result.SaveAsSearchablePdf("c:\\temp\\rectangle.pdf");
            //    PixelFinder.OCRImage.Save("c:\\temp\\bitmap.jpeg");
            //    string Text = new IronTesseract().Read(PixelFinder.OCRImage).Text;
            //    logger.Debug("OCRResult: " + Result.Text);
            //    logger.Debug("OCRResult: " + Text);
            //    Console.WriteLine(Result.Text);
            //}
        }
    }
}

