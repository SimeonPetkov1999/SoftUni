using System;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);

            var matrix = new int[rows, cols];

            var flowerPostion = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            while (flowerPostion[0] != "Bloom")
            {
                int flowerRow = int.Parse(flowerPostion[0]);
                int flowerCol = int.Parse(flowerPostion[1]);

                if (flowerRow >= rows || flowerRow < 0 ||
                    flowerCol >= cols || flowerCol < 0)
                {
                    Console.WriteLine("Invalid coordinates.");
                    flowerPostion = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (row == flowerRow || col == flowerCol)
                        {
                            matrix[row, col]++;
                        }
                    }
                }

                flowerPostion = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}