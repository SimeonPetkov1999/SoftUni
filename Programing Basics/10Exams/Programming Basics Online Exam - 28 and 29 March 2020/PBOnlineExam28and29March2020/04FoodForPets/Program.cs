using System;

namespace _04FoodForPets
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double allFood = double.Parse(Console.ReadLine());

            double allFoodEatenByDog = 0.0;
            double allFoodEatenByCat = 0.0;
            double allFoodEaten = 0.0;
            double biscuitsEaten = 0;
            int foodEatenByDog;
            int foodEatenByCat;

            for (int i = 1; i <= days; i++)
            {
                foodEatenByDog = int.Parse(Console.ReadLine());
                foodEatenByCat = int.Parse(Console.ReadLine());

                allFoodEatenByDog = allFoodEatenByDog + foodEatenByDog;
                allFoodEatenByCat = allFoodEatenByCat + foodEatenByCat;
                allFoodEaten = allFoodEatenByDog + allFoodEatenByCat;

                if (i % 3 == 0)
                {
                    biscuitsEaten += ((foodEatenByCat + foodEatenByDog) * 0.1);
                }

                foodEatenByCat = 0;
                foodEatenByDog = 0;
            }

            double percentageFoodEaten = (allFoodEaten / allFood) * 100;
            double percentageFoodEatenByDog = (allFoodEatenByDog / allFoodEaten) * 100;
            double percentageFoodEatenByCat = (allFoodEatenByCat / allFoodEaten) * 100;

           


            Console.WriteLine($"Total eaten biscuits: {Math.Round(biscuitsEaten)}gr.");
            Console.WriteLine($"{percentageFoodEaten:f2}% of the food has been eaten.");
            Console.WriteLine($"{percentageFoodEatenByDog:f2}% eaten from the dog.");
            Console.WriteLine($"{percentageFoodEatenByCat:f2}% eaten from the cat.");




        }
    }
}
