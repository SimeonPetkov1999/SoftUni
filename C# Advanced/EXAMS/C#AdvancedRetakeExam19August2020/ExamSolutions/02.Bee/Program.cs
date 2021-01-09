using System;

namespace _02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            var matrix = new char[size, size];

            var beeRow = -1;
            var beeCol = -1;
            for (int row = 0; row < size; row++)
            {
                var currentLine = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currentLine[col];
                    if (matrix[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                        matrix[row, col] = '.';
                    }
                }
            }
            var polinatedFlowers = 0;
            var command = Console.ReadLine().ToLower();
            while (command != "end" && CheckIfPossible(command, matrix, beeCol, beeRow))
            {
                if (command == "up")
                {
                    matrix[beeRow, beeCol] = '.';
                    beeRow--;
                    polinatedFlowers = PolinateFlower(matrix, beeRow, beeCol, polinatedFlowers);
                    if (matrix[beeRow, beeCol] == 'O' && CheckIfPossible(command, matrix, beeCol, beeRow))
                    {
                        matrix[beeRow, beeCol] = '.';
                        beeRow--;
                        polinatedFlowers = PolinateFlower(matrix, beeRow, beeCol, polinatedFlowers);
                    }
                }
                else if (command == "down")
                {
                    matrix[beeRow, beeCol] = '.';
                    beeRow++;
                    polinatedFlowers = PolinateFlower(matrix, beeRow, beeCol, polinatedFlowers);
                    if (matrix[beeRow, beeCol] == 'O' && CheckIfPossible(command, matrix, beeCol, beeRow))
                    {
                        matrix[beeRow, beeCol] = '.';
                        beeRow++;
                        polinatedFlowers = PolinateFlower(matrix, beeRow, beeCol, polinatedFlowers);
                    }
                }
                else if (command == "left")
                {
                    matrix[beeRow, beeCol] = '.';
                    beeCol--;
                    polinatedFlowers = PolinateFlower(matrix, beeRow, beeCol, polinatedFlowers);
                    if (matrix[beeRow, beeCol] == 'O' && CheckIfPossible(command, matrix, beeCol, beeRow))
                    {
                        matrix[beeRow, beeCol] = '.';
                        beeCol--;
                        polinatedFlowers = PolinateFlower(matrix, beeRow, beeCol, polinatedFlowers);
                    }
                }
                else if (command == "right")
                {
                    matrix[beeRow, beeCol] = '.';
                    beeCol++;
                    polinatedFlowers = PolinateFlower(matrix, beeRow, beeCol, polinatedFlowers);
                    if (matrix[beeRow, beeCol] == 'O' && CheckIfPossible(command, matrix, beeCol, beeRow))
                    {
                        matrix[beeRow, beeCol] = '.';
                        beeCol++;
                        polinatedFlowers = PolinateFlower(matrix, beeRow, beeCol, polinatedFlowers);
                    }
                }
                command = Console.ReadLine().ToLower();
            }
            if (!CheckIfPossible(command, matrix, beeCol, beeRow))
            {
                Console.WriteLine("The bee got lost!");
            }
            if (polinatedFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {polinatedFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - polinatedFlowers} flowers more");
            }
            PrintMatrix(matrix);
        }
        private static int PolinateFlower(char[,] matrix, int beeRow, int beeCol, int polinatedFlowers)
        {
            if (matrix[beeRow, beeCol] == 'f')
            {
                matrix[beeRow, beeCol] = 'B';
                polinatedFlowers++;
            }
            return polinatedFlowers;
        }
        public static bool CheckIfPossible(string command, char[,] matrix, int beeCol, int beeRow)
        {
            if (command == "up" && beeRow - 1 < 0)
            {
                matrix[beeRow, beeCol] = '.';
                return false;
            }
            else if (command == "down" && beeRow + 1 >= matrix.GetLength(0))
            {
                matrix[beeRow, beeCol] = '.';
                return false;
            }
            else if (command == "left" && beeCol - 1 < 0)
            {
                matrix[beeRow, beeCol] = '.';
                return false;
            }
            else if (command == "right" && beeCol + 1 >= matrix.GetLength(1))
            {
                matrix[beeRow, beeCol] = '.';
                return false;
            }
            else if (command == "end")
            {
                matrix[beeRow, beeCol] = 'B';
                return true;
            }
            return true;
        }
        public static void PrintMatrix(char[,] matrix)
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