using System;
using System.Linq;

public class FootballTeamStartup
{
    public static void Main()
    {
        string input = string.Empty;
        var teams = new TeamCollection();

        while ((input = Console.ReadLine()) != "END")
        {
            var data = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            var command = data[0];
            var teamName = data[1];
            switch (command.ToLower())
            {
                case "team":
                    InsertTeam(teams, teamName);
                    break;
                case "add":
                    AddPlayerToTeam(teams, data, teamName);
                    break;
                case "remove":
                    RemovePlayer(teams, data, teamName);
                    break;
                case "rating":
                    DisplayRating(teams, teamName);
                    break;
                default:
                    break;
            }
        }
    }

    private static void DisplayRating(TeamCollection teams, string teamName)
    {
        var team = teams.SingleOrDefault(x => x.Name == teamName);
        bool isMissingTeam = team == null;
        Console.WriteLine(isMissingTeam ? $"Team {teamName} does not exist." : $"{team.Name} - {team.Rating:f0}");
    }

    private static void RemovePlayer(TeamCollection teams, string[] data, string teamName)
    {
        var playerName = data[2];
        var team = teams.SingleOrDefault(x => x.Name == teamName);
        var player = new Player(playerName);
        team.Remove(player);
    }

    private static void AddPlayerToTeam(TeamCollection teams, string[] data, string teamName)
    {
        var team = teams.SingleOrDefault(x => x.Name.Equals(teamName));
        if (team == null)
        {
            Console.WriteLine($"Team {teamName} does not exist.");
            return;
        }
        var playerName = data[2];
        var endurance = int.Parse(data[3]);
        var spirit = int.Parse(data[4]);
        var dribble = int.Parse(data[5]);
        var passing = int.Parse(data[6]);
        var shooting = int.Parse(data[7]);
        var player = new Player(playerName, endurance, spirit, dribble, passing, shooting);
        if (!player.IsValid())
        {
            return;
        }
        team.Add(player);

    }

    private static void InsertTeam(TeamCollection teams, string teamName)
    {
        var team = new Team(teamName);
        if (team.Name == null)
        {
            return;
        }
        teams.AddTeam(team);
    }
}

