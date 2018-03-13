using System;

public class Car
{
    private const double TankCapacity = 160;

    private double fuelAmount;
    private Tyre tyre;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        Hp = hp;
        FuelAmount = fuelAmount;
        Tyre = tyre;
    }
    public int Hp { get; }

    public double FuelAmount
    {
        get => fuelAmount;
        internal set
        {
            fuelAmount = Math.Min(value, TankCapacity);

            if (fuelAmount < 0)
            {
                fuelAmount = -1;
                throw new ArgumentException("Out of fuel");
            }
        }
    }
    public Tyre Tyre
    {
        get => tyre;
        internal set => tyre = value; 
    }
}

