using System;

namespace UsdToBgn
{
    class Program
    {
        static void Main(string[] args)
        {
            double USD = double.Parse(Console.ReadLine());
            double BGN = USD * 1.79546;

            Console.WriteLine($"{BGN:F2}");
        }
    }
}
