using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace P02_CarsSalesman
{
    public class Car
    {
        private const string offset = "  ";

        private int weight;
        private string color;

        public string Model { get; }
        public Engine Engine { get; }
        public int  Weight { get;}
        public string Color { get; }



        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = -1;
            this.Color = "n/a";
        }

        public Car(string model, Engine engine, int weight)
        :this(model, engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, string color)
        :this(model, engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
        :this(model, engine, weight)
        {
            this.Color = color;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.Model}:"+Environment.NewLine);
            sb.Append($"{this.Engine.ToString()}" + Environment.NewLine);
            sb.Append($"{offset}Weight: {(this.Weight == -1 ? "n/a" : this.Weight.ToString())}" + Environment.NewLine);
            sb.Append($"{offset}Color: {this.Color}");

            return sb.ToString().TrimEnd();
        }
    }
}
