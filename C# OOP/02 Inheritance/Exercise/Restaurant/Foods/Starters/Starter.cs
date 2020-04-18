using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Foods
{
    public class Starter :Food
    {
        public Starter(string name, decimal price, double grams) 
            : base(name, price, grams)
        {
        }
    }
}
