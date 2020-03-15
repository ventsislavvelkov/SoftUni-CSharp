using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        private string model;
        private string engine;
        private int weight;
        private string color;

        public string Model
        {
            get => this.model;
            set => this.model = value;
        }

        public string Engine
        {
            get => this.engine;
            set => this.engine = value;
        }

        public int Weight
        {
            get => this.weight;
            set => this.weight = value;
        }

        public string Color
        {
            get => this.color;
            set => this.color = value;
        }
    }
}
