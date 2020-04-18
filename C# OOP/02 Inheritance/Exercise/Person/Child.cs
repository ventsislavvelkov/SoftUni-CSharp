using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Child : Person
    {
        private List<Child> childs;

        public Child(string name, int age) 
            : base(name, age)
        {
        }
    }
}
