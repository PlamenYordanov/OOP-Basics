﻿public class AggressiveDriver : Driver
{
    public AggressiveDriver(string name, Car car) 
        : base(name, car)
    {
        FuelConsumptionPerKm = 2.7;
    }
    public override double Speed => base.Speed * 1.3;

    public override int OvertakeInterval()
    {
        if (Car.Tyre.Name == "Ultrasoft")
        {
            return 3;
        }
        return base.OvertakeInterval();
    }
}

