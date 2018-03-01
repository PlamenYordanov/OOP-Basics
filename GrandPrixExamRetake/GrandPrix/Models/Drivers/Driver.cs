using System;

public abstract class Driver
{
    private string name;
    private double totalTime;
    private Car car;
    private double fuelConsumptionPerKm;
    

    public Driver(string name, Car car)
    {
        Name = name;
        Car = car;
    }
    public virtual int OvertakeInterval() => 2;

    public string Name
    {
        get => name;
        protected set => name = value;
    }
    public double TotalTime
    {
        get =>totalTime;
        internal set => totalTime = value;
    }
    public double FuelConsumptionPerKm
    {
        get => fuelConsumptionPerKm;
        protected set => fuelConsumptionPerKm = value;
    }
    public virtual double Speed => ((Car.Hp + Car.Tyre.Degradation) / car.FuelAmount);
    
    public Car Car
    {
        get => car;
        protected set => car = value;
    }
    public void UpdateTotalTime(int trackLength)
    {
        TotalTime +=  60 / (trackLength / Speed);
    }
    public void ReduceFuelAmount(int trackLength)
    {
        Car.FuelAmount -= trackLength * FuelConsumptionPerKm;
    }

    public string CrashReason { get; set; } = null;

    public override string ToString()
    {
        return $"{Name} wins the race for {TotalTime:f3} seconds.";
    }
    public void Refuel(double fuelAmount)
    {
        car.FuelAmount += fuelAmount;
    }
    public void Box()
    {
        TotalTime += 20;
    }
    public void ChangeTyres(Tyre tyre)
    {
        Car.Tyre = tyre;
    }
}

