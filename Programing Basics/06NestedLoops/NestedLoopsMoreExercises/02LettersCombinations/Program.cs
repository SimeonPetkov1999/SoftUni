using System;

namespace _02LettersCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            char ingnore = char.Parse(Console.ReadLine());
            int allCombination = 0;

            for (char i = start; i <= end; i++)
            {
                for (char j = start; j <= end; j++)
                {
                    for (char k = start; k <= end; k++)
                    {
                        if (i != ingnore && j != ingnore && k != ingnore)
                        {
                            Console.Write($"{i}{j}{k} ");
                            allCombination++;
                        }

                    }
                }
            }

            Console.WriteLine(allCombination);
        }
    }
}
