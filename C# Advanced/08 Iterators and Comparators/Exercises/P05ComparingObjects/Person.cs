using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Microsoft.VisualBasic;

namespace P05ComparingObjects
{
    public class Person :IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public int CompareTo([AllowNull] Person person)
        {
            int result = 1;

            if (person != null)
            {
                result = this.Name.CompareTo(person.Name);

                if (result == 0)
                {
                    result = this.Age.CompareTo(person.Age);

                    if (result == 0)
                    {
                        result = this.Town.CompareTo(person.Town);
                    }
                }
            }

            return result;
        }
    }
}
