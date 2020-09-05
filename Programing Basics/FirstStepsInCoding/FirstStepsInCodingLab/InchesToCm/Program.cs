using System;
using System.Dynamic;

namespace InchesToCm
{
    class Program
    {
        static void Main(string[] args)
        {
            double inches = double.Parse(Console.ReadLine());
            double Cm = inches * 2.54;
            Console.WriteLine(Cm);
        }
    }
}
