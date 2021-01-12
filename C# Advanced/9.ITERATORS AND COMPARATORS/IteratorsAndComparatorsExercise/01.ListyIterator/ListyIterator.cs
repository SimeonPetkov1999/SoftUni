using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> data;
        private int index;

        public ListyIterator()
        {
            this.data = new List<T>();
            this.Index = -1;
        }

        public ListyIterator(List<T> data)
        {
            this.data = data;
            this.Index = 0;
        }

        public List<T> Data
        {
            get { return this.data; }
            set { this.data = value; }
        }
        public int Index
        {
            get { return this.index; }
            set { this.index = value; }
        }

        public bool Move()
        {
            if (this.Index >= 0 && this.Index < this.Data.Count - 1)
            {
                this.Index++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            if (this.Index >= 0 && this.Index < this.Data.Count - 1)
            {
                return true;
            }
            return false;
        }

        public void Print()
        {
            if (this.Index != -1)
            {
                Console.WriteLine(this.Data[this.Index]);
            }
            else
            {
                throw new InvalidOperationException("Invalid Operation");
            }
        }
    }
}
