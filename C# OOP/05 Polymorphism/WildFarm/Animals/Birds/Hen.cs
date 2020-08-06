using System;
using System.Collections.Generic;
using WildFarm.Food;

namespace WildFarm.Animals.Birds
{
    public class Hen : Bird
    {

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {

        }

        public override double WeightMultiplier
        {
            get { return 0.35; }
        }

        public override ICollection<Type> PrefferedFoods
        {
            get { return new List<Type>() { typeof(Meat), typeof(Vegetable), typeof(Fruit), typeof(Seeds) }; }
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
