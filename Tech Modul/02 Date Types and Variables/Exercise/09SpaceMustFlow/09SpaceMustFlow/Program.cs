using System;

namespace _09SpaceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int days = 0;
            int sumYield = 0;

            while (startingYield >= 100)
            {
                sumYield += startingYield - 26;
                days++;
                startingYield -= 10;
              
            }
            if (sumYield >= 26)
            {
                sumYield -= 26;
            }
          
          

            Console.WriteLine(days);
            Console.WriteLine(sumYield);

        }
    }
}
