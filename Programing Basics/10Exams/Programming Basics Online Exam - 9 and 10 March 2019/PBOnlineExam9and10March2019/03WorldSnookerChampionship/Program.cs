using System;

namespace _03WorldSnookerChampionship
{
    class Program
    {
        static void Main(string[] args)
        {
            string stage = Console.ReadLine();
            string typeOfTicket = Console.ReadLine();
            int numberOfTickets = int.Parse(Console.ReadLine());
            char trohpyPic = char.Parse(Console.ReadLine());
            double price = 0.0;

            if (typeOfTicket == "Standard")
            {
                switch (stage)
                {
                    case "Quarter final":
                        price = 55.50;
                        break;
                    case "Semi final":
                        price = 75.88;
                        break;
                    case "Final":
                        price = 110.10;
                        break;
                }
            }

            else if (typeOfTicket == "Premium")
            {
                switch (stage)
                {
                    case "Quarter final":
                        price = 105.20;
                        break;
                    case "Semi final":
                        price = 125.22;
                        break;
                    case "Final":
                        price = 160.66;
                        break;
                }
            }

            else if (typeOfTicket == "VIP")
            {
                switch (stage)
                {
                    case "Quarter final":
                        price = 118.90;
                        break;
                    case "Semi final":
                        price = 300.40;
                        break;
                    case "Final":
                        price = 400.0;
                        break;
                }
            }

            double finalPrice = price * numberOfTickets;
            bool noTrophy = false;

            if (finalPrice > 4000)
            {
                finalPrice *= 0.75;
                trohpyPic='N';

            }
            else if (finalPrice > 2500 && finalPrice <= 4000)
            {
                finalPrice *= 0.90;
            }
            if (trohpyPic == 'Y')
            {
                finalPrice += numberOfTickets * 40;
            }
                Console.WriteLine($"{finalPrice:f2}");
        }
    }
}
