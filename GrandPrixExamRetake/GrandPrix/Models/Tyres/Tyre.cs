using System;

public abstract class Tyre
{
    private string name;
    private double hardness;
    private double degradation;

    public Tyre(double hardness)
    {
        Hardness = hardness;
        Degradation = 100;
        
    }
    public string Name
    {
        get { return name; }
        protected set
        {
            name = value;
        }
    }
    public double Hardness
    {
        get { return hardness; }
        protected set
        {
            hardness = value;
        }
    }
    public virtual double Degradation
    {
        get { return degradation; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Blown Tyre");
            }
            degradation = value;
        }
    }
    public virtual void Degrade()
    {
        Degradation -= hardness;
    }
}
