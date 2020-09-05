using System;

namespace _05SmallShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string item = Console.ReadLine();
            string city = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            double price;

            switch (city)
            {
                case "Sofia":
                    switch (item)
                    {
                        case "coffee":
                            price = 0.50;
                            break;
                        case "water":
                            price = 0.80;
                            break;
                        case "beer":
                            price = 1.20;
                            break;
                        case "sweets":
                                price = 1.45;
                            break;
                        default:
                            price = 1.60;
                            break;
                    }
                    break;
                case "Plovdiv":
                    switch (item)
                    {
                        case "coffee":
                            price = 0.40;
                            break;
                        case "water":
                            price = 0.70;
                            break;
                        case "beer":
                            price = 1.15;
                            break;
                        case "sweets":
                            price = 1.30;
                            break;
                        default:
                            price = 1.50;
                            break;
                    }
                    break;
                default:
                    switch (item)
                    {
                        case "coffee":
                            price = 0.45;
                            break;
                        case "water":
                            price = 0.70;
                            break;
                        case "beer":
                            price = 1.10;
                            break;
                        case "sweets":
                            price = 1.35;
                            break;
                        default:
                            price = 1.55;
                            break;
                    }
                    break;

            }

            Console.WriteLine($"{quantity*price}");
        }
    }
}
