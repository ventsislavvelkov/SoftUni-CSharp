using System;
using System.Collections.Generic;
using System.Linq;

namespace P01GenericBoxOfString
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var elements =  new List<double>();

            for (int i = 0; i < n; i++)
            {
                var input = double.Parse(Console.ReadLine());
                elements.Add(input);
            }

            var box = new Box<double>(elements);
            var element = double.Parse(Console.ReadLine());

           var countOfGreaterElements = box.CountElements(elements, element);
           Console.WriteLine(countOfGreaterElements);





        }
    }
}
