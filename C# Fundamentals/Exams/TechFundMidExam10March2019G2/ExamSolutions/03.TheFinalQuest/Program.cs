using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.TheFinalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();

            string[] line = Console.ReadLine().Split();
            while (line[0] != "Stop")
            {
                string command = line[0];
                if (command == "Delete")
                {
                    int index = int.Parse(line[1]);
                    index++;
                    if (index >= 0 && index < input.Count)
                    {
                        input.RemoveAt(index);
                    }
                }
                else if (command == "Swap")
                {
                    string word1 = line[1];
                    string word2 = line[2];
                    if (input.Contains(word1) && input.Contains(word2))
                    {
                        int index1 = input.IndexOf(word1);
                        int index2 = input.IndexOf(word2);

                        string temp = word1;
                        input[index1] = input[index2];
                        input[index2] = temp;
                    }
                }
                else if (command == "Put")
                {
                    string word = line[1];
                    int index = int.Parse(line[2]);

                    if (index > 0 && index <= input.Count + 1)
                    {
                        input.Insert(index - 1, word);
                    }
                }

                else if (command == "Replace")
                {
                    string word1 = line[1];
                    string word2 = line[2];

                    if (input.Contains(word2))
                    {
                        int index = input.IndexOf(word2);
                        input[index] = word1;
                    }
                }

                else if (command=="Sort")
                {
                    input = input.OrderByDescending(x => x).ToList();
                }

                line = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", input));
        }
    }
}