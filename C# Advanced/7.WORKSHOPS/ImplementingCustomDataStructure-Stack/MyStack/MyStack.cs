using System;
using System.Collections.Generic;
using System.Text;

namespace MyStack
{
    class MyStack
    {
        private int capacity;
        private int[] data;

        public MyStack() : this(4) { }

        public MyStack(int capacity)
        {
            this.capacity = capacity;
            this.data = new int[capacity];
        }

        public int Count { get; private set; }

        public void Push(int item) 
        {
            IsResizeNeeded();
            this.data[this.Count] = item;
            Count++;
        }

        public int Pop() 
        {
            CheckIsItEmpty();
            var toReturn = this.data[this.Count - 1];
            this.Count--;
            return toReturn;
        }

        public int Peek() 
        {
            CheckIsItEmpty();
            return this.data[this.Count - 1];
        }

        public void ForEach(Action<int> action) 
        {
            for (int i = this.Count-1; i >= 0; i--)
            {
                action(this.data[i]);
            }
        }

        private void IsResizeNeeded() 
        {
            if (this.data.Length==this.Count)
            {
                Resize();
            }
        }

        private void Resize() 
        {
            var newData = new int[this.data.Length * 2];

            for (int i = 0; i < this.data.Length; i++)
            {
                newData[i] = data[i];
            }

            this.data = newData;
        }

        private void CheckIsItEmpty() 
        {
            if (this.Count==0)
            {
                throw new Exception("Stack is empty");
            }
        }

    }
}
