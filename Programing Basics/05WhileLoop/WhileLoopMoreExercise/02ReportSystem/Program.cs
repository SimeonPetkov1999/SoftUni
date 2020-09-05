using System;

namespace _02ReportSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetMoney = int.Parse(Console.ReadLine());
            double allMoney = 0;

            int cashMoneyBr = 0;
            double allCashMoeny = 0;
            int cardMoneyBr = 0;
            double allCardMoney = 0;
            string input;



            while (true)
            {

                input = Console.ReadLine();
                if (input == "End")
                {

                    Console.WriteLine("Failed to collect required money for charity.");
                    Environment.Exit(0);
                }
                int cashMoney = int.Parse(input);

                if (cashMoney <= 100)
                {
                    cashMoneyBr++;
                    allCashMoeny += cashMoney;
                    allMoney += cashMoney;
                    Console.WriteLine("Product sold!");
                }
                else
                {
                    Console.WriteLine("Error in transaction!");
                }

                int cardMoney = int.Parse(Console.ReadLine());

                if (cardMoney >= 10)
                {
                    cardMoneyBr++;
                    allCardMoney += cardMoney;
                    allMoney += cardMoney;
                    Console.WriteLine("Product sold!");
                }
                else
                {
                    Console.WriteLine("Error in transaction!");
                }



                if (allMoney >= targetMoney)
                {
                    double cashAverage = allCashMoeny / cashMoneyBr;
                    double cardAverage = allCardMoney / cardMoneyBr;
                    Console.WriteLine($"Average CS: {cashAverage:f2}");
                    Console.WriteLine($"Average CC: {cardAverage:f2}");
                    Environment.Exit(0);
                }

            }

        }
    }
}
