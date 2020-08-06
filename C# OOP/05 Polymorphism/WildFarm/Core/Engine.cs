using System;
using System.Collections.Generic;
using WildFarm.Animals;
using WildFarm.Interfaces;
using WildFarm.Animals.Mammals;
using WildFarm.Animals.Birds;

namespace WildFarm.Core
{
    public class Engine
    {
        private ICollection<IAnimal> animals;
        private FoodFactory foodFactory;

        public Engine()
        {
            this.animals = new List<IAnimal>();
            this.foodFactory = new FoodFactory();
        }
        public void Run()
        {
            while (true)
            {
                var animalArgs = Console.ReadLine().Split();
                if (animalArgs[0] == "End")
                {
                    break;
                }
                var foodArgs = Console.ReadLine().Split();
                var foodType = foodArgs[0];
                var foodQuantity = int.Parse(foodArgs[1]);

                IAnimal animal = ProduceAnimal(animalArgs);

                IFood food = this.foodFactory.ProduceFood(foodType, foodQuantity);

                animals.Add(animal);

                Console.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Feed(food);
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                    continue;
                }

            }
            Console.WriteLine(string.Join(Environment.NewLine, this.animals));

        }

        public static IAnimal ProduceAnimal(string[] animalArgs)
        {
            IAnimal animal = null;

            var animalType = animalArgs[0];
            var name = animalArgs[1];
            var weight = double.Parse(animalArgs[2]);
            var livingRegion = string.Empty;

            if (animalType == "Cat" || animalType == "Tiger")
            {
                livingRegion = animalArgs[3];
                var breed = animalArgs[4];

                if (animalType == "Cat")
                {
                    animal = new Cat(name, weight, livingRegion, breed);
                }
                else if (animalType == "Tiger")
                {
                    animal = new Tiger(name, weight, livingRegion, breed);

                }

            }
            else if (animalType == "Dog" || animalType == "Mouse")
            {
                livingRegion = animalArgs[3];
                if (animalType == "Dog")
                {
                    animal = new Dog(name, weight, livingRegion);
                }
                else if (animalType == "Mouse")
                {
                    animal = new Mouse(name, weight, livingRegion);
                }

            }
            else if (animalType == "Hen" || animalType == "Owl")
            {
                var wingSize = double.Parse(animalArgs[3]);
                if (animalType == "Hen")
                {
                    animal = new Hen(name, weight, wingSize);
                }
                else if (animalType == "Owl")
                {
                    animal = new Owl(name, weight, wingSize);
                }
            }
            return animal;
        }
    }
}