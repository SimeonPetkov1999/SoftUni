using System;
using System.Linq;

namespace _3.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = readMatrix();
            
            int maxSum = int.MinValue;
            int currentSum = 0;
            int maxRow = -1;
            int maxCol = -1;
            for (int row = 0; row < matrix.GetLength(0)-2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-2; col++)
                {
                    for (int srow = row; srow < row + 3; srow++)
                    {
                        for (int scol = col; scol < col + 3; scol++)
                        {
                            currentSum += matrix[srow, scol];
                        }
                    }

                    if (currentSum>maxSum)
                    {
                        maxSum = currentSum;
                        maxRow = row;
                        maxCol = col;
                    }
                    currentSum = 0;
                }
            }
            Console.WriteLine("Sum = " + maxSum);
            for (int row = maxRow; row < maxRow + 3; row++)
            {
                for (int col = maxCol; col < maxCol + 3; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
        private static int[,] readMatrix()
        {        
            var input = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();
            int rows = input[0];
            int cols = input[1];
            var matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
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
