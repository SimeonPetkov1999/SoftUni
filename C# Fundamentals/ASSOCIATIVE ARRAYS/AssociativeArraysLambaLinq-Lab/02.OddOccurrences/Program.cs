using System;
using System.Collections.Generic;

namespace _02.OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().ToLower().Split();

            Dictionary<string, int> eachWordCount = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                if (!eachWordCount.ContainsKey(words[i]))
                {
                    eachWordCount.Add(words[i], 1);
                }
                else
                {
                    eachWordCount[words[i]]++;
                }
            }

            foreach (var word in eachWordCount)
            {
                if (word.Value % 2 != 0)
                {
                    Console.Write($"{word.Key} ");
                }
            }
        }
    }
}
