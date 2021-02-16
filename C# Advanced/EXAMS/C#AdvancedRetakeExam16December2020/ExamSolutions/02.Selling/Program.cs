using System;

namespace _02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];
            var playerRow = -1;
            var playerCol = -1;

            for (int row = 0; row < n; row++)
            {
                var currentRow = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == 'S')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            int money = 0;
            while (true)
            {
                matrix[playerRow, playerCol] = '-';
                var command = Console.ReadLine();
                playerRow = MoveRow(command, playerRow);
                playerCol = MoveCol(command, playerCol);

                if (PlayerIsOutside(playerRow, playerCol, n))
                {
                    Console.WriteLine($"Bad news, you are out of the bakery.");
                    Print(matrix, money);
                }
                else if (char.IsDigit(matrix[playerRow, playerCol]))
                {
                    money += int.Parse(matrix[playerRow, playerCol].ToString());
                    if (money >= 50)
                    {
                        matrix[playerRow, playerCol] = 'S';
                        Console.WriteLine($"Good news! You succeeded in collecting enough money!");
                        Print(matrix, money);                       
                    }
                }
                else if (matrix[playerRow, playerCol] == 'O')
                {
                    matrix[playerRow, playerCol] = '-';
                    MoveToOtherPillar(n, matrix, ref playerRow, ref playerCol);
                }
                matrix[playerRow, playerCol] = 'S';
            }
        }
        public static void MoveToOtherPillar(int n, char[,] matrix, ref int playerRow, ref int playerCol)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == 'O' && (playerRow != row && playerCol != col))
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
        }
        public static void Print(char[,] matrix, int money)
        {
            Console.WriteLine($"Money: {money}");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
            Environment.Exit(0);
        }
        public static bool PlayerIsOutside(int playerRow, int playerCol, int n)
        {
            if (playerRow < 0 || playerRow >= n || playerCol < 0 || playerCol >= n)
            {
                return true;
            }
            return false;
        }
        public static int MoveRow(string command, int playerRow)
        {
            if (command == "up")
            {
                return playerRow - 1;
            }
            else if (command == "down")
            {
                return playerRow + 1;
            }
            return playerRow;
        }
        public static int MoveCol(string command, int playerCol)
        {
            if (command == "left")
            {
                return playerCol - 1;
            }
            else if (command == "right")
            {
                return playerCol + 1;
            }
            return playerCol;
        }
    }
}
