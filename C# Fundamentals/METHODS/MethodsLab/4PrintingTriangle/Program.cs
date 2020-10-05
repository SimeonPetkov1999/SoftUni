using System;

namespace _4PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                PrintLine(i);
            }
            for (int i = n-1 ; i >= 1; i--)
            {
                PrintLine(i);
            }
        }
        static void PrintLine(int end) 
        {
            for (int i = 1; i <= end; i++)
            {
                Console.Write(i+ " ");
            }
            Console.WriteLine();
        }
    }
}
