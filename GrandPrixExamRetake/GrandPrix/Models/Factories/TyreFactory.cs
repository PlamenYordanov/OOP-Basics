using System.Collections.Generic;

public class TyreFactory
{
    public static Tyre CreateTyre(List<string> args)
    {
        var type = args[4];
        var hardness = double.Parse(args[5]);
        switch (type)
        {
            case "Hard":
                return new HardTyre(hardness);
            default:
                var grip = double.Parse(args[6]);
                return new UltrasoftTyre(hardness, grip);
        }
    }
}


