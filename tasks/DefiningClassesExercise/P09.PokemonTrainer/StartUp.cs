using System;
using System.Collections.Generic;
using System.Linq;

namespace P09.PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var trainers = new List<Trainer>();
            while (input != "Tournament")
            {
                CollectPokemons(input, trainers);
                input = Console.ReadLine();
            }
            var command = Console.ReadLine();
            while (command != "End")
            {
                Tournament(trainers, command);
                command = Console.ReadLine();
            }
            trainers = trainers.OrderByDescending(t => t.NumberOfBadges).ToList();
            Console.WriteLine(String.Join(Environment.NewLine, trainers));
        }

        public static void Tournament(List<Trainer> trainers, string command)
        {
            foreach (var tr in trainers)
            {
                if (tr.Pokemons.Any(p => p.Element == command))
                {
                    tr.NumberOfBadges++;
                }
                else
                {
                    tr.Pokemons.Select(p => p.Health -= 10).ToList();
                    tr.Pokemons = tr.Pokemons.Where(p => p.Health > 0).ToList();
                }
            }
        }

        public static void CollectPokemons(string input, List<Trainer> trainers)
        {
            var pokemonArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var trainerName = pokemonArgs[0];
            var pokemonName = pokemonArgs[1];
            var element = pokemonArgs[2];
            var health = int.Parse(pokemonArgs[3]);
            var pokemon = new Pokemon(pokemonName, element, health);
            if (trainers.Any(t => t.Name == trainerName))
            {
                trainers.First(t => t.Name == trainerName).Pokemons.Add(pokemon);
            }
            else
            {
                var trainer = new Trainer(trainerName);
                trainer.Pokemons.Add(pokemon);
                trainers.Add(trainer);
            }
        }
    }
}
