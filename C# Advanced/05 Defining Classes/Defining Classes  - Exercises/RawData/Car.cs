using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tire;

        public Engine Engine
        {
            get { return this.engine; }
            set { this.engine = value; }
        }

        public Cargo Cargo
        {
            get { return this.cargo; }
            set { this.cargo = value; }
        }

        public Tire[] Tire
        {
            get { return this.tire; }
            set { this.tire = value; }
        }
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tire = tires;
        }
    }
}
