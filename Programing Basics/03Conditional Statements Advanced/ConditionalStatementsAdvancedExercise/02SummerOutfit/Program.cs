using System;

namespace _02SummerOutfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int degrees = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();

            string outfit = null;
            string shoes = null;

            if (degrees>=10 && degrees <=18)
            {
                if (timeOfDay=="Morning")
                {
                    outfit = "Sweatshirt";
                    shoes = "Sneakers";
                }

                else
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }

            }

            else if (degrees>18&&degrees<=24)
            {
                if (timeOfDay=="Afternoon")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
                else
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
            }

            else
            {
                if (timeOfDay == "Morning")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }

                else if (timeOfDay=="Afternoon")
                {
                    outfit = "Swim Suit";
                    shoes = "Barefoot";
                }

                else
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
                
            }

            Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
        }
    }
}
