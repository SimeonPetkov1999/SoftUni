using System;

namespace _01.ConvertMetersToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            double meteres = double.Parse(Console.ReadLine());

            double km = meteres * 0.001;
            Console.WriteLine($"{km:f2}");
        }
    }
}
