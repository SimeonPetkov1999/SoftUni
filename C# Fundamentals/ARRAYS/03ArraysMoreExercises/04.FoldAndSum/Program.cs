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
            int[] firstRow = new int[2 * k];
            int[] secondRow = new int[2 * k];
            int[] sumArray = new int[2 * k];

            int temp = k - 1;
            for (int i = 0; i < k; i++)
            {
                firstRow[temp--] = numbers[i];
            }
            int temp2 = firstRow.Length - k;
            for (int i = numbers.Length - 1; i >= numbers.Length - k; i--)
            {
                firstRow[temp2++] = numbers[i];
            }
            int index = 0;
            for (int i = k; i < numbers.Length - k; i++)
            {
                secondRow[index++] = numbers[i];
            }
            for (int i = 0; i <sumArray.Length; i++)
            {
                sumArray[i] = firstRow[i] + secondRow[i];
            }
            Console.WriteLine(string.Join(' ',sumArray));
        }
    }
}
