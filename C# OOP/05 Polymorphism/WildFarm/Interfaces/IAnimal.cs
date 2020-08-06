using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WildFarm.Interfaces
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }
        string ProduceSound();
        void Feed(IFood food);
    }
}
