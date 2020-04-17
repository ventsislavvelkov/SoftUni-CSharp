using System.Collections.Generic;

namespace P01_RawData
{
    public class Car
    {
        private readonly ICollection<Tire> tires;

        public IReadOnlyCollection<Tire> Tires { get => (IReadOnlyCollection<Tire>)this.tires; }
        public Engine Engine { get; }
        public Cargo Cargo { get; } 
        public string Model { get; } 


        public Car(string model, Engine engine, Cargo cargo, ICollection<Tire> tires)
        { 
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.tires = tires;
        }
       
      
      
        
    } 
}