using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    class MyStack<T> : IEnumerable<T>
    {
        private const int initialCapacity = 4;
        private T[] items;
        private int count;

        public MyStack()
        {
            this.items = new T[initialCapacity];
            this.count = 0;
        }


        public T[] Items { get; private set; }

        public int Count { get; set; }

        public void Push(T element)
        {
            EnsureCapacity();
            this.items[this.count] = element;
            this.count++;
        }

        public T Pop()
        {
            ValidationIndex();
            var lastIndex = this.count - 1;
            T last = this.items[lastIndex];
            this.count--;
            return last;
        }



        public T Peek()
        {
            ValidationIndex();
          
            return this.items[this.count-1];

        }

        public void ForEach(Action<T> action)
        {
            for (int i = this.count - 1; i >= 0; i--)
            {
                action(this.items[i]);
            }
        }

        private void ValidationIndex()
        {
            if (this.items.Length == 0)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void EnsureCapacity()
        {
            if (this.items.Length > this.count)
            {
                return;
            }
            var tempArray = new T[2 * this.items.Length];

            //Short copy all elements from old array to new array
            // Array.Copy(this.Items,tempArray,this.items.Length);

            for (int i = 0; i < this.items.Length; i++)
            {
                tempArray[i] = this.items[i];
            }

            this.items = tempArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.count - 1; i >= 0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return null;
        }
    }
}
