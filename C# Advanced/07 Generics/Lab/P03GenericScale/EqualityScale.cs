using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T>
          where T:IComparable<T>
    {
        private T left;
        private T right;

        public EqualityScale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

        public bool AreEqual()
        {
            var value = this.left.CompareTo(this.right);

            var result = false;

            if (value != 0)
            {
                result = false;
            }
            else
            {
                result = true;
            }

            return result;
        }

    }
}

