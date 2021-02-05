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
            int firstBurrowRow = -1;
            int firstBurrowCol = -1;
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
                    else if (currentRow[col] == 'B' && firstBurrowRow == -1)
                    {
                        firstBurrowRow = row;
                        firstBurrowCol = col;
                    }
                    else if (currentRow[col] == 'B' && firstBurrowRow != -1)
                    {
                        secondBurrowRow = row;
                        secondBurrowCol = col;
                    }
                    matrix[row, col] = currentRow[col];
                }
            }
            // ------------------------------------------

            int foodEaten = 0;

            while (true)
            {
                var command = Console.ReadLine();
                if (command == "up")
                {
                    if (IsPossibleToMoveUp(snakeRow))
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        if (matrix[snakeRow - 1, snakeCol] == '*')
                        {
                            foodEaten++;
                            snakeRow--;
                        }
                        else if (matrix[snakeRow - 1, snakeCol] == 'B')
                        {
                            matrix[snakeRow - 1, snakeCol] = '.';
                            snakeRow = secondBurrowRow;
                            snakeCol = secondBurrowCol;
                        }
                        else
                        {
                            snakeRow--;
                        }                     
                    }
                    else
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        break;
                    }
                }
                else if (command == "down")
                {
                    if (IsPossibleToMoveDown(snakeRow, size))
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        if (matrix[snakeRow + 1, snakeCol] == '*')
                        {
                            foodEaten++;
                            snakeRow++;
                        }
                        else if (matrix[snakeRow + 1, snakeCol] == 'B')
                        {
                            matrix[snakeRow + 1, snakeCol] = '.';
                            snakeRow = secondBurrowRow;
                            snakeCol = secondBurrowCol;
                        }
                        else
                        {
                            snakeRow++;
                        }
                    }
                    else
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        break;
                    }
                }
                else if (command == "left")
                {
                    if (IsPossibleToMoveLeft(snakeCol))
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        if (matrix[snakeRow, snakeCol - 1] == '*')
                        {
                            foodEaten++;
                            snakeCol--;
                        }
                        else if (matrix[snakeRow, snakeCol - 1] == 'B')
                        {
                            matrix[snakeRow, snakeCol - 1] = '.';
                            snakeRow = secondBurrowRow;
                            snakeCol = secondBurrowCol;
                        }
                        else
                        {
                            snakeCol--;
                        }
                    }
                    else
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        break;
                    }
                }
                else if (command == "right")
                {
                    if (IsPossibleToMoveRight(snakeCol, size))
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        if (matrix[snakeRow, snakeCol + 1] == '*')
                        {
                            foodEaten++;
                            snakeCol++;
                        }
                        else if (matrix[snakeRow, snakeCol + 1] == 'B')
                        {
                            matrix[snakeRow, snakeCol + 1] = '.';
                            snakeRow = secondBurrowRow;
                            snakeCol = secondBurrowCol;
                        }
                        else
                        {
                            snakeCol++;
                        }
                    }
                    else
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        break;
                    }
                }
                matrix[snakeRow, snakeCol] = 'S';
                if (foodEaten == 10)
                {
                    Console.WriteLine("You won! You fed the snake.");
                    Console.WriteLine($"Food eaten: {foodEaten}");
                    Print(matrix);
                    Environment.Exit(0);
                }
            }

            Console.WriteLine("Game over!");
            Console.WriteLine($"Food eaten: {foodEaten}");
            Print(matrix);
        }

        private static void Print(char[,] matrix)
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

        private static bool IsPossibleToMoveRight(int snakeCol, int size)
        {
            if (snakeCol + 1 >= size)
            {
                return false;
            }
            return true;
        }

        private static bool IsPossibleToMoveLeft(int snakeCol)
        {
            if (snakeCol - 1 < 0)
            {
                return false;
            }
            return true;
        }

        private static bool IsPossibleToMoveDown(int snakeRow, int size)
        {
            if (snakeRow + 1 >= size)
            {
                return false;
            }
            return true;
        }

        private static bool IsPossibleToMoveUp(int snakeRow)
        {
            if (snakeRow - 1 < 0)
            {
                return false;
            }
            return true;
        }
    }
}
