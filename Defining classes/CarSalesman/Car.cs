using System;

public class Car
{
    public string Model { get; set; }

    public Engine Engine { get; set; }

    public string Weight { get; set; }

    public string Color { get; set; }

    public Car(string model, Engine engine, string weight = @"n/a", string color = @"n/a")
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = weight;
        this.Color = color;
    }
    public override string ToString()
    {
        var newLine = Environment.NewLine;
        return $@"{this.Model}:
{this.Engine}
  Weight: {this.Weight}
  Color: {this.Color}";
    }

}

