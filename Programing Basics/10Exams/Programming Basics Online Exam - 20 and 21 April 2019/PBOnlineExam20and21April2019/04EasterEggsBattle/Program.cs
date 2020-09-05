using System;

namespace _04EasterEggsBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            int eggsPlayerOne = int.Parse(Console.ReadLine());
            int eggsPlayerTwo = int.Parse(Console.ReadLine());
            string input;
                
            while (true)
            {
                input = Console.ReadLine();
                if (input =="End of battle")
                {
                    Console.WriteLine($"Player one has {eggsPlayerOne} eggs left.");
                    Console.WriteLine($"Player two has {eggsPlayerTwo} eggs left.");
                    break;

                }
                if (input=="one")
                {
                    eggsPlayerTwo--;
                }
                else
                {
                    eggsPlayerOne--;
                }

                if (eggsPlayerOne == 0)
                {
                    Console.WriteLine($"Player one is out of eggs. Player two has {eggsPlayerTwo} eggs left.");
                    break;
                }

                else if (eggsPlayerTwo == 0)
                {
                    Console.WriteLine($"Player two is out of eggs. Player one has {eggsPlayerOne} eggs left.");
                    break;
                }

            }
        }
    }
}
