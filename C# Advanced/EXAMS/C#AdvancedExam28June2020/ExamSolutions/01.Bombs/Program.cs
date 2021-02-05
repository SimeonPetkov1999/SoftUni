using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class Program
    {
        private const int DaturaBomb = 40;
        private const int CherryBomb = 60;
        private const int SmokeDecoyBomb = 120;

        static void Main(string[] args)
        {
            var bombEffects = ReadInput();
            var bombCasings = ReadInput();

            var bombEffectsQueue = new Queue<int>(bombEffects);
            var bombCasingsStack = new Stack<int>(bombCasings);

            int enzioDaturaBombs = 0;
            int enzioCherryBombs = 0;
            int enzioSmokeDecoyBombs = 0;
            bool IsSuccesfull = false;

            while (bombCasingsStack.Any() && bombEffectsQueue.Any())
            {
                var currentEffect = bombEffectsQueue.Dequeue();
                var currentCasing = bombCasingsStack.Pop();
                var currentSum = currentCasing + currentEffect;

                while (currentSum != DaturaBomb &&
                       currentSum != CherryBomb &&
                       currentSum != SmokeDecoyBomb)
                {
                    currentCasing -= 5;
                    currentSum = currentCasing + currentEffect;
                }

                switch (currentSum)
                {
                    case DaturaBomb:
                        enzioDaturaBombs++;
                        break;
                    case CherryBomb:
                        enzioCherryBombs++;
                        break;
                    case SmokeDecoyBomb:
                        enzioSmokeDecoyBombs++;
                        break;
                }

                if (enzioCherryBombs >= 3 && enzioDaturaBombs >= 3 && enzioSmokeDecoyBombs >= 3)
                {
                    IsSuccesfull = true;
                    break;
                }
            }

            PrintIsItSuccesfull(IsSuccesfull);
            PrintLeftCasingsAndEffects(bombEffectsQueue, bombCasingsStack);
            PrintBombs(enzioDaturaBombs, enzioCherryBombs, enzioSmokeDecoyBombs);
        }

        private static void PrintLeftCasingsAndEffects(Queue<int> bombEffectsQueue, Stack<int> bombCasingsStack)
        {
            string bombEffectsOutput = bombEffectsQueue.Any() ?
                                     string.Join(", ", bombEffectsQueue) :
                                     "empty";
            Console.WriteLine($"Bomb Effects: {bombEffectsOutput}");
            string bombCasingsOutput = bombCasingsStack.Any() ?
                                     string.Join(", ", bombCasingsStack) :
                                     "empty";
            Console.WriteLine($"Bomb Casings: {bombCasingsOutput}");
        }

        private static void PrintBombs(int enzioDaturaBombs, int enzioCherryBombs, int enzioSmokeDecoyBombs)
        {
            Console.WriteLine($"Cherry Bombs: {enzioCherryBombs}");
            Console.WriteLine($"Datura Bombs: {enzioDaturaBombs}");
            Console.WriteLine($"Smoke Decoy Bombs: {enzioSmokeDecoyBombs}");
        }

        private static void PrintIsItSuccesfull(bool IsSuccesfull)
        {
            if (IsSuccesfull)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
        }

        private static int[] ReadInput()
        {
            return Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
