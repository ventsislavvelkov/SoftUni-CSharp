using System;

namespace _09GreaterOfTwoValues
{
    class Program
    {
        static int GetMax(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        static char GetMax(char a, char b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        static string GetMax(string a, string b)
        {
            if (a.CompareTo(b) >= 0)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            switch (command)
            {
                case "int":
                    int inputInt = int.Parse(Console.ReadLine());
                    int inputInt2 = int.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(inputInt, inputInt2));
                    break;

                case "char":
                    char inputChar = char.Parse(Console.ReadLine());
                    char inputChar2 = char.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(inputChar, inputChar2));
                    break;

                case "string":
                    string inputStr = Console.ReadLine();
                    string inputStr2 = Console.ReadLine();
                    Console.WriteLine(GetMax(inputStr, inputStr2));
                    break;
            }
        }
    }
}
