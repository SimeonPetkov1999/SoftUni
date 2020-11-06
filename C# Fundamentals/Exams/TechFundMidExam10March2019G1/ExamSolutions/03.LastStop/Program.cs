using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LastStop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string[] inputArgs = Console.ReadLine().Split();
            while (inputArgs[0]!="END")
            {
                string command = inputArgs[0];
                if (command=="Change")
                {
                    int paintNum = int.Parse(inputArgs[1]);
                    int toChange = int.Parse(inputArgs[2]);

                    if (numbers.Contains(paintNum))
                    {
                        int index = numbers.IndexOf(paintNum);
                        numbers[index] = toChange;
                    }
                }

                else if (command =="Hide")
                {
                    int paintNum = int.Parse(inputArgs[1]);
                    if (numbers.Contains(paintNum))
                    {
                        numbers.Remove(paintNum);
                    }
                }

                else if (command=="Switch")
                {
                    int num1 = int.Parse(inputArgs[1]);
                    int num2 = int.Parse(inputArgs[2]);

                    if (numbers.Contains(num1) && numbers.Contains(num2))
                    {
                        int index1 = numbers.IndexOf(num1);
                        int index2 = numbers.IndexOf(num2);

                        int temp = numbers[index1];
                        numbers[index1] = numbers[index2];
                        numbers[index2] = temp;
                    }
                }

                else if (command=="Insert")
                {
                    int index = int.Parse(inputArgs[1]);
                    int painNum = int.Parse(inputArgs[2]);
                    index++;
                    if (index>=0 && index <=numbers.Count)
                    {
                        numbers.Insert(index, painNum);
                    }
                }

                else if (command=="Reverse")
                {
                    numbers.Reverse();
                }
                inputArgs = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
