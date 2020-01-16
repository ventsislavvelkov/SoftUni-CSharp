using System;

namespace _11RefactorVolumeOfPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
         
            Console.Write("Length: ");
            double length;
            length = double.Parse(Console.ReadLine());

            Console.Write("Width: ");
            double width;
            width = double.Parse(Console.ReadLine());

            Console.Write("Height: ");
            double heigth;
            heigth = double.Parse(Console.ReadLine());

            double volume = 0;
            volume = ((length * width) * heigth) / 3;
            Console.Write($"Pyramid Volume: {volume:f2}");

        }
    }
}
