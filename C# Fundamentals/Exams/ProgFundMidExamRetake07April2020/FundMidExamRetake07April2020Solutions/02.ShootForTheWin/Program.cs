using System;
using System.Linq;

namespace _02.ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string input = string.Empty;
            int shotTargets = 0;
            while ((input = Console.ReadLine()) != "End")
            {
                int indexOfTarget = int.Parse(input);
                int pointsOfTarget;

                if (indexOfTarget < 0 || indexOfTarget > targets.Length - 1)
                {
                    continue;
                }

                if (targets[indexOfTarget] != -1)
                {
                    pointsOfTarget = targets[indexOfTarget];
                    targets[indexOfTarget] = -1;
                    shotTargets++;
                    for (int i = 0; i < targets.Length; i++)
                    {
                        if (targets[i] != -1 && targets[i] > pointsOfTarget)
                        {
                            targets[i] = targets[i] - pointsOfTarget;
                        }

                        else if (targets[i] != -1 && targets[i] <= pointsOfTarget)
                        {
                            targets[i] = targets[i] + pointsOfTarget;
                        }
                    }
                }
            }
            Console.WriteLine($"Shot targets: {shotTargets} -> " + string.Join(" ", targets));
        }
    }
}
