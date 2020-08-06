using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        public const double CAR_AIR_CONDITIONER = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }
        public override double FuelConsumption
        {
            get
            {
                return base.FuelConsumption;
            }
            protected set
            {
                base.FuelConsumption = CAR_AIR_CONDITIONER + value;
            }
        }

    }
}
