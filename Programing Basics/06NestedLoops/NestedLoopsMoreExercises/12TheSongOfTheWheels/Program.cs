using System;

namespace _12TheSongOfTheWheels
{
    class Program
    {
        static void Main(string[] args)
        {
            int M = int.Parse(Console.ReadLine());
            int counter = 0;
            int password = 0;

            for (int a = 1; a <= 9; a++)
            {
                for (int b = 1; b <= 9; b++)
                {
                    for (int c = 1; c <= 9; c++)
                    {
                        for (int d = 1; d <= 9; d++)
                        {
                            if (a < b && c > d)
                            {
                                if ((a * b) + (c * d) == M)
                                {
                                    Console.Write($"{a}{b}{c}{d} ");
                                    counter++;
                                    if (counter==4)
                                    {
                                        password = int.Parse($"{a}{b}{c}{d}");
                                    }
                                }

                            }

                        }
                    }
                }
            }
            Console.WriteLine();
            if (counter>=4)
            {
                Console.WriteLine($"Password: {password}");
            }
            else
            {
                Console.WriteLine("No!");
            }
        }
    }
}
