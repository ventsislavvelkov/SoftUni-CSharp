using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Channels;

namespace SpeedRacing
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var numberOfCar = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < numberOfCar; i++)
            {
                var carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var model = carInfo[0];
                var fuelAmount = double.Parse(carInfo[1]);
                var fuelCunsumptionPerKilometer = double.Parse(carInfo[2]);

                var car = new Car(model, fuelAmount, fuelCunsumptionPerKilometer);
                
                cars.Add(car);
            
            }

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var carModel = tokens[1];

                if (carModel == "End")
                {
                    break;
                }
                var amountOfKm = double.Parse(tokens[2]);

                var car = cars.FirstOrDefault(x => x.Model == carModel);
                car.Drive(carModel, amountOfKm);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }

            

        }
    }
}
