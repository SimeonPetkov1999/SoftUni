using System;
using System.Numerics;

namespace _03.BigFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger fac=new BigInteger();

            fac = 1;
            for (int i = 2; i <= n; i++)
            {
                fac *= i;
            }

            Console.WriteLine(fac);
        }
    }
}
