using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.HelloFrance
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine()
                 .Split(new string[] { "->", "|" } ,StringSplitOptions.RemoveEmptyEntries)
                 .ToList();

            List<decimal> newPrices = new List<decimal>();

            decimal initialBudget = decimal.Parse(Console.ReadLine());
            decimal budget = initialBudget;

            for (int i = 0; i < items.Count; i+=2)
            {
                string type = items[i];
                decimal price = decimal.Parse(items[i + 1]);

                switch (type)
                {
                    case"Clothes":
                        if (price<=50.00m)
                        {
                            budget = addNewPrices(price, budget, newPrices);
                        }
                        break;
                    case "Shoes":
                        if (price<=35.00m)
                        {
                            budget = addNewPrices(price, budget, newPrices);
                        }
                        break;
                    case "Accessories":
                        if (price<=20.50m)
                        {
                            budget = addNewPrices(price, budget, newPrices);
                        }
                        break;
                }                
            }
            decimal profit = newPrices.Sum() - newPrices.Sum() / 1.40m;
            decimal newBudget = budget + newPrices.Sum();

            foreach (var item in newPrices)
            {
                Console.Write($"{item:f2} ");
            }
            Console.WriteLine();
            Console.WriteLine($"Profit: {profit:f2}");

            if (newBudget>=150)
            {
                Console.WriteLine("Hello, France!");
            }
            else
            {
                Console.WriteLine($"Time to go.");
            }
        }
        static decimal addNewPrices(decimal price, decimal budget, List<decimal> newPrices) 
        {
            if (budget - price >= 0)
            {               
                budget -= price;
                newPrices.Add(price * 1.40m);
            }
            return budget;
        }
    }
}
