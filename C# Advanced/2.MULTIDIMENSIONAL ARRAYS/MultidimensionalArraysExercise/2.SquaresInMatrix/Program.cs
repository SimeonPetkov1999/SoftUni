using System;
using System.Linq;

namespace _2.SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];
            int cols = input[1];
            var matrix = new string[rows, cols];
            ReadMatrix(rows, cols, matrix);

            int squares = NumberOfSquares(rows, cols, matrix);
            Console.WriteLine(squares);
        }

        private static int NumberOfSquares(int rows, int cols, string[,] matrix)
        {
            int num = 0;
            for (int row = 0; row < rows-1; row++)
            {
                for (int col = 0;  col < cols-1;  col++)
                {
                    bool checkFirstLine = matrix[row, col] == matrix[row, col + 1];
                    bool checkSecondLine = matrix[row + 1, col] == matrix[row + 1, col + 1];
                    bool checkForEqual = matrix[row, col] == matrix[row + 1, col];
                    if (checkFirstLine && checkSecondLine&& checkForEqual)
                    {
                        num++;
                    }
                }
            }
            return num;
        }

        private static void ReadMatrix(int rows, int cols, string[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                var currentLine = Console.ReadLine()
                    .Split();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentLine[col];
                }
            }
        }
    }
}
