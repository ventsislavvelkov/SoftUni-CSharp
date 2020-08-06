using System;
using System.Collections.Generic;
using WildFarm.Food;

namespace WildFarm.Animals.Mammals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {

        }

        public override double WeightMultiplier
        {
            get { return 0.1; }
        }

        public override ICollection<Type> PrefferedFoods
        {
            get { return new List<Type>() { typeof(Vegetable), typeof(Fruit) }; }
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
        public override string ToString()
        {
            return string.Format("{0} [{1}, {2}, {3}, {4}]", this.GetType().Name
                , this.Name, this.Weight, this.LivingRegion, this.FoodEaten);
        }
    }
}
