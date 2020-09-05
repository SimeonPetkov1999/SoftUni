using System;

namespace _03KartCenter
{
    class Program
    {
        static void Main(string[] args)
        {
            double insertedMoney = double.Parse(Console.ReadLine());
            string laps = Console.ReadLine();
            string fanCard = Console.ReadLine();
            string typeCard = Console.ReadLine();

            double price = 0;

            if (laps=="five")
            {
                switch (typeCard)
                {
                    case "Child":
                        price = 7;
                        break;
                    case "Junior":
                        price = 9;
                        break;
                    case "Adult":
                        price = 12;
                        break;
                    case "Profi":
                        price = 18;
                        break;
                }
            }

            else if (laps =="ten")
            {
                switch (typeCard)
                {
                    case "Child":
                        price = 11;
                        break;
                    case "Junior":
                        price = 16;
                        break;
                    case "Adult":
                        price = 21;
                        break;
                    case "Profi":
                        price = 32;
                        break;
                }
            }

            if (fanCard=="yes")
            {
                price *= 0.80;
            }

            if (price<=insertedMoney)
            {
                Console.WriteLine($"You bought {typeCard} ticket for {laps} laps. Your change is {insertedMoney-price:f2}lv.");
            }
            else
            {
                Console.WriteLine($"You don't have enough money! You need {price-insertedMoney:f2}lv more.");
            }
        }
    }
}
