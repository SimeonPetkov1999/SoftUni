using System;
using System.Linq;

namespace _07.MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int maxSequencedNum = int.MinValue;
            int maxSequence = int.MinValue;

            int currentSequencedNum = 1;
            int currentMaxSequence = 1;
 
            for (int i = 0; i < numbers.Length-1; i++)
            {
                if (numbers[i]==numbers[i+1])
                {
                    currentMaxSequence++;
                    currentSequencedNum = numbers[i];
                }
                else
                {
                    currentMaxSequence = 1;
                }


                if (currentMaxSequence>maxSequence)
                {
                    maxSequence = currentMaxSequence;
                    maxSequencedNum = currentSequencedNum;
                }
            }

            for (int i = 0; i < maxSequence; i++)
            {
                Console.Write(maxSequencedNum + " ");
            }
        }
    }
}
