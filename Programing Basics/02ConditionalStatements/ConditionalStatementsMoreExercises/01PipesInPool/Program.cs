using System;

namespace _01PipesInPool
{
    class Program
    {
        static void Main(string[] args)
        {
            int voulmeOfThePool = int.Parse(Console.ReadLine());
            int p1DebitOneHour = int.Parse(Console.ReadLine());
            int p2DebitOneHour = int.Parse(Console.ReadLine());
            double hoursWorkerLeft = double.Parse(Console.ReadLine());

            double p1Water = hoursWorkerLeft * p1DebitOneHour;
            double p2Water = hoursWorkerLeft * p2DebitOneHour;

            double allWater = p1Water + p2Water;

            if (allWater <= voulmeOfThePool)
            {
                double percentagePoll = (allWater / voulmeOfThePool) * 100;
                double percentageP1 = p1Water / allWater * 100;
                double percentageP2 = p2Water / allWater * 100;

                Console.WriteLine($"The pool is {percentagePoll:f2}% full. Pipe 1: {percentageP1:f2}%. Pipe 2: {percentageP2:f2}%.");
            }

            else
            {
                Console.WriteLine($"For {hoursWorkerLeft} hours the pool overflows with {allWater-voulmeOfThePool:f2} liters.");
            }

        }
    }
}
