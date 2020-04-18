using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Foods
{
    public class Soup:Starter
    {
        public Soup(string name, decimal price, double grams) 
            : base(name, price, grams)
        {
        }
    }
}
