using System;

namespace _03FilmPremiere
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            string packet = Console.ReadLine();
            int numberOfTickets = int.Parse(Console.ReadLine());
            double price = 0.0;

            switch (packet)
            {
                case"Drink":
                    switch (movie)
                    {
                        case"John Wick":
                            price = 12.00;
                            break;
                        case"Star Wars":
                            price = 18.00;
                            break;
                        case "Jumanji":
                            price = 9.00;
                            break;
                    }
                    break;
                case "Popcorn":
                    switch (movie)
                    {
                        case "John Wick":
                            price = 15.00;
                            break;
                        case "Star Wars":
                            price = 25.00;
                            break;
                        case "Jumanji":
                            price = 11.00;
                            break;
                    }
                    break;
                case "Menu":
                    switch (movie)
                    {
                        case "John Wick":
                            price = 19.00;
                            break;
                        case "Star Wars":
                            price = 30.00;
                            break;
                        case "Jumanji":
                            price = 14.00;
                            break;
                    }
                    break;
            }

            double finalPrice = numberOfTickets * price;

            if (movie=="Star Wars" && numberOfTickets>=4)
            {
                finalPrice *= 0.70;
            }

            else if (movie=="Jumanji" && numberOfTickets==2)
            {
                finalPrice *= 0.85;
            }

            Console.WriteLine($"Your bill is {finalPrice:f2} leva.");
        }
    }
}
