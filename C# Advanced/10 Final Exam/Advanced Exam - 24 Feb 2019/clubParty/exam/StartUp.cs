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
            var hall = new Queue<string>();
            var reservation = new List<int>();

            while (input.Any())
            {
                var curChar = input.Peek();

                var curReservation = 0;

                var isNumber = int.TryParse(curChar, out curReservation);

                if (!isNumber)
                {
                    hall.Enqueue(curChar);
                    input.Pop();
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

                            if (sumOfReservation + curReservation <= capacity)
                            {
                                reservation.Add(curReservation);
                                input.Pop();
                            }
                            else
                            {
                                Console.WriteLine($"{hall.Dequeue()} -> {string.Join(", ", reservation)}");
                                reservation.Clear();
                            }
                        }
                        else
                        {
                            reservation.Add(curReservation);
                            input.Pop();
                        }
                    }
                    else
                    {
                        input.Pop();
                    }
                }
            }
        }
    }
}
