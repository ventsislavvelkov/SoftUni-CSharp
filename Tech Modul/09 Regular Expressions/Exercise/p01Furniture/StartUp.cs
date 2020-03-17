using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace p01Furniture
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var regex = @"[>]{2}(?<name>[A-Za-z]+)[<]{2}(?<price>\d+\.\d+|\d+)[!](?<quantity>\d+)";
            var furniture = new List<string>();
            var totalPrice = 0.0;
            
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Purchase")
                {
                    break;
                }
                var matched = Regex.Matches(input, regex);

                foreach (Match matches in matched)
                {
                    var name = matches.Groups["name"].Value;
                    var price = matches.Groups["price"].Value;
                    var quantity = matches.Groups["quantity"].Value;

                    totalPrice += double.Parse(price) * int.Parse(quantity);
                    furniture.Add(name);
                }
            }

            foreach (var name in furniture)
            {
                Console.WriteLine(name);
                
            }

            Console.WriteLine($"Total money spend: {totalPrice:F2}");
        }
    }
}
