using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ListManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string[] commandArgs = Console.ReadLine().Split();

            int blacklistedCount = 0;
            int lostCount = 0;
            while (commandArgs[0] != "Report")
            {
                string command = commandArgs[0];

                if (command == "Blacklist")
                {
                    string name = commandArgs[1];

                    if (names.Contains(name))
                    {
                        int index = names.IndexOf(name);
                        names[index] = "Blacklisted";
                        blacklistedCount++;
                        Console.WriteLine($"{name} was blacklisted.");
                    }
                    else
                    {
                        Console.WriteLine($"{name} was not found.");
                    }
                }

                else if (command == "Error")
                {
                    int index = int.Parse(commandArgs[1]);
                    if (names[index] != "Blacklisted" && names[index] != "Lost")
                    {
                        Console.WriteLine($"{names[index]} was lost due to an error.");
                        names[index] = "Lost";
                        lostCount++;
                    }
                }

                else if (command == "Change")
                {
                    int index = int.Parse(commandArgs[1]);
                    string newName = commandArgs[2];
                    if (index>=0 && index<=names.Count-1)
                    {
                        Console.WriteLine($"{names[index]} changed his username to {newName}.");
                        names[index] = newName;
                    }
                }
                commandArgs = Console.ReadLine().Split();
            }

            Console.WriteLine($"Blacklisted names: {blacklistedCount}");
            Console.WriteLine($"Lost names: {lostCount}");
            Console.WriteLine(string.Join(" ",names));
        }
    }
}
