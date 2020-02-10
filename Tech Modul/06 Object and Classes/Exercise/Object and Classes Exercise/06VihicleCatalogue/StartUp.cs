using System;
using System.Collections.Generic;
using System.Linq;

namespace _06VihicleCatalogue
{
    class StartUp
    {
        static void Main()
        {
            var carCatalogue = new List<CarCatalogue>();

            while (true)
            {
                var vehicle = Console.ReadLine().Split();
                var type = vehicle[0];

                if (type == "End")
                {
                    break;
                }
                else
                {
                    var model = vehicle[1];
                    var color = vehicle[2];
                    var horsepower = int.Parse(vehicle[3]);

                    carCatalogue.Add(new CarCatalogue(type, model, color, horsepower));

                }
            }

            while (true)
            {
                var printModel = Console.ReadLine();

                if (printModel == "Close the Catalogue")
                {
                    break;
                }
                else
                {
                    Console.WriteLine(string.Join(" ", carCatalogue.Where(x => x.Model == printModel)));
                }
            }
            var cars = carCatalogue.Where(x => x.Type == "car").ToList();
            var truck = carCatalogue.Where(x => x.Type == "truck").ToList();

            if (cars.Count > 0)
            {
                var carAvarageHorsepower = carCatalogue.Where(x => x.Type == "car").Average(x => x.HorsePower);
                Console.WriteLine($"Cars have average horsepower of: {carAvarageHorsepower:f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:F2}.");
            }

            if (truck.Count > 0)
            {
                var truckAvarageHorsepower = carCatalogue.Where(x => x.Type == "truck").Average(x => x.HorsePower);
                Console.WriteLine($"Trucks have average horsepower of: {truckAvarageHorsepower:f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:F2}.");
            }
        }
    }

    class CarCatalogue
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        public CarCatalogue(string type, string model, string color, int horsePower)
        {
            this.Type = type;
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;
        }

        public override string ToString()
        {
            return $"Type: {(Type == "car" ? "Car" : "Truck")}{Environment.NewLine}" +
                   $"Model: {Model}{Environment.NewLine}" +
                   $"Color: {Color}{Environment.NewLine}" +
                   $"Horsepower: {HorsePower}";
        }
    }
}
