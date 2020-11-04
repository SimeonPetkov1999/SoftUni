using System;
using System.Collections.Generic;

namespace _04.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, CMyPrice> orders = new Dictionary<string, CMyPrice>();

            string[] command = Console.ReadLine().Split();

            while (command[0]!="buy")
            {
                string item = command[0];
                double price = double.Parse(command[1]);
                double quantity = double.Parse(command[2]);

                if (!orders.ContainsKey(item))
                {
                    orders.Add(item, new CMyPrice());
                    orders[item].Price = price;
                    orders[item].Quantity = quantity;
                }

                else
                {
                    orders[item].Price = price;
                    orders[item].Quantity += quantity;
                }
                command = Console.ReadLine().Split();
            }

            foreach (var item in orders)
            {
                Console.WriteLine($"{item.Key} -> {item.Value.calculate():f2}");
            }
        }
    }
    public class CMyPrice 
    {
        public double Price { get; set; }
        public double Quantity { get; set; }
        public double calculate()
        {
          return Price*Quantity;
        }
    }
}
