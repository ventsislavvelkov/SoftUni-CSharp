using System;

namespace _07WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
           int numberoflines = int.Parse(Console.ReadLine());
            int volumeOfTank = 255;
            int litersInTank = 0;

            for (int i = 0; i < numberoflines; i++)
            {
                int incomingLiters= int.Parse(Console.ReadLine());

                if (litersInTank+incomingLiters<=volumeOfTank)
                {

                    litersInTank += incomingLiters;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }

            }
            Console.WriteLine(litersInTank);
        }
    }
}
