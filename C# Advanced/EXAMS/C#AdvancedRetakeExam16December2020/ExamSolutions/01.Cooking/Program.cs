using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            var liquidsQueue = new Queue<int>(ReadInput());
            var ingredientsStack = new Stack<int>(ReadInput());
            int breads = 0;
            int cakes = 0;
            int pastries = 0;
            int fruitPies = 0;

            while (liquidsQueue.Any() && ingredientsStack.Any())
            {
                var currentLiquid = liquidsQueue.Dequeue();
                var currentIngredients = ingredientsStack.Pop();
                var sum = currentLiquid + currentIngredients;

                switch (sum)
                {
                    case 25: breads++; break;
                    case 50: cakes++; break;
                    case 75: pastries++; break;
                    case 100: fruitPies++; break;
                    default: ingredientsStack.Push(currentIngredients + 3); break;
                }
            }

            PrintIfSucceeded(breads, cakes, pastries, fruitPies);
            PrintWahtsLeft(liquidsQueue, ingredientsStack);
            PrintCookedProducts(breads, cakes, pastries, fruitPies);
        }

        private static void PrintIfSucceeded(int breads, int cakes, int pastries, int fruitPies)
        {
            if (breads != 0 && cakes != 0 && pastries != 0 && fruitPies != 0)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
        }

        private static void PrintCookedProducts(int breads, int cakes, int pastries, int fruitPies)
        {
            Console.WriteLine($"Bread: {breads}");
            Console.WriteLine($"Cake: {cakes}");
            Console.WriteLine($"Fruit Pie: {fruitPies}");
            Console.WriteLine($"Pastry: {pastries}");
        }

        private static void PrintWahtsLeft(Queue<int> liquidsQueue, Stack<int> ingredientsStack)
        {
            string liquidsMessage = liquidsQueue.Any() ? string.Join(", ", liquidsQueue) : "none";
            Console.WriteLine($"Liquids left: {liquidsMessage}");
            string ingredientsMessage = ingredientsStack.Any() ? string.Join(", ", ingredientsStack) : "none";
            Console.WriteLine($"Ingredients left: {ingredientsMessage}");
        }

        public static int[] ReadInput() =>
            Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
    }
}
