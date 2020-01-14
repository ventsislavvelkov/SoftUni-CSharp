using System;

namespace _04BackIn30Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minuts = int.Parse(Console.ReadLine());
            int halfHour = 30;

            minuts += halfHour;

            if (minuts > 60)
            {
                minuts -= 60;
                hours += 1;
            }
            if (hours > 23 )
            {
                hours = 0;
            }
            Console.WriteLine($"{hours}:{minuts:D2}");
        }
    }
}
