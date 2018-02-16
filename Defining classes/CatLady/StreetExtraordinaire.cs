public class StreetExtraordinaire : Cat
{
    private int decibelsOfMeowing;

    public StreetExtraordinaire(string name, int decibels) 
        : base(name)
    {
        this.decibelsOfMeowing = decibels;
    }
    public override string ToString()
    {
        return $"{typeof(StreetExtraordinaire)}" + base.ToString() + $"{this.decibelsOfMeowing}";
    }
}

