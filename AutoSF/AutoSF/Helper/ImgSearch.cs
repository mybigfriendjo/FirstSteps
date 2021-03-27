using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoSF.Helper {
    public static class ImgSearch {

        [DllImport(@"C:\Temp\Resources\ImageSearchDLL.dll")]
        static extern IntPtr ImageSearch(int x, int y, int right, int bottom, [MarshalAs(UnmanagedType.LPStr)] string imagePath);


        public static String[] UseImageSearch(string IMGPath, string tolerance,int xUpperLeftCoordinate = -1920, int yUpperLeftCoordinate = 270,int xLowerRightCoordinate = 0,int yLowerRightCoordinate = 540) {

            int right = Screen.PrimaryScreen.WorkingArea.Right;
            int bottom = Screen.PrimaryScreen.WorkingArea.Bottom;

            IMGPath = "*" + tolerance + " " + IMGPath;

            IntPtr result;
            if(MainWindow.CurrentHostName == "VMgr4ndpa") {
                xUpperLeftCoordinate += 1920;
                xLowerRightCoordinate += 1920;
                result = ImageSearch(xUpperLeftCoordinate, yUpperLeftCoordinate, xLowerRightCoordinate, yLowerRightCoordinate, IMGPath); //searchArea is in between x 0,and y 270, goes to x 1920,goes to y 540
            }
            else {
                result = ImageSearch(xUpperLeftCoordinate, yUpperLeftCoordinate, xLowerRightCoordinate, yLowerRightCoordinate, IMGPath);
            }
            String res = Marshal.PtrToStringAnsi(result);

            if(res[0] == '0') return null;//not found

            String[] data = res.Split('|');
            //0->found, 1->x, 2->y, 3->image width, 4->image height;        

            // Then, you can parse it to get x and y:
            //int x; int y;
            //int.TryParse(data[1], out x);
            //int.TryParse(data[2], out y);
            //Console.WriteLine(x.ToString() + ", " + y.ToString());

            return data;
        }
    }
}
