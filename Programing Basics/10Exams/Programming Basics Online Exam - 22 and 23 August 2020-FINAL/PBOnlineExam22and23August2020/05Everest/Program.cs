using System;

namespace _05Everest
{
    class Program
    {
        static void Main(string[] args)
        {
            int meters = 5364;
            int days = 1;
            string sleepOrNo = Console.ReadLine();
            while (sleepOrNo != "END")
            {
                if (sleepOrNo == "Yes")
                {
                    days++;
                    if (days > 5)
                    {
                        break;
                    }
                }
                int climbedMeters = int.Parse(Console.ReadLine());
                meters += climbedMeters;

                if (meters >= 8848)
                {
                    Console.WriteLine($"Goal reached for {days} days!");
                    Environment.Exit(0);
                }
                sleepOrNo = Console.ReadLine();
            }
            Console.WriteLine("Failed!");
            Console.WriteLine(meters);        
        }
    }
}
