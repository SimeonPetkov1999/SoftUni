using System;
using System.Globalization;
using System.Linq;

namespace _1.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            var matrix = new int[size, size];
            readMatrix(size, matrix);

            int primaryDiagonal = primarySum(matrix);
            int secondaryDiagonal = secondarySum(matrix);
            Console.WriteLine(Math.Abs(primaryDiagonal-secondaryDiagonal));
            ;
        }

        private static int secondarySum(int[,] matrix)
        {
            int index = matrix.GetLength(0)-1;
            int sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = matrix.GetLength(1)-1; col >= 0 ; col--)
                {
                    if (col == index)
                    {
                        sum += matrix[row, col];
                        index--;
                        break;
                    }
                }
            }
            return sum;
        }
        private static int primarySum(int[,] matrix)
        {
            int index = 0;
            int sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col == index)
                    {
                        sum += matrix[row, col];
                        index++;
                        break;
                    }
                }
            }
            return sum;
        }

        private static void readMatrix(int size, int[,] matrix)
        {
            for (int row = 0; row < size; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }
    }
}
