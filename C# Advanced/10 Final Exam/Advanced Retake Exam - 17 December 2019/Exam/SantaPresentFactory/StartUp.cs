using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace SantaPresentFactory
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var materials = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var magic = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var stack = new Stack<int>();
            var queen = new Queue<int>();

            var doll = 150;
            var dollCounter = 0;
            var woodenTrain = 250;
            var woodenTrainCounter = 0;
            var teddyBear = 300;
            var teddyBearCounter = 0;
            var bicycle = 400;
            var bicyclyCounter = 0;

            foreach (var t in materials)
            {
                stack.Push(t);
            }

            foreach (var t in magic)
            {
                queen.Enqueue(t);
            }

            while (stack.Count != 0 && queen.Count != 0)
            {
                var currMaterial = stack.Peek();
                var currMegic = queen.Peek();

                if (currMegic == 0)
                {
                    queen.Dequeue();
                    if (queen.Count > 0)
                    {
                        currMegic = queen.Peek();
                    }
                    else
                    {
                        break;
                    }
                }

                if (currMaterial == 0)
                {
                    stack.Pop();
                    if (stack.Count > 0)
                    {
                        currMaterial = stack.Peek();
                    }
                    else
                    {
                        break;
                    }
                }

                var currentMultiplication = currMegic * currMaterial;

                if (currentMultiplication < 0)
                {
                    var currSum = currMegic + currMaterial;
                    queen.Dequeue();
                    stack.Pop();
                    stack.Push(currSum);
                }
                else
                {
                    if (currentMultiplication == doll)
                    {
                        dollCounter++;
                        stack.Pop();
                        queen.Dequeue();
                    }
                    else if (currentMultiplication == woodenTrain)
                    {
                        woodenTrainCounter++;
                        stack.Pop();
                        queen.Dequeue();
                    }
                    else if (currentMultiplication == teddyBear)
                    {
                        teddyBearCounter++;
                        stack.Pop();
                        queen.Dequeue();
                    }
                    else if (currentMultiplication == bicycle)
                    {
                        bicyclyCounter++;
                        stack.Pop();
                        queen.Dequeue();
                    }
                    else
                    {
                        queen.Dequeue();
                        stack.Pop();
                        currMaterial += 15;
                        stack.Push(currMaterial);
                    }
                }

            }

            if (dollCounter >0 && woodenTrainCounter > 0 || teddyBearCounter > 0 && bicyclyCounter > 0)
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }

            if (stack.Count > 0)
            {
                Console.WriteLine($"Materials left: {string.Join(", ", stack)}");
            }
            if (queen.Count > 0)
            {
                Console.WriteLine($"Magic left: {string.Join(", ", queen)}");
            }

            if (bicyclyCounter > 0)
            {
                Console.WriteLine($"Bicycle: {bicyclyCounter}");
            }

            if (dollCounter > 0)
            {
                Console.WriteLine($"Doll: {dollCounter}");
            }

            if (teddyBearCounter > 0)
            {
                Console.WriteLine($"Teddy bear: {teddyBearCounter}");
            }

            if (woodenTrainCounter > 0)
            {
                Console.WriteLine($"Wooden train: {woodenTrainCounter}");
            }

        
       
        }
    }
}
