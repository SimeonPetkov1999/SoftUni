using System;
using System.Linq;

namespace _5.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            var snake = Console.ReadLine();
            var matrix = new char[rows, cols];

            int snakeIndex = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if ((row + 1) % 2 != 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        snakeIndex = addChar(snake, matrix, snakeIndex, row, col);
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1)-1; col>= 0; col--)
                    {
                        snakeIndex = addChar(snake, matrix, snakeIndex, row, col);
                    }
                }
            }
            printMatrix(matrix);                   
        }

        private static int addChar(string snake, char[,] matrix, int snakeIndex, int row, int col)
        {
            matrix[row, col] = snake[snakeIndex];
            snakeIndex++;
            if (snakeIndex == snake.Length)
            {
                snakeIndex = 0;
            }
            return snakeIndex;
        }

        public static void printMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
