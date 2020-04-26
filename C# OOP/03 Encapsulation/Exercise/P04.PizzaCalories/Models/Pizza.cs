using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using P04.PizzaCalories.Comman;

namespace P04.PizzaCalories.Models
{
    public class Pizza
    {
        private const int TOPPINGS_MAX_COUNT = 10;
        private const int PIZZA_MAX_NAME_SIZE = 15;
        private const int PIZZA_MIN_NAME_SIZE = 1;

        private string name;
        private readonly List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) ||
                    value.Length > PIZZA_MAX_NAME_SIZE ||
                    value.Length < PIZZA_MIN_NAME_SIZE)
                {
                    throw new ArgumentException(GlobalException.InvalidPizzaNameExceptionMessage);
                }

                this.name = value;
            }
        }

        public double TotalCalories
        {
            get
            {
                return this.toppings.Sum(t => t.GetCaloriesPerGram) + this.Dough.GetCaloriesPerGram;
            }
        }

        public Dough Dough { get; private set; }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count == TOPPINGS_MAX_COUNT)
            {
                throw new ArgumentException(GlobalException.InvalidNumberOfToppingsExceptionMessage);
            }

            this.toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:F2} Calories.";
        }
    }
}
