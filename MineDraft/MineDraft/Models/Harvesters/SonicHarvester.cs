public class SonicHarvester : Harvester
{
    private int sonicFactor;

    public int SonicFactor
    {
        get { return sonicFactor; }
        set { sonicFactor = value; }
    }
    public SonicHarvester
        (string id, double oreOutput, double energyRequirement, int sonicFactor) 
        : base(id, oreOutput, energyRequirement / sonicFactor)
    {
        SonicFactor = sonicFactor;
    }
    public override string ToString()
    {
        return $"Sonic " + base.ToString();
    }
}

