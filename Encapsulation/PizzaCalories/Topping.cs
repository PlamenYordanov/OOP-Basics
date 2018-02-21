using System.Linq;
using System;

public class Topping
{
    private string type;
    private double weightInGrams;
    private static readonly string[] types = { "meat", "veggies", "cheese", "sauce" };

    public Topping(string type, double weightInGrams)
    {
        this.Type = type;
        this.WeightInGrams = weightInGrams;
    }
    public string Type
    {
        get { return this.type; }
        private set
        {
            if (!types.Contains(value.ToLower()))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            this.type = value;
        }
    }
    public double WeightInGrams
    {
        get { return this.weightInGrams; }
        private set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{this.type} weight should be in the range [1..50].");
            }
            this.weightInGrams = value;
        }
    }
    public double CaloriesPerGram()
    {
        double calories = 2;
        switch (this.type.ToLower())
        {
            case "meat":
                calories *= 1.2;
                break;
            case "veggies":
                calories *= 0.8;
                break;
            case "cheese":
                calories *= 1.1;
                break;
            case "sauce":
                calories *= 0.9;
                break;
        }
        return calories;
    }
}

