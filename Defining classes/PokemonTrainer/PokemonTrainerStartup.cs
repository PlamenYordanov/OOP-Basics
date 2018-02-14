using System;
using System.Collections.Generic;
using System.Linq;

public class PokemonTrainerStartup
{
    public static void Main()
    {
        string input = string.Empty;
        var trainers = new List<Trainer>();
        while ((input = Console.ReadLine()) != "Tournament")
        {
            var data = input.Split(new[] { ' ' }
            , StringSplitOptions.RemoveEmptyEntries);

            var trainerName = data[0];

            if (!trainers.Any(t => t.Name == trainerName))
            {
                var tempTrainer = new Trainer(trainerName);
                trainers.Add(tempTrainer);
            }

            var trainer = trainers.SingleOrDefault(t => t.Name == trainerName);

            AddPokemonToTrainer(data, trainer);
        }

        while ((input = Console.ReadLine()) != "End")
        {
            var element = input;

            foreach (var trainer in trainers)
            {
                if (!trainer.Pokemons.Any(p => p.Element == element))
                {
                    trainer.ReducePokemonsHealth();
                    continue;
                }
                trainer.AddBadge();
            }
        }
        trainers.OrderByDescending(t => t.GetBadgeCount).ToList().ForEach(x => Console.WriteLine(x));
    }

    private static void AddPokemonToTrainer(string[] data, Trainer trainer)
    {
        var pokemonName = data[1];
        var element = data[2];
        var health = int.Parse(data[3]);
        var pokemon = new Pokemon(pokemonName, element, health);
        trainer.AddPokemon(pokemon);
    }
}

