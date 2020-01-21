using System;
using System.Collections.Generic;
using System.Linq;

namespace _07ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToList();

            List<int> OriginNumbers = numbers.ToList();
           
            int counter = 0;
            int sum = 0;
            string input = "";
            bool IsOrigin = true;



            while ((input = Console.ReadLine()) != "end")
            {
                string[] tokens = input.Split();
                string command = tokens[0];

                

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

                switch (command)
                {
                    case "Contains":

                        int containNumber = int.Parse(tokens[1]);

                        for (int i = 0; i < numbers.Count; i++)
                        {
                            counter++;

                            if (containNumber == numbers[i])
                            {
                                Console.WriteLine("Yes");
                                break;
                            }

                        }

                        if (counter == numbers.Count)
                        {
                            Console.WriteLine("No such number");
                        }
                        counter = 0;
                        break;

                    case "PrintEven":

                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] % 2 == 0)
                            {
                                Console.Write(numbers[i] + " ");
                            }
                        }

                        Console.WriteLine();
                        break;

                    case "PrintOdd":

                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] % 2 == 1)
                            {
                                Console.Write(numbers[i] + " ");
                            }
                        }

                        Console.WriteLine();
                        break;

                    case "GetSum":

                        for (int i = 0; i < numbers.Count; i++)
                        {
                            sum += numbers[i];
                        }

                        Console.WriteLine(sum);
                        break;

                    case "Filter":

                        string condition = tokens[1];
                        int number = int.Parse(tokens[2]);

                        if (condition == "<")
                        {
                            for (int i = 0; i < numbers.Count; i++)
                            {
                                if (number > numbers[i])
                                {
                                    Console.Write(numbers[i] + " ");
                                }
                            }

                            Console.WriteLine();
                        }
                        else if (condition == ">")
                        {
                            for (int i = 0; i < numbers.Count; i++)
                            {
                                if (number < numbers[i])
                                {
                                    Console.Write(numbers[i] + " ");
                                }
                            }

                            Console.WriteLine();
                        }
                        else if (condition == ">=")
                        {
                            for (int i = 0; i < numbers.Count; i++)
                            {
                                if (number <= numbers[i])
                                {
                                    Console.Write(numbers[i] + " ");
                                }
                            }

                            Console.WriteLine();

                        }
                        else if (condition == "<=")
                        {
                            for (int i = 0; i < numbers.Count; i++)
                            {
                                if (number >= numbers[i])
                                {
                                    Console.Write(numbers[i] + " ");
                                }
                            }

                            Console.WriteLine();
                        }

                        break;
                }
            }

            for (int i = 0; i < OriginNumbers.Count; i++)
            {
                if (numbers.Count == OriginNumbers.Count)
                {
                    if (numbers[i] != OriginNumbers[i])
                    {
                        Console.WriteLine(string.Join(" ", numbers));
                        break;
                    }
                }
                else
                {
                    Console.WriteLine(string.Join(" ", numbers));
                    break;
                }

            }
            
        }
    }
}
