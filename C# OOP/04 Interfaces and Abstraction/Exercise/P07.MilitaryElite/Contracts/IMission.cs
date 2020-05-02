using System;
using System.Collections.Generic;
using System.Text;
using P07.MilitaryElite.Enumerations;

namespace P07.MilitaryElite.Contracts
{
    public interface IMission
    {
        string CodeName { get; }

        State State { get; }

        void CompleteMission();
    }
}
