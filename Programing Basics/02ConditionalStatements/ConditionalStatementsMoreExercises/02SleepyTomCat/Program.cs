using System;

namespace _02SleepyTomCat
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberFreeDays = int.Parse(Console.ReadLine());

            int workDays = 365 - numberFreeDays;
            int minutesForPlay = (workDays * 63) + (numberFreeDays * 127);
           
         

            if (minutesForPlay < 30000)
            {
                int minutesLeft = 30000 - minutesForPlay;
                int H = minutesLeft / 60;
                int M = minutesLeft % 60;
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{H} hours and {M} minutes less for play");

            }

            else if (minutesForPlay > 30000)
            {
                int minutesLeft =minutesForPlay - 30000;
                int H = minutesLeft / 60;
                int M = minutesLeft % 60;
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{H} hours and {M} minutes more for play");

            }

        }
    }
}
