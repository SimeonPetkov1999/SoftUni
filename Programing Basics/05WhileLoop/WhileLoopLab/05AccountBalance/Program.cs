using System;
using System.Reflection;

namespace _05AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double money = 0.0;
            double finalSum = 0.0;
            bool check = true;

            while (input!="NoMoreMoney")
            {
                money = double.Parse(input);
                if (money<0)
                {
                    Console.WriteLine("Invalid operation!");
                    Console.WriteLine($"Total: {finalSum:f2}");
                    check = false;
                    break;
                }

                finalSum += money;
                Console.WriteLine($"Increase: {money:f2}");
                input = Console.ReadLine();
            }
            if (check)
            {
                Console.WriteLine($"Total: {finalSum:f2}");
            }
            
            
        }
    }
}
