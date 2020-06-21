using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private List<Rabbit> data;

        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            data = new List<Rabbit>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public void Add(Rabbit rabbit)
        {
            if (this.Capacity > 0)
            {
                data.Add(rabbit);
            }
        }

        public bool RemoveRabbit(string name)
        {
           var rabbitName = data.FirstOrDefault(r => r.Name == name);

           return data.Remove(rabbitName);
        }

        public void RemoveSpecies(string species)
        {
            data.RemoveAll(r => r.Species == species);
        }

        public Rabbit SellRabbit(string name)
        {
            var sellRabbit = data.FirstOrDefault(r => r.Name == name);
            sellRabbit.Available = false;
            return sellRabbit;
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            var rabbitBySpecies = data.Where(r=>r.Species == species);
            
            foreach (var r in rabbitBySpecies)
            {
                r.Available = false;
            }

            return rabbitBySpecies.ToArray();
        }

        public int Count => data.Count;


    }
}
