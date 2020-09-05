using System;

namespace _03EnergyBooster
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string packetType = Console.ReadLine();
            int packetNumber = int.Parse(Console.ReadLine());

            double priceForPackets = 0.00;
            double FinalPrice;
            double discount;

            if (fruit == "Watermelon")
            {
                if (packetType == "small")
                {
                    priceForPackets = (2 * 56);
                    priceForPackets = priceForPackets * packetNumber;
                }

                else
                {
                    priceForPackets = 5 * 28.70;
                    priceForPackets = priceForPackets * packetNumber;
                }
            }

            else if (fruit == "Mango")
            {
                if (packetType == "small")
                {
                    priceForPackets = 2 * 36.66;
                    priceForPackets = priceForPackets * packetNumber;
                }

                else
                {
                    priceForPackets = 5 * 19.60;
                    priceForPackets = priceForPackets * packetNumber;
                }
            }

            else if (fruit == "Pineapple")
            {
                if (packetType == "small")
                {
                    priceForPackets = 2 * 42.10;
                    priceForPackets = priceForPackets * packetNumber;
                }

                else
                {
                    priceForPackets = 5 * 24.80;
                    priceForPackets = priceForPackets * packetNumber;
                }
            }

            else if (fruit == "Raspberry")
            {
                if (packetType == "small")
                {
                    priceForPackets = 2 * 20;
                    priceForPackets = priceForPackets * packetNumber;
                }

                else
                {
                    priceForPackets = 5 * 15.20;
                    priceForPackets = priceForPackets * packetNumber;
                }
            }

            if (priceForPackets >= 400 && priceForPackets <= 1000)
            {
                discount = 0.15;
                FinalPrice = priceForPackets - (priceForPackets * discount);
                Console.WriteLine($"{FinalPrice:f2} lv.");
            }

            else if (priceForPackets > 1000)
            {
                discount = 0.5;
                FinalPrice = priceForPackets - (priceForPackets * discount);
                Console.WriteLine($"{FinalPrice:f2} lv.");
            }

            else
            {
                Console.WriteLine($"{priceForPackets:f2} lv.");
            }
        }
    }
}
