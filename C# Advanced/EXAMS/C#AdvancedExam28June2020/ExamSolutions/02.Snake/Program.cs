using System;

namespace _02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Matrix and find needed Coordinates
            int size = int.Parse(Console.ReadLine());
            var matrix = new char[size, size];
            int snakeRow = -1;
            int snakeCol = -1;
            int burrowsFound = 0;
            int secondBurrowRow = -1;
            int secondBurrowCol = -1;
            for (int row = 0; row < size; row++)
            {
                var currentRow = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    if (currentRow[col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                    else if (currentRow[col] == 'B')
                    {
                        burrowsFound++;
                    }
                    if (currentRow[col] == 'B' && burrowsFound >= 1)
                    {
                        secondBurrowRow = row;
                        secondBurrowCol = col;
                    }
                    matrix[row, col] = currentRow[col];
                }
            }

            int foodEaten = 0;
            while (true)
            {
                var command = Console.ReadLine();
                matrix[snakeRow, snakeCol] = '.';
                switch (command)
                {
                    case "up":
                        snakeRow--;
                        break;
                    case "down":
                        snakeRow++;
                        break;
                    case "left":
                        snakeCol--;
                        break;
                    case "right":
                        snakeCol++;
                        break;
                }
                if (IsSnakeIsOutside(snakeRow, snakeCol, matrix))
                {
                    PrintGameOver(matrix, foodEaten);
                }
                if (matrix[snakeRow, snakeCol] == '*')
                {
                    foodEaten++;
                    if (foodEaten == 10)
                    {
                        PrintWonGame(matrix, snakeRow, snakeCol, foodEaten);
                    }
                }
                else if (matrix[snakeRow, snakeCol] == 'B')
                {
                    matrix[snakeRow, snakeCol] = '.';
                    snakeRow = secondBurrowRow;
                    snakeCol = secondBurrowCol;
                }
            }
        }

        private static void PrintWonGame(char[,] matrix, int snakeRow, int snakeCol, int foodEaten)
        {
            Console.WriteLine("You won! You fed the snake.");
            matrix[snakeRow, snakeCol] = 'S';
            Print(matrix, foodEaten);
            Environment.Exit(0);
        }

        private static void PrintGameOver(char[,] matrix, int foodEaten)
        {
            Console.WriteLine("Game over!");
            Print(matrix, foodEaten);
            Environment.Exit(0);
        }

        private static bool IsSnakeIsOutside(int snakeRow, int snakeCol, char[,] matrix)
        {
            if (snakeRow < 0 || snakeRow >= matrix.GetLength(0) ||
                snakeCol < 0 || snakeCol >= matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }

        private static void Print(char[,] matrix, int foodEaten)
        {
            Console.WriteLine($"Food eaten: {foodEaten}");
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
