public class Car
{
    public string Model { get; set; }
    public double FuelAmmount { get; set; }
    public double Consumption { get; set; }
    public double DistanceTravelled { get; set; } = 0;

    public Car(string model, double fuelAmmount, double consumption)
    {
        this.Model = model;
        this.FuelAmmount = fuelAmmount;
        this.Consumption = consumption;

    }
    public void Drive(double distance)
    {
        var fuelForTrip = this.Consumption * distance;
        if (fuelForTrip <= this.FuelAmmount)
        {
            this.FuelAmmount -= fuelForTrip;
            this.DistanceTravelled += distance;
        }
        else
        {
            System.Console.WriteLine($"Insufficient fuel for the drive");
        }
    }
    public override string ToString()
    {
        return $"{this.Model} {this.FuelAmmount:f2} {this.DistanceTravelled:f0}";
    }
}

