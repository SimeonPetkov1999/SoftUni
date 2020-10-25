using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split('!', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string[] input = Console.ReadLine().Split().ToArray();

            while (input[0] != "Go")
            {
                if (input[0] == "Urgent")
                {
                    string item = input[1];
                    if (!list.Contains(item))
                    {
                        list.Insert(0, item);
                    }
                }

                else if (input[0] == "Unnecessary")
                {
                    string item = input[1];
                    if (list.Contains(item))
                    {
                        list.Remove(item);
                    }
                }

                else if (input[0] == "Correct")
                {
                    string oldItem = input[1];
                    string newitem = input[2];

                    if (list.Contains(oldItem))
                    {
                        int index = list.IndexOf(oldItem);
                        list[index] = newitem;
                    }
                }

                else if (input[0] == "Rearrange")
                {
                    string item = input[1];
                    if (list.Contains(item))
                    {
                        list.Remove(item);
                        list.Add(item);
                    }
                }

                input = Console.ReadLine().Split().ToArray();
            }

            Console.WriteLine(string.Join(", ", list));
        }
    }
}
