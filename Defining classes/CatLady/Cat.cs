public abstract class Cat
{
    private string name;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public Cat(string name)
    {
        this.Name = name;
    }
    public override string ToString()
    {
        return  $" {typeof(Cat)} {this.Name} ";
    }
}

