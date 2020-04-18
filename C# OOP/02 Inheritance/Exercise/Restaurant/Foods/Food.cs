using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Foods
{
   public  class Food : Product
    {
        public Food(string name, decimal price, double grams) 
            : base(name, price)
        {
            this.Grams = grams;
        }

        public double Grams { get;}
    }
}
