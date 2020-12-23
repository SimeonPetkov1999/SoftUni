using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            var stackHistory = new Stack<string>();
            var CurrentText = string.Empty;
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var commandsArgs = Console.ReadLine().Split();
                string command = commandsArgs[0];
                if (command == "4")
                {
                    CurrentText = stackHistory.Pop();
                }
                else if (command == "1")
                {
                    var toAdd = commandsArgs[1];
                    stackHistory.Push(CurrentText);
                    CurrentText += toAdd;
                }
                else if (command == "2")
                {
                    var toErase = int.Parse(commandsArgs[1]);
                    stackHistory.Push(CurrentText);
                    CurrentText = CurrentText.Remove(CurrentText.Length - toErase);           
                }
                else if (command == "3")
                {
                    var index = int.Parse(commandsArgs[1]);
                    Console.WriteLine(CurrentText[index-1]);
                }
            }
        }
    }
}
