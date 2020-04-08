using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library( params Book[] name)
        {
            this.books = new List<Book>(name);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            // return this.books.GetEnumerator;

            foreach (var book in books)
            {
                yield return book;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
