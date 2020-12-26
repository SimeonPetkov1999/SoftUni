using System;
using System.Linq;

namespace _6.JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            var jaggArray = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine().Split()
                    .Select(int.Parse)
                    .ToArray();
                jaggArray[row] = currentRow;
            }

            var commandArgs = Console.ReadLine().Split();
            while (commandArgs[0] != "END")
            {
                int row = int.Parse(commandArgs[1]);
                int col = int.Parse(commandArgs[2]);
                int value = int.Parse(commandArgs[3]);
                //if (commandArgs[0] == "Add")
                //{
                //    try
                //    {
                //        jaggArray[row][col] += value;
                //    }
                //    catch (IndexOutOfRangeException)
                //    {
                //        Console.WriteLine("Invalid coordinates");  
                //    }
                //}
                //else if (commandArgs[0] == "Subtract")
                //{
                //    try
                //    {
                //        jaggArray[row][col] -= value;
                //    }
                //    catch (IndexOutOfRangeException)
                //    {
                //        Console.WriteLine("Invalid coordinates");
                //    }
                //}
                if (row < 0
                    || row >= rows
                    || col < 0
                    || col >= jaggArray[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else if (commandArgs[0] == "Add")
                {
                    jaggArray[row][col] += value;
                }
                else if (commandArgs[0] == "Subtract")
                {
                    jaggArray[row][col] -= value;
                }
                commandArgs = Console.ReadLine().Split();
            }

            foreach (var item in jaggArray)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
