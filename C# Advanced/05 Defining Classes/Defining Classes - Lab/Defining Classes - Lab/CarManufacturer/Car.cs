using  System;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;

        public string Make
        {
            get => this.make;
            set => this.make = value;
        }

        public string Model
        {
            get => this.model;
            set => this.model = value;
        }

        public int Year
        {
            get => this.year;
            set => this.year = value;
        }
    }
}
