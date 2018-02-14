using System;
using System.Collections.Generic;
using System.Linq;

public class SpeedRacingStartup
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var cars = new List<Car>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split();

            var model = input[0];
            var fuelAmmount = double.Parse(input[1]);
            var consumption = double.Parse(input[2]);
            var car = new Car(model, fuelAmmount, consumption);
            cars.Add(car);
        }
        string command = string.Empty;
        while ((command = Console.ReadLine()) != "End")
        {
            var carInput = command.Split();
            var model = carInput[1];
            var distance = double.Parse(carInput[2]);
            var car = cars.SingleOrDefault(c => c.Model.Equals(model));
            car.Drive(distance);
        }
        PrintCars(cars);
    }
    public static void PrintCars(List<Car> cars)
    {
        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }
}

