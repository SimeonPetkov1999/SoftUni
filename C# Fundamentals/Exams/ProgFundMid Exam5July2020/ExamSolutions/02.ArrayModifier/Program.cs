using System;
using System.Linq;

namespace _02.ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] commands = input.Split();
                string command;
                int index1 = 0;
                int index2 = 0;
                if (input != "decrease")
                {
                    command = commands[0];
                    index1 = int.Parse(commands[1]);
                    index2 = int.Parse(commands[2]);
                }
                else
                {
                    command = input;
                }
                switch (command)
                {
                    case "swap":
                        int temp = numbers[index1];
                        numbers[index1] = numbers[index2];
                        numbers[index2] = temp;
                        break;
                    case "multiply":
                        numbers[index1] = numbers[index1] * numbers[index2];
                        break;
                    case "decrease":
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            numbers[i] = numbers[i] - 1;
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(", ",numbers));
        }
    }
}
