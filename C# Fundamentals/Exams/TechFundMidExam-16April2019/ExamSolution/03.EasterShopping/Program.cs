using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.EasterShopping
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shops = Console.ReadLine().Split().ToList();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split();

                switch (commands[0])
                {
                    case "Include":
                        string shop = commands[1];
                        shops.Add(shop);
                        break;
                    case "Visit":
                        string firstLast = commands[1];
                        int numberOfShops = int.Parse(commands[2]);

                        if (shops.Count >= numberOfShops)
                        {
                            if (firstLast == "first")
                            {
                                shops.RemoveRange(0, numberOfShops);
                            }

                            else if (firstLast == "last")
                            {
                                shops.RemoveRange(shops.Count - numberOfShops, numberOfShops);
                            }
                        }
                        break;
                    case "Prefer":
                        int index1 = int.Parse(commands[1]);
                        int index2 = int.Parse(commands[2]);

                        if ((index1 >= 0 && index1 <= shops.Count - 1) && ((index2 >= 0 && index2 <= shops.Count - 1)))
                        {
                            string temp = shops[index1];
                            shops[index1] = shops[index2];
                            shops[index2] = temp;
                        }
                        break;
                    case "Place":
                        int index = int.Parse(commands[2]);
                        index++;
                        if (index >= 0 && index <= shops.Count - 1)
                        {
                            shops.Insert(index, commands[1]);
                        }
                        break;
                }
            }
            Console.WriteLine("Shops left:");
            Console.WriteLine(string.Join(" ",shops));
        }
    }
}
