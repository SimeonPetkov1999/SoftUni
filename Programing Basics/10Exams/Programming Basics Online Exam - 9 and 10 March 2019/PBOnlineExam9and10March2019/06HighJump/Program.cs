using System;
using System.Drawing;

namespace _06HighJump
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetHeight = int.Parse(Console.ReadLine());
            int startingHeight = targetHeight - 30;
            int fails = 0;
            int jumps = 0;

            for (int currentHeight = startingHeight; currentHeight <= targetHeight; currentHeight += 5)
            {
                int height = int.Parse(Console.ReadLine());
                jumps++;           
                if (height > currentHeight)
                {  
                    continue;
                }
                else
                {
                    while (height <= currentHeight)
                    {
                        fails++;
                        if (fails == 3)
                        {
                            Console.WriteLine($"Tihomir failed at {currentHeight}cm after {jumps} jumps.");
                            Environment.Exit(0);
                        }
                        height = int.Parse(Console.ReadLine());
                        jumps++;
                    }
                }
                fails = 0;
            }
            Console.WriteLine($"Tihomir succeeded, he jumped over {targetHeight}cm after {jumps} jumps.");
        }
    }
}
