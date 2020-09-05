using Microsoft.VisualBasic;
using System;

namespace _03MobileOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            string lenghtOfContract = Console.ReadLine();
            string typeOfContract = Console.ReadLine();
            string internet = Console.ReadLine();
            int numberOfMonths = int.Parse(Console.ReadLine());

            double priceForMounth = 0.0;


            if (lenghtOfContract=="one")
            {
                switch (typeOfContract)
                {
                    case "Small":
                        priceForMounth = 9.98;
                        break;
                    case "Middle":
                        priceForMounth = 18.99;
                        break;
                    case "Large":
                        priceForMounth = 25.98;
                        break;
                    default:
                        priceForMounth = 35.99;
                        break;
                }
            }

            else
            {
                switch (typeOfContract)
                {
                    case "Small":
                        priceForMounth = 8.58;
                        break;
                    case "Middle":
                        priceForMounth = 17.09;
                        break;
                    case "Large":
                        priceForMounth = 23.59;
                        break;
                    default:
                        priceForMounth = 31.79;
                        break;
                }
            }

            if (internet=="yes")
            {
                if (priceForMounth<=10)
                {
                    priceForMounth += 5.50;
                }

                else if (priceForMounth<=30)
                {
                    priceForMounth += 4.35;
                }

                else if (priceForMounth>30)
                {
                    priceForMounth += 3.85;
                }
            }

            double finnalPrice = priceForMounth * numberOfMonths;

            if (lenghtOfContract=="two")
            {
                finnalPrice = finnalPrice - (finnalPrice * 0.0375);
            }

            Console.WriteLine($"{finnalPrice:f2} lv.");
        }
    }
}
