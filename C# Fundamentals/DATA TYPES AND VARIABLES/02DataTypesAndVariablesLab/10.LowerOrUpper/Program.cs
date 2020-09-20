using System;

namespace _10.LowerOrUpper
{
    class Program
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());

            if (a >= 65 && a <= 90)
            {
                Console.WriteLine("upper-case");
            }

            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
