using System;
using System.Linq;

namespace _10.LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[] field = new int[size];

            int[] ladybugsIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < ladybugsIndexes.Length; i++)
            {
                if (i==ladybugsIndexes[i])
                {
                    field[i] = 1;
                }
            }

            string input = Console.ReadLine();
            while (input!="end")
            {
                string[] commands = input.Split();
                string leftOrRight = commands[1];
                int indexOfBug = int.Parse(commands[0].ToString());
                int flightLenght = int.Parse(commands[2].ToString());

                if (leftOrRight=="right")
                {
                    
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", field));

        }
    }
}
