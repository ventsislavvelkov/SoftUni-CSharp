using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _02AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var resource = new Dictionary<string, int>();

            while (input != "stop")
            {
                int quantity = int.Parse(Console.ReadLine()); ;

                if (!resource.ContainsKey(input))
                {
                    resource.Add(input, quantity);

                }
                else
                {
                    resource[input] += quantity;
                }



                input = Console.ReadLine();
            }

            foreach (var item in resource)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }

        }
    }
}