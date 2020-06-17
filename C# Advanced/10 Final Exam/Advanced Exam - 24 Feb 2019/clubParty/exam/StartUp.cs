using System;
using System.Collections.Generic;
using System.Linq;

namespace exam
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var capacity = int.Parse(Console.ReadLine());
            var consoleInput = Console.ReadLine().Split();
            var input = new Stack<string>(consoleInput);
            var hall = new Queue<char>();
            var reservation = new List<int>();

            while (input.Any())
            {
                var currChar = char.Parse(input.Pop());

                if (char.IsLetter(currChar))
                {
                    hall.Enqueue(currChar);
                }
                else
                {
                    if (hall.Any())
                    {
                        var sumOfReservation = 0;
                       
                        if (reservation.Any())
                        {
                            foreach (var r in reservation)
                            {
                                sumOfReservation += r;
                            }

                            if (sumOfReservation < capacity)
                            {
                                reservation.Add(currChar);
                            }
                            else
                            {
                                Console.WriteLine($"{hall.Dequeue()} -> {string.Join(", ", reservation)}");
                                reservation.Clear();
                            }
                        }


                    }
                }
            }



        }
    }
}
