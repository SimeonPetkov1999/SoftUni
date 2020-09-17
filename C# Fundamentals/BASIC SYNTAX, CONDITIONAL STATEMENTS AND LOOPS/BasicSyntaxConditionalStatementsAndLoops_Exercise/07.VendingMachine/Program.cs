using System;

namespace _07.VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputCoins = Console.ReadLine();
            double money = 0;
            double coin = 0;

            while (inputCoins != "Start")
            {
                coin = double.Parse(inputCoins);
                bool AcceptedCoins = coin == 0.1 || coin == 0.2 || coin == 0.5 || coin == 1 || coin == 2;
                if (!AcceptedCoins)
                {
                    Console.WriteLine($"Cannot accept {coin}");
                    inputCoins = Console.ReadLine();
                    continue;
                }
                money += coin;
                inputCoins = Console.ReadLine();
            }
            string inputProduct = Console.ReadLine();
            double price = 0;
            while (inputProduct != "End")
            {
                switch (inputProduct)
                {
                    case "Nuts":
                        price = 2.0;
                        break;
                    case "Water":
                        price = 0.7;
                        break;
                    case "Crisps":
                        price = 1.5;
                        break;
                    case "Soda":
                        price = 0.8;
                        break;
                    case "Coke":
                        price = 1.0;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        inputProduct = Console.ReadLine();
                        continue;
                }
                if ((money - price) >= 0)
                {
                    Console.WriteLine($"Purchased {inputProduct.ToLower()}");
                }
                else
                {
                    Console.WriteLine($"Sorry, not enough money");
                    inputProduct = Console.ReadLine();
                    continue;
                }
                money -= price;
                inputProduct = Console.ReadLine();
            }
            Console.WriteLine($"Change: {money:f2}");
        }
    }
}
