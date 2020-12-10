using System;

namespace ConsoleÜbung14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the following informations in the same order:  Name of the worker, Amount of working hours, €/h");

            string workerName = Console.ReadLine();
            int workHours = Convert.ToInt32(Console.ReadLine());
            double moneyPerHour = Convert.ToDouble(Console.ReadLine());
            double overallCost = moneyPerHour * workHours;

            Console.WriteLine("Employee " + workerName + " earns " + overallCost + " € in " + workHours +" hours");
            //better way for WriteLine:
            Console.Write("Employee {0} earns {1} Eur in {2} hours", workerName, overallCost, workHours);
        }
    }
}
