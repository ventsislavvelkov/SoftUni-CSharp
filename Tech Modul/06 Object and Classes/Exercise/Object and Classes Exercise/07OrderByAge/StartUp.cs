using System;
using System.Collections.Generic;
using System.Linq;

namespace _07OrderByAge
{
    class StartUp
    {
        static void Main(string[] args)
        { 
            var people = new List<People>();

            while (true)
            {
                var input = Console.ReadLine().Split();
                var name = input[0];

                if (name == "End")
                {
                    break;
                }
                else
                {
                    var id = input[1];
                    var age = int.Parse(input[2]);

                    people.Add(new People(name,id,age));
                }
            }

            Console.WriteLine(string.Join(" ", people.OrderBy(x=>x.Age)));
        }
    }

    class People
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }

        public People(string name, string id, int age)
        {
            this.Name = name;
            this.Id = id;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"{Name} with ID: {Id} is {Age} years old.{Environment.NewLine}";
        }
    }
}
