using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuple
{
    class Threeuple<TFirst, TSecond, TThurd>
    {
        public Threeuple(TFirst first, TSecond second, TThurd thurd)
        {
            this.First = first;
            this.Second = second;
            this.Thurd = thurd;
        }

        public TFirst First { get; set; }
        public TSecond Second { get; set; }
        public TThurd Thurd { get; set; }

        public override string ToString()
        {
            return $"{this.First} -> {this.Second} -> {this.Thurd}";
        }
    }
}
