using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    public class Doctor
    {
        private readonly List<Patient> patients;

        private Doctor()
        {
            this.patients = new List<Patient>();
        }
        public Doctor(string firstName, string lastName)
        :this()
        {
            this.FirstName = firstName;
            this.LastName = lastName;

        }

        public string FirstName { get; }
        public string LastName { get;  }

        public string FullName => this.FirstName + this.LastName;
        public IReadOnlyCollection<Patient> Patients => this.patients;

        public void AddPatientToDoctor(Patient patient)
        {
            this.patients.Add(patient);
        }
    }
}
