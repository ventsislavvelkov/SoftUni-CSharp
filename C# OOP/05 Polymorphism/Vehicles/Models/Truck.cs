using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double TRUCK_AIR_CONDITIONER = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
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
            this.FuelQuantity += fuelQuantity * 0.95;
        }
    }
}
