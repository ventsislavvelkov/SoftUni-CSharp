using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private const string ERROR_MESSAGE = "Invalid input!";
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get => this.name;


            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ERROR_MESSAGE);
                }

                this.name = value;
            }
        }

        public int Age
        {
            get => this.age;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ERROR_MESSAGE);
                }

                this.age = value;
            }
        }

        public string Gender
        {
            get => this.gender;
            private set
            {
                if (value != "Male" && value != "Female")
                {
                    throw new ArgumentException(ERROR_MESSAGE);
                }

                this.gender = value;
            }

        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"{this.GetType().Name}")
                .AppendLine($"{this.Name} {this.Age} {this.Gender}")
                .AppendLine($"{this.ProduceSound()}");
           
            return sb.ToString().TrimEnd();
        }
    }
}
