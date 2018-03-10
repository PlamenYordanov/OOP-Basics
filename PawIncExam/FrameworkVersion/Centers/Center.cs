using System.Collections.Generic;

public abstract class Center
{
    protected Center(string name)
    {
        Name = name;
        StoredAnimals = new List<Animal>();
    }

    public string Name { get; protected set; }

    public List<Animal> StoredAnimals { get; protected set; }

}

