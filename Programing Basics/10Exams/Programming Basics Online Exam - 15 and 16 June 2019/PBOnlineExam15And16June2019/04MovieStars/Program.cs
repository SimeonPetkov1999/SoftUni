using System;

namespace _04MovieStars
{
    class Program
    {
        static void Main(string[] args)
        {
            double budgetForActors = double.Parse(Console.ReadLine());

            string nameOfActor = Console.ReadLine();
            while (nameOfActor != "ACTION")
            {            
                if (nameOfActor.Length>15)
                {
                    budgetForActors = budgetForActors - (budgetForActors * 0.20);
                    nameOfActor = Console.ReadLine();
                    continue;
                }
                double sallary = double.Parse(Console.ReadLine());
                budgetForActors -= sallary;
                if (budgetForActors<0)
                {
                    Console.WriteLine($"We need {Math.Abs(budgetForActors):f2} leva for our actors.");
                    Environment.Exit(0);
                }
                nameOfActor = Console.ReadLine();
            }
            Console.WriteLine($"We are left with {budgetForActors:f2} leva.");
        }
    }
}
