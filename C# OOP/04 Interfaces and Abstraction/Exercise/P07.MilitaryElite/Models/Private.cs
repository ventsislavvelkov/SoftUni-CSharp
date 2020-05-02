using System;
using System.Collections.Generic;
using System.Text;
using P07.MilitaryElite.Contracts;

namespace P07.MilitaryElite.Models
{
    public class Private : Solder, IPrivate
    {
        

        public Private(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }
        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return $"{base.ToString()} Salary: {this.Salary:f2}";
        }
    }
}
