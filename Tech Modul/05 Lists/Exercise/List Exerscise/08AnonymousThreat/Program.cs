using System;
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
                                 //   Console.WriteLine(string.Join(" ", input));
                                   // Console.WriteLine();
                                }

                                number = diferense;
                                while (number != 0)
                                {
                                    input.RemoveAt(mergeStartIndex + number);
                                    number--;
                                }
                            }

                          //  Console.WriteLine(string.Join(" ", input));
                          //  Console.WriteLine();

                            break;
                        case "devide":
                            var devideIndex = int.Parse(inputCommand[1]);
                            var devideParts = int.Parse(inputCommand[2]);

                            

                            break;
                    }


                }
            }

            Console.WriteLine(string.Join(" ", input));
        }
    }
}
