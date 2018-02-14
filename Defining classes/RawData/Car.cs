using System.Collections.Generic;

public class Car
{
    public string Model { get; set; }
    public Engine Engine { get; set; }
    public Cargo Cargo { get; set; }
    public ICollection<Tire> Tires { get; set; } = new List<Tire>();
    public Car(string model, Engine engine, Cargo cargo, List<Tire> tires)
    {
        this.Model = model;
        this.Engine = engine;
        this.Cargo = cargo;
        this.Tires = tires;
    }
}

