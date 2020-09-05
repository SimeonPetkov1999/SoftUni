using System;

namespace _07WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordSeconds = double.Parse(Console.ReadLine());
            double distanceMeters = double.Parse(Console.ReadLine());
            double timeInSecondsFor1M = double.Parse(Console.ReadLine());

            double ivanTime = distanceMeters * timeInSecondsFor1M;
            double additionalTime = Math.Floor((distanceMeters / 15)) * 12.5;
            ivanTime = ivanTime + additionalTime;

            if (ivanTime>=recordSeconds)
            {
                Console.WriteLine($"No, he failed! He was {ivanTime-recordSeconds:f2} seconds slower.");
            }

            else
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {ivanTime:f2} seconds.");
            }

        }
    }
}
