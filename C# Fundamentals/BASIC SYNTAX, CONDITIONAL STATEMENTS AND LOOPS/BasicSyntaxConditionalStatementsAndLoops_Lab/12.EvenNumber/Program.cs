using System;

namespace _12.EvenNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int input = int.Parse(Console.ReadLine());

                if (input%2==0)
                {
                    Console.WriteLine($"The number is: {Math.Abs(input)}");
                    break;
                }

                Console.WriteLine("Please write an even number.");
            }
        }
    }
}
