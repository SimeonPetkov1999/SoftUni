using System;

namespace _06AreaFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string areaType = Console.ReadLine();

            if (areaType=="square")
            {
                double a = double.Parse(Console.ReadLine());
                Console.WriteLine($"{a*a:f2}");
            }

            else if (areaType == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());

                Console.WriteLine($"{a*b:f2}");
            }

            else if (areaType == "circle")
            {
                double r = double.Parse(Console.ReadLine());
                double area = Math.PI * Math.Pow(r, 2);

                Console.WriteLine($"{area:f2}");
            }

            else
            {
                double a = double.Parse(Console.ReadLine());
                double Hb = double.Parse(Console.ReadLine());
                double area = (a * Hb) / 2;

                Console.WriteLine($"{area:f2}");

            }
        }
    }
}
