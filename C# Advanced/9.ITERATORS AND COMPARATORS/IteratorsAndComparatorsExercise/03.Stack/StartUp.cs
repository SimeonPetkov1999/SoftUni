using System;
using System.Linq;

namespace _03.Stack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var stack = new MyStack<string>();

            var command = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            while (command[0]!="END")
            {
                if (command[0]=="Push")
                {
                    stack.Push(command.Skip(1).ToArray());
                }
                if (command[0]=="Pop")
                {
                    if (!stack.Any())
                    {
                        Console.WriteLine("No elements");
                        Environment.Exit(0);
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
                command = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
