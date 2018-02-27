using System;

public class UltrasoftTyre : Tyre
{
    private const string ConstName = "Ultrasoft";
    private double grip;

    public UltrasoftTyre(double hardness, double grip)
        : base(hardness)
    {
        Grip = grip;
        Name = ConstName;
    }
    public double Grip
    {
        get => grip;
        protected set => grip = value;
    }
    public override double Degradation
    {
        get => base.Degradation;

        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException("Blown Tyre");
            }
            base.Degradation = value;
        }
    }
    public override void Degrade()
    {
        Degradation -= Hardness + Grip;
    }
}

