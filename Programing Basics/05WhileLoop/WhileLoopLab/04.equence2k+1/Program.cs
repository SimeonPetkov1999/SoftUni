using System;

namespace _04.equence2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //int n = int.Parse(Console.ReadLine());


            //for (int i = 1; i <= n; i=i*2+1)
            //{
            //    Console.WriteLine(i);
            //}

            int number = int.Parse(Console.ReadLine());

            int k = 1;

            while (k<=number)
            {
                Console.WriteLine(k);
                k = k * 2 + 1;
            }
        }
    }
}
