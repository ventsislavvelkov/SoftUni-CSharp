using System;
using System.Collections.Generic;

namespace _04Orders
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var orders = new Dictionary<string, double[]>();

            while (true)
            {
                var input = Console.ReadLine().Split();
                var product = input[0];

                if (product == "buy")
                {
                    break;
                }
                else
                {
                    var price = double.Parse(input[1]);
                    var quantity = int.Parse(input[2]);

                    if (!orders.ContainsKey(product))
                    {
                        orders[product] = new double[2];
                    }

                    orders[product][0] = price;
                    orders[product][1] += quantity;
                }
            }


            foreach (var kvp in orders)
            {
                Console.WriteLine($"{kvp.Key} -> {(kvp.Value[0] * kvp.Value[1]):f2}");
            }
        }
    }
}
