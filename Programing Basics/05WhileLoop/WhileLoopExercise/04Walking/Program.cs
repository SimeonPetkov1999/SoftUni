using System;

namespace _04Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int steps = 0;
            int allSteps = 0;
            
            while (true)
            {
                string input = Console.ReadLine();
                if (input=="Going home")
                {
                    steps = int.Parse(Console.ReadLine());
                    allSteps += steps;
                    if (allSteps>=10000)
                    {
                        Console.WriteLine("Goal reached! Good job!");
                        Console.WriteLine($"{allSteps - 10000} steps over the goal!");
                    }
                    else
                    {
                        Console.WriteLine($"{10000-allSteps} more steps to reach goal.");
                    }
                    break;
                }

                steps = int.Parse(input);
                allSteps += steps;

                if (allSteps>=10000)
                {
                    Console.WriteLine("Goal reached! Good job!");
                    Console.WriteLine($"{allSteps-10000} steps over the goal!");
                    break;
                }

            }
        }
    }
}
