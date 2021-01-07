using System;
using System.Collections;

namespace MyStack
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack stack = new MyStack();

            for (int i = 1; i < 7; i++)
            {
                stack.Push(i);
            }

            stack.ForEach(n => Console.WriteLine(n + 10));
        }
    }
}
