using System;
using System.Collections.Generic;
using System.Linq;

public class Trainer
{
    private string name;

    private int badges = 0;

    private List<Pokemon> pokemons = new List<Pokemon>();

    public string Name { get { return this.name; } }

    public ICollection<Pokemon> Pokemons { get { return this.pokemons; } } 

    public Trainer(string name)
    {
        this.name = name;
    }
    public void AddBadge()
    {
        this.badges++;
    }
    public int GetBadgeCount => this.badges;

    public void AddPokemon(Pokemon pokemon)
    {
        this.pokemons.Add(pokemon);
    }

    public  void ReducePokemonsHealth()
    {
        foreach (var pokemon in this.pokemons)
        {
            pokemon.Health -= 10;
        }
        RemoveDeadPokemon();
    }
    private void RemoveDeadPokemon()
    {
        this.pokemons.RemoveAll(p => p.Health <= 0);
    }
    public override string ToString()
    {
        return $"{this.Name} {this.badges} {this.Pokemons.Count}";
    }
}

