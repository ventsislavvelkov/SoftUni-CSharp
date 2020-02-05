using System;
using System.Dynamic;
using System.Linq;

namespace _05BombNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToList();

            var specialBomb = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            var specialNumber = specialBomb[0];
            var lenght = specialBomb[1];
            var count = lenght;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (specialNumber == numbers[i])
                {
                    while (count > 0)
                    {
                        if (i - count >= 0 && i - count < numbers.Count)
                        {
                            numbers.RemoveAt(i - count);
   
                            i--;
                        }

                        count--;
                    }

                    count = lenght;

                    while (count > 0)
                    {
                        if (i + count >= 0 && i + count < numbers.Count)
                        {
                            numbers.RemoveAt(i + count);
                        }

                        count--;
                    }

                    numbers.RemoveAt(i);
                }

                count = lenght;
            }

            var sum = 0;

            foreach (var num in numbers)
            {
                sum += num;
            }

            Console.WriteLine(sum);
        }
    }
}
