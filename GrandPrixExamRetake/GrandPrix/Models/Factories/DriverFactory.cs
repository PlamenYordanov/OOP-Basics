using System.Collections.Generic;

public class DriverFactory
{
    public static Driver CreateDriver(List<string> args)
    {
        var type = args[0];
        var name = args[1];
        var hp = int.Parse(args[2]);
        var fuelAmount = double.Parse(args[3]);
        var tyre = TyreFactory.CreateTyre(args);
        var car = new Car(hp, fuelAmount, tyre);

        switch (type)
        {
            case "Aggressive":
                return new AggressiveDriver(name, car);
            default:
                return new EnduranceDriver(name, car);
        }
    }
}

