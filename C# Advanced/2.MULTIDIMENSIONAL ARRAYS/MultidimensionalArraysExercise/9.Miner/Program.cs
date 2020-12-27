using System;
using System.Linq;

namespace _9.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            var commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var matrix = readMatrix(size);

            int numberOfCoals = 0;
            numberOfCoals = GetNumberOfCoals(matrix, numberOfCoals);
            int currentPositionRow = -1;
            int currentPositionCol = -1;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == "s")
                    {
                        currentPositionRow = row;
                        currentPositionCol = col;
                    }
                }
            }

            for (int i = 0; i < commands.Length; i++)
            {
                string currentCommand = commands[i];
                string charOnScreen = string.Empty;
                if (currentCommand == "up" && currentPositionRow - 1 >= 0)
                {
                    charOnScreen = matrix[currentPositionRow - 1, currentPositionCol];
                    if (charOnScreen=="c")
                    {
                        numberOfCoals--;
                        matrix[currentPositionRow - 1, currentPositionCol]="*";
                        if (numberOfCoals==0)
                        {
                            Console.WriteLine($"Win {currentPositionRow}{currentPositionCol}");//?
                            return;
                        }
                    }
                    else if (charOnScreen=="e")
                    {
                        Console.WriteLine($"you died {currentPositionRow}{currentPositionCol}");
                        return;
                    }
                    matrix[currentPositionRow, currentPositionCol]="*";
                    currentPositionRow--;
                }
                else if (currentCommand == "down" && currentPositionRow + 1 < size)
                {
                    charOnScreen = matrix[currentPositionRow + 1, currentPositionCol];
                    if (charOnScreen == "c")
                    {
                        numberOfCoals--;
                        matrix[currentPositionRow + 1, currentPositionCol] = "*";
                        if (numberOfCoals == 0)
                        {
                            Console.WriteLine($"Win {currentPositionRow}{currentPositionCol}");//?
                            return;
                        }
                    }
                    else if (charOnScreen == "e")
                    {
                        Console.WriteLine($"you died {currentPositionRow}{currentPositionCol}");
                        return;
                    }
                    matrix[currentPositionRow, currentPositionCol] = "*";
                    currentPositionRow++;
                }
                else if (currentCommand == "left" && currentPositionCol - 1 >= 0)
                {
                    charOnScreen = matrix[currentPositionRow, currentPositionCol-1];
                    if (charOnScreen == "c")
                    {
                        numberOfCoals--;
                        matrix[currentPositionRow, currentPositionCol-1] = "*";
                        if (numberOfCoals == 0)
                        {
                            Console.WriteLine($"Win {currentPositionRow}{currentPositionCol}");//?
                            return;
                        }
                    }
                    else if (charOnScreen == "e")
                    {
                        Console.WriteLine($"you died {currentPositionRow}{currentPositionCol}");
                        return;
                    }
                    matrix[currentPositionRow, currentPositionCol] = "*";
                    currentPositionCol--;
                }
                else if (currentCommand=="right" && currentPositionCol + 1 <size)
                {
                     charOnScreen = matrix[currentPositionRow, currentPositionCol+1];
                    if (charOnScreen == "c")
                    {
                        numberOfCoals--;
                        matrix[currentPositionRow, currentPositionCol+1] = "*";
                        if (numberOfCoals == 0)
                        {
                            Console.WriteLine($"Win {currentPositionRow}{currentPositionCol}");//?
                            return;
                        }
                    }
                    else if (charOnScreen == "e")
                    {
                        Console.WriteLine($"you died {currentPositionRow}{currentPositionCol}");
                        return;
                    }
                    matrix[currentPositionRow, currentPositionCol] = "*";
                    currentPositionCol++;
                }

            }

            Console.WriteLine($"coals left {numberOfCoals}");
        }

        public static int GetNumberOfCoals(string[,] matrix, int numberOfCoals)
        {
            foreach (var item in matrix)
            {
                if (item == "c")
                {
                    numberOfCoals++;
                }
            }
            return numberOfCoals;
        }

        public static string[,] readMatrix(int size)
        {
            var matrix = new string[size, size];
            for (int row = 0; row < size; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            return matrix;
        }
    }
}
