using System;

namespace _03Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            int courses = 0;
            
            if (numberOfPeople == capacity || numberOfPeople % capacity == 0)
            {
                courses = (numberOfPeople / capacity);
            }
            else
            {
                courses = (numberOfPeople / capacity) +1;
            }
           

            Console.WriteLine(courses);
        }
    }
}
