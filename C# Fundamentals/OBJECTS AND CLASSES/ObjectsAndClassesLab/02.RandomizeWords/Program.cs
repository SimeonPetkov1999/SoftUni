using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split().ToList();
            //string[] mixedWords = new string[words.Count];
            Random rnd = new Random();
            

            for (int i = 0; i < words.Count; i++)
            {
                int random =rnd.Next(i, words.Count);
                var a = words[i];
                var b = words[random];
                words[i] = b;
                words[random] = a;
            }

            Console.WriteLine(string.Join(Environment.NewLine,words));
        }
    }
}
