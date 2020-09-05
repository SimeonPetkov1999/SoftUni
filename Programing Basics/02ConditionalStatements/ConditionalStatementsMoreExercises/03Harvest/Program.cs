using System;

namespace _03Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            int squareMeterLoze = int.Parse(Console.ReadLine());
            double grapesFor1squareMeter = double.Parse(Console.ReadLine());
            int neededWine = int.Parse(Console.ReadLine());
            int numberOfWorkers = int.Parse(Console.ReadLine());

            double allGrapes = squareMeterLoze * grapesFor1squareMeter;
            double allWine = ((allGrapes / 2.5) * 0.4);

            if (allWine >= neededWine)
            {
                double litersLeft = Math.Ceiling(allWine - neededWine);
                double wineForWorkers =Math.Ceiling( litersLeft / numberOfWorkers);

                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(allWine)} liters.");
                Console.WriteLine($"{litersLeft} liters left -> {wineForWorkers} liters per person.");

            }

            else 
            {
                double litersNeeded = Math.Floor(neededWine - allWine);

                Console.WriteLine($"It will be a tough winter! More {litersNeeded} liters wine needed.");
            }


        }
    }
}
