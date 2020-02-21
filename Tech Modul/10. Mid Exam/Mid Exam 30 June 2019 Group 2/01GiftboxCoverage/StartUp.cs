using System;

namespace _01GiftboxCoverage
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var sizeOfSide = double.Parse(Console.ReadLine());
            var numbersOfSheetOfPaper = int.Parse(Console.ReadLine());
            var areaOfSingleSheet = double.Parse(Console.ReadLine());

            var totalArea = sizeOfSide * sizeOfSide * 6;

            var areaCovered = 0.0;

            for (int i = 1; i <= numbersOfSheetOfPaper; i++)
            {
                if (i % 3 != 0)
                {
                    areaCovered += areaOfSingleSheet;
                }
                else
                {
                    areaCovered += areaOfSingleSheet * 0.25;
                }
                
            }

            var percentCover = (areaCovered / totalArea) * 100;

            Console.WriteLine($"You can cover {percentCover:F2}% of the box.");
        }
    }
}
























