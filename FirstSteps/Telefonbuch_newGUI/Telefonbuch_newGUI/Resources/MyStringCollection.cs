using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Specialized;

namespace Telefonbuch.Resources
{
    class MyStringCollection
    {
        public static void MyStringCol()
        { 

            StringCollection MyStringCol = new StringCollection();
            String[] myArray = new String[] { "NumberOfLines", "Line", "DownsAfterLine" };
            MyStringCol.AddRange(myArray); //Copies the Array "myArray" to the End of the StringCollection "MyString"

            Console.WriteLine("Initial contents of the StringCollection:");
            PrintValues(MyStringCol);

        }

        public static void PrintValues(IEnumerable myStingCol)
        {
            foreach (Object obj in myStingCol)
                Console.WriteLine("   {0}", obj);
            Console.WriteLine();
        }

    }

}

