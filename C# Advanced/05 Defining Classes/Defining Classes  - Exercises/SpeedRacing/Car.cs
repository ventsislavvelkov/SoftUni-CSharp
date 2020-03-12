using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public double FuelAmount
        {
            get { return this.fuelAmount; }
            set { this.fuelAmount = value; }
        }

        public double FuelConsumptionPerKilometer
        {
            get { return this.fuelConsumptionPerKilometer; }
            set { this.fuelConsumptionPerKilometer = value; }

        }

        public double TravelledDistance
        {
            get { return this.travelledDistance; }
            set { this.travelledDistance = value; }
        }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;

        }

        public void Drive(string modelCar, double amountOfKilometers)
        {
            var usedFuel = amountOfKilometers * this.FuelConsumptionPerKilometer;

            if (usedFuel > this.FuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                this.FuelAmount -= usedFuel;
                this.TravelledDistance += amountOfKilometers;
            }
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:F2} {this.TravelledDistance}";
        }
    }
}
