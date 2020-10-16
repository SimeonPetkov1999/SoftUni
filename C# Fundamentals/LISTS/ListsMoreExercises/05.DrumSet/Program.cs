using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.DrumSet
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            List<int> originalDrumSet = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> currentDrumSet = new List<int>(originalDrumSet);

            string input = Console.ReadLine();

            
            while (input != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(input);

                for (int i = 0; i < currentDrumSet.Count; i++)
                {
                    if (currentDrumSet[i] - hitPower <= 0)
                    {
                        if (money < originalDrumSet[i] * 3)
                        {
                            currentDrumSet.RemoveAt(i);
                            originalDrumSet.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            currentDrumSet[i] = originalDrumSet[i];
                            money -= currentDrumSet[i] * 3;
                        }

                    }
                    else
                    {
                        currentDrumSet[i] -= hitPower;
                    }
                }
                input = Console.ReadLine();
            }

            string resultDrumSet = string.Join(' ', currentDrumSet);
            Console.WriteLine(resultDrumSet);
            Console.WriteLine($"Gabsy has {money:f2}lv.");

        }
    }
}
