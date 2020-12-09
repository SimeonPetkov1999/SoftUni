using System;
using System.Linq;

namespace _01.TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] commandArgs = Console.ReadLine().Split("|");

            while (commandArgs[0]!="Decode")
            {
                string command = commandArgs[0];
                if (command=="Move")
                {
                    int numOfLetters = int.Parse(commandArgs[1]);
                    string removed = input.Substring(0, numOfLetters);
                    input = input.Insert(input.Length,removed);
                    input = input.Remove(0, numOfLetters);
                }
                else if (command=="Insert")
                {
                    int index = int.Parse(commandArgs[1]);
                    string value = commandArgs[2];
                    input = input.Insert(index, value);
                }
                else if (command=="ChangeAll")
                {
                    string toChange = commandArgs[1];
                    string replacement = commandArgs[2];
                    input = input.Replace(toChange, replacement);
                }
                commandArgs = Console.ReadLine().Split("|");
            }

            Console.WriteLine($"The decrypted message is: {input}");
        }
    }
}
