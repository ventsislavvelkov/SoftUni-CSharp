using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raiding.Contracts;

namespace Raiding.Core
{
    public class Engine
    {
        private HeroFactory heroFactory;
        private readonly ICollection<IHero> heroes;

        public Engine()
        {
            this.heroFactory = new HeroFactory();
            this.heroes = new List<IHero>();
        }

        public void Run()
        {
            var numberOfNeededHeroes = int.Parse(Console.ReadLine());
            var counterOfHeroes = 0;

            while (counterOfHeroes != numberOfNeededHeroes)
            {

                var name = Console.ReadLine();
                var type = Console.ReadLine();

                try
                {
                    var hero = this.heroFactory.ProduceHero(name, type);
                    heroes.Add(hero);
                    counterOfHeroes++;
                }
                catch (ArgumentException msg)
                {
                    Console.WriteLine(msg.Message);
                }
            }

            var bossPower = int.Parse(Console.ReadLine());
            var sumOfPowers = 0;
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                sumOfPowers += hero.Power;
            }
            if (sumOfPowers >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
