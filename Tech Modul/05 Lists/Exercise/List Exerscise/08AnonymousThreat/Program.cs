using System;
using System.Collections.Generic;
using System.Linq;

namespace _08AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            while (true)
            {
                var inputCommand = Console.ReadLine().Split().ToList();

                if (inputCommand[0] == "3:1")
                {
                    break;
                }
                else
                {
                    var commands = inputCommand[0];

                    switch (commands)
                    {
                        case "merge":

                            var mergeStartIndex = int.Parse(inputCommand[1]);
                            var mergeEndIndex = int.Parse(inputCommand[2]);

                            if (mergeStartIndex < 0) mergeStartIndex = 0;

                            if (mergeEndIndex > input.Count) mergeEndIndex = input.Count - 1;

                            if (mergeStartIndex < mergeEndIndex)
                            {
                                var diferense = mergeEndIndex - mergeStartIndex;
                                var number = 1;

                                while (number <= diferense)
                                {
                                    input[mergeStartIndex] += input[mergeStartIndex + number];
                                    number++;
                                }

                                number = diferense;
                                while (number != 0)
                                {
                                    input.RemoveAt(mergeStartIndex + number);
                                    number--;
                                }
                            }

                            break;
                        case "divide":
                            var startIndex = int.Parse(inputCommand[1]);

                            var divideWord = input[startIndex];
                            var partitions = int.Parse(inputCommand[2]);

                            var divideElements = new List<string>();
                            input.RemoveAt(startIndex);

                            var parts = divideWord.Length / partitions;

                            for (int i = 0; i < partitions; i++)
                            {
                                if (i == partitions -1)
                                {
                                    divideElements.Add(divideWord.Substring(i * parts));
                                }
                                else
                                {
                                    divideElements.Add(divideWord.Substring(i * parts, parts));
                                }
                            }

                            input.InsertRange(startIndex, divideElements);
                            
                            break;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", input));
        }
    }
}
