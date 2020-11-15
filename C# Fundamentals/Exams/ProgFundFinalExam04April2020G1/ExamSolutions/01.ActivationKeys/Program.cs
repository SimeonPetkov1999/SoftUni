using System;
using System.Text;

namespace _01.ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            string activationKey = Console.ReadLine();
            string[] commandArgs = Console.ReadLine()
                .Split(">>>", StringSplitOptions.RemoveEmptyEntries);

            while (commandArgs[0] != "Generate")
            {
                string command = commandArgs[0];
                if (command == "Contains")
                {
                    string substring = commandArgs[1];

                    if (activationKey.Contains(substring))
                    {
                        Console.WriteLine($"{activationKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (command == "Flip")
                {
                    string type = commandArgs[1];
                    int startIndex = int.Parse(commandArgs[2]);
                    int endIndex = int.Parse(commandArgs[3]);
                    sb.Append(activationKey);

                    if (type == "Upper")
                    {
                        for (int i = startIndex; i < endIndex; i++)
                        {
                            sb[i] = char.ToUpper(sb[i]);
                        }
                    }
                    else if (type == "Lower")
                    {
                        for (int i = startIndex; i < endIndex; i++)
                        {
                            sb[i] = char.ToLower(sb[i]);
                        }
                    }
                    activationKey = sb.ToString();
                    sb.Clear();
                    Console.WriteLine(activationKey);
                }

                else if (command == "Slice")
                {
                    int startIndex = int.Parse(commandArgs[1]);
                    int endIndex = int.Parse(commandArgs[2]);
                    int lenght = endIndex - startIndex;

                    activationKey = activationKey.Remove(startIndex, lenght);
                    Console.WriteLine(activationKey);
                }
                commandArgs = Console.ReadLine()
                .Split(">>>", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"Your activation key is: {activationKey}");

        }
    }
}
