using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private List<Harvester> harvesters = new List<Harvester>();
    private List<Provider> providers = new List<Provider>();
    private string mode = "Full";
    private double totalStoredEnergy;
    private double totalMinedOre;

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            var harvester = HarvesterFactory.CreateHarvester(arguments);
            harvesters.Add(harvester);
            return $"Successfully registered {arguments[0]} Harvester - {arguments[1]}";
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }
    }
    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            var provider = ProviderFactory.CreateProvider(arguments);
            providers.Add(provider);
            return $"Successfully registered {arguments[0]} Provider - {arguments[1]}";
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }
    }
    public string Day()
    {
        var providedEnergy = providers.Sum(x => x.EnergyOutput);
        var providedOre = harvesters.Sum(x => x.OreOutput);
        totalStoredEnergy += providedEnergy;
        var allHarvesterEnergy = GetCurrentHarvesterEnergy(harvesters, mode, ref providedOre);

        if (allHarvesterEnergy <= totalStoredEnergy)
        {
            totalStoredEnergy -= allHarvesterEnergy;
            totalMinedOre += providedOre;
        }
        else
        {
            providedOre = 0;
        }
        var sb = new StringBuilder();
        sb.AppendLine("A day has passed.");
        sb.AppendLine($"Energy Provided: {providedEnergy}");
        sb.AppendLine($"Plumbus Ore Mined: {providedOre}");
        return sb.ToString().TrimEnd();

    }
    public string Mode(List<string> arguments)
    {
        var newMode = arguments[0];
        mode = newMode;
        return $"Successfully changed working mode to {newMode} Mode";
    }
    public string Check(List<string> arguments)
    {
        string id = arguments[0];

        if (harvesters.Any(x => x.Id == id))
        {
            var currentHarvester = harvesters.SingleOrDefault(x => x.Id == id);
            return currentHarvester.ToString();
        }

        else if (providers.Any(x => x.Id == id))
        {
            var currentProvider = providers.SingleOrDefault(x => x.Id == id);
            return currentProvider.ToString();
        }

        return $"No element found with id – {id}";
    }
    public string ShutDown()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"System Shutdown");
        sb.AppendLine($"Total Energy Stored: {totalStoredEnergy}");
        sb.AppendLine($"Total Mined Plumbus Ore: {totalMinedOre}");
        return sb.ToString().TrimEnd();
    }
    private double GetCurrentHarvesterEnergy(List<Harvester> harvesters, string mode, ref double providedOre)
    {
        var allHarvesterEnergy = harvesters.Sum(x => x.EnergyRequirement);

        switch (mode.ToLower())
        {
            case "full":
                break;
            case "half":
                allHarvesterEnergy *= 0.6;
                providedOre *= 0.5;
                break;
            default:
                allHarvesterEnergy = 0;
                providedOre = 0;
                break;
        }
        return allHarvesterEnergy;
    }
}
