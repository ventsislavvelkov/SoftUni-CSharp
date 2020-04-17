using System.Collections.Generic;

namespace P01_RawData
{
    public class Car
    {
        public Engine Engine { get; }
        public string Model { get; }


        public Car(string model, Engine engine, int cargoWeight, string cargoType, double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age, double tire3Pressure, int tire3age, double tire4Pressure, int tire4age)
        {
            this.Model = model;
            this.Engine = engine;
            this.cargoWeight = cargoWeight;
            this.cargoType = cargoType;
            this.tires = new KeyValuePair<double, int>[] { KeyValuePair.Create(tire1Pressure, tire1Age), KeyValuePair.Create(tire2Pressure, tire2Age), KeyValuePair.Create(tire3Pressure, tire3age), KeyValuePair.Create(tire4Pressure, tire4age) };
        }
       
      
        public int cargoWeight;
        public string cargoType;
        public KeyValuePair<double, int>[] tires;
    }
}