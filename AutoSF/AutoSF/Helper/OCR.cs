using System;
using System.Drawing;
using System.Windows.Forms;
using NLog;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using IronOcr;
using System.Drawing.Imaging;

namespace AutoSF.Helper {
    public class OCR {

        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        public IronTesseract Ocr = new IronTesseract();
        public static Image FullsizeImage;
        public static Image TransformedCropImage;


        public static string OCRcheck(int RectUpperLeftX, int RectUpperLeftY, int RectWith = 140, int RectHigh = 45, string Whitelist = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ß! -%/äüöÄÜÖ") {
            Bitmap src = new Bitmap(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height); // Create an empty bitmap with the size of all connected screen
            Graphics graphics = Graphics.FromImage(src as Image); // Create a new graphics objects that can capture the scree
            graphics.CopyFromScreen(SystemInformation.VirtualScreen.Left, SystemInformation.VirtualScreen.Top, 0, 0, src.Size); // Screenshot moment → screen content to graphics object
            FullsizeImage = src;

            Rectangle cropRect = new Rectangle(RectUpperLeftX, RectUpperLeftY, RectWith, RectHigh);
            Bitmap cropped = (Bitmap)src.Clone(cropRect, src.PixelFormat);

            cropped.Save("c:\\temp\\SrcTest.png");
            var OCR = new IronTesseract();
            OCR.Language = OcrLanguage.GermanFast;
            //OCR.Configuration.BlackListCharacters = "013456789";
            OCR.Configuration.WhiteListCharacters = Whitelist;
            OCR.Configuration.ReadBarCodes = false;
            //OCR.Configuration.RenderSearchablePdfsAndHocr = false;

            string OCRText = OCR.Read(cropped).Text;
            if(OCRText == null || OCRText == "") {
                TransformedCropImage = Transform(cropped);
                TransformedCropImage.Save("c:\\temp\\SrcTestTransform.png");
                OCR.Configuration.PageSegmentationMode = TesseractPageSegmentationMode.SingleChar;
                OCRText = OCR.Read(TransformedCropImage).Text;
                if(OCRText == "" || OCRText == null) {
                    OCR.Configuration.PageSegmentationMode = TesseractPageSegmentationMode.AutoOsd;
                    Bitmap resizedCropped = new Bitmap(cropped.Width + cropped.Width + cropped.Width, cropped.Height); //creating empty Bitmap - 3times the Width of the cropped Image
                    using(Graphics g = Graphics.FromImage(resizedCropped)) {
                        g.DrawImage(cropped, 0, 0); //Adding Image 1 on pos 0,0
                        g.DrawImage(cropped, cropped.Width, 0); //Adding Image 2 on pos Image1.Witdh,0
                        g.DrawImage(cropped, cropped.Width + cropped.Width, 0);
                    }

                    resizedCropped.Save("c:\\temp\\SrcTestresizedCropped.png");
                    OCRText = OCR.Read(resizedCropped).Text;
                    if(OCRText.Length == 6) {
                        OCRText = OCRText.Substring(0,2);
                    }
                    else if(OCRText.Length == 3) {
                        OCRText = OCRText.Substring(0, 1);
                    }
                }
            }
            log.Debug("OCR text: " + OCRText);
            LoopGarbageCollector.ClearGarbageCollector();
            return OCRText;
        }

        public static Bitmap Transform(Bitmap source) { //invert
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(source.Width, source.Height);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            // create the negative color matrix
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]{
                new float[] {-1, 0, 0, 0, 0},
                new float[] {0, -1, 0, 0, 0},
                new float[] {0, 0, -1, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {1, 1, 1, 0, 1}
            });

            // create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            attributes.SetColorMatrix(colorMatrix);

            g.DrawImage(source, new Rectangle(0, 0, source.Width, source.Height),
                        0, 0, source.Width, source.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();

            return newBitmap;
        }
    }
}
