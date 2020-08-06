using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vehicles.Contracts;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;

        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            protected set { this.fuelQuantity = value; }
        }

        public virtual double FuelConsumption { get; protected set; }


        public string Drive(double distance)
        {
            var neededFuel = this.FuelConsumption * distance;
            if (this.FuelQuantity >= neededFuel)
            {
                this.FuelQuantity -= neededFuel;
                return string.Format("{0} travelled {1} km", this.GetType().Name, distance);
            }
            return string.Format("{0} needs refueling", this.GetType().Name);
        }


        public virtual void Refuel(double fuelQuantity)
        {
            this.FuelQuantity += fuelQuantity;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1:f2}", this.GetType().Name, this.FuelQuantity);
        }
    }
}
