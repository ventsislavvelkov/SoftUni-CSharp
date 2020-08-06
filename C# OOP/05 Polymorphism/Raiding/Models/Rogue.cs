using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int ROGUE_POWER = 80;

        public Rogue(string name)
            : base(name,ROGUE_POWER)
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
