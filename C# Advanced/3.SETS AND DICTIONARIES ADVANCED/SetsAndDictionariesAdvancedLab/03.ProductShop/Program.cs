using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, Dictionary<string, double>>();

            var input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "Revision")
            {
                string shopName = input[0];
                string item = input[1];
                double price = double.Parse(input[2]);

                if (!dictionary.ContainsKey(shopName))
                {
                    dictionary.Add(shopName, new Dictionary<string, double>());
                    dictionary[shopName].Add(item, price);
                }
                else
                {
                    if (!dictionary[shopName].ContainsKey(item))
                    {
                        dictionary[shopName].Add(item, price);
                    }
                    else
                    {
                        dictionary[shopName][item] = price;//?
                    }
                }
                input = Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var (key, value) in dictionary.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{key}->");
                foreach (var (keyItem, valuePrice) in value)
                {
                    Console.WriteLine($"Product: {keyItem}, Price: {valuePrice}");
                }
            }
        }
    }
}