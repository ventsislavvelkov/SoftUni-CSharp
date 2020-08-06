using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double BUS_AIR_CONDITIONER = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }
        public override double FuelConsumption
        {
            get { return base.FuelConsumption; }
            protected set { base.FuelConsumption = value + BUS_AIR_CONDITIONER; }
        }
        public string DriveEmpty(double distance)
        {
            var neededFuel = (base.FuelConsumption-BUS_AIR_CONDITIONER) * distance;
            if (this.FuelQuantity >= neededFuel)
            {
                this.FuelQuantity -= neededFuel;
                return string.Format("{0} travelled {1} km", this.GetType().Name, distance);
            }
            return string.Format("{0} needs refueling", this.GetType().Name);
        }
    }
}