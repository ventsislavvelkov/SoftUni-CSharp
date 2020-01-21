using System;
using System.Linq;
using System.Collections.Generic;


namespace _06ListManipulationBasic
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToList();

            string input = "";

            while ((input = Console.ReadLine()) != "end")
            {
                string[] tokens = input.Split();

                switch (tokens[0])
                {
                    case "Add":
                        int addToken = int.Parse(tokens[1]);
                        numbers.Add(addToken);
                        break;
                    case "Remove":
                        int removeToken = int.Parse(tokens[1]);
                        numbers.Remove(removeToken);
                        break;
                    case "RemoveAt":
                        int removeAtToken = int.Parse(tokens[1]);
                        numbers.RemoveAt(removeAtToken);
                        break;
                    case "Insert":
                        int insertTokenNumber = int.Parse(tokens[1]);
                        int insertRokenIndex = int.Parse(tokens[2]);
                        numbers.Insert(insertRokenIndex, insertTokenNumber);
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
