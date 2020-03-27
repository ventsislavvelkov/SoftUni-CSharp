using System;
using System.Collections.Generic;
using System.Linq;

namespace P10Crossroads
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var greenLightInterval = int.Parse(Console.ReadLine());
            var freeWindowInterval = int.Parse(Console.ReadLine());

            var cars = new Queue<string>();
            var command= string.Empty;
            var crash = false;
            var crashedCar = string.Empty;
            var hitIndex = -1;
            var passedCar = 0;

            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "green")
                {
                    var currentGreenLight = greenLightInterval;

                    while (currentGreenLight > 0 && cars.Any())
                    {
                        var currentCar = cars.Peek();
                        var carLenght = currentCar.Length;

                        currentGreenLight -= carLenght;

                        if (currentGreenLight >=0)
                        {
                            cars.Dequeue();
                            passedCar++;
                        }
                        else
                        {
                            var left = Math.Abs(currentGreenLight);

                            if (left <= freeWindowInterval)
                            {
                                cars.Dequeue();
                                passedCar++;
                            }
                            else
                            {
                                crash = true;
                                crashedCar = currentCar;
                                hitIndex = carLenght - left + freeWindowInterval;

                                break;
                            }
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }

                if (crash)
                {
                    break;
                }

            }

            if (crash)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{crashedCar} was hit at {crashedCar[hitIndex]}.");
            }
            else
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{passedCar} total cars passed the crossroads.");
            }
        }
    }
}
