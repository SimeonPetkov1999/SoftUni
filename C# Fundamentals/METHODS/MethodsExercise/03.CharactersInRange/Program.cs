using System;

namespace _03.CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            PrintPartOfAscii(start, end);
        }
        static void PrintPartOfAscii(char start, char end) 
        {
            int smallerChar = Math.Min(start, end);
            int biggerChar = Math.Max(start, end);

            for (int i = smallerChar+1; i < biggerChar; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
