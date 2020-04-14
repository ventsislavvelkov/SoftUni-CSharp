using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private int currentIndex;

        private List<T> store;


        public ListyIterator()
        {
            this.store = new List<T>();
            currentIndex = 0;
        }

        public ListyIterator(List<T> store)
        {
            this.store = store;
            currentIndex = 0;
        }

        public void Add(List<T> elements)
        {
            this.store.AddRange(elements);
        }

        public bool Move()
        {
            if (this.HasNext())
            {
                this.currentIndex++;
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (this.store.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.store[currentIndex]);
        }

        public bool HasNext()
        {
            if (currentIndex < this.store.Count-1)
            {
                return true;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.store)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
