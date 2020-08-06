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
        private double tankCapacity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }

            }
        }

        public virtual double FuelConsumption { get; protected set; }

        public double TankCapacity { get; private set; }


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
            if (fuelQuantity<=0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (fuelQuantity + this.FuelQuantity > this.TankCapacity)
            {
                throw new ArgumentException(string.Format("Cannot fit {0} fuel in the tank", fuelQuantity));
            }
            this.FuelQuantity += fuelQuantity;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1:f2}", this.GetType().Name, this.FuelQuantity);
        }




    }
}
