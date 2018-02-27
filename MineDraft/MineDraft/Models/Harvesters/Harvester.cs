using System;
using System.Text;

public abstract class Harvester : INamable
{
    private string id;
    private double oreOutput;
    private double energyRequirement;
    private const string ErrorMessage = "Harvester is not registered, because of it's {0}";
    public string Id
    {
        get { return id; }
        protected set
        {
            id = value;
        }
    }
    public double OreOutput
    {
        get { return oreOutput; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException(string.Format(ErrorMessage, nameof(OreOutput)));
            }
            oreOutput = value;
        }
    }
    public double EnergyRequirement
    {
        get { return energyRequirement; }
        protected set
        {
            if (value < 0 || value > 20000)
            {
                throw new ArgumentException(string.Format(ErrorMessage, nameof(EnergyRequirement)));
            }
            energyRequirement = value;
        }
    }
    public Harvester(string id, double oreOutput, double energyRequirement)
    {
        Id = id;
        OreOutput = oreOutput;
        EnergyRequirement = energyRequirement;
    }
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Harvester - {Id}");
        sb.AppendLine($"Ore Output: {OreOutput}");
        sb.AppendLine($"Energy Requirement: {EnergyRequirement}");
        return sb.ToString().Trim();
    }
}

