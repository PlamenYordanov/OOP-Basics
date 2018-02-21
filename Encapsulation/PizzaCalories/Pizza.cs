using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    private string name;
    private List<Topping> toppings;
    private Dough dough;

    public Pizza(string name, Dough dough)
    {
        this.Name = name;
        this.Dough = dough;
        this.toppings = new List<Topping>();
    }

    public string Name
    {
        get { return this.name; }
        private set
        {
            if (string.IsNullOrEmpty(value) || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            this.name = value;
        }
    }
    public List<Topping> Toppings
    {
        get { return this.toppings; }
    }
    public Dough Dough
    {
        get { return this.dough; }
        set { this.dough = value; }
    }
    public void AddTopping(Topping topping)
    {
        if(this.toppings.Count() > 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
        this.toppings.Add(topping);
    }
    public double TotalCalories()
    {
        var doughCalories = this.dough.WeightInGrams * this.dough.CaloriesPerGram();
        var toppingCalories = this.toppings.Sum(x => x.CaloriesPerGram() * x.WeightInGrams);
        var totalCalories = doughCalories + toppingCalories;
        return totalCalories;
    }
    public override string ToString()
    {
        return $"{this.name} - {this.TotalCalories():f2} Calories.";
    }
}

