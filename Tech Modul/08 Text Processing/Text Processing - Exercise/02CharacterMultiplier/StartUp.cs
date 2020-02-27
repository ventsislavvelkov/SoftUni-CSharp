using System;

namespace _02CharacterMultiplier
{
    class StartUp
    {
        static void Main(string[] args)
        {
           var strings = Console.ReadLine().Split();

           var firstStr = strings[0];
           var secondStr = strings[1];

           var minStr = string.Empty;
           var maxStr = string.Empty;

           if (firstStr.Length > secondStr.Length)
           {
               minStr = secondStr;
               maxStr = firstStr;
           }
           else
           {
               minStr = firstStr;
               maxStr = secondStr;
           }

           var totalSum = 0; 

           for (int i = 0; i < minStr.Length; i++)
           {
               totalSum += minStr[i] * maxStr[i];
           }

           for (int i = minStr.Length; i < maxStr.Length; i++)
           {
               totalSum += maxStr[i];
           }

           Console.WriteLine(totalSum);


        }
    }
}
