using System;
using System.Collections.Generic;
using System.Text;
using P05.BirthdayCelebrations.Interfaces;

namespace P05.BirthdayCelebrations.Models
{
    public class Pet : IBirthdate
    {
        public Pet(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }
        public string Name { get; private set; }
        public string Birthday { get; private set; }
    }
}
