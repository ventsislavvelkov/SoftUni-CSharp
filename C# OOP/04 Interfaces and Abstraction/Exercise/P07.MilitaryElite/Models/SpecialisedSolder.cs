using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using P07.MilitaryElite.Contracts;
using P07.MilitaryElite.Enumerations;
using P07.MilitaryElite.Exceptions;

namespace P07.MilitaryElite.Models
{
   public abstract class SpecialisedSolder: Private, ISpecialisedSolder
    {
        protected SpecialisedSolder(int id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary)
        {
            this.Corps = this.TryParseCorps(corps);
        }

        public Corps Corps { get; private set; }

        private Corps TryParseCorps(string corpsStr)
        {
            Corps corps;

            bool parsed = Enum.TryParse<Corps>(corpsStr, out corps);

            if (!parsed)
            {
                throw new InvalidCorpsException();
            }
            return corps;
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine +
                   $"Corps: {this.Corps.ToString()}";
        }
    }
}
