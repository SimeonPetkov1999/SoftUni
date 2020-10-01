using System;
using System.Linq;

namespace _04.FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int k = numbers.Length / 4;

            int[] firstRow = new int[2*k];
            int[] secondRow = new int[2*k];
            int[] firstLeftRow = new int[k];
            int[] firstRightRow = new int[k];

            ///int temp = k - 1;
            ///for (int i = 0; i < k; i++)
            ///{
            ///    firstRow[temp--] = numbers[i];
            ///}
            ///

            for (int i = 0; i < k; i++)
            {
                firstLeftRow[i] = numbers[i];
            }

            for (int i = 0; i < k; i++)
            {
                firstRightRow[i] = numbers[i];
            }



        }
    }
}
