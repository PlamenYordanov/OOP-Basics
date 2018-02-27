public class HardTyre : Tyre
{
    private const string ConstName = "Hard";

    public HardTyre( double hardness)
        : base(hardness)
    {
        Name = ConstName;  
    }
    
}

