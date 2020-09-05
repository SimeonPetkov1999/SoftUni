using System;

namespace _05TennisRanklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTours = int.Parse(Console.ReadLine());
            int startingPoints = int.Parse(Console.ReadLine());
            int points = 0;
            int wins = 0;
            for (int i = 0; i < numberOfTours; i++)
            {
                string result = Console.ReadLine();

                switch (result)
                {
                    case "W":
                        points += 2000;
                        wins++;
                        break;
                    case "F":
                        points += 1200;
                        break;
                    case "SF":
                        points += 720;
                        break;
                }
            }
            ;
            int finalPoints = startingPoints + points;
            double averagePoints = Math.Floor(points * 1.0 / numberOfTours);
            double percentWins = (wins * 1.0 / numberOfTours) * 100;

            Console.WriteLine($"Final points: {finalPoints}");
            Console.WriteLine($"Average points: {averagePoints}");
            Console.WriteLine($"{percentWins:f2}%");
        }
    }
}
