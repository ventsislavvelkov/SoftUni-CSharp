using System;
using System.Collections.Generic;


namespace _02AMinerTask
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var resource = new Dictionary<string, int>();

            while (input != "stop")
            {
                var quantity = int.Parse(Console.ReadLine()); ;

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