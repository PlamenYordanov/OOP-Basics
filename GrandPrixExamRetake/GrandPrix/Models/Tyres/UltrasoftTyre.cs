using System;

public class UltrasoftTyre : Tyre
{
    private const string ConstName = "Ultrasoft";
    private double grip;
    private double degradation;

    public double Grip
    {
        get { return grip; }
        protected set
        {

            grip = value;
        }
    }
    public override double Degradation
    {
        get => this.Degradation;

        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException("Blown Tyre");
            }
            this.degradation = value;
        }
    }
    public UltrasoftTyre(double hardness, double grip)
        : base(hardness)
    {
        Grip = grip;
        Name = "Ultrasoft";
    }
    public override void Degrade()
    {
        Degradation -= Hardness + Grip;

    }
}

