using System;

namespace _02.CenterPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            ClosestPointToCenter(x1, y1, x2, y2);
         }

        static void ClosestPointToCenter(double x1, double y1, double x2, double y2)
        {
            double p = (x1 * x1) + (y1 * y1);
            double p2 = (x2 * x2) + (y2 * y2);
            if (p<=p2)
            {
                Console.WriteLine($"({x1}, {y1})");
            }

            else
            {
                Console.WriteLine($"({x2}, {y2})");

            }
        }
    }
}
