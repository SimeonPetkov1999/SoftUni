using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var stackOfNums = new Stack<int>(numbers);

            var command = Console.ReadLine().Split();
            while (command[0].ToLower()!= "end")
            {
                if (command[0].ToLower() == "add")
                {
                    stackOfNums.Push(int.Parse(command[1]));
                    stackOfNums.Push(int.Parse(command[2]));
                }
                else if (command[0].ToLower()=="remove")
                {
                    var toRemove = int.Parse(command[1]);
                    if (toRemove<=stackOfNums.Count)
                    {
                        for (int i = 0; i < toRemove; i++)
                        {
                            stackOfNums.Pop();
                        }
                    }
                }
                command = Console.ReadLine().Split();
            }

            Console.WriteLine($"Sum: {stackOfNums.Sum()}");
        }
    }
}
