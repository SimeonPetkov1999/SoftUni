using System;
using System.Reflection.Metadata;

namespace RadiansToDegree
{
    class Program
    {
        static void Main(string[] args)
        {
            double rad = double.Parse(Console.ReadLine());
            double deg = Math.Round((rad * 180) / Math.PI);

            Console.WriteLine(deg);

        }
    }
}
