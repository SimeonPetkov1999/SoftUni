using System;

namespace _05KartRankList
{
    class Program
    {
        static void Main(string[] args)
        {
            int golds = 0;
            int silvers = 0;
            int bronzes = 0;
            int winnerTime = int.MaxValue;
            string winnerName = "";

            while (true)
            {
                string name = Console.ReadLine();
                if (name=="Finish")
                {
                    break;
                }
                int minutes = int.Parse(Console.ReadLine());
                int seconds = int.Parse(Console.ReadLine());
                int allInSeconds = (minutes * 60) + seconds;

                if (allInSeconds<55)
                {
                    golds++;
                }

                else if (allInSeconds>=55 &&  allInSeconds<=85)
                {
                    silvers++;
                }

                else if (allInSeconds>85 && allInSeconds<=120)
                {
                    bronzes++;
                }

                if (winnerTime>allInSeconds)
                {
                    winnerTime = allInSeconds;
                    winnerName = name;
                }
            }
            
            int minutesWinner = winnerTime / 60;
            int secondsWinner = winnerTime % 60;

            Console.WriteLine($"With {minutesWinner} minutes and {secondsWinner} seconds {winnerName} is the winner of the day!");
            Console.WriteLine($"Today's prizes are {golds} Gold {silvers} Silver and {bronzes} Bronze cards!");

        }
    }
}
