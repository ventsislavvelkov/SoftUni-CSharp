using System.Text;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = string.Empty;
            var tires = new List<Tire[]>();

            while ((input = Console.ReadLine()) != "No more tires")
            {
                var tiresInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var currentTires = new Tire[4]
                {
                    new Tire(int.Parse(tiresInfo[0]), double.Parse(tiresInfo[1])),
                    new Tire(int.Parse(tiresInfo[2]), double.Parse(tiresInfo[3])),
                    new Tire(int.Parse(tiresInfo[4]), double.Parse(tiresInfo[5])),
                    new Tire(int.Parse(tiresInfo[6]), double.Parse(tiresInfo[7])),
                };

                tires.Add(currentTires);
            }

            var engines = new List<Engine>();

            while ((input = Console.ReadLine()) != "Engines done")
            {
                var enginesInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var horsePower = int.Parse(enginesInfo[0]);
                var cubicCapacity = double.Parse(enginesInfo[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);
            }

            var cars = new List<Car>();
            while ((input = Console.ReadLine()) != "Show special")
            {
                var carInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var carMake = carInfo[0];
                var carModel = carInfo[1];
                var carYear = int.Parse(carInfo[2]);
                var carFuelQuantity = double.Parse(carInfo[3]);
                var carFuelConsumptity = double.Parse(carInfo[4]);
                var engineIndex = int.Parse(carInfo[5]);
                var tiresIndex = int.Parse(carInfo[6]);

                Car car = new Car(carMake, carModel, carYear, carFuelQuantity, carFuelConsumptity, engines[engineIndex],
                    tires[tiresIndex]);
                cars.Add(car);
            }

            var specialCars = cars.Where(c => c.Year >= 2017
                                              && c.Engine.HorsePower > 330
                                              && c.Tires.Select(t => t.Pressure).Sum() >= 9
                                              && c.Tires.Select(t => t.Pressure).Sum() <= 10)
                                              .ToList();
            foreach (var car in specialCars)
            {
                car.Drive(20);
                Console.WriteLine(car);
            }



            //var make = Console.ReadLine();
            //var model = Console.ReadLine();
            //var year = int.Parse(Console.ReadLine());
            //var fuelQuantity = double.Parse(Console.ReadLine());
            //var fuelConsumption = double.Parse(Console.ReadLine());

            //Car firstCar = new Car();
            //Car secondCar = new Car(make, model, year);
            //Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);

            //Car car = new Car();

            //car.Make = "VW";
            //car.Model = "MK3";
            //car.Year = 1992;
            //car.FuelQuantity = 200;
            //car.FuelConsumption = 200;
            //car.Drive(2000);

            //Console.WriteLine(car.WhoAmI());
        }
    }
}
