using System;

public class Engine
{
    public string Model { get; set; }

    public int Power { get; set; }

    public string Displacement { get; set; }

    public string Efficiency { get; set; }

    public Engine(string model, int power, string displacement = "n/a", string efficiency = @"n/a")
    {
        this.Model = model;
        this.Power = power;
        this.Displacement = displacement;
        this.Efficiency = efficiency;
    }

    public override string ToString()
    {
        var newLine = Environment.NewLine;
        return $@"  {this.Model}:    
    Power: {this.Power}    
    Displacement: {this.Displacement}    
    Efficiency: {this.Efficiency}";
    }
}

