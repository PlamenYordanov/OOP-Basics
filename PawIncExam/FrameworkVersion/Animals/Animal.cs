using System;

public abstract class Animal : IEquatable<Animal>
{
    protected Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public string Name { get; protected set; }

    public int Age { get; protected set; }

    public CleansingStatus CleansingStatus { get; protected set; } = CleansingStatus.Uncleansed;

    public bool IsCastrated { get; protected set; } = false;

    public void Cleance()
    {
        CleansingStatus = CleansingStatus.Cleansed;
    }

    public void Castrate()
    {
        IsCastrated = true;
    }

    public override string ToString()
    {
        return $"{Name}";
    }

    public bool Equals(Animal other)
    {
        return Name == other.Name;
    }
}

