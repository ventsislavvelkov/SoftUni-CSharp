using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Train
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var wagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var maxPassengerInWagon = int.Parse(Console.ReadLine());

            var input = "";

            while ((input = Console.ReadLine()) != "end")
            {
                var inputinformation = input.Split();

                if (inputinformation[0] == "Add")
                {
                    var passengers = int.Parse(inputinformation[1]);
                    wagons.Add(passengers);
                }
                else
                {
                    var addPassengers = int.Parse(inputinformation[0]);

                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if ((wagons[i] + addPassengers) <= maxPassengerInWagon)
                        {
                            wagons[i] += addPassengers;

                            break;
                        }
                    }

                }
            }

            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
