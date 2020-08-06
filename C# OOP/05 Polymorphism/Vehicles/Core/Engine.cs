using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vehicles.Models;
using Vehicles.Contracts;

namespace Vehicles.Core
{
    public class Engine
    {
        public Engine()
        {

        }
        public void Run()
        {
            var carArgs = Console.ReadLine().Split();
            var truckArgs = Console.ReadLine().Split();

            var carFuelQuantity = double.Parse(carArgs[1]);
            var carFuelConsumption = double.Parse(carArgs[2]);

            var truckFuelQuantity = double.Parse(truckArgs[1]);
            var truckFuelConsumption = double.Parse(truckArgs[2]);

            IVehicle car = new Car(carFuelQuantity, carFuelConsumption);
            IVehicle truck = new Truck(truckFuelQuantity, truckFuelConsumption);

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split();

                var action = command[0];
                var vehicle = command[1];


                if (action == "Drive")
                {
                    var distance = double.Parse(command[2]);

                    if (vehicle == "Car")
                    {
                        Console.WriteLine(car.Drive(distance));
                    }
                    else if (vehicle == "Truck")
                    {
                        Console.WriteLine(truck.Drive(distance));
                    }
                }
                else if (action == "Refuel")
                {
                    var fuelQuantity = double.Parse(command[2]);
                    if (vehicle == "Car")
                    {
                        car.Refuel(fuelQuantity);
                    }
                    else if (vehicle == "Truck")
                    {
                        truck.Refuel(fuelQuantity);
                    }
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
