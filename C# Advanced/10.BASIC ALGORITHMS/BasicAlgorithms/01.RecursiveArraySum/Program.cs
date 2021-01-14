using System;
using System.Linq;

namespace _01.RecursiveArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Console.WriteLine(Sum(input,0));
        }

        public static int Sum(int[] arr, int index = 0) 
        {
            if (index==arr.Length)
            {
                return 0;
            }
            return arr[index] + Sum(arr, ++index);
        }
    }
}
