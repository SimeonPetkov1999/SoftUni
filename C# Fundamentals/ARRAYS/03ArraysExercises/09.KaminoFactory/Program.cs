using System;
using System.Linq;

namespace _09.KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            int[] bestDna = new int[lenght];
            int bestIndex = int.MinValue;
            int bestSum = 0;
            int bestSequenceLenght = 0;
            int currentSequenceLenght = 1;
            int currentSum = 0;
            int sample = 0;
            int bestSample = 0;
            int currentIndex = int.MinValue;

            bool checkForFirstIndex = false;

            while (input != "Clone them!")
            {
                int[] numbers = input.Split('!', StringSplitOptions.RemoveEmptyEntries).
                    Select(int.Parse).
                    ToArray();
                sample++;

                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    if (numbers[i] == 1 && numbers[i + 1] ==1)
                    {
                        currentSequenceLenght++;
                        if (!checkForFirstIndex)
                        {
                            currentIndex = i;
                            checkForFirstIndex = true;
                        }
                    }                         
                }
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i]==1)
                    {
                        currentSum++;
                    }
                }
                if (currentSequenceLenght > bestSequenceLenght)
                {
                    bestDna = numbers;
                    bestSum = currentSum;
                    bestSample = sample;
                    bestIndex = currentIndex;
                    bestSequenceLenght = currentSequenceLenght;
                }
                if (currentSequenceLenght == bestSequenceLenght)
                {
                    if (currentIndex < bestIndex)
                    {
                        bestDna = numbers;
                        bestSum = currentSum;
                        bestSample = sample;
                        bestIndex = currentIndex;
                        bestSequenceLenght = currentSequenceLenght;
                    }
                }
                if ((currentSequenceLenght == bestSequenceLenght) && (currentIndex == bestIndex))
                {
                    if (currentSum > bestSum)
                    {
                        bestDna = numbers;
                        bestSum = currentSum;
                        bestSample = sample;
                        bestIndex = currentIndex;
                        bestSequenceLenght = currentSequenceLenght;
                    }
                }
                checkForFirstIndex = false;
                currentIndex = 0;
                currentSequenceLenght = 1;
                currentSum = 0;
                input = Console.ReadLine();
            }
            Console.WriteLine($"Best DNA sample {bestSample} with sum: {bestSum}.");
            Console.WriteLine(string.Join(" ", bestDna));
        }
    }
}
