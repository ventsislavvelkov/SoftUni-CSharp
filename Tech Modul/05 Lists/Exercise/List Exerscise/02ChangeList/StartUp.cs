using System;
using System.Linq;

namespace _02ChangeList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var operation = "";

            while ((operation = Console.ReadLine()) != "end")
            {

                var input = operation.Split();
                var command = input[0];
                var element = int.Parse(input[1]);

                switch (command)
                {
                    case "Delete":
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] == element)
                            {
                                numbers.Remove(element);
                            }
                        }
                        break;

                    case "Insert":
                        var position = int.Parse(input[2]);
                        numbers.Insert(position, element);
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
