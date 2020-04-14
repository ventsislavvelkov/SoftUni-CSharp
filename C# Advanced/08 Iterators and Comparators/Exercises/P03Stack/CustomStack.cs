using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P03Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> innerList;

        public CustomStack()
        {
            this.innerList = new List<T>();
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Push(T element)
        {
            this.innerList.Add(element);
            this.Count++;
        }

        public T Pop()
        {
            this.CheckIfEmpty();
            this.Count--;

            T tempElement = this.innerList[this.Count];
            this.innerList.Remove(tempElement);

            return tempElement;
        }

        public T Peek()
        {
            this.CheckIfEmpty();

            return this.innerList[this.Count - 1];
        }

        private void CheckIfEmpty()
        {
            if (this.Count == 0)
            {
                Console.WriteLine("No elements");
                Environment.Exit(0);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int number = innerList.Count - 1; number >= 0; number--)
            {
                yield return innerList[number];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
