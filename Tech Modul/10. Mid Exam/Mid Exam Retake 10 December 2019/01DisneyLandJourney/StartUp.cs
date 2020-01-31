using System;
using System.Threading;

namespace _01DisneyLandJourney
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var moneyForJourney = double.Parse(Console.ReadLine());
            var mounts = int.Parse(Console.ReadLine());
            var savedMoney = 0.0;

            for (int i = 1; i <= mounts; i++)
            {
                if (i == 1)
                {
                    savedMoney += moneyForJourney * 0.25;
                }
                else if (i % 2 != 0)
                {
                    savedMoney -= savedMoney * 0.16;
                    savedMoney += moneyForJourney * 0.25;

                }
                else if (i % 4 == 0)
                {
                    savedMoney += savedMoney * 0.25;
                    savedMoney += moneyForJourney * 0.25;
                }
                else
                {
                    savedMoney += moneyForJourney * 0.25;
                }

            }

            if (savedMoney >= moneyForJourney)
            {
                Console.WriteLine($"Bravo! You can go to Disneyland and you will have {savedMoney - moneyForJourney:f2}lv. for souvenirs.");
            }
            else
            {
                Console.WriteLine($"Sorry. You need {moneyForJourney - savedMoney :f2}lv. more.");
            }

        }
    }
}
