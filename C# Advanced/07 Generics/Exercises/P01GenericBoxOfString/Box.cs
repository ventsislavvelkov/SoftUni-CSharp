using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace P01GenericBoxOfString
{
    public class Box<T>
    {
        public Box(List<T> value)
        {
            this.Values = value;
        }
        public List<T> Values { get; set; }

        public void Swap(List<T> item, int first, int second)
        {
            T temp = item[first];
            item[first] = item[second];
            item[second] = temp;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var item in Values)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
