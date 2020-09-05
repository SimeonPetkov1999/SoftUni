using System;

namespace _07FootballLeague
{
    class Program
    {
        static void Main(string[] args)
        {
            int stadiumCapacity = int.Parse(Console.ReadLine());
            int numberOfFans = int.Parse(Console.ReadLine());

            double percentageA = 0.0;
            double percentageB = 0.0;
            double percentageV = 0.0;
            double percentageG = 0.0;
            double allFansPercentage;

            for (int i = 0; i < numberOfFans; i++)
            {
                char sector = char.Parse(Console.ReadLine());

                switch (sector)
                {
                    case 'A':
                        percentageA++;
                        break;
                    case 'B':
                        percentageB++;
                        break;
                    case 'V':
                        percentageV++;
                        break;
                    case 'G':
                        percentageG++;
                        break;
                }
            }
;
            percentageA = (percentageA / numberOfFans) * 100;
            percentageB = (percentageB / numberOfFans) * 100;
            percentageV = (percentageV / numberOfFans) * 100;
            percentageG = (percentageG / numberOfFans) * 100;
            allFansPercentage = ((numberOfFans*1.0) / stadiumCapacity) * 100;

            Console.WriteLine($"{percentageA:f2}%");
            Console.WriteLine($"{percentageB:f2}%");
            Console.WriteLine($"{percentageV:f2}%");
            Console.WriteLine($"{percentageG:f2}%");
            Console.WriteLine($"{allFansPercentage:f2}%");


        }
    }
}
