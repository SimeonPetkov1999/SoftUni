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
                if (ladybugsIndexes[i] >= 0 && ladybugsIndexes[i] < size)
                {
                    field[ladybugsIndexes[i]] = 1;
                }
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] commands = input.Split();
                string leftOrRight = commands[1];
                int indexOfBug = int.Parse(commands[0].ToString());
                int flightLenght = int.Parse(commands[2].ToString());

                if (indexOfBug < 0 || indexOfBug > field.Length - 1 || field[indexOfBug] == 0)
                {
                    continue;
                }
                if (leftOrRight == "right")
                {
                    int targetIndex = indexOfBug + flightLenght;
                    field[indexOfBug] = 0;
                    while (targetIndex<field.Length)
                    {
                        if (field[targetIndex]==1)
                        {
                            targetIndex += targetIndex;
                        }
                        else
                        {
                            field[targetIndex] = 1;
                            break;
                        }
                    }
                }

                else if (leftOrRight == "left")
                {
                    int targetIndex = indexOfBug - flightLenght;
                    field[indexOfBug] = 0;

                    while (targetIndex >= 0)
                    {
                        if (field[targetIndex] == 1)
                        {
                            targetIndex -= targetIndex;
                        }

                        else
                        {
                            field[targetIndex] = 1;
                            break;
                        }
                    }
                }               
            }
            Console.WriteLine(string.Join(" ", field));
         }
    }
}
