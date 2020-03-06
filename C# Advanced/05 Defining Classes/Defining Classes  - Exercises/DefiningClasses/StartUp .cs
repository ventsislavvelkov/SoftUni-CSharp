using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var name = "Pesho";
            var age = 24;

            Person person = new Person()
            {
                Name = "Pesho",
                Age = 20
            };


            Console.WriteLine($"{person.Name} -> {person.Age}");
        }
    }
}
