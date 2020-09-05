using System;

namespace _07MinNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double num;
            double min = double.MaxValue;

            while (input != "Stop")
            {
                num = double.Parse(input);
                if (num < min)
                {
                    min = num;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(min);

        }
    }
}
