using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using Microsoft.VisualBasic;

namespace _04ListOperations
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToList();

            while (true)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (input[0] == "End")
                {
                    break;
                }
                else
                {
                    var command = input[0];
                    var isInRange = false;
                    switch (command)
                    {
                        case "Add":

                            var add = int.Parse(input[1]);
                            numbers.Add(add);

                            break;
                        case "Insert":

                            var insertNumber = int.Parse(input[1]);
                            var insertIndex = int.Parse(input[2]);

                           isInRange = IsInBoundery(numbers, insertIndex);

                            if (isInRange)
                            {
                                numbers.Insert(insertIndex, insertNumber);
                            }

                            break;
                        case "Remove":

                            var removeIndex = int.Parse(input[1]);

                            isInRange = IsInBoundery(numbers, removeIndex);

                            if (isInRange)
                            {
                                numbers.RemoveAt(removeIndex);
                            }


                            break;
                        case "Shift":
                            var shiftCommand = input[1];
                            var shiftCount = int.Parse(input[2]);

                            if (shiftCommand == "left")
                            {
                                numbers = LeftRotation(numbers, shiftCount);
                            }
                            else
                            {
                                numbers = RightRotation(numbers, shiftCount);
                            }
                            break;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        static bool IsInBoundery(List<int> numbers, int index)
        {
            var isInRange = false;

            if (index < numbers.Count && index >= 0)
            {
                isInRange = true;
            }
            else
            {
                Console.WriteLine("Invalid index");
            }


            return isInRange;
        }


        static List<int> RightRotation(List<int> numbers, int count)
        {
            while (count > 0)
            {
                count--;

                var lastNumber = numbers[numbers.Count-1];

                for (int i = numbers.Count - 1; i > 0 ; i--)
                {
                    numbers[i] = numbers[i - 1];
                }

                numbers[0] = lastNumber;
            }

            return numbers;

        }

        static List<int> LeftRotation(List<int> numbers, int count)
        {
            while (count > 0)
            {
                count--;

                var firstNumber = numbers[0];

                for (int i = 0; i < numbers.Count-1; i++)
                {
                    numbers[i] = numbers[i + 1];
                }

                numbers[numbers.Count - 1] = firstNumber;
            }

            return numbers;

        }
    }
}
