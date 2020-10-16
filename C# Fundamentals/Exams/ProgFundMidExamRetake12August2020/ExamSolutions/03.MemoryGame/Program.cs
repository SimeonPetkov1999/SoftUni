using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine().Split().ToList();

            List<string> input = Console.ReadLine().Split().ToList();
            int moves = 0;
            while (input[0] != "end")
            {
                int index1 = int.Parse(input[0]);
                int index2 = int.Parse(input[1]);

                if (index1 == index2)
                {
                    moves++;
                    AddingElementsToTheList(elements, moves);
                    input = Console.ReadLine().Split().ToList();
                    continue;

                }
                else if (index1 < 0 || index1 >= elements.Count)
                {
                    moves++;
                    AddingElementsToTheList(elements, moves);
                    input = Console.ReadLine().Split().ToList();
                    continue;
                }
                else if (index2 < 0 || index2 >= elements.Count)
                {
                    moves++;
                    AddingElementsToTheList(elements, moves);
                    input = Console.ReadLine().Split().ToList();
                    continue;
                }

                if (elements[index1] == elements[index2])
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {elements[index1]}!");
                    moves++;
                    elements.RemoveAt(Math.Max(index1, index2));
                    elements.RemoveAt(Math.Min(index1, index2));

                }

                else if (elements[index1] != elements[index2])
                {
                    Console.WriteLine("Try again!");
                    moves++;
                }

                if (elements.Count == 0)
                {
                    Console.WriteLine($"You have won in {moves} turns!");
                     Environment.Exit(0);
                }
                input = Console.ReadLine().Split().ToList();
            }

            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(string.Join(" ",elements));
           
        }
        static void AddingElementsToTheList(List<string> elements, int moves)
        {
            Console.WriteLine("Invalid input! Adding additional elements to the board");
            int middle = elements.Count / 2;
            elements.Insert(middle, $"-{moves}a");
            elements.Insert(middle, $"-{moves}a");
        }
    }
}
