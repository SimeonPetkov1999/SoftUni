using System;

namespace _05.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string order = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            Calculate(order, quantity);
        }
        static void Calculate(string order, double quantity) 
        {
            switch (order)
            {
                case"coffee":
                    Console.WriteLine($"{quantity*1.50:f2}");
                    break;
                case "water":
                    Console.WriteLine($"{quantity * 1.00:f2}");
                    break;
                case "coke":
                    Console.WriteLine($"{quantity * 1.40:f2}");
                    break;
                case "snacks":
                    Console.WriteLine($"{quantity * 2.00:f2}");
                    break;
            }
        }
    }
}
