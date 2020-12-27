using System;
using System.Linq;

namespace _4.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToArray();

            int rows = input[0];
            int cols = input[1];
            var matrix = readMatrix(rows, cols);

            var commandArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (commandArgs[0]!="END")
            {
                if (isValid(commandArgs,matrix))
                {
                    printMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                commandArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public static void printMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]+" ");
                }
                Console.WriteLine();
            }
        }

        public static bool isValid(string[] commandArgs, string[,] matrix) 
        {
            if (commandArgs.Length==5)
            {
                string command = commandArgs[0];
                int row1 = int.Parse(commandArgs[1]);
                int col1 = int.Parse(commandArgs[2]);
                int row2 = int.Parse(commandArgs[3]);
                int col2 = int.Parse(commandArgs[4]);

                if (command != "swap" ||
               row1 < 0 ||
               row1 >= matrix.GetLength(0) ||
               col1 < 0 ||
               col1 >= matrix.GetLength(1) ||
               row2 < 0 ||
               row2 >= matrix.GetLength(0) ||
               col2 < 0 ||
               col2 >= matrix.GetLength(1))
                {
                    return false;
                }
                else
                {
                    string temp = matrix[row1, col1];
                    matrix[row1, col1] = matrix[row2, col2];
                    matrix[row2, col2] = temp;
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public static string[,] readMatrix(int rows, int cols)
        {
            var matrix = new string[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            return matrix;
        }
    }
}
