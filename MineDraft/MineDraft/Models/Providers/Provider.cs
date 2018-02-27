using System;
using System.Text;

public abstract class Provider : INamable
{
    private string id;
    private double energyOutput;
    private const string ErrorMessage = "Provider is not registered, because of it's {0}";

    public string Id
    {
        get { return id; }
        protected set { id = value; }
    }
    public double EnergyOutput
    {
        get { return energyOutput; }
        protected set
        {
            if (value < 0 || value > 10000)
            {
                throw new ArgumentException(string.Format(ErrorMessage, nameof(EnergyOutput)));
            }
            energyOutput = value;
        }
    }
    public Provider(string id, double energyOutput)
    {
        Id = id;
        EnergyOutput = energyOutput;
    }
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Provider - {Id}");
        sb.AppendLine($"Energy Output: {EnergyOutput}");

        return sb.ToString().Trim();
    }
}

