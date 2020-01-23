using System;
using System.Dynamic;
using System.Text;

namespace _05DigitsLettersOther
{
    class Program
    {
        static void Main(string[] args)
        {
            string simpleString = Console.ReadLine();

            var digit = new StringBuilder();
            var letter = new StringBuilder();
            var other = new StringBuilder();

            for (int i = 0; i < simpleString.Length; i++)
            {
                if (char.IsDigit(simpleString[i]))
                {
                    digit.Append(simpleString[i]);
                }
                else if (char.IsLetter(simpleString[i]))
                {
                    letter.Append(simpleString[i]);
                }
                else
                {
                    other.Append(simpleString[i]);
                }
            }

            Console.WriteLine(digit);
            Console.WriteLine(letter);
            Console.WriteLine(other);
        }
    }
}
