public class Cymric : Cat
{
    private double furLength;

    public Cymric(string name, double furLength)
        : base(name)
    {
        this.furLength = furLength;
    }
    public override string ToString()
    {
        return $"{typeof(Cymric)}" + base.ToString() + $"{this.furLength:f2}";
    }
}

