using System;

namespace _07SafePasswordsGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int maxPass = int.Parse(Console.ReadLine());
            int allPass = 0;
            char A = (char)35;
            char B = (char)64;

            for (int x = 1; x <= a; x++)
            {
                for (int y = 1; y <= b; y++)
                {
                    Console.Write($"{A}{B}{x}{y}{B}{A}|");
                    allPass++;
                    if (allPass==maxPass)
                    {
                        Environment.Exit(0);
                    }
                    A++;
                    B++;

                    if (A>55)
                    {
                        A = (char)35;
                    }

                    if (B>96)
                    {
                        B = (char)64;
                    }
                }
            }
         }
    }
}
