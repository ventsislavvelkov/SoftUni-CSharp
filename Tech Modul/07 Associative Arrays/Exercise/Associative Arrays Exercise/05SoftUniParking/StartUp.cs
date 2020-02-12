using System;
using System.Collections.Generic;

namespace _05SoftUniParking
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var commandNumbers = int.Parse(Console.ReadLine());
            var softUniParking = new Dictionary<string,string>();
          

            for (int i = 0; i < commandNumbers; i++)
            {
                var input = Console.ReadLine().Split();
                var command = input[0];
                var name = input[1];
                var plateNumber = input[2];

                if (command == "register")
                {
                    if (!softUniParking.ContainsKey(name))
                    {
                        softUniParking[name] = plateNumber;
                        Console.WriteLine($"{name} registered {plateNumber} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {plateNumber}");
                    }
                }
                else
                {
                    if (softUniParking.ContainsKey(name))
                    {
                        softUniParking[name] = plateNumber;
                        Console.WriteLine($"{name} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                }
            }
        }
    }
}
