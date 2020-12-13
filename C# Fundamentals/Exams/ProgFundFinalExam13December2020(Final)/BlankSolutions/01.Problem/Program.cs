using System;
using System.Linq;

namespace _01.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] commandArgs = Console.ReadLine().Split();//?
            while (commandArgs[0]!="End")
            {
                string command = commandArgs[0];

                if (command=="Translate")
                {
                    string ch = commandArgs[1];
                    string toReplace = commandArgs[2];
                    input = input.Replace(ch, toReplace);
                    Console.WriteLine(input);
                }
                else if (command =="Remove")
                {
                    int startIndex = int.Parse(commandArgs[1]);
                    int count = int.Parse(commandArgs[2]);
                    input = input.Remove(startIndex, count);
                    Console.WriteLine(input);
                }
                else if (command=="Includes")
                {
                    string toCheck = commandArgs[1];
                    if (input.Contains(toCheck))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (command=="Start")
                {
                    string toCheck = commandArgs[1];
                    int lenght = toCheck.Length;
                    string sub = input.Substring(0, lenght);
                    if (sub==toCheck)
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (command=="Lowercase")
                {
                    input = input.ToLower();
                    Console.WriteLine(input);
                }
                else if (command=="FindIndex")
                {
                    char ch = char.Parse(commandArgs[1]);
                    int index = input.LastIndexOf(ch);
                    Console.WriteLine(index);
                }
                commandArgs = Console.ReadLine().Split();//?
            }
        }
    }
}
