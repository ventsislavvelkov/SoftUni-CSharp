using System.Text;
using  System;
using System.Globalization;

namespace CarManufacturer
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var make = Console.ReadLine();
            var model = Console.ReadLine();
            var year = int.Parse(Console.ReadLine());
            var fuelQuantity = double.Parse(Console.ReadLine());
            var fuelConsumption = double.Parse(Console.ReadLine());

            Car firstCar = new Car();
            Car secondCar = new Car(make,model,year);
            Car thirdCar = new Car(make, model, year,fuelQuantity, fuelConsumption);


        }
    }
}
