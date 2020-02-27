using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace _05MultiplyBigNumber
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var firstNumber = Console.ReadLine();
            var multiplier = int.Parse(Console.ReadLine());

            var builder = new StringBuilder();

            var onMind = 0;

            for (int i = firstNumber.Length-1; i >= 0 ; i--)
            {
                var currentNumber = int.Parse(firstNumber[i].ToString());

                var result = currentNumber * multiplier + onMind;

                builder.Append(result % 10);
                
                onMind = result / 10;
            }

            if (onMind != 0 )
            {
                builder.Append(onMind);
            }

            var resultNumer =string.Join("", builder.ToString().Reverse()).TrimStart('0');

            if (resultNumer == string.Empty)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(resultNumer);
            }
        }
    }
}
