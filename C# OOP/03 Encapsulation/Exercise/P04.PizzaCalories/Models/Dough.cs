using System;
using System.Collections.Generic;
using System.Text;
using P04.PizzaCalories.Comman;

namespace P04.PizzaCalories.Models
{
    public class Dough
    {
        private const int BASE_CALORIES_PER_GRAM = 2;
        private const int DOUGH_MIN_VALUE = 1;
        private const int DOUGH_MAX_VALUE = 200;

        private string flourType;
        private string bakingTechinique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException(GlobalException.InvalidTypeOfDoughExceptionMessage);
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechinique;
            private set
            {
                if (value.ToLower() != "crispy" &&
                    value.ToLower() != "chewy" &&
                    value.ToLower() != "homemade")
                {
                    throw new ArgumentException(GlobalException.InvalidTypeOfDoughExceptionMessage);
                }

                this.bakingTechinique = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < DOUGH_MIN_VALUE || value > DOUGH_MAX_VALUE)
                {
                    throw new ArgumentException(GlobalException.InvalidWeightOfDoughExceptionMessage);
                }

                this.weight = value;
            }
        }

        public double GetCaloriesPerGram => this.CalculateCalories();
        

        private double CalculateCalories()
        {
            double flourModifier = 0.0;
            double bakingModifier = 0.0;

            flourModifier = CalculateFlourModifier(flourModifier);

            bakingModifier = CalculateBakingModifier(bakingModifier);

            double totalCalories = BASE_CALORIES_PER_GRAM * this.Weight * flourModifier * bakingModifier;

            return totalCalories;
        }

        private double CalculateBakingModifier(double bakingModifier)
        {
            switch (this.BakingTechnique.ToLower())
            {
                case "crispy":
                    bakingModifier = 0.9;
                    break;
                case "chewy":
                    bakingModifier = 1.1;
                    break;
                case "homemade":
                    bakingModifier = 1.0;
                    break;
            }

            return bakingModifier;
        }

        private double CalculateFlourModifier(double flourModifier)
        {
            switch (this.FlourType.ToLower())
            {
                case "white":
                    flourModifier = 1.5;
                    break;
                case "wholegrain":
                    flourModifier = 1.0;
                    break;
            }

            return flourModifier;
        }
    }
}
