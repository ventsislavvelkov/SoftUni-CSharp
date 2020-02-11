using System;
using System.Collections.Generic;
using System.Linq;

namespace _03LegendaryFarming
{
    class StartUp
    {
        static void Main()
        {


            var materials = new Dictionary<string, int>();
            var junkMaterials = new Dictionary<string,int>();
            materials["motes"] = 0;
            materials["fragments"] = 0;
            materials["shards"] = 0;

            while (true)
            {
                var input = Console.ReadLine().ToLower().Split();
                bool hasToBreack = false;

                for (int i = 1; i <= input.Length; i += 2)
                {
                    var numberOfMaterials = int.Parse(input[i - 1]);
                    var type = input[i];

                    if (type == "motes")
                    {
                        materials[type] += numberOfMaterials;

                        if (materials[type] >= 250)
                        {
                            Console.WriteLine("Dragonwrath obtained!");
                            materials[type] -= 250;
                            hasToBreack = true;
                            break;
                        }
                    }
                    else if (type == "fragments")
                    {
                        materials[type] += numberOfMaterials;

                        if (materials[type] >= 250)
                        {
                            Console.WriteLine("Valanyr obtained!");
                            materials[type] -= 250;
                            hasToBreack = true;
                            break;
                        }
                    }
                    else if (type == "shards")
                    {
                        materials[type] += numberOfMaterials;

                        if (materials[type] >= 250)
                        {
                            Console.WriteLine("Shadowmourne obtained!");
                            materials[type] -= 250;
                            hasToBreack = true;
                            break;
                        }
                    }
                    else
                    {
                        if (!junkMaterials.ContainsKey(type))
                        {
                            junkMaterials[type] = numberOfMaterials;
                        }
                        else
                        {
                            junkMaterials[type] += numberOfMaterials;
                        }
                    }
                }

                if (hasToBreack)
                {
                    break;
                }
            }

            materials = materials
                            .OrderByDescending(x => x.Value)
                            .ThenBy(x => x.Key)
                            .ToDictionary(x => x.Key, x => x.Value);

            junkMaterials = junkMaterials
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in materials)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            foreach (var kvp in junkMaterials)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }


    }
}
