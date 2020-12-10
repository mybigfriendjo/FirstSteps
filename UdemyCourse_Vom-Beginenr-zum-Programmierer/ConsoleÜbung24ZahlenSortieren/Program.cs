using System;
using System.Collections.Immutable;
using System.Linq;

namespace ConsoleÜbung24ZahlenSortieren
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter 3 numbers with space inbetween: ");
            string userInput = Console.ReadLine();
            int[] userInputArray = Array.ConvertAll((userInput.Split(" ")), int.Parse);

            userInputArray = userInputArray.OrderBy(i => i).ToArray();

            Console.Write(String.Join(",",userInputArray));
        }
    }
}
