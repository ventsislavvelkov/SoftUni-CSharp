using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Tire
    {
        private double tirePressure;

        private int tireAge;

        public double TirePressure
        {
            get { return this.tirePressure;}
            set { this.tirePressure = value; }
        }

        public int TireAge
        {
            get { return this.tireAge; }
            set { this.tireAge = value; }
        }
        public Tire(double tirePressure, int tireAge)
        {
            this.tirePressure = tirePressure;
            this.tireAge = tireAge;
        }
    }
}
