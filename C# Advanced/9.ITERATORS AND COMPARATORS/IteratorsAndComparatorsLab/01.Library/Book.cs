using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {

        public string Title { get; set; }
        public int Year { get; set; }
        public List<string> Authors { get; set; }//?

        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = authors.ToList();
        }

        public int CompareTo(Book other)
        {
            var compare = this.Year.CompareTo(other.Year);
            if (compare == 0)
            {
                compare = this.Title.CompareTo(other.Title);
            }

            return compare;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
    }
}
