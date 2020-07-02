using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;

        }

        public string Name { get; }

        public virtual int Age
        {
            get => this.age;
            set
            {
                if (value > 0)
                {
                    this.age = value;
                }

            }
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }
    }
}
