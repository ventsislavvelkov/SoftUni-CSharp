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
            var busArgs = Console.ReadLine().Split();

            var carFuelQuantity = double.Parse(carArgs[1]);
            var carFuelConsumption = double.Parse(carArgs[2]);
            var carTankCapacity = double.Parse(carArgs[3]);

            var truckFuelQuantity = double.Parse(truckArgs[1]);
            var truckFuelConsumption = double.Parse(truckArgs[2]);
            var truckTankCapacity = double.Parse(truckArgs[3]);

            var busFuelQuantity = double.Parse(busArgs[1]);
            var busFuelConsumption = double.Parse(busArgs[2]);
            var busTankCapacity = double.Parse(busArgs[3]);
          
                IVehicle car = new Car(carFuelQuantity, carFuelConsumption, carTankCapacity);
                IVehicle truck = new Truck(truckFuelQuantity, truckFuelConsumption, truckTankCapacity);
                IVehicle bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);
           
           
           

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split();

                var action = command[0];
                var vehicle = command[1];

                try
                {
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
                        else if (vehicle == "Bus")
                        {
                            Console.WriteLine(bus.Drive(distance));
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
                        else if (vehicle == "Bus")
                        {
                            bus.Refuel(fuelQuantity);
                        }
                    }
                    else if (action == "DriveEmpty")
                    {
                        var kilometers = double.Parse(command[2]);
                        var busAs = bus as Bus;

                        Console.WriteLine(busAs.DriveEmpty(kilometers));
                    }
                }
                catch (ArgumentException msg)
                {

                    Console.WriteLine(msg.Message);
                }
                
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
