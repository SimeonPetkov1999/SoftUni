using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string[] command = Console.ReadLine()
                .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0]!="Craft!")
            {
                if (command[0]=="Collect")
                {
                    string item = command[1];
                    if (!items.Contains(item))
                    {
                        items.Add(item);
                    }
                }
                else if (command[0]=="Drop")
                {
                    string item = command[1];
                    if (items.Contains(item))
                    {
                        items.Remove(item);
                    }
                }

                else if (command[0]=="Renew")
                {
                    string item = command[1];
                    if (items.Contains(item))
                    {           
                        items.Remove(item);
                        items.Add(item);
                    }
                }            
                else
                {
                    string[] newCommand = command[1].Split(":", StringSplitOptions.RemoveEmptyEntries);
                    string oldItem = newCommand[0];
                    string newItem = newCommand[1];

                    if (items.Contains(oldItem))
                    {
                        int index = items.IndexOf(oldItem);
                        items.Insert(++index, newItem);
                    }
                }
                command = Console.ReadLine()
                .Split(" - ", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(string.Join(", ",items));
        }
    }
}
