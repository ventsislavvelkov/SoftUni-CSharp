using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raiding.Contracts;
using Raiding.Models;

namespace Raiding.Core
{
    public class HeroFactory
    {
        public IHero ProduceHero(string name, string type)
        {
            IHero hero = null;

            if (type == "Druid")
            {
                hero = new Druid(name);
            }
            else if (type == "Paladin")
            {
                hero = new Paladin(name);
            }
            else if (type == "Rogue")
            {
                hero = new Rogue(name);
            }
            else if (type == "Warrior")
            {
                hero = new Warrior(name);
            }
            else
            {
                throw new ArgumentException("Invalid hero!");
            }
            return hero;
        }

    }
}
