using System;

namespace _01.DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            if (type == "int")
            {
                PrintResult(int.Parse(Console.ReadLine()));
            }

            else if (type == "real")
            {
                PrintResult(double.Parse(Console.ReadLine()));
            }

            else
            {
                PrintResult(Console.ReadLine());
            }
        }

        static void PrintResult(int a)
        {
            Console.WriteLine(a * 2);
        }

        static void PrintResult(double a)
        {
            Console.WriteLine($"{a * 1.5:f2}");
        }
        static void PrintResult(string a)
        {
            Console.WriteLine($"${a}$");
        }
    }
}
