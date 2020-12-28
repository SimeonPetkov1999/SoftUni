using System;

namespace _10.RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);

            var matrix = new char[rows, cols];
            readMatrix(matrix, rows, cols);

            int playerPostitonRow = 0;
            int playerPositionCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'P')
                    {
                        playerPostitonRow = row;
                        playerPositionCol = col;
                        matrix[row, col] = '.';
                    }
                }
            }
            bool won = false;
            bool lost = false;
            string commands = Console.ReadLine();
            for (int i = 0; i < commands.Length; i++)
            {
                char currentCommand = commands[i];
                if (matrix[playerPostitonRow, playerPositionCol] == 'B')
                {
                    printMatrix(matrix);
                    Console.WriteLine($"dead: {playerPostitonRow} {playerPositionCol}");
                    Environment.Exit(0);
                }
                if (currentCommand == 'R')
                {
                    if (playerPositionCol + 1 >= cols)
                    {
                        won = true;
                        break;
                    }
                    else if (matrix[playerPostitonRow, playerPositionCol + 1] == 'B')
                    {
                        playerPositionCol++;
                        lost = true;
                        break;
                    }
                    playerPositionCol++;
                    addSmallBunny(matrix);
                    fixBinny(matrix);
                }
                else if (currentCommand == 'L')
                {
                    if (playerPositionCol - 1 < 0)
                    {
                        won = true;
                        break;
                    }
                    else if (matrix[playerPostitonRow, playerPositionCol - 1] == 'B')
                    {
                        playerPositionCol--;
                        lost = true;
                        break;
                    }
                    playerPositionCol--;
                    addSmallBunny(matrix);
                    fixBinny(matrix);
                }
                else if (currentCommand == 'U')
                {
                    if (playerPostitonRow - 1 < 0)
                    {
                        won = true;
                        break;
                    }
                    else if (matrix[playerPostitonRow - 1, playerPositionCol] == 'B')
                    {
                        playerPostitonRow--;
                        lost = true;
                        break;
                    }
                    playerPostitonRow--;
                    addSmallBunny(matrix);
                    fixBinny(matrix);
                }
                else if (currentCommand == 'D')
                {
                    if (playerPostitonRow + 1 >= rows)
                    {
                        won = true;
                        break;
                    }
                    else if (matrix[playerPostitonRow + 1, playerPositionCol] == 'B')
                    {
                        playerPostitonRow++;
                        lost = true;
                        break;
                    }
                    playerPostitonRow++;
                    addSmallBunny(matrix);
                    fixBinny(matrix);
                }
            }
            if (won)
            {
                addSmallBunny(matrix);
                fixBinny(matrix);
                printMatrix(matrix);
                Console.WriteLine($"won: {playerPostitonRow} {playerPositionCol}");
            }
            if (lost)
            {
                addSmallBunny(matrix);
                fixBinny(matrix);
                printMatrix(matrix);
                Console.WriteLine($"dead: {playerPostitonRow} {playerPositionCol}");
            }
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
        //make all small bunnies big again
        public static void fixBinny(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'b')
                    {
                        matrix[row, col] = 'B';
                    }
                }
            }
        }
        public static void addSmallBunny(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        //add small bunny top
                        if (row - 1 >= 0 && matrix[row - 1, col] != 'B')
                        {
                            matrix[row - 1, col] = 'b';
                        }
                        //add small bunny bottom
                        if (row + 1 < matrix.GetLength(0) && matrix[row + 1, col] != 'B')
                        {
                            matrix[row + 1, col] = 'b';
                        }
                        //add small bunny right
                        if (col + 1 < matrix.GetLength(1) && matrix[row, col + 1] != 'B')
                        {
                            matrix[row, col + 1] = 'b';
                        }
                        //add small bunny Left  
                        if (col - 1 >= 0 && matrix[row, col - 1] != 'B')
                        {
                            matrix[row, col - 1] = 'b';
                        }
                    }
                }
            }
        }
        public static void readMatrix(char[,] matrix, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                var currentLine = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentLine[col];
                }
            }
        }
    }
}
