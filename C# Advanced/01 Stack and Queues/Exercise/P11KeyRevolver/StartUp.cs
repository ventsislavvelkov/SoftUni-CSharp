using System;
using System.Collections.Generic;
using System.Linq;

namespace P11KeyRevolver
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var oneBulletPrice = int.Parse(Console.ReadLine());
            var gunBarrelSize = int.Parse(Console.ReadLine());
            var allBullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var allLocks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var intelligence = int.Parse(Console.ReadLine());

            var bullets = new Stack<int>(allBullets);
            var locks = new Queue<int>(allLocks);

            var bulletCounter = 0;
            var earnedMoney = 0;
            var shootCounter = 0;

            while (bullets.Count > 0 || locks.Count > 0)
            {


                if (bullets.Peek() <= locks.Peek())
                {
                    shootCounter++;
                    Console.WriteLine($"Bang!");
                    locks.Dequeue();
                    bullets.Pop();
                    bulletCounter++;
                }
                else
                {
                    shootCounter++;
                    Console.WriteLine($"Ping!");
                    bullets.Pop();
                    bulletCounter++;
                }
                if (shootCounter == gunBarrelSize && bullets.Count > 0)
                {
                    Console.WriteLine($"Reloading!");
                    shootCounter = 0;
                }
                if (bullets.Count >= 0 && locks.Count == 0)
                {
                    earnedMoney = intelligence - (bulletCounter * oneBulletPrice);
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${earnedMoney}");
                    return;

                }
                else if (locks.Any() && bullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    return;
                }

            }
        }
    }
}
