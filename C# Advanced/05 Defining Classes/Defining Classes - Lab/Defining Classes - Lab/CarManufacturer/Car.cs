﻿using System;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

        public Engine Engine
        {
            get { return this.engine; }
            set { this.engine = value; }
        }

        public Tire[] Tires
        {
            get { return this.tires; }
            set { this.tires = value; }
        }

        public string Make
        {
            get { return this.make; }
            set { this.make = value; }
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public int Year
        {
            get { return this.year; }
            set { this.year = value; }
        }

        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set { this.fuelQuantity = value; }
        }

        public double FuelConsumption
        {
            get { return this.fuelConsumption; }
            set { this.fuelConsumption = value; }
        }

        public void Drive(double distance)
        {
            double consumedFuel = distance * this.FuelConsumption / 100;

            if (consumedFuel > this.FuelQuantity)
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
            else
            {
                this.FuelQuantity -= consumedFuel;
            }
        }

        public string WhoAmI()
        {
            StringBuilder car = new StringBuilder();

            car.AppendLine($"Make: {this.Make}");
            car.AppendLine($"Model: {this.Model}");
            car.AppendLine($"Year: {this.Year}");
            car.Append($"Fuel: {this.FuelQuantity:F2}L");

            return car.ToString();
        }


        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }


        public Car(string make, string model, int year)
        :this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }

        public override string ToString()
        {
            return $"Make: {this.Make}" + Environment.NewLine +
                   $"Model: {this.Model}" + Environment.NewLine +
                   $"Year: {this.Year}" + Environment.NewLine +
                   $"HorsePowers: {this.Engine.HorsePower}" + Environment.NewLine +
                   $"FuelQuantity: {this.FuelQuantity}";
        }

    }
}

