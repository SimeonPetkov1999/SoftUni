using System;
using System.Collections.Generic;

namespace _02.MinerTask
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, int> resources = new Dictionary<string, int>();

            while (true)
            {
                string currentResource = Console.ReadLine();
                if (currentResource=="stop")
                {
                    break;
                }
                int quantity = int.Parse(Console.ReadLine());

                if (!resources.ContainsKey(currentResource))
                {
                    resources.Add(currentResource, quantity);
                }
                else
                {
                    resources[currentResource] += quantity;
                }
            }

            foreach (var item in resources)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
