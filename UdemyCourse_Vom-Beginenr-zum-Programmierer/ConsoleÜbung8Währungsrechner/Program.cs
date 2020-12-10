using System;

namespace ConsoleÜbung8Währungsrechner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Bitte geben Sie einen Betrag in Euro ein der umgerechnet werden soll: ");      
            int valueEuro = Convert.ToInt32(Convert.ToDouble(Console.ReadLine()));
            double valueInDollar = Convert.ToInt32(valueEuro * 1.09);
            double valueInSF = Convert.ToInt32(valueEuro * 1.05);
            Console.WriteLine("Wert in Dollar: " + valueInDollar + "\n" + "Wert in SchweizerFranken: " + valueInSF);
        }
    }
}
