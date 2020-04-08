using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class LibraryIterator : IEnumerator<Book>
    {
        private readonly List<Book> books;
        private int currentIndex;

        public LibraryIterator(IEnumerable<Book> books)
        {
            Reset();
            this.books = new List<Book>(books);
        }

        public Book Current => this.books[currentIndex];

        object IEnumerator.Current => this.Current;

        public void Dispose() { }

        public bool MoveNext()
        {
            this.currentIndex = this.currentIndex + 1;
            bool result = this.currentIndex < this.books.Count;

            return result;
        }

        public void Reset()
        {
            this.currentIndex = -1;
        }
    }
}