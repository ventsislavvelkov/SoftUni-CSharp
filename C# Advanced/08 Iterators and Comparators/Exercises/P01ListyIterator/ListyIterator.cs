using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T>
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
            this.store = new List<T>(store);
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
                currentIndex++;
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (this.store.Any())
            {
                Console.WriteLine(this.store[currentIndex]);
            }
            else
            {
                Console.WriteLine("Invalid Operation!");
            }
        }

        public bool HasNext()
        {
            if (currentIndex < this.store.Count-1)
            {
                return true;
            }
            return false;
        }
    }
}
