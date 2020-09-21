using System;
using System.IO;

namespace _03.FloatingEquality
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());

            double diff = Math.Abs(num1 - num2);

            if (diff < 0.000001)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
            
        }
    }
}
