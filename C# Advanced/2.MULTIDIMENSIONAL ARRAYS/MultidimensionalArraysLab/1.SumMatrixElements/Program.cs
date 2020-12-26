using System;
using System.Linq;

namespace _1.SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = parseMatrix();

            int rows = input[0];
            int cols = input[1];
            var matrix = new int[rows, cols];
            int sum = 0;
            for (int row = 0; row < rows; row++)
            {
                var currentRow = parseMatrix();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                    sum += matrix[row, col];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);

            //for (int row = 0; row < matrix.GetLength(0); row++)
            //{
            //    for (int col = 0; col < matrix.GetLength(1); col++)
            //    {
            //        Console.Write(matrix[row,col]+" ");
            //    }
            //    Console.WriteLine();
            //}

        }

        private static int[] parseMatrix() => Console.ReadLine().Split(", ").Select(int.Parse).ToArray();


    }
}
