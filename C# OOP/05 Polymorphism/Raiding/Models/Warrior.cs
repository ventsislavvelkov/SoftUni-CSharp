using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int WARRIOR_POWER = 100;

        public Warrior(string name)
            : base(name,WARRIOR_POWER)
        {

        }

       
        public override string CastAbility()
        {
            return string.Format("{0} - {1} hit for {2} damage"
                , this.GetType().Name
                , base.Name
                , base.Power);
        }
    }
}
