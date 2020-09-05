using System;

namespace _05DivideWithoutRemainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double p1 = 0.0;
            double p2 = 0.0;
            double p3 = 0.0;


            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());

                if (input % 2 ==0)
                {
                    p1++;
                }

                if (input % 3 == 0)
                {
                    p2++;
                }

                if (input % 4 ==0)
                {
                    p3++;
                }
            }

            p1 = (p1 / n) * 100;
            p2 = (p2 / n) * 100;
            p3 = (p3 / n) * 100;

            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
        }
    }
}
