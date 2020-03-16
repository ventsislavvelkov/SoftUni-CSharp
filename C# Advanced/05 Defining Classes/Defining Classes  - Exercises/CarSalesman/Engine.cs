using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        private string model;
        private int power;
        private int displacement;
        private double efficiency;

        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
        }

        public Engine(string model, int power, int displacement)
            : this(model, power)
        {
            this.Displacement = displacement;
        }

        public Engine(string model, int power, double efficiency)
            : this(model, power)
        {
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, double efficiency)
            : this(model, power, displacement)
        {
            this.Efficiency = efficiency;
        }
        public string Model
        {
            get => this.model;
            set => this.model = value;
        }

        public int Power
        {
            get => this.power;
            set => this.power = value;
        }

        public int Displacement
        {
            get => this.displacement;
            set => this.displacement = value;
        }

        public double Efficiency
        {
            get => this.efficiency;
            set => this.efficiency = value;
        }
    }
}
