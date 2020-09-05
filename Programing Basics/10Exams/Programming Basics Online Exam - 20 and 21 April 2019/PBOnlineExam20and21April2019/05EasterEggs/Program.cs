using System;

namespace _05EasterEggs
{
    class Program
    {
        static void Main(string[] args)
        {
            string egg;
            int numberOfEggs = int.Parse(Console.ReadLine());
            int redEggs = 0;
            int orangeEggs = 0;
            int blueEggs = 0;
            int greenEggs = 0;


            for (int i = 0; i < numberOfEggs; i++)
            {
                egg = Console.ReadLine();

                if (egg == "red")
                {
                    redEggs++;
                }

                else if (egg == "orange")
                {
                    orangeEggs++;
                }

                else if (egg =="blue")
                {
                    blueEggs++;
                }

                else
                {
                    greenEggs++;
                }
            }

            Console.WriteLine($"Red eggs: {redEggs}");
            Console.WriteLine($"Orange eggs: {orangeEggs}");
            Console.WriteLine($"Blue eggs: {blueEggs}");
            Console.WriteLine($"Green eggs: {greenEggs}");

            if (redEggs>orangeEggs && redEggs>blueEggs && redEggs>greenEggs)
            {
                Console.WriteLine($"Max eggs: {redEggs} -> red");
            }

            else if (orangeEggs>redEggs && orangeEggs> blueEggs && orangeEggs>greenEggs)
            {
                Console.WriteLine($"Max eggs: {orangeEggs} -> orange");

            }

            else if (blueEggs>redEggs && blueEggs>orangeEggs && blueEggs>greenEggs)
            {
                Console.WriteLine($"Max eggs: {blueEggs} -> blue");

            }

            else
            {
                Console.WriteLine($"Max eggs: {greenEggs} -> green");
                
            }


        }
    }
}
