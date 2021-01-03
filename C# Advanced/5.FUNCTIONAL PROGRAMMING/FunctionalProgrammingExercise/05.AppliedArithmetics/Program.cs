using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], string ,int[]> changeArray = (array,command) =>
             {
                 if (command == "add")
                 {
                     return array.Select(x => x = x + 1).ToArray();
                 }
                 else if (command == "multiply")
                 {
                     return array.Select(x => x = x * 2).ToArray();
                 }
                 else if (command == "subtract")
                 {
                     return array.Select(x => x = x - 1).ToArray();
                 }
                 else
                 {
                     return null;
                 }
             };
 
            var numbers = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            while (true)
            {
                var command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }
                if (command=="print")
                {
                    Console.WriteLine(string.Join(" ",numbers));
                }
                else
                {
                    numbers = changeArray(numbers, command);
                }
               
            }
        }
    }
}
