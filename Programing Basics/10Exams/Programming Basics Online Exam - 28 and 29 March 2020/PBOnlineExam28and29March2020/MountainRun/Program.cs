using System;

namespace MountainRun
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordSeconds = double.Parse(Console.ReadLine());
            double distanceMeters = double.Parse(Console.ReadLine());
            double timeInSecondsFor1Meter = double.Parse(Console.ReadLine());

            double GoshoTimeInSeconds = distanceMeters * timeInSecondsFor1Meter;
            double additionalTime = Math.Floor(distanceMeters / 50) * 30;
            GoshoTimeInSeconds = additionalTime + GoshoTimeInSeconds;
            

            double timeNoRecord = GoshoTimeInSeconds - recordSeconds;

            if (recordSeconds < GoshoTimeInSeconds)
            {
                Console.WriteLine($"No! He was {timeNoRecord:f2} seconds slower.");
            }

            else if (recordSeconds > GoshoTimeInSeconds)
            {
                Console.WriteLine($"Yes! The new record is {GoshoTimeInSeconds:f2} seconds.");
            }

            else
            {
                Console.WriteLine($"No! He was 0.00 seconds slower.");
            }

        }
    }
}
