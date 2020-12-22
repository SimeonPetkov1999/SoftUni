using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
             var stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            var capacity = int.Parse(Console.ReadLine());
            var sum = 0;
            var racks = 1;
            while (stack.Any())
            {
                if (sum + stack.Peek() < capacity)
                {
                    sum += stack.Pop();
                }
                else if (sum + stack.Peek() == capacity)
                {
                    if (stack.Count >= 1)
                    {
                        racks++;
                        sum = 0;
                    }
                }
                else
                {
                    sum = 0;
                    racks++;
                }
            }
            Console.WriteLine(racks);
         }
    }
}
