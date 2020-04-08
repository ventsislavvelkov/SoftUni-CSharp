using System;

namespace Truple
{
    public class StartUp
    {
        static void Main()
        {
            var personInfo = Console.ReadLine().Split();
            var fullName = $"{personInfo[0]} {personInfo[1]}";
            var address = personInfo[2];

            var nameAndBeer = Console.ReadLine().Split();
            var name = nameAndBeer[0];
            var beerAmount = int.Parse(nameAndBeer[1]);

            var input = Console.ReadLine().Split();
            var firstArgument = int.Parse(input[0]);
            var secondArgument = double.Parse(input[1]);

            var first = new Truple<string,string>(fullName,address);
            var second = new Truple<string,int>(name,beerAmount);
            var thurd = new Truple<int,double>(firstArgument,secondArgument);

            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(thurd);
            

        }
    }
}
