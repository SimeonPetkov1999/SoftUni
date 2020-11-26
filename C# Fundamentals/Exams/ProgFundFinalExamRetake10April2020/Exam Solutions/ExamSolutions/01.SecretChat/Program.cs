using System;
using System.Linq;

namespace _01.SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();

            string[] commandArgs = Console.ReadLine()
                .Split(":|:", StringSplitOptions.RemoveEmptyEntries);

            while (commandArgs[0] != "Reveal")
            {
                string command = commandArgs[0];

                if (command=="InsertSpace")
                {
                    int index = int.Parse(commandArgs[1]);
                    inputLine = inputLine.Insert(index, " ");
                    Console.WriteLine(inputLine);
                }

                else if (command=="Reverse")
                {
                    string sub = commandArgs[1];
                    if (inputLine.Contains(sub))
                    {
                        int index = inputLine.IndexOf(sub);
                        int lenght = sub.Length;
                        inputLine= inputLine.Remove(index, lenght);
                        sub = ReverseString(sub);
                        inputLine= inputLine.Insert(inputLine.Length, sub);
                        Console.WriteLine(inputLine);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }

                else if (command =="ChangeAll")
                {
                    string substring = commandArgs[1];
                    string replacement = commandArgs[2];
                    inputLine = inputLine.Replace(substring, replacement);
                    Console.WriteLine(inputLine);
                }

                commandArgs = Console.ReadLine()
                .Split(":|:", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"You have a new text message: {inputLine}");
        }

        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

    }
}
