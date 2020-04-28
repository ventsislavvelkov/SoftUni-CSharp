using System;
using System.Collections.Generic;
using System.Text;
using P04.BorderControl.Interfaces;

namespace P04.BorderControl.Models
{
    public class Citizen : IIdentable
    {
        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }
    }
}
