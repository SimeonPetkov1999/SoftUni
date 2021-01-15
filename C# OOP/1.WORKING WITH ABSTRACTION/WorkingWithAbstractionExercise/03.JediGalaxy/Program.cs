using System;
using System.Linq;

namespace WorkingWithAbstractionExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizeOfMatrix = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var rows = sizeOfMatrix[0];
            var cols = sizeOfMatrix[1];
            var matrix = ReadMatrix(rows, cols);
            var sum = 0l;

            while (true)
            {
                var jediCoordinates = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (jediCoordinates[0] == "Let")
                {
                    break;
                }
                var evilCoordinates = Console.ReadLine()
                   .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (evilCoordinates[0] == "Let")
                {
                    break;
                }
                EvilTurn(matrix, evilCoordinates);
                sum = JediSumOfStart(matrix, sum, jediCoordinates);
            }
            Console.WriteLine(sum);
        }

        public static long JediSumOfStart(int[,] matrix, long sum, string[] jediCoordinates)
        {
            var jediRow = int.Parse(jediCoordinates[0]);
            var jediCol = int.Parse(jediCoordinates[1]);
            while (jediRow >= 0 && jediCol < matrix.GetLength(1))
            {
                if (jediRow >= 0 && jediRow < matrix.GetLength(0) && jediCol >= 0 && jediCol < matrix.GetLength(1))
                {
                    sum += matrix[jediRow, jediCol];
                }
                jediRow--;
                jediCol++;
            }

            return sum;
        }

        public static void EvilTurn(int[,] matrix, string[] evilCoordinates)
        {
            var evilRow = int.Parse(evilCoordinates[0]);
            var evilCol = int.Parse(evilCoordinates[1]);

            while (evilRow >= 0 && evilCol >= 0)//?
            {
                if (evilRow >= 0 && evilRow < matrix.GetLength(0) && evilCol >= 0 && evilCol < matrix.GetLength(1))
                {
                    matrix[evilRow, evilCol] = 0;
                }
                evilRow--;
                evilCol--;
            }
        }

        public static int[,] ReadMatrix(int rows, int cols)
        {
            var matrix = new int[rows, cols];
            var num = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = num++;
                }
            }
            return matrix;
        }
    }
}
