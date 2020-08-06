using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raiding.Contracts
{
    public interface IHero
    {
        string Name { get; }

        int Power { get; }

        string CastAbility();
    }
}
