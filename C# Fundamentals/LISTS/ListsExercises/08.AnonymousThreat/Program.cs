using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace _08.AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().
                Split(' ', StringSplitOptions.RemoveEmptyEntries).
                ToList();

            string[] command = Console.ReadLine().Split();

            while (command[0] != "3:1")
            {
                if (command[0] == "merge")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);

                    if (startIndex < 0 || startIndex >= input.Count)
                    {
                        startIndex = 0;
                    }

                    if (endIndex >= input.Count)
                    {
                        endIndex = input.Count - 1;
                    }

                    for (int i = startIndex + 1; i <= endIndex; i++)
                    {
                        input[startIndex] += input[startIndex + 1];
                        input.RemoveAt(startIndex + 1);
                    }
                }

                else if (command[0] == "divide")
                {
                    int index = int.Parse(command[1]);
                    int partitions = int.Parse(command[2]);
                    string toDevide = input[index];

                    string[] devided = new string[partitions];
                    int indexOfstring = 0;
                    for (int i = 0; i < partitions; i++)
                    {
                        devided[i] += toDevide[indexOfstring++];
                        devided[i] += toDevide[indexOfstring++];
                    }

                    input.RemoveAt(index);

                    for (int i = index; i < partitions; i++)
                    {
                        input.Insert(i, devided[i]);
                    }

                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join("", input));

        }
    }
}