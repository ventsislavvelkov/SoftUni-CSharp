using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private Dictionary<string, List<Car>> cars;

        private int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new Dictionary<string, List<Car>>(this.capacity);
        }

        public int Count => this.cars.Count;

        public string AddCar(Car car)
        {
            var message = string.Empty;

            if (this.cars.ContainsKey(car.RegistrationNumber))
            {
                message = "Car with that registration number, already exists!";
            }
            else if (this.Count >= capacity)
            {
                message = "Parking is full!";
            }
            else
            {
                this.cars.Add(car.RegistrationNumber, new List<Car>());
                this.cars[car.RegistrationNumber].Add(car);

                message = $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }

            return message;
        }

        public string RemoveCar(string registrationNumber)
        {
            var message = string.Empty;

            if (!this.cars.ContainsKey(registrationNumber))
            {
                message = "Car with that registration number, doesn't exist!";
            }
            else
            {
                this.cars.Remove(registrationNumber);

                message = $"Successfully removed {registrationNumber}";
            }

            return message;
        }

        public Car GetCar(string registrationNumber)
        {
            var foundCar = this.cars[registrationNumber]
                .FirstOrDefault(x => x.RegistrationNumber == registrationNumber);

            return foundCar;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var regNumber in registrationNumbers)
            {
                if (this.cars.ContainsKey(regNumber))
                {
                    this.cars.Remove(regNumber);
                }
            }
        }

    }
}
