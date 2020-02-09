using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class StartUp
    {
        static void Main(string[] args)
        {
           var numbers = Console.ReadLine().Split().ToList();

           var letters = Console.ReadLine().Select(x => x.ToString()).ToList();   

            var result = new List<string>();

            for (int i = 0; i < numbers.Count; i++)   
            {
                var sumOfDigits = 0;

                foreach (var symbol in numbers[i]) 
                {
                    var digit = symbol - '0';
                    sumOfDigits += digit;
                }

                if (sumOfDigits > letters.Count) 
                {
                    sumOfDigits = sumOfDigits % letters.Count;
                }

                result.Add(letters[sumOfDigits]); 
                letters.RemoveAt(sumOfDigits); 
            }

            Console.WriteLine(string.Join("", result));

        }
    }
}
