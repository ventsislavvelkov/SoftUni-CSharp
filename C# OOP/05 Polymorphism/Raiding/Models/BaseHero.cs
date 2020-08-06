using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raiding.Contracts;

namespace Raiding.Models
{
    public abstract class BaseHero : IHero
    {
        protected BaseHero(string name,int power)
        {
            this.Name = name;
            this.Power = power;
        }
        public string Name { get; protected set; }

        public  int Power { get; protected set; }

        public virtual string CastAbility()
        {
            return $"{ this.GetType().Name} - {this.Name} healed for { this.Power}"; 
        }
       
    }
}
