using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite.Contracts
{
   public  interface ICommando : ISpecialisedSolder
    {
        IReadOnlyCollection<IMission> Missions { get; }

        void AddMission(IMission mission);


    }
}
