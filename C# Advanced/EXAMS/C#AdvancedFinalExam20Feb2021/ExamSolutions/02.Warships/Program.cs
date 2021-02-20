using System;
using System.Linq;

namespace _02.Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            var matrix = new string[size, size];
            var attacksCoordinates = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var allShipsAtFirst = 0;
            var firstPlyerShips = 0;

            var secondPlyerShips = 0;
            var shipsDestroyed = 0;

            for (int row = 0; row < size; row++)
            {
                var currentLine = Console.ReadLine().Split();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currentLine[col];
                    if (matrix[row, col] == "<")
                    {
                        firstPlyerShips++;
                        allShipsAtFirst++;
                    }
                    else if (matrix[row, col] == ">")
                    {
                        secondPlyerShips++;
                        allShipsAtFirst++;
                    }
                }
            }


            for (int i = 0; i < attacksCoordinates.Length; i++)
            {
                var currentCoordinates = attacksCoordinates[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var row = int.Parse(currentCoordinates[0]);
                var col = int.Parse(currentCoordinates[1]);

                if (IsCoordinatesValid(row, col, size))
                {
                    if (matrix[row, col] == "#")
                    {
                        MineExplode(row, col, matrix);                      
                    }
                    else if (matrix[row, col] == ">" || matrix[row, col] == "<")
                    {
                        matrix[row, col] = "X";                      
                    }
                    shipsDestroyed = GetAllShipsLeft(matrix);
                }

                firstPlyerShips = GetPlyerShips(matrix,"<");
                secondPlyerShips = GetPlyerShips(matrix, ">");

                if (firstPlyerShips == 0)
                {
                    Console.WriteLine($"Player Two has won the game! {allShipsAtFirst-shipsDestroyed} ships have been sunk in the battle.");
                    Environment.Exit(0);
                }
                else if (secondPlyerShips == 0)
                {
                    Console.WriteLine($"Player One has won the game! {allShipsAtFirst - shipsDestroyed} ships have been sunk in the battle.");
                    Environment.Exit(0);
                }
            }

            Console.WriteLine($"It's a draw! Player One has {firstPlyerShips} ships left. Player Two has {secondPlyerShips} ships left.");

        }

        private static int GetAllShipsLeft(string[,] matrix)
        {
            var ships = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            { 
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    if (matrix[row, col] == "<" || matrix[row, col] == ">")
                    {
                        ships++;
                    }
                }
            }
            return ships;
        }

        private static int GetPlyerShips(string[,] matrix,string player)
        {
            var ships = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            { 
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    if (matrix[row, col] == player)
                    {
                        ships++;
                    }
                }
            }
            return ships;
        }

        private static void MineExplode(int row, int col, string[,] matrix)
        {
            matrix[row, col] = "X";
            if (IsCoordinatesValid(row - 1, col - 1, matrix.GetLength(0)))
            {
                matrix[row - 1, col - 1] = "X";
            }
            if (IsCoordinatesValid(row - 1, col, matrix.GetLength(0)))
            {
                matrix[row - 1, col] = "X";
            }
            if (IsCoordinatesValid(row - 1, col + 1, matrix.GetLength(0)))
            {
                matrix[row - 1, col + 1] = "X";
            }
            if (IsCoordinatesValid(row, col - 1, matrix.GetLength(0)))
            {
                matrix[row, col - 1] = "X";
            }
            if (IsCoordinatesValid(row, col + 1, matrix.GetLength(0)))
            {
                matrix[row, col + 1] = "X";
            }
            if (IsCoordinatesValid(row + 1, col - 1, matrix.GetLength(0)))
            {
                matrix[row + 1, col - 1] = "X";
            }
            if (IsCoordinatesValid(row + 1, col, matrix.GetLength(0)))
            {
                matrix[row + 1, col] = "X";
            }
            if (IsCoordinatesValid(row + 1, col + 1, matrix.GetLength(0)))
            {
                matrix[row + 1, col + 1] = "X";
            }
        }

        private static bool IsCoordinatesValid(int row, int col, int size)
        {
            if (row >= size || row < 0 || col >= size || col < 0)
            {
                return false;
            }
            return true;
        }
    }
}
