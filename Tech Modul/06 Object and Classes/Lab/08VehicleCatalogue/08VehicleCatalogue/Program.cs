using System;
using System.Collections.Generic;
using System.Linq;

namespace _08VehicleCatalogue
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();

            while (true)
            {
                List<string> inputVihicle = Console.ReadLine().Split("/").ToList();

                if (inputVihicle[0] == "end")
                {
                    break;
                }

                string tupe = inputVihicle[0];
                string brand = inputVihicle[1];
                string model = inputVihicle[2];
                int powerWeight = int.Parse(inputVihicle[3]);

                if (tupe == "Car")
                {
                    Car car = new Car();
                    {
                        car.Brand = brand;
                        car.Model = model;
                        car.HorsePower = powerWeight;
                    }
                    cars.Add(car);
                }
                else
                {

                    Truck truck = new Truck();
                    {
                        truck.Brand = brand;
                        truck.Model = model;
                        truck.Weight = powerWeight;
                    }

                    trucks.Add(truck);
                }
            }

            if (cars.Count > 0)
            {
                Console.WriteLine($"Cars: ");

                foreach (Car car in cars.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");

                foreach (Truck truck in trucks.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }

        }
    }

    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
    }

    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }

    class CatalogVihicle
    {
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }
    }
}
