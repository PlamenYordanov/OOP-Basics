using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private List<Driver> drivers = new List<Driver>();
    private List<Driver> removedDrivers = new List<Driver>();
    private Weather weather = Weather.Sunny;
    private int completedLaps = 0;

    public int TrackLength { get; private set; }

    public int LapsNumber { get; private set; }

    public int CompletedLaps { get => completedLaps; }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        LapsNumber = lapsNumber;
        TrackLength = trackLength;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            var driver = DriverFactory.CreateDriver(commandArgs);
            drivers.Add(driver);
        }
        catch (ArgumentException)
        { }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        var reason = commandArgs[0];
        var driverName = commandArgs[1];
        var driver = drivers.SingleOrDefault(x => x.Name == driverName);
        driver.Box();
        switch (reason)
        {
            case "Refuel":
                var fuelAmount = double.Parse(commandArgs[2]);
                driver.Refuel(fuelAmount);
                break;
            case "ChangeTyres":
                commandArgs.Insert(0, "");
                commandArgs.Insert(0, "");
                var tyre = TyreFactory.CreateTyre(commandArgs);
                driver.ChangeTyres(tyre);
                break;
            default:
                break;
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        try
        {
            var lapsToComplete = int.Parse(commandArgs[0]);

            if (lapsToComplete + completedLaps > LapsNumber)
            {
                throw new ArgumentException($"There is no time! On lap {completedLaps}.");
            }

            for (int lap = 0; lap < lapsToComplete; lap++)
            {
                UpdateDriverTimes(TrackLength);
                foreach (var driver in drivers)
                {
                    try
                    {
                        driver.ReduceFuelAmount(TrackLength);
                        driver.Car.Tyre.Degrade();
                    }
                    catch (Exception e)
                    {
                        driver.CrashReason = e.Message;
                        removedDrivers.Add(driver);
                    }
                }

                Overtake(drivers);
                removedDrivers.AddRange(drivers.Where(x => x.CrashReason == "Crashed"));
                drivers.RemoveAll(d => removedDrivers.Contains(d));
                completedLaps++;
            }
            return "";
        }
        catch (ArgumentException e)
        {
            return e.Message;
        }
    }

    private void UpdateDriverTimes(int trackLength)
    {
        foreach (var driver in drivers)
        {
            driver.UpdateTotalTime(trackLength);
        }
    }

    public string GetLeaderboard()
    {

        var sb = new StringBuilder();
        sb.AppendLine($"Lap {completedLaps}/{LapsNumber}");
        int position = 1;
        foreach (var driver in drivers.OrderBy(x => x.TotalTime))
        {
            sb.AppendLine($"{position} {driver.Name} {driver.TotalTime:f3}");
            position++;
        }
        removedDrivers.Reverse();
        foreach (var driver in removedDrivers)
        {
            sb.AppendLine($"{position} {driver.Name} {driver.CrashReason}");
            position++;
        }
        return sb.ToString().TrimEnd();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        var newWeather = (Weather)Enum.Parse(typeof(Weather), commandArgs[0]);
        weather = newWeather;
    }

    internal Driver GetWinner()
    {
        var winner = drivers.OrderBy(x => x.TotalTime).First();
        return winner;
    }

    private void Overtake(List<Driver> drivers)
    {
        var tempDrivers = drivers
            .OrderByDescending(x => x.TotalTime)
            .ToList();

        for (int i = 0; i < drivers.Count - 1; i++)
        {
            var leadDriver = tempDrivers[i + 1];
            var trailDriver = tempDrivers[i];
            if (trailDriver.TotalTime - leadDriver.TotalTime > trailDriver.OvertakeInterval())
            {
                continue;
            }

            if (trailDriver.FuelConsumptionPerKm == 2.7
                    && trailDriver.OvertakeInterval() == 3
                    && weather == Weather.Foggy)
            {
                trailDriver.CrashReason = "Crashed";
            }
            else if (trailDriver.FuelConsumptionPerKm == 1.5
                && trailDriver.OvertakeInterval() == 3
                 && weather == Weather.Rainy)
            {
                trailDriver.CrashReason = "Crashed";
            }
            else
            {
                trailDriver.TotalTime -= trailDriver.OvertakeInterval();
                leadDriver.TotalTime += trailDriver.OvertakeInterval();
                Console.WriteLine($"{trailDriver.Name} has overtaken {leadDriver.Name} on lap {completedLaps + 1}.");
                i++;
            }
        }
    }
}

