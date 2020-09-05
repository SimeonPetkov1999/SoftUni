using System;

namespace _02LunchBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfSeries = Console.ReadLine();
            int lenghtOfEpisode = int.Parse(Console.ReadLine());
            int lenghtOfBreak = int.Parse(Console.ReadLine());

            double timeForLunch = lenghtOfBreak * (1.0 / 8);
            double timeForOtdih = lenghtOfBreak * (1.0 / 4);
            double leftTime = lenghtOfBreak - timeForLunch - timeForOtdih;

            if (leftTime>=lenghtOfEpisode)
            {
                Console.WriteLine($"You have enough time to watch {nameOfSeries} and left with {Math.Ceiling(leftTime-lenghtOfEpisode)} minutes free time.");
            }

            else
            {
                Console.WriteLine($"You don't have enough time to watch {nameOfSeries}, you need {Math.Ceiling(lenghtOfEpisode-leftTime)} more minutes.");
            }


        }
    }
}
