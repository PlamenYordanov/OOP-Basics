using System;
using System.Collections.Generic;
using System.Linq;

public class CarSalesmanStartup
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var engines = new List<Engine>();
        var cars = new List<Car>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }
            , StringSplitOptions.RemoveEmptyEntries);
            var engineModel = input[0];
            var enginePower = int.Parse(input[1]);
            var engine = new Engine(engineModel, enginePower);

            for (int j = 2; j < input.Length; j++)
            {
                if (!int.TryParse(input[j], out int displacement))
                {
                    var efficiency = input[j];
                    engine.Efficiency = efficiency;
                    continue;
                }
                engine.Displacement = displacement.ToString();
            }

            engines.Add(engine);

        }
        int m = int.Parse(Console.ReadLine());

        for (int i = 0; i < m; i++)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }
            ,StringSplitOptions.RemoveEmptyEntries);
            var carModel = input[0];
            var engine = engines.SingleOrDefault(e => e.Model == input[1]);
            var car = new Car(carModel, engine);
            
            for (int j = 2; j < input.Length; j++)
            {
                if (!int.TryParse(input[j], out int weight))
                {
                    var color = input[j];
                    car.Color = color;
                    continue;
                }
                car.Weight = weight.ToString();
            }
            cars.Add(car);
        }
        cars.ForEach(x => Console.WriteLine(x));
    }
}

