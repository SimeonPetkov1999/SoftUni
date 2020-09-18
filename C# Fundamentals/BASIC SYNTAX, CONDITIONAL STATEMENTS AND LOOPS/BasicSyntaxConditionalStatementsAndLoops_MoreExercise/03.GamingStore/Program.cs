using System;

namespace _03.GamingStore
{
    class Program
    {     
        static void Main(string[] args)
        {
            double currentBallance = double.Parse(Console.ReadLine());
            double moneySpent = 0;
            double price = 0;
            string game = Console.ReadLine();
            while (game!="Game Time")
            {
                switch (game)
                {
                    case"OutFall 4":
                        price = 39.99;
                        break;
                    case "CS: OG":
                        price = 15.99;
                        break;
                    case "Zplinter Zell":
                        price = 19.99;                    
                        break;
                    case "Honored 2":
                        price = 59.99;
                        break;
                    case "RoverWatch":
                        price = 29.99;
                        break;
                    case "RoverWatch Origins Edition":
                        price = 39.99;
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        game = Console.ReadLine();
                        continue;                       
                }

                if (currentBallance < price)
                {
                    Console.WriteLine("Too Expensive");
                    game = Console.ReadLine();
                    continue;
                }

                currentBallance -=price;
                moneySpent += price;

                Console.WriteLine($"Bought {game}");

                if (currentBallance==0)
                {
                    Console.WriteLine("Out of money");
                    Environment.Exit(0);
                }           
                game = Console.ReadLine();
            }

            Console.WriteLine($"Total spent: ${moneySpent:f2}. Remaining: ${currentBallance:f2}");
        }
    }
}
