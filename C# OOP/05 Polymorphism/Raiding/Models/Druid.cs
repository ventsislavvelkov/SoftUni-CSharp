using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int DRUID_POWER = 80;

        public Druid(string name)
            : base(name,DRUID_POWER)
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
