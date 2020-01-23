using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToList();

            int maxPassengerInWagon = int.Parse(Console.ReadLine());

            string input = "";

            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputinformation = input.Split();

                if (inputinformation[0] == "Add")
                {
                    int passengers = int.Parse(inputinformation[1]);
                    wagons.Add(passengers);

                }
                else
                {
                    int addPassengers = int.Parse(inputinformation[0]);

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