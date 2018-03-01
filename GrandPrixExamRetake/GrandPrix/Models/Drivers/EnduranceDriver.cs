public class EnduranceDriver : Driver
{
    public EnduranceDriver(string name, Car car)
        : base(name, car)
    {
        FuelConsumptionPerKm = 1.5;
    }
    public override int OvertakeInterval()
    {
        if (Car.Tyre.Name == "Hard")
        {
            return 3;
        }
        return base.OvertakeInterval();
    }
}

