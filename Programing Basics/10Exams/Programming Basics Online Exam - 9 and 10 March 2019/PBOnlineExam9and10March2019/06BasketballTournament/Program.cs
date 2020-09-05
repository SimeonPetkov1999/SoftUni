using System;
using System.Net.NetworkInformation;

namespace _06BasketballTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOftournament = Console.ReadLine();
            int wins = 0;
            int loses = 0;
            int allGames = 0;


            while (nameOftournament!="End of tournaments")
            {
                int numberOfGames = int.Parse(Console.ReadLine());

                for (int i = 1; i <= numberOfGames; i++)
                {
                    int pointsDesiTeam = int.Parse(Console.ReadLine());
                    int pointsOtherTeam = int.Parse(Console.ReadLine());

                    if (pointsDesiTeam>pointsOtherTeam)
                    {
                        int diffWin = pointsDesiTeam - pointsOtherTeam;
                        Console.WriteLine($"Game {i} of tournament {nameOftournament}: win with {diffWin} points.");
                        wins++;
                    }

                    else
                    {
                        int diffLost = pointsOtherTeam - pointsDesiTeam;
                        Console.WriteLine($"Game {i} of tournament {nameOftournament}: lost with {diffLost} points.");
                        loses++;
                    }

                }
                allGames += numberOfGames;
                nameOftournament = Console.ReadLine();
            }

            double percentageWins = wins * 1.0 / allGames * 100;
            double percentageLoses = loses * 1.0 / allGames * 100;

            Console.WriteLine($"{percentageWins:f2}% matches win");
            Console.WriteLine($"{percentageLoses:f2}% matches lost");

        }
    }
}
