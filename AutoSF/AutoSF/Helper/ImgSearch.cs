using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoSF.Helper {
    public static class ImgSearch {

        //[DllImport("ImageSearchDLL.dll")]
        [DllImport(@"C:\ImageSearchDLL.dll")]
        static extern IntPtr ImageSearch(int x, int y, int right, int bottom, [MarshalAs(UnmanagedType.LPStr)] string imagePath);
        

        public static String[] UseImageSearch(string imgPath, string tolerance) {
            int right = Screen.PrimaryScreen.WorkingArea.Right;
            int bottom = Screen.PrimaryScreen.WorkingArea.Bottom;

            imgPath = "*" + tolerance + " " + imgPath;

            IntPtr result;
            if(MainWindow.CurrentHostName == "VMgr4ndpa") {
                result = ImageSearch(0, 270, right, 540, imgPath); //searchArea is in between x 0,and y 270, goes to x 1080,goes to y 540
            }
            else {
                result = ImageSearch(-1920, 270, right, 540, imgPath);
            }
            String res = Marshal.PtrToStringAnsi(result);

            if(res[0] == '0') return null;//not found

            String[] data = res.Split('|');
            //0->found, 1->x, 2->y, 3->image width, 4->image height;        

            // Then, you can parse it to get x and y:
            int x; int y;
            int.TryParse(data[1], out x);
            int.TryParse(data[2], out y);
            //Console.WriteLine(x.ToString() + ", " + y.ToString());

            return data;
        }
    }
}
