using System;

namespace _01.SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int max = Math.Max(Math.Max(num1, num2), num3);
            int min = Math.Min(Math.Min(num1, num2), num3);
            int middle = (num1 + num2 + num3) - (max + min);

            Console.WriteLine(max);
            Console.WriteLine(middle);
            Console.WriteLine(min);

        }
    }
}
