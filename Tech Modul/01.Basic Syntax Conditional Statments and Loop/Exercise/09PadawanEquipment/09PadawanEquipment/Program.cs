using System;

namespace _09PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double amountOfMoney = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double priceOfLightsaber = double.Parse(Console.ReadLine());
            double priceOfRobe = double.Parse(Console.ReadLine());
            double priceOfBelt = double.Parse(Console.ReadLine());
            double soldMoney = 0;
            int freeBelt = 0;

            if (countOfStudents >= 6)
            {
                for (int i = 6; i <= countOfStudents; i += 6)
                {
                    freeBelt++;
                }
            }


            soldMoney += (priceOfBelt * (countOfStudents - freeBelt)) + (priceOfLightsaber * (Math.Ceiling(countOfStudents * 1.10))) + (priceOfRobe * countOfStudents);

            if (amountOfMoney >= soldMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {soldMoney:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {soldMoney - amountOfMoney:f2}lv more.");
            }


        }
    }
}
