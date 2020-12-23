using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputLine = Console.ReadLine();

            var stack = new Stack<char>();
            bool isBalanced = true;
            char lastChar = 'A';
            for (int i = 0; i < inputLine.Length; i++)
            {
                char currentChar = inputLine[i];
                if (stack.Any())
                {
                     lastChar = stack.Peek();
                }
               
                switch (currentChar)
                {
                    case '(':
                    case '{':
                    case '[':
                        stack.Push(currentChar);
                        break;
                    case ')':

                        if (lastChar == '(' && stack.Any())
                        {
                            stack.Pop();
                            continue;
                        }
                        else
                        {
                            isBalanced = false;
                        }
                        break;
                    case '}':

                        if (lastChar == '{' && stack.Any())
                        {
                            stack.Pop();
                            continue;
                        }
                        else
                        {
                            isBalanced = false;
                        }
                        break;
                    case ']':

                        if (lastChar == '[' && stack.Any())
                        {
                            stack.Pop();
                            continue;
                        }
                        else
                        {
                            isBalanced = false;
                        }
                        break;
                }
                if (!isBalanced)
                {
                    Console.WriteLine("NO");
                    Environment.Exit(0);
                }
            }
            Console.WriteLine("YES");
         }

    }
}
