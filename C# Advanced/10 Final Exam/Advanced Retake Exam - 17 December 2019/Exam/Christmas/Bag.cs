using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        private readonly HashSet<Present> data;

        //private Bag()
        //{
        //    this.data = new HashSet<Present>();
        //}

        public Bag(string color, int capacity)
           // : this()
        {
            this.Color = color;
            this.Capacity = capacity;
            this.data = new HashSet<Present>();
        }

        public string Color { get; set; }
        public int Capacity { get; set; }

        public void Add(Present present)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(present);
            }
        }

        public bool Remove(string name)
        {
            var isRemoved = false;
            var present = this.data.FirstOrDefault(p => p.Name == name);

            if (present != null)
            {
                
                this.data.Remove(present);
                isRemoved = true;
            }

            return isRemoved;
        }

        public Present GetHeaviestPresent()
        {
            var present = this.data.OrderByDescending(p => p.Weight).First();
            return present;
        }

        public Present GetPresent(string name)
        {
            var present = this.data.FirstOrDefault(p => p.Name == name);

            return present;
        }

        public int Count => this.data.Count;

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{Color} bag contains:");

            foreach (var p in data)
            {
                sb.AppendLine($"Present {p.Name} for a {p.Gender}");
            }

            return sb.ToString().TrimEnd();
        }


    }
}
