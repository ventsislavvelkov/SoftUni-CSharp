using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var firstInput = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var secondInput = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var queen = new Queue<int>(firstInput);
            var stack = new Stack<int>(secondInput);


            var daturaBombs = 40;
            var cherryBombs = 60;
            var smokeDecoyBombs = 120;
            var counterDaturaBombs = 0;
            var counterCherryBombs = 0;
            var counterSmokeDecoyBombs = 0;
            var isWinner = false;

            while (stack.Any() && queen.Any())
            {
                var bombEffect = queen.Peek();
                var bombCasing = stack.Peek();

                if (bombEffect + bombCasing == daturaBombs)
                {
                    counterDaturaBombs++;
                    stack.Pop();
                    queen.Dequeue();

                }
                else if (bombEffect + bombCasing == cherryBombs)
                {
                    counterCherryBombs++;
                    stack.Pop();
                    queen.Dequeue();
                }
                else if (bombEffect + bombCasing == smokeDecoyBombs)
                {
                    counterSmokeDecoyBombs++;
                    stack.Pop();
                    queen.Dequeue();
                }
                else
                {
                    stack.Pop();
                    if (bombCasing - 5 >= 0)
                    {
                        stack.Push(bombCasing - 5);
                    }

                }

                if (counterCherryBombs >= 3 && counterDaturaBombs >= 3 && counterSmokeDecoyBombs >= 3)
                {
                    isWinner = true;
                    break;
                }

            }

            if (isWinner)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (queen.Any())
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", queen)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }


            if (stack.Any())
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", stack)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }




            Console.WriteLine($"Cherry Bombs: {counterCherryBombs}");
            Console.WriteLine($"Datura Bombs: {counterDaturaBombs}");
            Console.WriteLine($"Smoke Decoy Bombs: {counterSmokeDecoyBombs}");


        }
    }
}
