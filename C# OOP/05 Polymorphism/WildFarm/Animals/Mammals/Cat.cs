using System;
using System.Collections.Generic;
using WildFarm.Food;

namespace WildFarm.Animals.Mammals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {

        }

        public override double WeightMultiplier
        {
            get { return 0.3; }
        }

        public override ICollection<Type> PrefferedFoods
        {
            get { return new List<Type>() { typeof(Meat), typeof(Vegetable) }; }
        }
        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
