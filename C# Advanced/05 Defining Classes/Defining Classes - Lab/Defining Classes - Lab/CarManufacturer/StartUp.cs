using System.Text;

namespace CarManufacturer
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            var car = new Car {Make = "VW", Model = "MK3", Year = 1992};


            Console.WriteLine($"Make: {car.Make}{Environment.NewLine}Model: {car.Model}{Environment.NewLine}Year: {car.Year}");
        }
    }
}
