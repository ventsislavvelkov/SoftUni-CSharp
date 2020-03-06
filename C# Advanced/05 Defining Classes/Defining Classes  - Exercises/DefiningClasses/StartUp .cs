using System;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var name = "Pesho";
            var age = 24;

            Person person = new Person()
            {
                Name = name,
                Age = age
            };


           Console.WriteLine($"{person.Name} -> {person.Age}");
        }
    }
}
