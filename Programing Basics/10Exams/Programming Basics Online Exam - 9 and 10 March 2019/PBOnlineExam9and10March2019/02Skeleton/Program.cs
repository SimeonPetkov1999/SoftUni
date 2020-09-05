using System;

namespace _02Skeleton
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());
            double lenghtOfTrack = double.Parse(Console.ReadLine());
            int secondsFor100m = int.Parse(Console.ReadLine());

            int controlSeconds = minutes * 60 + seconds;
            double secondsLost = (lenghtOfTrack / 120) * 2.5;
            double marinTime = (lenghtOfTrack / 100) * secondsFor100m - secondsLost;

            if (marinTime<=controlSeconds)
            {
                Console.WriteLine("Marin Bangiev won an Olympic quota!");
                Console.WriteLine($"His time is {marinTime:f3}.");
            }

            else
            {
                Console.WriteLine($"No, Marin failed! He was {marinTime-controlSeconds:f3} second slower.");
            }

        }
    }
}
