using System;

namespace _06EasterDecoration
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfClientsInTheShop = int.Parse(Console.ReadLine());
            string input;
            double priceForClient = 0.0;
            double finalPrice = 0.0;
            int numberOfPokupki = 0;

            for (int i = 0; i < numberOfClientsInTheShop; i++)
            {
                input = Console.ReadLine();

                while (input!="Finish")
                {
                   
                    switch (input)
                    {
                        case "basket":
                            priceForClient += 1.50;
                            break;
                        case "wreath":
                            priceForClient += 3.80;
                            break;
                        case "chocolate bunny":
                            priceForClient += 7.00;
                            break;
                    }
                    numberOfPokupki++;
                    input = Console.ReadLine();
                }

                if (numberOfPokupki % 2 == 0)
                {
                    priceForClient *= 0.80;
                }
                finalPrice += priceForClient;

                Console.WriteLine($"You purchased {numberOfPokupki} items for {priceForClient:f2} leva.");
                priceForClient = 0;
                numberOfPokupki = 0;
            }
            Console.WriteLine($"Average bill per client is: {finalPrice/numberOfClientsInTheShop:f2} leva.");
        }
    }
}
