using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyList
{
    public class MyList<T> : IEnumerable<T>
    {
        private T[] data;
        private int capacity;
        public int Count { get; private set; }

        public MyList() : this(4) { }
        public MyList(int capacity)
        {
            this.data = new T[capacity];
            this.capacity = capacity;
        }

        /// <summary>
        /// Add item at the end of the list
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            IsResizeNeeded();
            this.data[Count] = item;
            Count++;
        }

        /// <summary>
        /// Removes item at the given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Returns the removed item</returns>
        public T RemoveAt(int index)
        {
            ValidateIndex(index);
            var removed = this.data[index];
            for (int i = index; i < this.Count; i++)
            {
                this.data[i] = this.data[i + 1];
            }
            this.Count--;

            return removed;
        }

        /// <summary>
        /// Check if given item is int the collection
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool Contains(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (data[i].Equals(element))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Swaps the elements at the given indexes
        /// </summary>
        /// <param name="firstIndex"></param>
        /// <param name="secondIndex"></param>
        public void Swap(int firstIndex, int secondIndex)
        {
            ValidateIndex(firstIndex);
            ValidateIndex(secondIndex);

            var temp = this.data[firstIndex];
            this.data[firstIndex] = this.data[secondIndex];
            this.data[secondIndex] = temp;
        }

        /// <summary>
        /// Insert item in the given index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, T item)
        {

            ValidateIndex(index);
            IsResizeNeeded();
            for (int i = this.Count; i >= index + 1; i--)
            {
                this.data[i] = this.data[i - 1];
            }
            this.data[index] = item;
            this.Count++;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns>Returns a collection of items in the given range</returns>
        public T[] GetRange(int index,int count) 
        {
            ValidateIndex(index);
            ValidateIndex(index + count-1);
            var toReturn = new T[count];
            int j = 0;

            for (int i = index; i < count+index; i++)
            {
                toReturn[j++] = this.data[i];
            }
            return toReturn;
        }

        /// <summary>
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Index of the first element equal to the item if it is int the List. Otherwise returns -1</returns>
        public int FirstIndexOf(T item) 
        {
            if (Contains(item))
            {
                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i].Equals(item))
                    {
                        return i;
                    }
                }
                return -1;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Check if the given predicate is true for all items in the List
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public bool TrueForAll(Predicate<T> predicate)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (!predicate(this.data[i]))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Clear all items in the current List
        /// </summary>
        public void Clear()
        {
            this.Count = 0;
            this.data = new T[this.capacity];
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return this.data[index];
            }
            set
            {
                ValidateIndex(index);
                this.data[index] = value;
            }
        }
        private void Resize()
        {
            var newData = new T[this.data.Length * 2];

            for (int i = 0; i < this.data.Length; i++)
            {
                newData[i] = this.data[i];
            }

            this.data = newData;
        }
        private void ValidateIndex(int index)
        {
            var message = this.Count == 0 ?
                "List is empty" :
                "Index out of Range";

            if (index < 0 || index >= this.Count)
            {
                throw new Exception(message);
            }
        }
        private void IsResizeNeeded() 
        {
            if (this.Count == this.data.Length)
            {
                Resize();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.data
                .Take(this.Count)
                .ToList()
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
