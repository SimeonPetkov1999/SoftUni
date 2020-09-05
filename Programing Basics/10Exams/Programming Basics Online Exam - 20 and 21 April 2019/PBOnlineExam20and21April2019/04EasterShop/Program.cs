using System;

namespace _04EasterShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfEggsInStore = int.Parse(Console.ReadLine());
            string BuyOrFill;
            int eggs;
            int lastEggs = 0;
            int eggsSold = 0;

            while (true)
            {
                BuyOrFill = Console.ReadLine();
                if (BuyOrFill == "Close")
                {
                    Console.WriteLine("Store is closed!");
                    Console.WriteLine($"{eggsSold} eggs sold.");
                    break;
                }
                eggs = int.Parse(Console.ReadLine());

                if (BuyOrFill == "Buy")
                {
                    lastEggs = numberOfEggsInStore;
                    numberOfEggsInStore =numberOfEggsInStore - eggs;
                    if (numberOfEggsInStore<0)
                    {
                        Console.WriteLine("Not enough eggs in store!");
                        Console.WriteLine($"You can buy only {lastEggs}.");
                        break;
                    }
                    eggsSold = eggsSold + eggs;
                }

                else
                {
                    numberOfEggsInStore += eggs;
                }

              

            }

        }
    }
}
