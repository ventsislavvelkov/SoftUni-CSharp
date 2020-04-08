using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

namespace GenericArrayCreator
{
    public static class ArrayCreator
    {
        public static T[] Create<T>(int lenght, T value)
        {
            var arr = new T[lenght];

            for (int i = 0; i < lenght; i++)
            {
                arr[i] = value;
            }

            return arr;
        }
    }
}
