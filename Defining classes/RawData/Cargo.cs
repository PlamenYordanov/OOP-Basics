using System;

public class Cargo
{
    public double Weight { get; set; }
    public CarType Type { get; set; }
    public Cargo(double weight, string type)
    {
        this.Weight = weight;
        this.Type = (CarType)Enum.Parse(typeof(CarType), type);
    }
}

public enum CarType
{
    fragile,
    flamable
}