using System;

namespace _06VetParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfDays = int.Parse(Console.ReadLine());
            int numberOfHoursForDay = int.Parse(Console.ReadLine());

            double daySum = 0.0;
            double totalSum = 0.0;

            for (int day = 1; day <= numberOfDays; day++)
            {
                for (int hour = 1; hour <= numberOfHoursForDay; hour++)
                {
                    if (day % 2 == 0 && hour % 2 != 0)
                    {
                        daySum += 2.50;
                    }

                    else if (day % 2 != 0 && hour % 2 == 0)
                    {
                        daySum += 1.25;
                    }

                    else
                    {
                        daySum += 1.00;
                    }
                }
                Console.WriteLine($"Day: {day} - {daySum:f2} leva");
                totalSum += daySum;
                daySum = 0;
            }
            Console.WriteLine($"Total: {totalSum:f2} leva");
        }
    }
}
