using System;

namespace _02.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[] firstArray = { 1, 1 };
            long[] secondArray = firstArray;

            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < firstArray.Length + 1; j++)
                {
                    if (i == 0)
                    {
                        Console.WriteLine("1");
                        break;
                    }
                    if (i == 1)
                    {
                        Console.WriteLine(string.Join(" ", secondArray));
                        break;
                    }
                    if (j == 0)
                    {
                        secondArray = new long[firstArray.Length + 1];
                    }
                    if (j == 0 || j == secondArray.Length - 1)
                    {
                        secondArray[j] = 1;
                        continue;
                    }
                    if (j == 1)
                    {
                        secondArray[1] = firstArray[j] + 1;
                        continue;
                    }
                    secondArray[j] = firstArray[j - 1] + firstArray[j];
                }
                if (i != 0 && i != 1)
                {
                    Console.WriteLine(string.Join(" ", secondArray));
                    firstArray = secondArray;
                }
            }
        }
    }
}
