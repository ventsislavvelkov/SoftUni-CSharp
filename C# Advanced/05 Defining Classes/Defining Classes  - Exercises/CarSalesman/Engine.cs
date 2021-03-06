﻿using System;
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
        private string efficiency;

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

        public Engine(string model, int power, string efficiency)
            : this(model, power)
        {
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency)
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

        public string Efficiency
        {
            get => this.efficiency;
            set => this.efficiency = value;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var displacementStr = this.Displacement.Equals(0) ? "n/a" : this.Displacement.ToString();
            var efficiencyStr = String.IsNullOrEmpty(this.efficiency) ? "n/a" :this.Efficiency;

            sb.AppendLine($"{this.Model}:")
                .AppendLine($"    Power: {this.Power}")
                .AppendLine($"    Displacement: {displacementStr}")
                .AppendLine($"    Efficiency: {efficiencyStr}");

            return sb.ToString().TrimEnd();
        }
    }
}
