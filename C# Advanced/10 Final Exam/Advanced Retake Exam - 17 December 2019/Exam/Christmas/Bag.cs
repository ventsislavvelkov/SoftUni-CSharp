using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        private readonly List<Present> data;

        //private Bag()
        //{
        //    this.data = new HashSet<Present>();
        //}

        public Bag(string color, int capacity)
           // : this()
        {
            this.Color = color;
            this.Capacity = capacity;
            this.data = new List<Present>();
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
            var person = this.data.FirstOrDefault(p => p.Name == name);

            if (person != null)
            {
                this.data.Remove(person);
                isRemoved = true;
            }

            return isRemoved;
        }

        public Present GetHeaviestPresent()
        {
            return this.data.OrderByDescending(p => p.Weight).FirstOrDefault();
        }

        public Present GetPresent(string name)
        {
            return this.data.FirstOrDefault(p => p.Name == name);
        }

        public int Count => this.data.Count;

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Color} bag contains:");

            sb.AppendLine(string.Join(Environment.NewLine, this.data));

            return sb.ToString().TrimEnd();
        }


    }
}
