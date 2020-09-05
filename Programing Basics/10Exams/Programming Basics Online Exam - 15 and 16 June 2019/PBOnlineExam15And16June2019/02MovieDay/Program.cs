using System;

namespace _02MovieDay
{
    class Program
    {
        static void Main(string[] args)
        {
            int timeForFilming = int.Parse(Console.ReadLine());
            int numberOfScenes = int.Parse(Console.ReadLine());
            int lenghtOfScene = int.Parse(Console.ReadLine());

            double podgotovka = timeForFilming * 0.15;
            double neededTimeForFilming = numberOfScenes * lenghtOfScene;
            double neededTime = podgotovka + neededTimeForFilming;

            if (neededTime<=timeForFilming)
            {
                Console.WriteLine($"You managed to finish the movie on time! You have {Math.Round(timeForFilming-neededTime)} minutes left!");
            }
            else
            {
                Console.WriteLine($"Time is up! To complete the movie you need {Math.Round(neededTime-timeForFilming)} minutes.");
            }
        }
    }
}
