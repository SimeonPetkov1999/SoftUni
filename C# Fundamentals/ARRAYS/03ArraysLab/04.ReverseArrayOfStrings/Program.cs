using System;

namespace _04.ReverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            for (int i = 0; i < input.Length / 2; i++)
            {
                string temp = input[i];
                input[i] = input[input.Length - i - 1];
                input[input.Length - i - 1] = temp;
            }
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
