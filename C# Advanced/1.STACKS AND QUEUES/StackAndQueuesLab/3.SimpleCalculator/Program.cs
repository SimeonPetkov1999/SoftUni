using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            var stack = new Stack<string>(input.Reverse());

            while (stack.Count>1)
            {
                var firstNum = int.Parse(stack.Pop());                
                var symbol = stack.Pop();
                var secondNum = int.Parse(stack.Pop());

                var result = 0;
                if (symbol=="+")
                {
                    result = firstNum + secondNum;
                }
                else if (symbol=="-")
                {
                    result = firstNum - secondNum;
                }
                stack.Push(result.ToString());
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
