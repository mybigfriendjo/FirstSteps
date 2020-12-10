using System;

namespace ConsoleÜbung16KreisBerechnung
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the Circle radius in centimeters: ");
            double circleRadius = Convert.ToDouble(Console.ReadLine());
            double circleAreaSize = Math.Pow((circleRadius),2) * Math.PI;
            double circleCircumference = 2* circleRadius * Math.PI;
            Console.Write("The Area of the circle is: {0} cm²\nThe circumference is: {1}cm", circleAreaSize,circleCircumference);
        }
    }
}
