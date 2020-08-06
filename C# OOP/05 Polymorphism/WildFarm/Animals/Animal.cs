using System;
using System.Collections.Generic;
using WildFarm.Interfaces;

namespace WildFarm.Animals
{
    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }

        public abstract double WeightMultiplier { get; }

        public abstract ICollection<Type> PrefferedFoods { get; }

        public abstract string ProduceSound();

        public void Feed(IFood food)
        {
            if (!this.PrefferedFoods.Contains(food.GetType()))
            {
                throw new ArgumentException(string.Format("{0} does not eat {1}!", this.GetType().Name, food.GetType().Name));
            }
            this.Weight += this.WeightMultiplier * food.Quantity;
            this.FoodEaten += food.Quantity;
        }



    }
}
