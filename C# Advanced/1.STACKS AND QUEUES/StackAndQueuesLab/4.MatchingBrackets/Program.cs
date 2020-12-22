using System;
using System.Collections.Generic;
using System.Linq;
namespace _4.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i]=='(')
                {
                    stack.Push(i);
                }
                else if (input[i]==')')
                {
                    var startIndex = stack.Pop();
                    var lenght = input.Length;
                    Console.WriteLine(input.Substring(startIndex,i-startIndex+1));
                }
            }
        }
    }
}
