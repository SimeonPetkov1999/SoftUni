using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstInput = Console.ReadLine();
            List<int> numbers = firstInput.Split().Select(int.Parse).ToList();

            string input = Console.ReadLine();

            while (input != "end")
            {
                List<string> command = input.Split().ToList();

                if (command[0] == "Add")
                {
                    numbers.Add(int.Parse(command[1]));
                }

                else if (command[0] == "Remove")
                {
                    numbers.Remove(int.Parse(command[1]));
                }

                else if (command[0] == "RemoveAt")
                {
                    numbers.RemoveAt(int.Parse(command[1]));
                }

                else if (command[0] == "Insert")
                {
                    numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                }

                else if (command[0] == "Contains")
                {
                    if (numbers.Contains(int.Parse(command[1])))
                    {
                        Console.WriteLine("Yes");
                    }

                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }

                else if (command[0] == "PrintEven")
                {
                    Console.WriteLine($"{string.Join(" ", numbers.FindAll(i => i % 2 == 0))} ");
                }

                else if (command[0] == "PrintOdd")
                {
                    Console.WriteLine($"{string.Join(" ", numbers.FindAll(i => i % 2 != 0))} ");
                }

                else if (command[0] == "GetSum")
                {
                    Console.WriteLine(numbers.Sum());
                }

                else if (command[0] == "Filter")
                {
                    int num = int.Parse(command[2]);
                    if (command[1] == "<")
                    {
                        Console.WriteLine($"{string.Join(" ", numbers.FindAll(i => i < num))} ");
                    }
                    else if (command[1] == ">")
                    {
                        Console.WriteLine($"{string.Join(" ", numbers.FindAll(i => i > num))} ");
                    }
                    else if (command[1] == ">=")
                    {
                        Console.WriteLine($"{string.Join(" ", numbers.FindAll(i => i >= num))} ");
                    }
                    else if (command[1] == "<=")
                    {
                        Console.WriteLine($"{string.Join(" ", numbers.FindAll(i => i <= num))} ");
                    }
                }
                input = Console.ReadLine();
            }       
            List<int> original = firstInput.Split().Select(int.Parse).ToList();
            if (!original.SequenceEqual(numbers))
            {
                PrintList(numbers);
            }
        }

        
        static void PrintList(List<int> numbers)
        {
            Console.WriteLine(string.Join(" ", numbers));
        }

    }
}
