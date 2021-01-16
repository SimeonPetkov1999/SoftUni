using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public Stack<string> Stack { get; set; }

        public StackOfStrings()
        {
            this.Stack = new Stack<string>();
        }

        public bool IsEmpty() 
        {
            return this.Count == 0;
        }
        public Stack<string> AddRange<T>(ICollection<string> collection)
        {
            foreach (var item in collection)
            {
                this.Stack.Push(item);
            }
            return this.Stack;

        }

    }
}
