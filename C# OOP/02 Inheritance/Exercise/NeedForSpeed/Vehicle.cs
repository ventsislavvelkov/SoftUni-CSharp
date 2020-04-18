using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace NeedForSpeed
{
   public abstract class Vehicle
   {
       private const double defaultFuelConsumption = 1.25;
        private double fuel;
       public Vehicle(int horsePower, double fuel)
       {
           this.HorsePower = horsePower;
           this.Fuel = fuel;
       }

        public virtual double FuelConsumption => defaultFuelConsumption;
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {

            var fuelNeeded = kilometers * this.FuelConsumption;

            if (this.Fuel >= fuelNeeded)
            {
                this.Fuel -= fuelNeeded;
            }
        }
    }
}
