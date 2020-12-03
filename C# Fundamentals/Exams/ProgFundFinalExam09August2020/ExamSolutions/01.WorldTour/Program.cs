using System;

namespace _01.WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] commandArgs = Console.ReadLine().Split(":");
            while (commandArgs[0] != "Travel")
            {
                string command = commandArgs[0];
                if (command == "Add Stop")
                {
                    int index = int.Parse(commandArgs[1]);
                    string str = commandArgs[2];
                    if (index >= 0 && index < input.Length)
                    {
                        input = input.Insert(index, str);
                    }
                    Console.WriteLine(input);
                }
                else if (command == "Remove Stop")
                {
                    int startIndex = int.Parse(commandArgs[1]);
                    int endIndex = int.Parse(commandArgs[2]);
                    bool isValid = (startIndex >= 0 && startIndex < input.Length) && (endIndex >= 0 && endIndex < input.Length);
                    if (isValid)
                    {
                        input = input.Remove(startIndex, endIndex - startIndex+1);
                    }
                    Console.WriteLine(input);
                }
                else if (command == "Switch")
                {
                    string oldString = commandArgs[1];
                    string newString = commandArgs[2];
                    input = input.Replace(oldString, newString);
                    Console.WriteLine(input);
                }
                commandArgs = Console.ReadLine().Split(":");
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {input}");
        }
    }
}
