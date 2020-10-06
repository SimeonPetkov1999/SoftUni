using System;

namespace _01.SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            Console.WriteLine(SmalletsOfThreeNums(num1,num2,num3));
        }

        static int SmalletsOfThreeNums(int num1, int num2, int num3) 
        {
            int smallest = Math.Min(Math.Min(num1, num2),num3);
            return smallest;
        }
    }
}
