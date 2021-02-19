using System;
using System.Collections.Generic;
using System.Linq;
namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            var tasksStack = new Stack<int>(ReadInput(", "));
            var threadsQueue = new Queue<int>(ReadInput(" "));
            var tasktoKill = int.Parse(Console.ReadLine());

            while (true)
            {
                var currentTask = tasksStack.Peek();
                var currentThread = threadsQueue.Peek();
                if (currentTask == tasktoKill)
                {
                    Console.WriteLine($"Thread with value {currentThread} killed task {tasktoKill}");
                    Console.WriteLine(string.Join(' ',threadsQueue));
                    Environment.Exit(0);
                }
                else if (currentThread>=currentTask)
                {
                    tasksStack.Pop();
                    threadsQueue.Dequeue();
                }
                else
                {
                    threadsQueue.Dequeue();
                }
            }
        }
        private static IEnumerable<int> ReadInput(string delimeter) =>
            Console.ReadLine().Split(delimeter).Select(int.Parse).ToArray();

    }
}
