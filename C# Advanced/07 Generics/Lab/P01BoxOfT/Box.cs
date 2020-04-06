using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> element;
        public int Count { get; private set; }
        public T Element { get; set; }

        public Box ()
        {
            this.element = new List<T>();
        }

        public void Add(T value)
        {
            this.element.Add(value);
            this.Count++;
        }

        public T Remove()
        {
            T remove = this.element[this.Count - 1];
            this.element.RemoveAt(this.Count-1);
            this.Count--;

            return remove; 
        }
    }
}
