using System;
using System.Collections.Generic;
using System.Text;

namespace Truple
{
    public class Truple<TFirst, TSecond>
    {
        public Truple(TFirst firstItem, TSecond secondItem)
        {
            this.FirstItem = firstItem;
            this.SecondItem = secondItem;

        }
        public TFirst FirstItem { get; set; }
        public TSecond SecondItem { get; set; }

        public override string ToString()
        {
            return $"{this.FirstItem} -> {this.SecondItem}";
        }
    }
}
