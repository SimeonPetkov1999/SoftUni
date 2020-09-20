using System;

namespace _07.WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int currentsCapacity = 0;

            for (int i = 0; i < n; i++)
            {
                int liters = int.Parse(Console.ReadLine());

                if (currentsCapacity + liters > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                }

                else
                {
                    currentsCapacity += liters;
                }
            }

            Console.WriteLine(currentsCapacity);
        }
    }
}
