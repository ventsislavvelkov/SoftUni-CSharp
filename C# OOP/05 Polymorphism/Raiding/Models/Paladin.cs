using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int PALADIN_POWER = 100;

        public Paladin(string name)
            : base(name,PALADIN_POWER)
        { }

      
        //public override string CastAbility()
        //{
        //    return string.Format("{0} - {1} healed for {2}"
        //        , this.GetType().Name
        //        , this.Name
        //        , this.Power);
        //}
    }
}
