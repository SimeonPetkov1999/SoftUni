using System;
using System.Linq;

namespace _5.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = parseMatrix();

            int rows = input[0];
            int cols = input[1];
            var matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = parseMatrix();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int maxRow = 0;
            int maxCol = 0;
            int sum = int.MinValue;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    if (matrix[row, col] +
                        matrix[row, col + 1] +
                        matrix[row + 1, col] +
                        matrix[row + 1, col + 1] > sum)
                    {
                        maxRow = row;
                        maxCol = col;
                        sum = matrix[row, col] +
                             matrix[row, col + 1] +
                            matrix[row + 1, col] +
                           matrix[row + 1, col + 1];
                    }
                }
            }

            Console.WriteLine($"{matrix[maxRow, maxCol]} {matrix[maxRow, maxCol + 1]}");
            Console.WriteLine($"{matrix[maxRow + 1, maxCol]} {matrix[maxRow + 1, maxCol + 1]}");
            Console.WriteLine(sum);
        }

        private static int[] parseMatrix()
            => Console.ReadLine()
            .Split(", ")
            .Select(int.Parse)
            .ToArray();
    }
}
