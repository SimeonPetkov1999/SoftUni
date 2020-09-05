using System;

namespace _04Darts
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerName = Console.ReadLine();
            int playerPoints = 301;
            int successfulShots = 0;
            int unsuccessfulShot = 0;

            string ring = Console.ReadLine();

            while (ring!="Retire")
            {
                int currentPoints = int.Parse(Console.ReadLine());

                switch (ring)
                {
                    case "Single":
                        playerPoints -= currentPoints;
                        if (playerPoints < 0)
                        {
                            playerPoints += currentPoints;
                            unsuccessfulShot++;
                        }
                        else
                        {
                            successfulShots++;
                        }
                        break;
                    case "Double":
                        playerPoints -= currentPoints*2;
                        if (playerPoints<0)
                        {
                            playerPoints += currentPoints * 2;
                            unsuccessfulShot++;
                        }
                        else
                        {
                            successfulShots++;
                        }
                        break;
                    case "Triple":
                        playerPoints -= currentPoints*3;
                        if (playerPoints < 0)
                        {
                            playerPoints += currentPoints * 3;
                            unsuccessfulShot++;
                        }
                        else
                        {
                            successfulShots++;
                        }
                        break;
                }
                if (playerPoints == 0)
                {
                    break;
                }

                ring = Console.ReadLine();
            }

            if (ring=="Retire")
            {
                Console.WriteLine($"{playerName} retired after {unsuccessfulShot} unsuccessful shots.");
            }

            else if (playerPoints==0)
            {
                Console.WriteLine($"{playerName} won the leg with {successfulShots} shots.");
            }

        }
    }
}
