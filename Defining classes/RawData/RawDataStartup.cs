using System;
using System.Collections.Generic;
using System.Linq;

public class RawDataStartup
{
    public static void Main()
    {
        var cars = new List<Car>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split();
            var model = input[0];

            var engineSpeed = int.Parse(input[1]);
            var enginePower = int.Parse(input[2]);
            var engine = new Engine(engineSpeed, enginePower);

            var cargoWeight = double.Parse(input[3]);
            var cargoType = input[4];
            var cargo = new Cargo(cargoWeight, cargoType);

            var tires = new List<Tire>();
            GetTires(input, tires);

            var car = new Car(model, engine, cargo, tires);
            cars.Add(car);
        }
        string command = Console.ReadLine();
        switch (command)
        {
            case "fragile":
                PrintFragileCars(cars);
                break;
            case "flamable":
                PrintFlamableCars(cars);
                break;
            default:
                break;
        }
    }

    private static void PrintFlamableCars(List<Car> cars)
    {
        foreach (var car in cars.Where(c => c.Cargo.Type == CarType.flamable 
                                        && c.Engine.Power > 250))
        {
            Console.WriteLine(car.Model);
        }
    }

    private static void PrintFragileCars(List<Car> cars)
    {
        foreach (var car in cars.Where(c => c.Cargo.Type == CarType.fragile
                                        && c.Tires.Any(t => t.Pressure < 1)))
        {
            Console.WriteLine(car.Model);
        }
    }

    private static void GetTires(string[] input, List<Tire> tires)
    {
        for (int j = 5; j < input.Length; j += 2)
        {
            var tirePressure = double.Parse(input[j]);
            var tireAge = int.Parse(input[j + 1]);
            var tire = new Tire(tirePressure, tireAge);
            tires.Add(tire);
        }
    }
}

