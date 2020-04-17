using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    public class Room
    {
        private List<Patient> patient;

        public Room()
        {
            this.patient = new List<Patient>();
        }
        public Room(byte number)
        :this()
        {
            this.Number = number; 
        }
        public byte  Number { get; }

        public IReadOnlyCollection<Patient> Patient { get => this.patient;}

    }
}
