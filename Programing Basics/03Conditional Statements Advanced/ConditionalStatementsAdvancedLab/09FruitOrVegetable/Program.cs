using System;

namespace _09FruitOrVegetable
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();

            switch (fruit)
            {
                case "banana":
                case "apple":
                case "kiwi":
                case "cherry":
                case "lemon":
                case "grapes":
                    Console.WriteLine("fruit");
                    break;
                case "tomato":
                case "cucumber":
                case "pepper":
                case "carrot":
                    Console.WriteLine("vegetable");
                    break;
                default:
                    Console.WriteLine("unknown");
                    break;

            }
        }
    }
}
