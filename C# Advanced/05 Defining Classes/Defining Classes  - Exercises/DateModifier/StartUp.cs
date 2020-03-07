using System;

namespace DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var firstDate = Console.ReadLine();
            var secondDate = Console.ReadLine();

            DateModifier  date = new DateModifier();

            Console.WriteLine(date.GetDifferenceInDays(firstDate,secondDate));
        }
    }
}
