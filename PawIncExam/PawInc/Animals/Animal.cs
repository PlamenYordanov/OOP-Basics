public abstract class Animal
{
    protected Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public string  Name { get; protected set; }

    public int Age { get; protected set; }

    public CleansingStatus CleansingStatus { get; protected set; } = CleansingStatus.Uncleansed;

    public void Cleance()
    {
        CleansingStatus = CleansingStatus.Cleansed;
    }
    public override string ToString()
    {
        return $"{Name}";
    }
}

