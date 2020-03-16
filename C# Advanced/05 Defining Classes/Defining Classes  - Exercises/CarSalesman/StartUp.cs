using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;

namespace CarSalesman
{
    class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();
            var engines = new HashSet<Engine>();

            for (int i = 0; i < n; i++)
            {
                Engine engine = null;

                var tokkens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var model = tokkens[0];
                var power = int.Parse(tokkens[1]);
                var displasment = 0;
                var efficiency = "";

                if (tokkens.Length == 2)
                {
                    engine = new Engine(model,power);
                }
                else if (tokkens.Length == 3)
                {
                    var isInt = int.TryParse(tokkens[2], out displasment);

                    if (!isInt)
                    {
                        efficiency = tokkens[2];
                        engine = new Engine(model,power,efficiency);
                    }
                    else
                    {
                        displasment = int.Parse(tokkens[2]);
                        engine = new Engine(model, power, displasment);
                    }
                }
                else if (tokkens.Length == 4 )
                {
                    displasment = int.Parse(tokkens[2]);
                    efficiency = tokkens[3];
                    engine = new Engine(model,power,displasment,efficiency);
                }

                engines.Add(engine);
            }

            var m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                var carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var model = carInfo[0];
                var engine = carInfo[1];
                var weight = 0;
                var color = "";
                Car car = null;

                if (carInfo.Length == 2)
                {
                    car = new Car(model,engine);
                }
                else if (carInfo.Length == 3)
                {
                    var isInt = int.TryParse(carInfo[2], out weight);

                    if (isInt)
                    {
                        weight = int.Parse(carInfo[2]);
                        car = new Car(model,engine,weight);
                    }
                    else
                    {
                        color = carInfo[2];
                        car = new Car(model,engine,color);
                    }
                }
                else if (carInfo.Length == 4)
                {
                    weight = int.Parse(carInfo[2]);
                    color = carInfo[3];
                    car = new Car(model,engine,weight,color);
                }

                cars.Add(car);
            }
        }
    }
}
