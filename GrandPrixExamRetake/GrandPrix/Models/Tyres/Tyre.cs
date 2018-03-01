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
        get => name;
        protected set => name = value;
    }
    public double Hardness
    {
        get => hardness;
        protected set => hardness = value;
    }
    public virtual double Degradation
    {
        get => degradation;
        protected set
        {
            if (value < 0)
            {
                degradation = -1;
                throw new BlownTyreException();
            }
            degradation = value;
        }
    }
    public virtual void Degrade()
    {
        Degradation -= hardness;
    }
}
