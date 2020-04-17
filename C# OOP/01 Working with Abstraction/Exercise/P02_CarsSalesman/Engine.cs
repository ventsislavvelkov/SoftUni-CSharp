using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace P02_CarsSalesman
{
    public class Engine
    {
        private const string offset = "  ";

        public string Model { get; }
        public int Power { get; }
        public int Displacement { get; }
        public string Efficiency { get; }


        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = -1;
            this.Efficiency = "n/a";
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"{offset}{this.Model}:" + Environment.NewLine);
            sb.AppendFormat($"{offset}{offset}Power: {this.Power}" + Environment.NewLine);
            sb.AppendFormat($"{offset}{offset}Displacement: {(this.Displacement == -1 ? "n/a" : this.Displacement.ToString())}" + Environment.NewLine);
            sb.AppendFormat($"{offset}{offset}Efficiency: {this.Efficiency}" + Environment.NewLine);

            return sb.ToString().TrimEnd();
        }
    }
}