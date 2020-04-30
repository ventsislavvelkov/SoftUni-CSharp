using System;
using System.Collections.Generic;
using System.Text;
using P07.MilitaryElite.Enumerations;

namespace P07.MilitaryElite.Contracts
{
   public interface ISpecialisedSolder : IPrivate
    {
        Corps Corps { get; }
    }
}
 