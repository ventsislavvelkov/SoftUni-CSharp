using System;
using System.Collections.Generic;
using System.Linq;

namespace _02ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToList();

            string operation = "";

            while ((operation = Console.ReadLine()) != "end")
            {

                string[] input = operation.Split();
                string command = input[0];
                int element = int.Parse(input[1]);

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
                        int position = int.Parse(input[2]);
                        numbers.Insert(position, element);
                        break;
                }


            }

            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}