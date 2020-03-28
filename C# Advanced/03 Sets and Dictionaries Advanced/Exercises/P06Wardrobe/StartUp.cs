using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Channels;

namespace P06Wardrobe
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var clothes = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var clothesColor = input[0];
                var ithems = input[1].Split(",").ToArray();

                if (!clothes.ContainsKey(clothesColor))
                {
                    clothes.Add(clothesColor, new Dictionary<string, int>());
                }

                for (int j = 0; j < ithems.Length; j++)
                {
                    var currentIthem = ithems[j];
                    if (clothes[clothesColor].ContainsKey(currentIthem))
                    {
                        clothes[clothesColor][currentIthem]++;
                    }
                    else
                    {
                        clothes[clothesColor].Add(currentIthem, 1);
                    }
                }
            }

            var find = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var colorOfIthem = find[0];
            var typeOfIthem = find[1];

            foreach (var (color, wardrobe) in clothes)
            {
                Console.WriteLine($"{color} clothes:");

                foreach (var (cloth, count) in wardrobe)
                {
                    var result = $"* {cloth} - {count}";

                    if (colorOfIthem == color && cloth == typeOfIthem)
                    {
                        result += " (found!)";
                    }

                    Console.WriteLine(result);
                }
            }
        }
    }
}
