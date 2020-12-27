using System;
using System.Linq;

namespace _6.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            var array = new double[rows][];
            readArray(rows, array);
            analyzeArray(array);

            while (true)
            {
                var command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "End")
                {
                    printArray(array);
                    break;
                }
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                bool isValid = row >= 0 && row < rows && col >= 0 && col < array[row].Length;
                if (isValid)
                {
                    manipulateArray(array, command, row, col);
                }
            }
        }

        public static void manipulateArray(double[][] array, string[] command, int row, int col)
        {
            int value = int.Parse(command[3]);
            if (command[0] == "Add")
            {
                array[row][col] += value;
            }
            else if (command[0] == "Subtract")
            {
                array[row][col] -= value;
            }
        }

        public static void printArray(double[][] array) 
        {
            foreach (var row in array)
            {
                Console.WriteLine(string.Join(" ",row));
            }
        }
        public static void readArray(int rows, double[][] array)
        {
            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
                array[row] = currentRow;
            }
        }

        public static void analyzeArray(double[][] array)
        {
            for (int row = 0; row < array.GetLength(0) - 1; row++)
            {
                if (array[row].Length == array[row + 1].Length)
                {
                    array[row] = array[row].Select(n => n * 2).ToArray();
                    array[row + 1] = array[row + 1].Select(n => n * 2).ToArray();
                }
                else
                {
                    array[row] = array[row].Select(n => n / 2).ToArray();
                    array[row + 1] = array[row + 1].Select(n => n / 2).ToArray();
                }
            }
        }
    }
}
