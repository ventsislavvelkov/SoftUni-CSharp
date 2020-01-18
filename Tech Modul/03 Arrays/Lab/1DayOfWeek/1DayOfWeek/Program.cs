using System;

namespace _1DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] dayOfWeek =
                            {
                             "Monday",
                             "Tuesday",
                             "Wednesday",
                             "Thursday",
                             "Friday",
                             "Saturday",
                             "Sunday"
                            };
            int n = int.Parse(Console.ReadLine());

            if (n > 0 && n < 8)
            {
                Console.WriteLine(dayOfWeek[n-1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}
