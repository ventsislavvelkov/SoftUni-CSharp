using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using P07.MilitaryElite.Contracts;

namespace P07.MilitaryElite.Models
{
   public class Engineer : SpecialisedSolder, IEngineer
   {
       private ICollection<IRepair> repairs;
        public Engineer(int id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = new List<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs => (IReadOnlyCollection<IRepair>) this.repairs;
        public void AddRepair(IRepair repair)
        {
           this.repairs.Add(repair);
        }

        public override string ToString()
        {
           StringBuilder sb = new StringBuilder();

           sb
               .AppendLine(base.ToString())
               .AppendLine("Repairs:");

           foreach (var repair in this.repairs)
           {
               sb.AppendLine($"  {repair.ToString()}");
           }

           return sb.ToString().TrimEnd();
        }
   }
}
