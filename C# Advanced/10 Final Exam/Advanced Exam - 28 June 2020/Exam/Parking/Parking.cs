using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
   public  class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.data = new List<Car>();
        }
        public string Type { get; set; }
        public int Capacity { get; set; }

        public void Add(Car  car)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            var isRemoved = false;

            var car = this.data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);

            if (car != null)
            {
                this.data.Remove(car);
                isRemoved = true;
            }

            return isRemoved;
        }

        public Car GetLatestCar()
        {
            Car car = this.data.OrderByDescending(c => c.Year).FirstOrDefault();

            return car;
        }

        public Car GetCar(string manufacturer, string model)
        {

            var car = this.data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);

            return car;
        }

        public int Count => this.data.Count;

        public string GetStatistics()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {this.Type}:")
                .AppendLine($"{string.Join(Environment.NewLine, this.data)}");

            return sb.ToString().TrimEnd();
        }
    }
}
