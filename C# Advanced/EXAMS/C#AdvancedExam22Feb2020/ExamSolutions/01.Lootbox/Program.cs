using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstLootBoxQueue = new Queue<int>(ReadLine());
            var secondLootBoxStack = new Stack<int>(ReadLine());

            var collection = 0;
            while (firstLootBoxQueue.Any() && secondLootBoxStack.Any())
            {
                var queue = firstLootBoxQueue.Peek();
                var stack = secondLootBoxStack.Peek();
                var sum = queue + stack;

                if (sum % 2 == 0)
                {
                    collection += sum;
                    firstLootBoxQueue.Dequeue();
                    secondLootBoxStack.Pop();
                }
                else
                {
                    firstLootBoxQueue.Enqueue(secondLootBoxStack.Pop());
                }
            }

            var lootBoxEmpty = firstLootBoxQueue.Any() ? "Second lootbox is empty" : "First lootbox is empty";
            var outputMessage = collection >= 100 ? $"Your loot was epic! Value: " : $"Your loot was poor... Value: ";
            Console.WriteLine(lootBoxEmpty);
            Console.WriteLine(outputMessage + collection);
        }

        private static int[] ReadLine() =>
             Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
    }
}
