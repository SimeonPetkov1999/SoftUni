using System;

namespace _06Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int widthOfCake = int.Parse(Console.ReadLine());
            int heightOfCake = int.Parse(Console.ReadLine());

            int sizeOfCake = widthOfCake * heightOfCake;
            int slices = 0;

            
            while (true)
            {
                string input = Console.ReadLine();
                if (input=="STOP")
                {
                    Console.WriteLine($"{sizeOfCake-slices} pieces are left.");
                    break;
                }

                slices += int.Parse(input);

                if (slices > sizeOfCake)
                {
                    Console.WriteLine($"No more cake left! You need {slices-sizeOfCake} pieces more.");
                    break;
                }
            }

        }
    }
}
