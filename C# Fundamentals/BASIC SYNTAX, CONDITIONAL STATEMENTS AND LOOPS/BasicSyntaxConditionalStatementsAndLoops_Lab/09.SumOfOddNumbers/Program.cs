using System;

namespace _09.SumOfOddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int oddNum = 0;
            int curnum = 1;

            while (oddNum!=n)
            {              
                if (curnum % 2 != 0)
                {
                    Console.WriteLine(curnum);
                    sum += curnum;
                    oddNum++;
                }
                curnum++;
                
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
