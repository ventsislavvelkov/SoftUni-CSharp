using System;
using System.Collections.Generic;
using WildFarm.Food;

namespace WildFarm.Animals.Mammals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {

        }

        public override double WeightMultiplier
        {
            get { return 1.00; }
        }

        public override ICollection<Type> PrefferedFoods
        {
            get { return new List<Type>() { typeof(Meat) }; }
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
