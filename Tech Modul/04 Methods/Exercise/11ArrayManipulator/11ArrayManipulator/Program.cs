using System;
using System.Collections.Generic;
using System.Linq;

namespace _11ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            while (true)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (input[0] == "end")
                {
                    break;
                }
                else
                {
                    switch (input[0])
                    {
                        case "exchange":

                            var exchangeIndex = int.Parse(input[1]);

                            if (exchangeIndex >= 0 && exchangeIndex < numbers.Length)
                            {
                                ArrayRotation(numbers, exchangeIndex);
                            }
                            else
                            {
                                Console.WriteLine("Invalid index");
                            }

                            break;
                        case "max":

                            var maxOddOrEvenNumber = input[1];
                            MaxOddOrEvenNumber(numbers, maxOddOrEvenNumber);


                            break;
                        case "min":

                            var minOddOrEvenNumber = input[1];
                            MinOddOrEvenNumber(numbers, minOddOrEvenNumber);

                            break;
                        case "first":
                            
                            var firstNumber = int.Parse(input[1]);
                            var firstOddOrEven = input[2];
                            FirstOddOrEven(numbers, firstNumber, firstOddOrEven);

                            break;
                        case "last":

                            var lastNumber = int.Parse(input[1]);
                            var lastOddOrEven = input[2];
                            LastOddOrEven(numbers, lastNumber, lastOddOrEven);

                            break;
                    }
                }
            }

            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }

        static void LastOddOrEven(int[] numbers, int number, string oddOrEven)
        {
            
            var lastNumbers = new List<int>();

            if (oddOrEven == "odd")
            {
                for (int i = numbers.Length - 1; i >= 0; i--)
                {
                    var num = numbers[i];

                    if (num % 2 != 0 && lastNumbers.Count < number)
                    {
                        lastNumbers.Add(numbers[i]);
                    }
                }

                lastNumbers.Reverse();

                if (number > numbers.Length)
                {
                    Console.WriteLine("Invalid count");
                }
                else
                {
                    Console.WriteLine($"[{string.Join(" ", lastNumbers)}]");
                }

            }
            else
            {
                for (int i = numbers.Length - 1; i >= 0; i--)
                {
                    var num = numbers[i];

                    if (num % 2 == 0 && lastNumbers.Count < number)
                    {
                        lastNumbers.Add(numbers[i]);
                    }

                }
                lastNumbers.Reverse();

                if (number > numbers.Length)
                {
                    Console.WriteLine("Invalid count");
                }
                else
                {
                    Console.WriteLine($"[{string.Join(" ", lastNumbers)}]");
                }

            }

        }

        static void FirstOddOrEven(int[] numbers, int number, string oddOrEven)
        {
            var firstNumbers = new List<int>();

            if (oddOrEven == "odd")
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    var num = numbers[i];

                    if (num % 2 != 0 && firstNumbers.Count < number)
                    {
                        firstNumbers.Add(numbers[i]);
                    }
                }

                if (number > numbers.Length)
                {
                    Console.WriteLine("Invalid count");
                }
                else
                {
                    Console.WriteLine($"[{string.Join(", ", firstNumbers)}]");
                }

            }
            else
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    var num = numbers[i];

                    if (num % 2 == 0 && firstNumbers.Count < number)
                    {
                        firstNumbers.Add(numbers[i]);
                    }

                }
                if (number > numbers.Length)
                {
                    Console.WriteLine("Invalid count");
                }
                else
                {
                    Console.WriteLine($"[{string.Join(", ", firstNumbers)}]");
                }
            }
        }

        static void MinOddOrEvenNumber(int[] numbers, string oddOrEven)
        {
            var min = int.MaxValue;
            var minIndex = -1;

            if (oddOrEven == "odd")
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    var num = numbers[i];

                    if (num % 2 != 0)
                    {
                        if (min >= num)
                        {
                            min = num;
                            minIndex = i;
                        }
                    }
                }

                if (minIndex == -1)
                {
                    Console.WriteLine("No matches");
                }
                else
                {
                    Console.WriteLine(minIndex);
                }

            }
            else
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    var num = numbers[i];

                    if (num % 2 == 0)
                    {
                        if (min >= num)
                        {
                            min = num;
                            minIndex = i;
                        }
                    }
                }
                if (minIndex == -1)
                {
                    Console.WriteLine("No matches");
                }
                else
                {
                    Console.WriteLine(minIndex);
                }
            }
        }


        static void MaxOddOrEvenNumber(int[] numbers, string oddOrEven)
        {
            var max = 0;
            var maxIndex = -1;

            if (oddOrEven == "odd")
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    var num = numbers[i];

                    if (num % 2 != 0)
                    {
                        if (max <= num)
                        {
                            max = num;
                            maxIndex = i;
                        }
                    }
                }

                if (maxIndex == -1)
                {
                    Console.WriteLine("No matches");
                }
                else
                {
                    Console.WriteLine(maxIndex);
                }
            }
            else
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    var num = numbers[i];

                    if (num % 2 == 0)
                    {
                        if (max <= num)
                        {
                            max = num;
                            maxIndex = i;
                        }
                    }
                }

                if (maxIndex == -1)
                {
                    Console.WriteLine("No matches");
                }
                else
                {
                    Console.WriteLine(maxIndex);
                }
            }
        }

        static int[] ArrayRotation(int[] numbers, int number)
        {

            while (number >= 0)
            {
                number--;

                var tmp = numbers[0];

                for (int i = 0; i < numbers.Length - 1; i++)
                {

                    numbers[i] = numbers[i + 1];
                }

                numbers[numbers.Length - 1] = tmp;
            }

            return numbers;
        }
    }
}
