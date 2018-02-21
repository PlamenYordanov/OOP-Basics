using System;
using System.Linq;

public class Dough
{
    private string flourType;
    private string bakingTechnique;
    private double weightInGrams;
    private static readonly string[] types = { "white", "wholegrain" };
    private static readonly string[] techniques = { "crispy", "chewy", "homemade" };

    public Dough(string flourType, string bakingTechnique, double weightInGrams)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.WeightInGrams = weightInGrams;
    }
    
    public string FlourType
    {
        get { return this.flourType; }
        private set
        {
            if(!types.Contains(value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            this.flourType = value;
        }
    }
    public string BakingTechnique
    {
        get { return this.bakingTechnique; }
        private set
        {
            if (!techniques.Contains(value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            this.bakingTechnique = value;
        }
    }
    public double WeightInGrams
    {
        get { return this.weightInGrams; }

        private set
        {
            if(value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            this.weightInGrams = value;
        }
    }
    public double CaloriesPerGram()
    {
        double flourTypeModifier = 0;
        double bakingTechniqueModifier = 0;

        switch (this.flourType.ToLower())
        {
            case "white":
                flourTypeModifier = 1.5;
                break;
            case "wholegrain":
                flourTypeModifier = 1;
                break;
        }
        switch (this.bakingTechnique.ToLower())
        {
            case "crispy":
                bakingTechniqueModifier = 0.9;
                break;
            case "chewy":
                bakingTechniqueModifier = 1.1;
                break;
            case "homemade":
                bakingTechniqueModifier = 1;
                break;
        }
        double caloriesPerGram = 2 * flourTypeModifier * bakingTechniqueModifier;
        return caloriesPerGram;
    }

}

