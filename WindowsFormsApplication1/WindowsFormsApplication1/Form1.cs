using System;
using System.Windows.Forms;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Specialized;

namespace Testdummy.Reference.MyStringTest
{
    public class Example
    {
        public static void Main()
        {
            /*
            String[] myArray = new String[] { "NumberOfLines","7", "DownsAfterLine","1","2","1","3","3","1","1","1","3","3","1","1"};
            //Set specific Value
            myArray[3] = "3";
            string Arraylength = (myArray.Length.ToString());
            ExampleTest.Properties.Settings.Default.MyExampleFile.AddRange (myArray);
            ExampleTest.Properties.Settings.Default.Save();

            string Config = string.Join("\n", myArray);
            MessageBox.Show(Config);
            */
            //var MsgBoxResult = 
            if(Convert.ToString(MessageBox.Show("Is Curser Position Ok to Click?", "Bla", MessageBoxButtons.YesNo, MessageBoxIcon.Question))=="Yes") {
                MessageBox.Show("Result is Yes");
            }
            else {
                MessageBox.Show("Result is something else");
            }
            //MessageBox.Show(Convert.ToString(MsgBoxResult));

            /*
            StringCollection MyStringCol = ExampleTest.Properties.Settings.Default.MyExampleFile;
            MessageBox.Show(MyStringCol[2]);*/


                /*
                StringCollection MyStringCol = ExampleTest.Properties.Settings.Default.MyExampleFile;
                if (MyStringCol == null)
                { MyStringCol = new StringCollection(); }
                String[] myArray = new String[] { "NumberOfLines", "Line", "DownsAfterLine" };
                MyStringCol.AddRange(myArray); //Copies the Array "myArray" to the End of the StringCollection "MyString"
                MyStringCol.Add("+1");

                ExampleTest.Properties.Settings.Default.MyExampleFile = MyStringCol;
                ExampleTest.Properties.Settings.Default.Save(); */

        }
     }
}
