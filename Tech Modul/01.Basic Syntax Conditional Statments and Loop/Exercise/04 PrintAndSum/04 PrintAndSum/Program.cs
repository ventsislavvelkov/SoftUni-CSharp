using System;

namespace _04_PrintAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int stop =  int.Parse(Console.ReadLine());

            int sum = 0;
            string allNumbers = "";

            for (int i = start; i <= stop; i++)
            {
                allNumbers += i + " "; 
                sum += i;
            }
            Console.WriteLine(  allNumbers);
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
