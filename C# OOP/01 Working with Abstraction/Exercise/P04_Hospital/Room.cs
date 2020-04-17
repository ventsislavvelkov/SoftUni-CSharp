using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace P04_Hospital
{
    public class Room
    {
        private const int MAX_CAPACITY = 3;
        private readonly List<Patient> patients;

        public Room()
        {
            this.patients = new List<Patient>();
        }
        public Room(byte number)
        :this()
        {
            this.Number = number; 
        }
        public byte  Number { get; }

        public int Count => this.Patient.Count;

        public IReadOnlyCollection<Patient> Patient { get => this.patients;}

        public void AddPatient(Patient patient)
        {
            if (this.Count > MAX_CAPACITY)
            {
                this.patients.Add(patient);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var patient in patients)
            {
                sb.Append(patient.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
