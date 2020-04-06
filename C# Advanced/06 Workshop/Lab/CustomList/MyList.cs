using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace CustomList
{
    class MyList<T>
    {
        private T[] items;

        private const int InitialCapacity = 2;

        public MyList()
        {
            this.items = new T[InitialCapacity];
            this.Count = 0;
        }

        public T[] Items { get; private set; }

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return this.items[index];
            }
            set
            {
                ValidateIndex(index);
                this.items[index] = value;
            }
        }

        public void Add(T element)
        {
            EnsureCapacity();
            this.items[this.Count] = element;
            this.Count++;

        }
         
        public T RemoveAt(int index)
        {
          ValidateIndex(index);
          T element = this.items[index];
          ShiftToLeft(index);
          this.Count--;
          Shrink();

          return element;
        }

        public void InsertAt(int index, T element)
        {
            ValidateIndex(index);
            this.Count++;
            EnsureCapacity();
            ShiftToRight(index);
            this.items[index] = element;

        }

        public bool Contains(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(element))
                {
                    return true;
                    break;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            ValidateIndex(firstIndex);
            ValidateIndex(secondIndex);
            var tmp = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = tmp;
        }

        public void Reversе()
        {
            for (int i = 0; i < this.Count / 2; i++)
            {
                Swap(i,this.Count - i -1);
            }
        }

        public override string ToString()
        {
            var bs = new StringBuilder();

            for (int i = 0; i < this.Count-1; i++)
            {
                bs.Append($"{this.items[i]}, ");
            }

            return bs.ToString().TrimEnd(' ', ',');
        }

        public void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void EnsureCapacity()
        {
            if (this.items.Length >  this.Count)
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
        private void Shrink()
        {
            if (this.Count * 4 >= this.items.Length)
            {
                return;
            }

            var tempArray = new T[this.items.Length / 2];
            for (int i = 0; i < this.Count; i++)
            {
                tempArray[i] = this.items[i];
            }

            this.items = tempArray;
        }
        private void ShiftToLeft(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count - 1] = default;
           

        }

        public void ShiftToRight(int index )
        {
            for (int i = this.Count-1; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }
    }
}
