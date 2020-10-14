using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable
    {
        private SortedSet<Book> books;
        public Library(params Book[] books)
        {
            this.Books = new SortedSet <Book> (books, new BookComparator());
        }
        public SortedSet<Book> Books { get; private set; }

        public IEnumerator GetEnumerator()
        {
            return new LibraryIterator(this.books.ToList());
        }
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int currentIndex;
            public LibraryIterator(IEnumerable<Book> books)
            {
                this.Reset();
                this.books = new List<Book>(books);
            }
            public Book Current => this.books[this.currentIndex];

            object IEnumerator.Current => this.Current;

            public void Dispose(){ }
            

            public bool MoveNext()
            {
                return ++this.currentIndex < this.books.Count;
            }

            public void Reset()
            {
                this.currentIndex = -1;
            }
        }
    }
}
