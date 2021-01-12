using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Stack
{
    public class MyStack<T> : IEnumerable<T>
    {
        private List<T> data;

        public List<T> Data 
        {
            get { return this.data; }
            set { this.data = value; } 
        }

        public MyStack()
        {
            this.Data = new List<T>();
        }

        public void Push(params T[] items) 
        {
            foreach (var item in items)
            {
                this.Data.Add(item);
            }
        }

        public void Pop() 
        {
            if (this.Data.Any())
            {
                this.data.RemoveAt(this.data.Count - 1);
            }
            else
            {
                throw new InvalidOperationException("No elements");//?
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Data.Count - 1; i >= 0; i--)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
