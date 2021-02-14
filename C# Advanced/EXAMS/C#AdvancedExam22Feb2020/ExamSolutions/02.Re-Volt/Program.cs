using System;

namespace _02.Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int numberOfCommands = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];

            int playerRow = -1;
            int playerCol = -1;
            for (int row = 0; row < n; row++)
            {
                var currentRow = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            for (int i = 0; i < numberOfCommands; i++)
            {
                matrix[playerRow, playerCol] = '-';
                var command = Console.ReadLine();
                playerRow = MoveRow(playerRow, command, n);
                playerCol = MoveCol(playerCol, command, n);

                if (matrix[playerRow,playerCol]=='B')
                {
                    playerRow = MoveRow(playerRow, command, n);
                    playerCol = MoveCol(playerCol, command, n);
                }
                if (matrix[playerRow,playerCol]=='T')
                {
                    var backDirection = ChangeDirection(command);
                    playerRow = MoveRow(playerRow, backDirection, n);
                    playerCol = MoveCol(playerCol, backDirection, n);
                }
                if (matrix[playerRow,playerCol]=='F')
                {
                    Console.WriteLine("Player won!");
                    matrix[playerRow, playerCol] = 'f';
                    PrintMatrix(matrix);
                    Environment.Exit(0);
                }
                matrix[playerRow, playerCol] = 'f';
            }
            Console.WriteLine("Player lost!");
            PrintMatrix(matrix);
            Environment.Exit(0);

        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }

        private static string ChangeDirection(string command)
        {
            string backDirection = null;
            switch (command)
            {
                case "up":
                    backDirection = "down";
                    break;
                case "down":
                    backDirection = "up";
                    break;
                case "left":
                    backDirection = "right";
                    break;
                case "right":
                    backDirection = "left";
                    break;
            }
            return backDirection;
        }

        public static int MoveRow(int playerRow, string command, int size)
        {
            if (command == "up")
            {
                if (playerRow - 1 < 0)
                {
                    return size - 1;
                }
                return playerRow - 1;
            }
            else if (command == "down")
            {
                if (playerRow + 1 >= size)
                {
                    return 0;
                }
                return playerRow + 1;
            }
            return playerRow;
        }
        public static int MoveCol(int playerCol, string command, int size)
        {
            if (command == "left")
            {
                if (playerCol - 1 < 0)
                {
                    return size - 1;
                }
                return playerCol - 1;
            }
            else if (command == "right")
            {
                if (playerCol + 1 >= size)
                {
                    return 0;
                }
                return playerCol + 1;
            }
            return playerCol;
        }
    }
}
