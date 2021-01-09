using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            var liliesInput = ReadInput();
            var rosesInput = ReadInput();

            var liliesStack = new Stack<int>(liliesInput);
            var rosesQueue = new Queue<int>(rosesInput);

            var flowersForLater = 0;
            var wreaths = 0;
            while (liliesStack.Any() && rosesQueue.Any())
            {
                var currentLilie = liliesStack.Pop();
                var currentRose = rosesQueue.Dequeue();

                while (currentLilie + currentRose > 15)
                {
                    currentLilie -= 2;
                }
                if (currentLilie + currentRose == 15)
                {
                    wreaths++;
                }
                else if (currentLilie + currentRose < 15)
                {
                    flowersForLater += currentLilie + currentRose;
                }
            }

            if (flowersForLater > 15)
            {
                wreaths += (int)(flowersForLater / 15);
            }   
            Print(wreaths);
        }

        public static void Print(int wreaths)
        {
            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }
        }

        public static int[] ReadInput()
        {
            return Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
