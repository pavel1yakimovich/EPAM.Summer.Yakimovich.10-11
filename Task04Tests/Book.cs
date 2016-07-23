using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04Tests
{
    class Book : IComparable<Book>, IEquatable<Book>
    {
        public int Pages { get; }
        public int Year { get; }

        public Book(int pages, int year)
        {
            Pages = pages;
            Year = year;
        }

        public int CompareTo(Book other)
        {
            return this.Pages.CompareTo(other.Pages);
        }

        public bool Equals(Book other)
        {
            if (this.Pages == other.Pages)
                return this.Year == other.Year;
            return false;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj);
        }
    }
}
