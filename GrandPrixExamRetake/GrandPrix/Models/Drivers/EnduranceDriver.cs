public class EnduranceDriver : Driver
{
    public EnduranceDriver(string name, Car car)
        : base(name, car)
    {
        FuelConsumptionPerKm = 1.5;
    }

}

