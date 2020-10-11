using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = ReadListOnLine();

            string input = Console.ReadLine();

            while (input!="end")
            {
                List<string> command = input.Split().ToList();

                if (command[0]=="Add")
                {
                    AddList(numbers, int.Parse(command[1]));
                }

                else if (command[0]=="Remove")
                {
                    RemoveFromList(numbers, int.Parse(command[1]));
                }

                else if (command[0]=="RemoveAt")
                {
                    RemoveAtList(numbers, int.Parse(command[1]));
                }

                else if (command[0]=="Insert")
                {
                    InsertAtIndex(numbers, int.Parse(command[1]), int.Parse(command[2]));
                }
                input = Console.ReadLine();
            }

            PrintList(numbers);
        }

        static void PrintList(List<int> numbers)
        {
            Console.WriteLine(string.Join(" ", numbers));
        }

        static void InsertAtIndex(List<int> numbers, int num, int index)
        {
            numbers.Insert(index,num);
        }

        static void RemoveAtList(List<int> numbers, int index)
        {
            numbers.RemoveAt(index);
        }

        static void RemoveFromList(List<int> numbers, int num)
        {
            numbers.Remove(num);
        }

        static void AddList(List<int> numbers, int num) 
        {
            numbers.Add(num);            
        }

        static List<int> ReadListOnLine()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            return numbers;

        }
    }
}
