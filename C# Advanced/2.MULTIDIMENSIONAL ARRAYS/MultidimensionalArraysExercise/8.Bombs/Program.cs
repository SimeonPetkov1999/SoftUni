using System;
using System.Linq;

namespace _8.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            var matrix = new int[size, size];
            readMatrix(size, matrix);
            var bombsCoordinates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < bombsCoordinates.Length; i++)
            {
                var currentBomb = bombsCoordinates[i]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                var BRow = currentBomb[0];
                var BCol = currentBomb[1];
                //detonateBomb(BRow, BCol, matrix);
            }
            int activeCells = 0;
            int sum = 0;
            foreach (var item in matrix)
            {
                if (item > 0)
                {
                    activeCells++;
                    sum += item;
                }
            }
            Console.WriteLine($"Alive cells: {activeCells}");
            Console.WriteLine($"Sum: {sum}");
            printMatrix(matrix);
        }

       

        public static void readMatrix(int size, int[,] matrix)
        {
            for (int row = 0; row < size; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }
        public static void printMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }


        //public static void detonateBomb(int row, int col, int[,] matrix)
        //{
        //    int bombValue = matrix[row, col];
        //    //all sides in matrix
        //    if (row > 0 &&
        //        row < matrix.GetLength(0) - 1 &&
        //        col > 0 && col < matrix.GetLength(1) - 1 &&
        //        bombValue != 0)
        //    {
        //        for (int currentRol = row - 1; currentRol <= row + 1; currentRol++)
        //        {
        //            for (int currentCol = col - 1; currentCol <= col + 1; currentCol++)
        //            {
        //                if (matrix[currentRol, currentCol] > 0)
        //                {
        //                    matrix[currentRol, currentCol] -= bombValue;
        //                }
        //            }
        //        }
        //        matrix[row, col] = 0;
        //       // printMatrix(matrix);
        //        //left side
        //    }
        //    else if (row > 0 &&
        //             row < matrix.GetLength(0) - 1 &&
        //             col == 0 &&
        //             col < matrix.GetLength(1) - 1 &&
        //             bombValue != 0)
        //    {
        //        for (int currentRol = row - 1; currentRol <= row + 1; currentRol++)
        //        {
        //            for (int currentCol = col; currentCol <= col + 1; currentCol++)
        //            {
        //                if (matrix[currentRol, currentCol] > 0)
        //                {
        //                    matrix[currentRol, currentCol] -= bombValue;
        //                }
        //            }
        //        }
        //        matrix[row, col] = 0;
        //        //printMatrix(matrix);
        //    }
        //    //top rigth
        //    else if (row == 0 &&
        //             col ==matrix.GetLength(1)-1 &&
        //             bombValue != 0)
        //    {
        //        for (int currentRol = row; currentRol <= row+1; currentRol++)
        //        {
        //            for (int currentCol = col - 1; currentCol < matrix.GetLength(0); currentCol++)
        //            {
        //                if (matrix[currentRol, currentCol] > 0)
        //                {
        //                    matrix[currentRol, currentCol] -= bombValue;
        //                }
        //            }
        //        }
        //        matrix[row, col] = 0;
        //       // printMatrix(matrix);
        //    }
        //    //bottom right
        //    else if (row == matrix.GetLength(0)-1 &&
        //             col == matrix.GetLength(1)-1 &&
        //             bombValue != 0)
        //    {
        //        for (int currentRol = row-1; currentRol <= row; currentRol++)
        //        {
        //            for (int currentCol = col - 1; currentCol < matrix.GetLength(1); currentCol++)
        //            {
        //                if (matrix[currentRol, currentCol] > 0)
        //                {
        //                    matrix[currentRol, currentCol] -= bombValue;
        //                }
        //            }
        //        }
        //        matrix[row, col] = 0;
        //       // printMatrix(matrix);
        //    }
        //    //top left
        //    else if (row == 0 &&
        //             col == 0 &&
        //             bombValue != 0)
        //    {
        //        for (int currentRol = row; currentRol <= row+1; currentRol++)
        //        {
        //            for (int currentCol = col; currentCol <= col+1; currentCol++)
        //            {
        //                if (matrix[currentRol, currentCol] > 0)
        //                {
        //                    matrix[currentRol, currentCol] -= bombValue;
        //                }
        //            }
        //        }
        //        matrix[row, col] = 0;
        //        // printMatrix(matrix);
        //    }
        //    //bottom left
        //    else if (row == matrix.GetLength(0)-1 &&
        //             col == matrix.GetLength(1)-1 &&
        //             bombValue != 0)
        //    {
        //        for (int currentRol = row-1; currentRol <= row; currentRol++)
        //        {
        //            for (int currentCol = col; currentCol <= col + 1; currentCol++)
        //            {
        //                if (matrix[currentRol, currentCol] > 0)
        //                {
        //                    matrix[currentRol, currentCol] -= bombValue;
        //                }
        //            }
        //        }
        //        matrix[row, col] = 0;
        //        // printMatrix(matrix);
        //    }
        //    //top
        //    else if (row == 0 &&
        //             col >= 1 &&
        //             bombValue != 0)
        //    {
        //        for (int currentRol = row; currentRol <= row+1; currentRol++)
        //        {
        //            for (int currentCol = col-1; currentCol <= col + 1; currentCol++)
        //            {
        //                if (matrix[currentRol, currentCol] > 0)
        //                {
        //                    matrix[currentRol, currentCol] -= bombValue;
        //                }
        //            }
        //        }
        //        matrix[row, col] = 0;
        //        // printMatrix(matrix);
        //    }


        //}
    }
}
