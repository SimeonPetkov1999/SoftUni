using System;

namespace _09Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int widhtFreeSpace = int.Parse(Console.ReadLine());
            int lenghtFreeSpace = int.Parse(Console.ReadLine());
            int heightFreeSpace = int.Parse(Console.ReadLine());

            int allSpace = widhtFreeSpace * lenghtFreeSpace * heightFreeSpace;
            int box=0;
            string input;

            while (true)
            {
                input = Console.ReadLine();
                if (input=="Done")
                {
                    Console.WriteLine($"{allSpace-box} Cubic meters left.");
                    break;
                }

                box += int.Parse(input);

                if (box>allSpace)
                {
                    Console.WriteLine($"No more free space! You need {box-allSpace} Cubic meters more.");
                    break;
                }
            }

        }
    }
}
