using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace RawData
{
    public class StartUp
    {
        static void Main()
        {
            var cars = new List<Car>();
            var engines = new List<Engine>();
            var cargos = new List<Cargo>();
            var numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                var carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var model = carInfo[0];
                var engineSpeed = int.Parse(carInfo[1]);
                var enginePower = int.Parse(carInfo[2]);
                var cargoWeight = int.Parse(carInfo[3]);
                var cargoType = carInfo[4];
                var tire1Pressure = double.Parse(carInfo[5]);
                var tire1Age = int.Parse(carInfo[6]);
                var tire2Pressure = double.Parse(carInfo[7]);
                var tire2Age = int.Parse(carInfo[8]);
                var tire3Pressure = double.Parse(carInfo[9]);
                var tire3Age = int.Parse(carInfo[10]);
                var tire4Pressure = double.Parse(carInfo[11]);
                var tire4Age = int.Parse(carInfo[12]);

                var engine = new Engine(engineSpeed, enginePower);
                engines.Add(engine);

                var cargo = new Cargo(cargoWeight, cargoType);
                cargos.Add(cargo);

                var tire1 = new Tire(tire1Pressure, tire1Age);
                var tire2 = new Tire(tire2Pressure, tire2Age);
                var tire3 = new Tire(tire3Pressure, tire3Age);
                var tire4 = new Tire(tire4Pressure, tire4Age);

                var tires = new Tire[4]
                {
                    tire1,
                    tire2,
                    tire3,
                    tire4
                };

                var car = new Car(model, engine, cargo, tires);
                cars.Add(car);

            }

            var command = Console.ReadLine();

            if (command == "fragile")
            {
                cars.Where(c=>c.Cargo.CargoType == "fragile")
                    .Where(x=>x.Tire.Any(t=>t.TirePressure < 1))
                    .Select(m=>m.Model)
                    .ToList()
                    .ForEach(m=>Console.WriteLine(m));
            }
            else
            {
                cars.Where(c=>c.Cargo.CargoType == "flamable")
                    .Where(c=>c.Engine.EnginePower > 250)
                    .Select(m=>m.Model)
                    .ToList()
                    .ForEach(m=>Console.WriteLine(m));
            }

        }
    }
}
