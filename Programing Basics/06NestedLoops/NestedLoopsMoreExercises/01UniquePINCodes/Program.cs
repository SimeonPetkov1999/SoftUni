using System;

namespace _01UniquePINCodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumTo = int.Parse(Console.ReadLine());
            int secondNumTo = int.Parse(Console.ReadLine());
            int thirdNumTo = int.Parse(Console.ReadLine());


            for (int first = 2; first <= firstNumTo; first += 2)
            {
                for (int second = 1; second <= secondNumTo; second++)
                {
                    for (int third = 2; third <= thirdNumTo; third += 2)
                    {
                        if (second == 2 || second == 3 || second == 5 || second == 7)
                        {
                            Console.WriteLine($"{first} {second} {third}");
                        }
                    }
                }
            }
        }
    }
}
