using System;
using System.Collections.Generic;
using System.Linq;

namespace _03Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            var inventory = Console.ReadLine().Split(", ").ToList();
            var isExists = false;

            while (true)
            {
                var input = Console.ReadLine().Split(" - ");

                var command = input[0];

                if (command == "Craft!")
                {
                    break;
                }

                var ithem = input[1];

                if (command == "Collect")
                {
                    isExists = IsExists(inventory, ithem);

                    if (!isExists)
                    {
                        inventory.Add(ithem);
                    }
                }
                else if (command == "Drop")
                {
                    isExists = IsExists(inventory, ithem);

                    if (isExists)
                    {
                        inventory.Remove(ithem);
                    }
                }
                else if (command == "Combine Items")
                {
                    var combine = ithem.Split(":").ToArray();
                    var firstIthem = combine[0].ToString();
                    var secondIthem = combine[1].ToString();
                    isExists = IsExists(inventory, firstIthem);

                    if (isExists)
                    {
                        var index = inventory.IndexOf(firstIthem);
                        inventory.Insert(index+1, secondIthem);
                    }
                }
                else if (command == "Renew")
                {
                    isExists = IsExists(inventory, ithem);

                    if (isExists)
                    {
                        inventory.Remove(ithem);
                        inventory.Add(ithem);

                    }
                }
            }

            Console.WriteLine(string.Join(", ", inventory));
        }

        private static bool IsExists(List<string> inventory, string ithem)
        {
            var isExists = false;

            if (inventory.Contains(ithem))
            {
                isExists = true;
            }

            return isExists;
        }
    }
}
