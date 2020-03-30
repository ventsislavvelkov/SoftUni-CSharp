using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main()
        {
            var pokemonTrainer = new List<Trainers>();
            var input = string.Empty;

            while ((input = Console.ReadLine()) != "Tournament")
            {
                var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                var trainerName = tokens[0];
                var pokemonName = tokens[1];
                var pokemonElement = tokens[2];
                var pokemonHealth = int.Parse(tokens[3]);

                if (!pokemonTrainer.Any(t=>t.Name == trainerName))
                {
                    pokemonTrainer.Add(new Trainers(trainerName));
                }

                var trainer = pokemonTrainer.First(t => t.Name == trainerName);
                trainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
            }

            input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                foreach (var trainer in pokemonTrainer)
                {
                    if (trainer.Pokemons.Any(t=>t.Element == input))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        trainer.Pokemons.ForEach(t => t.Health -= 10);
                    }

                    trainer.Pokemons = trainer.Pokemons.Where(p => p.Health > 0).ToList();
                }
                
            }

            var filterTrainers = pokemonTrainer.OrderByDescending(x => x.NumberOfBadges).ToList();

            foreach (var trainers in filterTrainers)
            {
                Console.WriteLine(trainers);
            }

        }
    }
}
