using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = Console.ReadLine();
            while (input != "End")
            {
                List<string> command = input.Split().ToList();


                if (command[0] == "Add")
                {
                    int num = int.Parse(command[1]);
                    numbers.Add(num);
                }

                else if (command[0] == "Insert")
                {
                    int num = int.Parse(command[1]);
                    int index = int.Parse(command[2]);

                    if (index >= numbers.Count || index < 0)
                    {
                        Console.WriteLine("Ivalid index");
                        input = Console.ReadLine();
                        continue;
                    }

                    numbers.Insert(index, num);
                }

                else if (command[0] == "Remove")
                {
                    int index = int.Parse(command[1]);

                    if (index >= numbers.Count || index<0)
                    {
                        Console.WriteLine("Invalid index");
                        input = Console.ReadLine();
                        continue;
                    }

                    numbers.RemoveAt(index);
                }

                else if (command[1] == "left")
                {
                    int count = int.Parse(command[2]);
                    ShiftLeft(numbers, count);
                }

                else if (command[1] == "right")
                {
                    int count = int.Parse(command[2]);
                    ShiftRight(numbers, count);
                }


                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
        static void ShiftLeft(List<int> nums, int count)
        {
            for (int i = 1; i <= count; i++)
            {
                int first = nums[0];
                nums.RemoveAt(0);
                nums.Add(first);
            }
        }

        static void ShiftRight(List<int> nums, int count)
        {
            for (int i = 1; i <= count; i++)
            {
                int last = nums[nums.Count - 1];
                nums.RemoveAt(nums.Count - 1);
                nums.Insert(0, last);
            }
        }
    }
}
