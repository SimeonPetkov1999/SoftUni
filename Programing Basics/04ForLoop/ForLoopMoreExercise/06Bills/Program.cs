using System;

namespace _06Bills
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfMonths = int.Parse(Console.ReadLine());

            double allelectricity = 0.0;
            double water = 20;
            double internet = 15;
            double others = 0.0;
            double average = 0.0;

            for (int i = 0; i < numberOfMonths; i++)
            {
                double electricity = double.Parse(Console.ReadLine());
                allelectricity += electricity;

                others += (electricity + water + internet) * 1.20;

            }

            average = (allelectricity + numberOfMonths * 20 + numberOfMonths * internet + others) / numberOfMonths;

            Console.WriteLine($"Electricity: {allelectricity:f2} lv");
            Console.WriteLine($"Water: {water * numberOfMonths:f2} lv");
            Console.WriteLine($"Internet: {internet*numberOfMonths:f2} lv");
            Console.WriteLine($"Other: {others:f2} lv");
            Console.WriteLine($"Average: {average:f2} lv");

        }
    }
}
