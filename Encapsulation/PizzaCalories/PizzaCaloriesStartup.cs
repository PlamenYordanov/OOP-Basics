using System;
using System.Linq;

public class PizzaCaloriesStartup
{
    public static void Main()
    {
        try
        {
            var pizzaInput = Console.ReadLine().Split().Select(x => x.Trim()).ToArray();
            var doughInput = Console.ReadLine().Split().Select(x => x.Trim()).ToArray();
            string pizzaName = pizzaInput[1];
            string flourType = doughInput[1];
            string bakingTechnique = doughInput[2];
            double doughWeight = double.Parse(doughInput[3]);
            var pizza = new Pizza(pizzaName, new Dough(flourType, bakingTechnique, doughWeight));
            string toppingData = string.Empty;
            while ((toppingData = Console.ReadLine()) != "END")
            {
                var splitTopping = toppingData.Split().Select(x => x.Trim()).ToArray();
                string toppingType = splitTopping[1];
                double toppingWeight = double.Parse(splitTopping[2]);
                pizza.AddTopping(new Topping(toppingType, toppingWeight));
            }
            Console.WriteLine(pizza);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}

