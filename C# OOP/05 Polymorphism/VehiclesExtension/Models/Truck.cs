using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double TRUCK_AIR_CONDITIONER = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
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
                base.FuelConsumption = TRUCK_AIR_CONDITIONER + value;
            }
        }
        public override void Refuel(double fuelQuantity)
        {
            if (fuelQuantity<=0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (fuelQuantity + this.FuelQuantity > this.TankCapacity)
            {
                throw new ArgumentException(string.Format("Cannot fit {0} fuel in the tank", fuelQuantity));
            }
            this.FuelQuantity += fuelQuantity * 0.95;
        }
    }
}
