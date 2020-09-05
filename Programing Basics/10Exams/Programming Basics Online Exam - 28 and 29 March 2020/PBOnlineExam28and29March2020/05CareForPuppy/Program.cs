using System;

namespace _05CareForPuppy
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodGrams = int.Parse(Console.ReadLine()) * 1000;
            string input;
            int foodEatenGrams;
            int allFoodEatenGrams=0;


            while (true)
            {
                input = Console.ReadLine();
                if (input!="Adopted")
                {
                    foodEatenGrams = int.Parse(input);
                    allFoodEatenGrams = allFoodEatenGrams + foodEatenGrams;
                }

                else
                {
                    break;
                }
            }

            if (allFoodEatenGrams<=foodGrams)
            {
                Console.WriteLine($"Food is enough! Leftovers: {foodGrams-allFoodEatenGrams} grams.");
            }

            else
            {
                Console.WriteLine($"Food is not enough! You need: {allFoodEatenGrams - foodGrams} grams more.");
            }
        }
    }
}
