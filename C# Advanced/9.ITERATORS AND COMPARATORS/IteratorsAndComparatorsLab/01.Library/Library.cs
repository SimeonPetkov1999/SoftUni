using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        public List<Book> Books { get; set; }

        public Library(params Book[] books)
        {
            this.Books = books.ToList();
            this.Books.Sort(new BookComparator());
        }

        public IEnumerator<Book> GetEnumerator()
        {         
            return new LibraryIterator(this.Books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        private class LibraryIterator : IEnumerator<Book>
        {
            private int Index { get; set; }
            private List<Book> books;

            public LibraryIterator(List<Book> books)
            {
                this.Reset();
                this.books = books;//?       
            }

            public Book Current
            {
                get
                {
                    return this.books[this.Index];
                }
            }

            public bool MoveNext()
            {
                return ++this.Index < this.books.Count;
            }

            public void Reset()
            {
                this.Index = -1;
            }

            public void Dispose() { }
            object IEnumerator.Current => throw new NotImplementedException();
        }
    }


}
