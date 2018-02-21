using System;
using System.Collections.Generic;
using System.Linq;

public class Team : INamable
{
    private string name;

    private List<Player> players;

    public string Name
    {
        get { return this.name; }

        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("A name should not be empty.");
                return;
            }
            this.name = value;
        }
    }
    public Team(string name)
    {
        Name = name;
        players = new List<Player>();
    }

    public double Rating => players.Any()? this.players.Average(x => x.Stats) : 0;
    
    public void Add(Player player)
    {
        players.Add(player);
    }
    public void Remove(Player player)
    {
        if (!players.Any(x => x.Name == player.Name))
        {
            Console.WriteLine($"Player {player.Name} is not in {this.Name} team.");
            return;
        }
        var playerToRemove = players.SingleOrDefault(x => x.Name == player.Name);

        players.Remove(playerToRemove);
    }
    
}

