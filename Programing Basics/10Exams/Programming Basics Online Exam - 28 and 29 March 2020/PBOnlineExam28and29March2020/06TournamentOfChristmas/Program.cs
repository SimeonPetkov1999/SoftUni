using System;
using System.IO;

namespace _06TournamentOfChristmas
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string sport;
            string result;
            int winCounter = 0;
            int loseCounter = 0;
            int winCoounterDays = 0;
            int loseCounterDays = 0;
            double money = 0.0;

            for (int i = 0; i < days; i++)
            {

                while (true)
                {
                    sport = Console.ReadLine();
                    if (sport == "Finish")
                    {
                        break;
                    }

                    result = Console.ReadLine();
                    if (result == "win")
                    {
                        winCounter++;
                    }

                    else if (result == "lose")
                    {
                        loseCounter++;
                    }
                }

                if (winCounter > loseCounter)
                {
                    money += (winCounter * 20) * 1.10;
                }

                else
                {
                    money +=  winCounter * 20;
                }             
                winCoounterDays += winCounter;
                loseCounterDays += loseCounter;
                winCounter = 0;
                loseCounter = 0;
            }

            if (winCoounterDays>loseCounterDays)
            {
                money = money * 1.20;
                Console.WriteLine($"You won the tournament! Total raised money: {money:f2}");
            }

            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {money:f2}");
            }
        }
    }
}
