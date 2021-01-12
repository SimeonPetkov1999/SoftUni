using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.Collection
{
    class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> data;
        private int index;


        public ListyIterator(params T[] data)
        {
            this.data = new List<T>(data);
            this.Index =0;
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
            if (this.Index == 0)
            {             
                throw new InvalidOperationException("Invalid Operation");
            }
            else
            {
                Console.WriteLine(this.Data[this.Index]);
            }
        }

        //public void PrintAll() 
        //{
        //    Console.WriteLine(string.Join(" ", this.Data));
        //}

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.Data)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
