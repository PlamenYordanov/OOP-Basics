using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        int lapsInRace = int.Parse(Console.ReadLine());
        int trackLength = int.Parse(Console.ReadLine());
        var raceTower = new RaceTower();
        raceTower.SetTrackInfo(lapsInRace, trackLength);

        while (raceTower.CompletedLaps != lapsInRace)
        {
            var input = Console.ReadLine().Split().ToList();
            var command = input[0];
            var args = input.Skip(1).ToList();
            switch (command)
            {
                case "RegisterDriver":
                    raceTower.RegisterDriver(args);
                    break;
                case "CompleteLaps":
                    var output = raceTower.CompleteLaps(args);
                    if (output != "")
                    {
                        Console.WriteLine(output);
                    }
                    break;
                case "Leaderboard":
                    Console.WriteLine(raceTower.GetLeaderboard());
                    break;
                case "Box":
                    raceTower.DriverBoxes(args);
                    break;
                case "ChangeWeather":
                    raceTower.ChangeWeather(args);
                    break;
                default:
                    break;
            }

        }
        var winner = raceTower.GetWinner();
        Console.WriteLine(winner);
    }
}

