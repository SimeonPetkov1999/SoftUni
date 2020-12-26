using System;

namespace _7.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            var pascalArr = new long[size][];

            if (size > 0)
            {
                pascalArr[0] = new long[] { 1 };
            }
            if (size > 1)
            {
                pascalArr[1] = new long[] { 1, 1 };
            }

            for (int rows = 2; rows < size; rows++)
            {
                pascalArr[rows] = new long[rows + 1];
                for (int col = 1; col < pascalArr[rows].Length-1; col++)
                {
                    pascalArr[rows][0] = 1;
                    pascalArr[rows][col] = pascalArr[rows - 1][col - 1] + pascalArr[rows - 1][col]; 
                    pascalArr[rows][pascalArr[rows].Length - 1] = 1;
                }
            }

            foreach (var item in pascalArr)
            {
                Console.WriteLine(string.Join(" ",item));
            }
        }
    }
}
