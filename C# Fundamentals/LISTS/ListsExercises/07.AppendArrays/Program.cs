using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputNums = Console.ReadLine().
                Split('|', StringSplitOptions.RemoveEmptyEntries).
                ToList();

            inputNums.Reverse();
            string chars = string.Empty;
            for (int i = 0; i < inputNums.Count; i++)
            {
                chars += inputNums[i]+" ";
            }
            string[] outputArr = chars.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(string.Join(" ",outputArr));
        }
    }
}
