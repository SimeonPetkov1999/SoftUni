﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book first, Book second)
        {
            var result = first.Title.CompareTo(second.Title);
            if (result == 0)
            {
                result = second.Year.CompareTo(first.Year);
            }

            return result;
        }
    }
}
