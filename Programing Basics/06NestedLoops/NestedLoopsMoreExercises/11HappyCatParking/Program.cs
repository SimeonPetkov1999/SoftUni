using System;

namespace _11HappyCatParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hoursInDay = int.Parse(Console.ReadLine());
            double sumForDay = 0;
            double finalSum = 0;

            for (int i = 1; i <= days; i++)
            {
                for (int j = 1; j <= hoursInDay; j++)
                {
                    if (i % 2 == 0 && j % 2 != 0)
                    {
                        sumForDay += 2.50;
                    }

                    else if (i % 2 != 0 && j % 2 == 0)
                    {
                        sumForDay += 1.25;
                    }

                    else
                    {
                        sumForDay += 1.00;
                    }
                }

                Console.WriteLine($"Day: {i} - {sumForDay:f2} leva");
                finalSum += sumForDay;
                sumForDay = 0;
            }

            Console.WriteLine($"Total: {finalSum:f2} leva");
        }
    }
}
