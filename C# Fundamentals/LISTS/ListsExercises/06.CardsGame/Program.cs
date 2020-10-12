using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayerCards = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToList();
            List<int> secondPlayerCards = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToList();

            while (true)
            {
                if (firstPlayerCards[0] > secondPlayerCards[0])
                {
                    int firstCard = firstPlayerCards[0];
                    firstPlayerCards.Add(firstCard);
                    firstPlayerCards.RemoveAt(0);
                    firstPlayerCards.Add(secondPlayerCards[0]);
                    secondPlayerCards.RemoveAt(0);
                }

                else if (firstPlayerCards[0] < secondPlayerCards[0])
                {
                    int firstCard = secondPlayerCards[0];
                    secondPlayerCards.Add(firstCard);
                    secondPlayerCards.RemoveAt(0);
                    secondPlayerCards.Add(firstPlayerCards[0]);
                    firstPlayerCards.RemoveAt(0);
                }

                else
                {
                    secondPlayerCards.RemoveAt(0);
                    firstPlayerCards.RemoveAt(0);

                }

                if (firstPlayerCards.Count == 0 || secondPlayerCards.Count == 0)
                {
                    break;
                }
            }

            int sum = Math.Max(firstPlayerCards.Sum(), secondPlayerCards.Sum());

            if (firstPlayerCards.Count>0)
            {
                Console.WriteLine($"First player wins! Sum: {sum}");
            }

            else
            {
                Console.WriteLine($"Second player wins! Sum: {sum}");
            }

        }
    }
}
