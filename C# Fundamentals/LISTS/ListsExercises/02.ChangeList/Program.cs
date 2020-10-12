using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = Console.ReadLine();

            while (input!="end")
            {
                List<string> command = input.Split().ToList();

                if (command[0]=="Delete")
                {
                    int numToDelete = int.Parse(command[1]);
                    numbers.RemoveAll(item => item == numToDelete);
                }
                else if (command[0]=="Insert")
                {
                    int numToInsert = int.Parse(command[1]);
                    int position = int.Parse(command[2]);
                    numbers.Insert(position, numToInsert);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
