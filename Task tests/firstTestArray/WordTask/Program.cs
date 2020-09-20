using System;
using System.Collections.Generic;
using System.Linq;

namespace WordTask
{
    class Program
    {
        private static char uniqueChar;

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            IsPermuOnPoly(input);
        }

        public static void IsPermuOnPoly(string input)
        {
            char[] inputToCharArr = input.ToCharArray();
            Array.Sort(inputToCharArr);
            List<char> allSymbols = inputToCharArr.Distinct().ToList();
            string firstPart = string.Empty;
            string secondPart = string.Empty;

            if (AreElementsEqual(inputToCharArr))
            {
                if (uniqueChar == '\0')
                {
                    firstPart = string.Join("", allSymbols);
                    allSymbols.Reverse();
                    secondPart = string.Join("", allSymbols);
                }
                else
                {
                    if (!(UniqueCharNumber(uniqueChar, inputToCharArr) >= 3))
                    {
                        allSymbols.Remove(uniqueChar);
                    }

                    firstPart = string.Join("", allSymbols);
                    allSymbols.Reverse();
                    secondPart = uniqueChar + string.Join("", allSymbols);
                }
                Console.WriteLine(firstPart + secondPart);
            }
            else
            {
                Console.WriteLine(false);
            }
        }

        public static int UniqueCharNumber(char unique, char[] inputToCharArr)
        {
            int counter = 0;
            for (int i = 0; i < inputToCharArr.Length; i++)
            {
                if (inputToCharArr[i] == unique)
                {
                    counter++;
                }
            }

            return counter;
        }

        public static bool AreElementsEqual(char[] inputToCharArr)
        {
            if (inputToCharArr.Length % 2 == 0)
            {
                for (int i = 0; i < inputToCharArr.Length - 1; i += 2)
                {
                    if (inputToCharArr[i] != inputToCharArr[i + 1])
                    {
                        return false;
                    }
                }
            }
            else
            {
                int counter = 0;
                for (int i = 0; i < inputToCharArr.Length - 2; i++)
                {
                    if (inputToCharArr[i] != inputToCharArr[i + 1])
                    {
                        counter++;
                        uniqueChar = inputToCharArr[i];
                        if (counter > 1)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        i++;
                    }
                }
                if (counter == 0)
                {
                    uniqueChar = inputToCharArr[inputToCharArr.Length - 1];
                }
            }

            return true;
        }

    }
}