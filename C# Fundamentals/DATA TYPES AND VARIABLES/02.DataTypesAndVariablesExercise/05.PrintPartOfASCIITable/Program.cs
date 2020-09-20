using System;

namespace _05.PrintPartOfASCIITable
{
    class Program
    {
        static void Main(string[] args)
        {
            int startOfAscii = int.Parse(Console.ReadLine());
            int endOfAscii = int.Parse(Console.ReadLine());


            for (int i = startOfAscii; i <= endOfAscii; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
