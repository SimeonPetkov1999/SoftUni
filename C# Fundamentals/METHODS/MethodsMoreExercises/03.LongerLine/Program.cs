using System;

namespace _03.LongerLine
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            double lenghtFirstLine = lenghtOfLine(x1, y1, x2, y2);
            double lenghtSecondLine = lenghtOfLine(x3, y3, x4, y4);

            if (lenghtFirstLine >= lenghtSecondLine)
            {
                ClosestPointToCenter(x1, y1, x2, y2);
            }
            else
            {
                ClosestPointToCenter(x3, y3, x4, y4);
            }
        }
        static double lenghtOfLine(double x1, double y1, double x2, double y2)
        {
            double result = Math.Pow((x2 - x1), 2) + Math.Pow((y1 - y2), 2);
            result = Math.Sqrt(result);
            return result;
        }

        static void ClosestPointToCenter(double x1, double y1, double x2, double y2)
        {
            double p = (x1 * x1) + (y1 * y1);
            double p2 = (x2 * x2) + (y2 * y2);
            if (p <= p2)
            {
                Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
            }
        }
    }
}
