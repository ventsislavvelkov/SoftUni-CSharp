using System;
using System.Collections.Generic;
using WildFarm.Food;

namespace WildFarm.Animals.Mammals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {

        }

        public override double WeightMultiplier
        {
            get { return 0.4; }
        }

        public override ICollection<Type> PrefferedFoods
        {
            get { return new List<Type>() { typeof(Meat) }; }
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
        public override string ToString()
        {
            return string.Format("{0} [{1}, {2}, {3}, {4}]", this.GetType().Name
                , this.Name, this.Weight, this.LivingRegion, this.FoodEaten);
        }
    }
}
