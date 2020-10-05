using System;

namespace _08.MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());

            Console.WriteLine(MyPower(num,power));
        }
        static double MyPower(double num, double power) 
        {
            double result = 1;
            for (int i = 1; i <= power; i++)
            {
                result *=num;
            }
            return result;
        }
    }
}
