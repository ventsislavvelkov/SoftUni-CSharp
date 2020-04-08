using System;

namespace Threeuple
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var first = Console.ReadLine().Split();
            var fullName = $"{first[0]} {first[1]}";
            var address = first[2];
            var town = first[3];

            var second = Console.ReadLine().Split();
            var nameSecond = second[0];
            var litresOfBeer = int.Parse(second[1]);
            var drink = second[2];

            var thurd = Console.ReadLine().Split();
            var nameThurd = thurd[0];
            var accountBalance = double.Parse(thurd[1]);
            var bankName = thurd[2];

            var firstThreeple = new Threeuple<string,string,string>(fullName,address,town);
            var secondThreeple = new Threeuple<string,int,string>(nameSecond,litresOfBeer,drink);
            var thurdThreeple = new Threeuple<string,double,string>(nameThurd,accountBalance,bankName);

            Console.WriteLine(firstThreeple);
            Console.WriteLine(secondThreeple);
            Console.WriteLine(thurdThreeple);
        }
    }
}
