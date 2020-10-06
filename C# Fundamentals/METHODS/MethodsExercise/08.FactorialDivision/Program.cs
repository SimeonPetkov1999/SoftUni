using System;

namespace _08.FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            double factorial1 = GetFactorial(num1);
            double factorial2 = GetFactorial(num2);

            double result = Divide(factorial1, factorial2);
            Console.WriteLine($"{result:f2}");
        }
        static double GetFactorial(int n)
        {
            double factorial = 1;
            for (int i = 2; i <= n; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
        static double Divide(double firstNUm, double secondnum)
        {
            return firstNUm * 1.0 / secondnum;
        }
    }
}
