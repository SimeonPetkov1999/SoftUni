using System;

namespace _1.RhombusOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintTop(n);
            PrintBottom(n);
        }

        public static void PrintBottom(int n)
        {
            for (int i = 0; i < n - 1; i++)
            {
                Console.Write(new string(' ', i + 1));
                for (int j = 0; j < n - 1 - i; j++)
                {
                    PrintRow();
                }
                Console.WriteLine();
            }
        }
        public static void PrintTop(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(new string(' ', n - 1 - i));
                for (int j = 0; j < i + 1; j++)
                {
                    PrintRow();
                }
                Console.WriteLine();
            }
        }
        private static void PrintRow()
        {
            Console.Write('*');
            Console.Write(' ');
        }
    }
}
