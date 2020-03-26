using System;
using System.ComponentModel.Design;

namespace NikuldensCharity
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var strings = Console.ReadLine();

            while (true)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var command = input[0];
                var isInRange = false;

                if (command == "Finish")
                {
                    break;
                }

                if (command == "Replace")
                {
                    var currentChar = input[1];
                    var newChar = input[2];

                   strings =  strings.Replace(currentChar, newChar);
                   Console.WriteLine(strings);
                }
                else if (command == "Cut")
                {
                    var startIndex = int.Parse(input[1]);
                    var endIndex = int.Parse(input[2]);

                    isInRange = iSInRange(strings, startIndex, endIndex);

                    if (isInRange)
                    {
                        strings = strings.Remove(startIndex, endIndex);
                        Console.WriteLine(strings);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }
                else if (command == "Make")
                {
                    var isUpperOrLower = input[1];

                    strings = isUpperOrLower == "Upper" ? strings.ToUpper() : strings.ToLower();

                    Console.WriteLine(strings);

                }
                else if (command == "Check")
                {
                    var containString = input[1];

                    var isContains = strings.Contains(containString);

                    Console.WriteLine(isContains
                        ? $"Message contains {containString}"
                        : $"Message doesn't contain {containString}");
                }
                else if (command == "Sum")
                {
                    var startIndex = int.Parse(input[1]);
                    var endIndex = int.Parse(input[2]);

                    isInRange = iSInRange(strings, startIndex, endIndex);

                    if (isInRange)
                    {
                        var substringStrings = strings.Substring(startIndex, endIndex);
                        var sum = 0;

                        for (int i = 0; i < substringStrings.Length; i++)
                        {
                            var currentCh = substringStrings[i];
                            sum += currentCh;
                        }

                        Console.WriteLine(sum);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }
            }
        }
        public static bool iSInRange(string strings, int startIndex, int endIndex)
        {
            var isInRange = false;

            if (startIndex >= 0 && strings.Length > endIndex)
            {
                isInRange = true;
            }

            return isInRange;
        }
    }
}
